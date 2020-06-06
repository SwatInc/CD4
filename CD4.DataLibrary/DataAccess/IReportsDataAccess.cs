using CD4.DataLibrary.Models.ReportModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IReportsDataAccess
    {
        Task<List<AnalysisRequestReportModel>> GetAnalysisReportByCinAsync(string cin);
    }
}