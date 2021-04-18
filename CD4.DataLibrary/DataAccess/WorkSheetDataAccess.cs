using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using System;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class WorkSheetDataAccess : DataAccessBase, IWorkSheetDataAccess
    {
        public async Task<WorklistModel> GetWorklistBySpecifiedDateAndStatusIdAsync(int selectedStatusId, int worksheetId, DateTime? startDate = null)
        {
            var storedProcedure = "";
            dynamic parameter;

            switch (worksheetId)
            {
                case 0:
                    storedProcedure = "[dbo].[usp_GetWorksheetBySpecifiedDateAndStatusId]";
                    parameter = new { StartDate = GetStartDate(startDate), StatusId = selectedStatusId };
                    break;
                default:
                    storedProcedure = "[dbo].[usp_GetWorksheetBySpecifiedDateStatusIdAndDiscipline]";
                    parameter = new { StartDate = GetStartDate(startDate), StatusId = selectedStatusId, DisciplineId = worksheetId };
                    break;
            }

            var results = await SelectWorksheetDatasets<dynamic>(storedProcedure, parameter);
            return results;

        }

        public async Task<WorklistModel> GetWorklistBySpecifiedDateAndAllStatusAsync(int worksheetId, DateTime? startDate = null)
        {
            var storedProcedure = "";
            dynamic parameter;

            switch (worksheetId)
            {
                case 0:
                    storedProcedure = "[dbo].[usp_GetWorksheetBySpecifiedDate]";
                    parameter = new { StartDate = GetStartDate(startDate) };
                    break;
                default:
                    storedProcedure = "[dbo].[usp_GetWorksheetBySpecifiedDateAndDiscipline]";
                    parameter = new { StartDate = GetStartDate(startDate), DisciplineId = worksheetId };
                    break;
            }

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
            return DateHelper.GetCD4FormatJustDateNoTime(startDate);
        }
    }
}
