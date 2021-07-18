using CD4.DataLibrary.DataAccess;
using CD4.ResultsInterface.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SwatInc.Lis.Lis02A2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CD4.AstmInterface.DownloaderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IExportService _exportService;
        private readonly IOrderDownloadDataAccess _orderDownloadDataAccess;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration,
            IExportService exportService,
            IOrderDownloadDataAccess orderDownloadDataAccess)
        {
            _logger = logger;
            _configuration = configuration;
            _exportService = exportService;
            _orderDownloadDataAccess = orderDownloadDataAccess;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var waitInterval = _configuration.GetValue<int>("WaitIntervalMilliseconds");
                var queryModeEnabled = _configuration.GetValue<bool>("IsQueryMode");

                try
                {
                    //if query mode is enabled, look for query files
                    if (queryModeEnabled)
                    {
                        _logger.LogDebug("Query mode enabled. Looking for pending queries.");
                        ProcessQueries();
                    }
                    else
                    {
                        _logger.LogDebug("Query mode disabled. Proceed with download mode");
                        ProcessOrderDownload();
                    }

                    _logger.LogWarning($"Waiting for {waitInterval} milliseconds.");
                    await Task.Delay(waitInterval, stoppingToken);

                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}\n\n{ex.StackTrace}");
                }

            }
        }

        private void ProcessOrderDownload()
        {
            var analyserName = _configuration.GetValue<string>("DownloadModeAnalyserName");
            var isQueryMode = _configuration.GetValue<bool>("IsQueryMode");
            var interfaceUser = _configuration.GetValue<int>("InterfaceUserId");

            #region Sanity checks

            if (analyserName is null)
            {
                _logger.LogError($"Analyser name [{analyserName}] cannot be null! Ignoring order download.");
                return;
            }

            if (isQueryMode)
            {
                _logger.LogError($"Query mode turned on! Ignoring download mode path.");
                return;
            }

            #endregion

            try
            {
                _logger.LogInformation($"Trying to donwload new orders for analyser: {analyserName} for all samples.");
                var orders = _orderDownloadDataAccess.DownloadAllOrdersForAnalyserAsync
                    (analyserName, interfaceUser)
                    .GetAwaiter()
                    .GetResult();

                if (orders is null)
                {
                    _logger.LogInformation("No orders downloaded available for analyser.");
                    return;
                }
                if (orders.Count == 0)
                {
                    _logger.LogInformation("No orders downloaded available for analyser.");
                    return;
                }

                var jsonOrders = JsonConvert.SerializeObject(orders);
                _logger.LogInformation($"Orders downloaded...\n{jsonOrders}");
                ExportQueryResponse(jsonOrders);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while trying to download ALL orders for analyser.");
                _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
            }

        }

        private void ProcessQueries()
        {

            var incomingPath = _configuration.GetValue<string>("IncomingDirectory");
            var queryControlFileExtension = _configuration.GetValue<string>("QueryControlFileExtension");
            var InterfaceUserId = _configuration.GetValue<int>("InterfaceUserId");

            _logger.LogInformation("looking for analyser query control files.");
            string[] controlFiles = Directory.GetFiles(incomingPath, $"*.{queryControlFileExtension}");
            if (controlFiles.Length == 0)
            {
                _logger.LogInformation("No incoming queries for processing.");
                return;
            }

            var queryJsonFiles = GetQueryDataFiles(controlFiles);

            _logger.LogInformation($"{queryJsonFiles.Count} query file(s) detected for processing.");
            _logger.LogDebug("Detected Files...");
            foreach (var item in queryJsonFiles)
            {
                _logger.LogDebug(item);
            }

            try
            {
                _logger.LogInformation("Calling function to parse queries...");
                var queries = ParseQueries<QueryRecord>(queryJsonFiles);
                if (queries.Count == 0) { _logger.LogInformation("Parse finction did not return any query records"); return; }

                _logger.LogInformation("Downloading orders for queries...");
                foreach (var query in queries)
                {
                    _logger.LogInformation($"Downloading orders for {query.UserFieldNumberTwo} for SID: {query.StartingRange.SpecimenID}.");
                    var orders = _orderDownloadDataAccess.DownloadAllAnalyserSpecificOrdersForQueriedSampleAsync
                        (query.UserFieldNumberTwo, query.StartingRange.SpecimenID, InterfaceUserId)
                        .GetAwaiter()
                        .GetResult();

                    if (orders is null) 
                    {
                        _logger.LogInformation("No orders downloaded. Writing out empty query response.");
                        ExportEmptyQueryResponse(query.StartingRange.SpecimenID);
                        continue;  
                    }
                    if (orders.Count == 0) 
                    {
                        _logger.LogInformation("No orders downloaded. Writing out empty query response.");
                        ExportEmptyQueryResponse(query.StartingRange.SpecimenID);
                        continue; 
                    }

                    var jsonOrders = JsonConvert.SerializeObject(orders);
                    _logger.LogInformation($"Orders downloaded...\n{jsonOrders}");
                    ExportQueryResponse(jsonOrders);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Query processing failed.");
                _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
                return;
            }
            finally
            {
                //clean up quries
            }
        }

        private void ExportEmptyQueryResponse(string sid)
        {
            var empty = new
            {
                Download = "",
                Sid = sid,
                SamplePriority = "",
                TestPriority = "",
                EpisodeNumber = "",
                Age = "",
                Fullname = "",
                NidPp = "",
                Birthdate = "",
                Address = ""
            };

            var emptyResponse = new List<dynamic>() { empty };

            ExportQueryResponse(JsonConvert.SerializeObject(emptyResponse));
            _logger.LogInformation("Exported empty query response.");
        }

        private void ExportQueryResponse(string jsonOrders)
        {
            var orderExportPath = _configuration.GetValue<string>("OrderExportDirectory");
            var orderDataFileExtension = _configuration.GetValue<string>("OrderDataFileExtension");
            var orderControlFileExtension = _configuration.GetValue<string>("OrderControlFileExtension");

            _exportService.ExportJsonDataAsync(jsonOrders, orderExportPath, orderDataFileExtension, orderControlFileExtension)
                .GetAwaiter()
                .GetResult();
        }

        private List<string> GetQueryDataFiles(string[] controlFiles)
        {
            var queryJsonDataFiles = new List<string>();
            var queryControlFileExtension = _configuration.GetValue<string>("QueryControlFileExtension");
            var queryDataFileExtension = _configuration.GetValue<string>("QueryDataFileExtension");
            var queryBackupFileExtension = _configuration.GetValue<string>("QueryBackupFileExtension");

            foreach (var controlFile in controlFiles)
            {
                try
                {
                    var controlFileInfo = new FileInfo(controlFile);
                    var queryDataFileInfo = new FileInfo(controlFileInfo.FullName
                        .Replace(queryControlFileExtension, queryDataFileExtension));
                    _logger.LogDebug($"Query File: {queryDataFileInfo.FullName}");


                    queryJsonDataFiles.Add(File.ReadAllText(queryDataFileInfo.FullName));

                    _logger.LogInformation($"Deleting control file: {controlFileInfo.Name}.");
                    if (controlFileInfo.Exists) { controlFileInfo.Delete(); }

                    _logger.LogInformation($"Renaming query file with backup extension {queryBackupFileExtension}");
                    if (queryDataFileInfo.Exists)
                    {
                        queryDataFileInfo.MoveTo
                            (queryDataFileInfo.FullName
                                .Replace(queryDataFileExtension, queryBackupFileExtension), true);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"An error occured while trying to read query data files.\n{ex.Message}\n{ex.StackTrace}");
                }
            }


            return queryJsonDataFiles;
        }

        private List<T> ParseQueries<T>(List<string> jsonQueries) where T : new()
        {
            if (jsonQueries is null)
            {
                throw new ArgumentNullException(nameof(jsonQueries));
            }

            List<T> queries = new();

            try
            {
                _logger.LogInformation("Trying to parse queries...");
                foreach (var jsonQuery in jsonQueries)
                {
                    var query = JsonConvert.DeserializeObject<List<T>>(jsonQuery);
                    if (query != null)
                    {
                        queries.AddRange(query);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to parse query.");
                _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
            }

            _logger.LogInformation($"Returning {queries.Count} query record(s)");
            return queries;

        }
    }
}
