using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ClinicalDetailsDataAccess : DataAccessBase, IClinicalDetailsDataAccess
    {
        public async Task<List<ClinicalDetailsDatabaseModel>> GetClinicalDetailsByRequestId(int requestId)
        {
            var parameter = new RequestIdParameterModel() { AnalysisRequestId = requestId };
            var storedProcedure = "[dbo].[usp_GetClinicalDetailsByRequestId]";
            return await LoadDataWithParameterAsync<ClinicalDetailsDatabaseModel, RequestIdParameterModel>(storedProcedure, parameter);
        }

        public async Task<bool> SyncClinicalDetails(string csvClinicalDetails, int analysisRequestId)
        {
            var storedProcedure = "[dbo].[usp_SyncClinicalDetails]";
            var syncData = new
            {
                CsvClinicalDetailIds = csvClinicalDetails,
                AnalysisRequestId = analysisRequestId
            };

            return await InsertOrUpdate<bool, dynamic>(storedProcedure, syncData);
        }

        /// <summary>
        /// gets a csv representation of Clinical detail ids from the passed in list
        /// No headers
        /// </summary>
        /// <param name="clinicalDetails"></param>
        /// <returns></returns>
        public static string GetCsvClinicalDetails
            (List<ClinicalDetailsSelectionModel> clinicalDetails)
        {
            var returnValue = string.Empty;
            foreach (var item in clinicalDetails)
            {
                if (!item.IsSelected) continue;
                if (string.IsNullOrEmpty(returnValue))
                {
                    returnValue = $"{item.Id}";
                    continue;
                }
                returnValue = $"{returnValue},{item.Id}";
            }

            return returnValue;
        }

    }
}
