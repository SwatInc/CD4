using CD4.ResultsInterface.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.ResultsInterface.Common.Services
{
    public interface IExportService
    {
        Task<bool> ExportToUploader(List<InterfaceResultsModel> interfaceResults, string basepath, string extension, string controlFileExtension);
    }
}