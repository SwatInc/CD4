using CD4.DataLibrary.DataAccess;
using CD4.ResultsInterface.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CD4.ResultsInterface
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IResultDataAccess _resultDataAccess;
        private readonly IStaticDataDataAccess _staticDataDataAccess;
        private List<ChannelMappingModel> _channelMappings;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration,
            IResultDataAccess resultDataAccess,
            IStaticDataDataAccess staticDataDataAccess)
        {
            _logger = logger;
            _configuration = configuration;
            _resultDataAccess = resultDataAccess;
            _staticDataDataAccess = staticDataDataAccess;

            _channelMappings = new List<ChannelMappingModel>();

            LoadChannelMappingAsync().GetAwaiter().GetResult();
        }

        private async Task LoadChannelMappingAsync()
        {
            try
            {
                var mappingData = await _staticDataDataAccess.GetChannelMappingData();
                _logger.LogInformation($"Channel mapping data loaded: {JsonConvert.SerializeObject(mappingData)}");
                if (mappingData is null) {return; }

                foreach (var item in mappingData)
                {
                    _channelMappings.Add(new ChannelMappingModel()
                    { 
                        AnalyserName = item.AnalyserName,
                        Download = item.Download,
                        TestId = item.TestId,
                        Unit = item.Unit,
                        Upload = item.Upload
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occured while trying to load channel mappping.\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var path = _configuration.GetValue<string>("IncomingDirectory");
                var waitInterval = _configuration.GetValue<int>("WaitIntervalMilliseconds");
                var controlFileExtension = _configuration.GetValue<string>("ControlFileExtension");
                string[] files;
                try
                {
                    files = Directory.GetFiles(path, controlFileExtension);
                    //if no files to process then return
                    if (files.Length != 0)
                    {
                        await StartProcessingIncomingAsync(files);
                    }
                    else
                    {
                        _logger.LogInformation("No incoming results for processing.");
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}\n\n{ex.StackTrace}");
                }
                finally
                {
                    _logger.LogInformation($"Waiting for {waitInterval} milliseconds.");
                    await Task.Delay(waitInterval, stoppingToken);
                }

            }
        }

        private async Task StartProcessingIncomingAsync(string[] files)
        {
            _logger.LogInformation($"Starting to process incoming files\n\n{JsonConvert.SerializeObject(files, Formatting.Indented)}");

            foreach (var item in files)
            {
                var dataFilePath = item.Replace(".ok", ".json");
                _logger.LogInformation($"Processing File: {dataFilePath}");
                try
                {
                    using (StreamReader reader = new StreamReader(dataFilePath))
                    {
                        var json = await reader.ReadToEndAsync();
                        _logger.LogInformation($"Results data to process.\n\n{json}");
                        var data = JsonConvert.DeserializeObject<List<InterfaceResultsModel>>(json);

                        //pass for uploading
                        await UploadResultsAsync(data);

                    }

                    DeleteExistingFile(dataFilePath.Replace(".json", ".ok"));
                    File.Move(dataFilePath, dataFilePath.Replace(".json", ".sav"));
                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occured while processing interface results." +
                        $" Please find the error information below.\n{ex.Message}\n{ex.StackTrace}");
                }
            }
        }

        private void DeleteExistingFile(string flepath)
        {
            var fileInfo = new FileInfo(flepath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        private async Task UploadResultsAsync(List<InterfaceResultsModel> resultsData)
        {
            if(resultsData is null) { return; }

            //iterate all specimens in the upload data
            foreach (var sample in resultsData)
            {
                //iterate all results for sample.
                foreach (var test in sample.Measurements)
                {
                    var mapping = _channelMappings.Find((x) => x.Upload == test.TestCode && x.AnalyserName == sample.InstrumentId.InstrumentCode);
                    if (mapping is null)
                    {
                        _logger.LogWarning($"Cannot find upload channel mapping for test [{test.TestCode}] on analyser [{sample.InstrumentId.InstrumentCode}]. " +
                            $"Result [{test.MeasurementValue}] for SID: [{sample.SampleId}] is discarded.");
                        continue;
                    }

                    //if mapping is not null continue
                    try
                    {
                        //call data layer to upload result.
                        _ = await _resultDataAccess.InterfaceUpdateResultByTestIdAndCinAsync
                            (mapping.TestId, sample.SampleId, test.MeasurementValue, sample.BatchId, "NM", 1);
                        _logger.LogInformation($"Upload requested for test [{test.TestCode}] with result [{test.MeasurementValue}] for sample [{sample.SampleId}]");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("An error occured while uploading result to CD4" +
                            $"\n{ex.Message}\n{ex.StackTrace}");
                    }

                }
            }
        }
    }
}
