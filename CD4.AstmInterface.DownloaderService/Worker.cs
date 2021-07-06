using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CD4.AstmInterface.DownloaderService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;


        public Worker(ILogger<Worker> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var path = _configuration.GetValue<string>("IncomingDirectory");
                var waitInterval = _configuration.GetValue<int>("WaitIntervalMilliseconds");
                var queryControlFileExtension = _configuration.GetValue<string>("QueryControlFileExtension");
                var orderControlFileExtension = _configuration.GetValue<string>("OrderControlFileExtension");
                var orderControlFileRequired = _configuration.GetValue<bool>("IsOrderControlFileRequired");
                var queryModeEnabled = _configuration.GetValue<bool>("IsQueryMode");
                var analyserName = _configuration.GetValue<string>("AnalyserName");

                try
                {
                    //if query mode is enabled, look for query files
                    if (queryModeEnabled)
                    {
                        _logger.LogDebug("Query mode enabled. Looking for pending queries.");
                        ProcessQueries(path, queryControlFileExtension);
                        return;
                    }

                    _logger.LogDebug("Query mode disabled. Proceed with download mode");
                    ProcessOrderDownload(analyserName);

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

        private void ProcessOrderDownload(string analyserName, bool isQueryMode = false, string sid = null)
        {
            #region Sanity checks

            if (analyserName is null)
            {
                _logger.LogError($"Analyser name [{analyserName}] cannot be null! Ignoring order download.");
                return;
            }

            if (isQueryMode && string.IsNullOrEmpty(sid))
            {
                _logger.LogError($"SID [{sid}] cannot be null with query mode turned on! Ignoring order download.");
                return;
            }

            #endregion



            throw new NotImplementedException();
        }

        private void ProcessQueries(string path, string controlFileExtension)
        {
            string[] files = Directory.GetFiles(path, controlFileExtension);
            if (files.Length == 0)
            {
                _logger.LogInformation("No incoming queries for processing.");
                return;
            }
            _logger.LogInformation($"{files.Length} query file(s) detected for processing.");
        }
    }
}
