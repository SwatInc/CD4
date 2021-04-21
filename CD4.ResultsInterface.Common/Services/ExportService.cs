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
        public async Task<bool> ExportToUploader(List<InterfaceResultsModel> interfaceResults, string basepath, string extension, string controlFileExtension)
        {
            if (interfaceResults.Count == 0)
            {
                return false;
            }

            var exportData = JsonConvert.SerializeObject(interfaceResults);
            var filenameWithoutExtension = $"{basepath}\\{DateTime.Now:yyyyMMdd_HHmmss_fffffff}";
            byte[] result = Encoding.UTF8.GetBytes(exportData);
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
    }
}