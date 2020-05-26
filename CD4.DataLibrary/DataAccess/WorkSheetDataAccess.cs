using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class WorkSheetDataAccess : DataAccessBase, IWorkSheetDataAccess
    {
        public async Task<WorklistModel> GetNotValidatedWorklist(DateTime? startDate = null)
        {
            var storedProcedure = "[dbo].[GetWorksheetWithIncompleteRequests]";
            var parameter = new { StartDate = GetStartDate(startDate) };

            var results = await SelectWorksheetDatasets<dynamic>(storedProcedure, parameter);
            return results;

        }

        /// <summary>
        /// Returns the start date in the format: yyyyMMdd
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private string GetStartDate(DateTime? startDate)
        {
            // If startDate parameter is an empty string, returns todays date in the format.
            if (startDate is null)
            {
                return DateTime.Today.ToString("yyyyMMdd");
            }

            //if date is supplied, return in the format yyyyMMdd
            return DateHelper.GetCD4FormatDate(startDate);
        }
    }
}
