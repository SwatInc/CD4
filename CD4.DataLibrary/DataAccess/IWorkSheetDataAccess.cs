using CD4.DataLibrary.Models;
using System;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IWorkSheetDataAccess
    {
        Task<WorklistModel> GetWorklistBySpecifiedDateAndAllStatusAsync(DateTime? startDate = null);
        Task<WorklistModel> GetWorklistBySpecifiedDateAndStatusIdAsync(int selectedStatusId, DateTime? startDate = null);
    }
}