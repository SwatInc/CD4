using CD4.DataLibrary.Models;
using System;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IWorkSheetDataAccess
    {
        Task<WorklistModel> GetNotValidatedWorklistAsync(DateTime? startDate = null);
    }
}