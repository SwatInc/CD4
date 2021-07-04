using CD4.ResultsInterface.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.ResultsInterface.Common.Services
{
    public interface IExportService
    {
        Task ExportQueryToOrderDownloaderAsync(List<string> jsonQueryRecord, string basepath, string extension, string controlFileExtension);
        Task ExportQueryToOrderDownloaderAsync(List<dynamic> queryRecord);
        Task<bool> ExportToUploaderAsync(List<InterfaceResultsModel> interfaceResults, string basepath, string extension, string controlFileExtension);
    }
}