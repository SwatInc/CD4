using CD4.ResultsInterface.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CD4.ResultsInterface.Common.Services
{
    public class ExportService : IExportService
    {
        private async Task<bool> ExportAsync<T>(List<T> dataList, string basepath, string extension, string controlFileExtension)
        {
            #region NULL Checks

            if (dataList is null)
            {
                throw new ArgumentNullException(nameof(dataList));
            }

            if (string.IsNullOrEmpty(basepath))
            {
                throw new ArgumentException($"'{nameof(basepath)}' cannot be null or empty.", nameof(basepath));
            }

            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException($"'{nameof(extension)}' cannot be null or empty.", nameof(extension));
            }

            if (string.IsNullOrEmpty(controlFileExtension))
            {
                throw new ArgumentException($"'{nameof(controlFileExtension)}' cannot be null or empty.", nameof(controlFileExtension));
            }

            if (dataList.Count == 0)
            {
                return false;
            }

            #endregion

            var exportData = JsonConvert.SerializeObject(dataList);

            try
            {
                return await ExportAsync<bool>(exportData, basepath, extension, controlFileExtension);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<bool> ExportAsync<T>(string jsonExportData, string basepath, string extension, string controlFileExtension)
        {
            #region NULL checks
            if (string.IsNullOrEmpty(jsonExportData))
            {
                throw new ArgumentException($"'{nameof(jsonExportData)}' cannot be null or empty.", nameof(jsonExportData));
            }

            if (string.IsNullOrEmpty(basepath))
            {
                throw new ArgumentException($"'{nameof(basepath)}' cannot be null or empty.", nameof(basepath));
            }

            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException($"'{nameof(extension)}' cannot be null or empty.", nameof(extension));
            }

            if (string.IsNullOrEmpty(controlFileExtension))
            {
                throw new ArgumentException($"'{nameof(controlFileExtension)}' cannot be null or empty.", nameof(controlFileExtension));
            }
            #endregion

            var filenameWithoutExtension = $"{basepath}\\{DateTime.Now:yyyyMMdd_HHmmss_fffffff}";
            byte[] result = Encoding.UTF8.GetBytes(jsonExportData);
            try
            {
                using (FileStream SourceStream = File.Open($"{filenameWithoutExtension}.{extension}", FileMode.OpenOrCreate))
                {
                    SourceStream.Seek(0, SeekOrigin.End);
                    await SourceStream.WriteAsync(result, 0, result.Length);
                }
                File.WriteAllText($"{filenameWithoutExtension}.{controlFileExtension}", "");
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExportToUploaderAsync(List<InterfaceResultsModel> interfaceResults, string basepath, string extension, string controlFileExtension)
        {
            return await ExportAsync(interfaceResults, basepath, extension, controlFileExtension);
        }

        public async Task ExportQueryToOrderDownloaderAsync(List<string> jsonQueryRecord, string basepath, string extension, string controlFileExtension)
        {
            #region NULL Check
            if (jsonQueryRecord is null)
            {
                throw new ArgumentNullException(nameof(jsonQueryRecord));
            }

            if (string.IsNullOrEmpty(basepath))
            {
                throw new ArgumentException($"'{nameof(basepath)}' cannot be null or empty.", nameof(basepath));
            }

            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException($"'{nameof(extension)}' cannot be null or empty.", nameof(extension));
            }

            if (string.IsNullOrEmpty(controlFileExtension))
            {
                throw new ArgumentException($"'{nameof(controlFileExtension)}' cannot be null or empty.", nameof(controlFileExtension));
            }
            #endregion

            _ = await ExportAsync(jsonQueryRecord, basepath, extension, controlFileExtension);
        }

        public async Task ExportQueryToOrderDownloaderAsync(List<dynamic> queryRecord)
        {
            #region NULL Check
            if (queryRecord is null)
            {
                throw new ArgumentNullException(nameof(queryRecord));
            }

            #endregion

            _ = await ExportAsync(queryRecord, "C:\\Export", "qrd.json", "qok");
        }

        public async Task ExportJsonDataAsync(string jsonExportData, string basepath, string extension, string controlFileExtension)
        {
            try
            {
                await ExportAsync<bool>(jsonExportData, basepath, extension, controlFileExtension);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}