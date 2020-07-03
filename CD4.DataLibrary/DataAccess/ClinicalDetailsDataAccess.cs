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
            var storedProcedureForFullSync = "[dbo].[usp_SyncClinicalDetails]";
            var storedProcedureForDeletion = "[dbo].[usp_DeleteAnalysisRequestClinicalDetails]";
            var storedProcedureInUse = "";
            dynamic data;

            //determine whether to do a fullsync or just a complete deletion of Clinical details for AR
            if (ProceedWithFullSync(csvClinicalDetails))
            {
                storedProcedureInUse = storedProcedureForFullSync;
                data = new
                {
                    CsvClinicalDetailIds = csvClinicalDetails,
                    AnalysisRequestId = analysisRequestId
                };
            }
            else
            {
                storedProcedureInUse = storedProcedureForDeletion;
                data = new
                {
                    AnalysisRequestId = analysisRequestId
                };

            }

            return await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedureInUse, data);
        }

        /// <summary>
        /// Looks for the number of clinical details in the csvClinicalDetails and determines whether database needs to synced or
        /// proceed with a full deletion of clinical details for the analysis request
        /// </summary>
        /// <param name="csvClinicalDetails">Comma saperated clinical detail ids</param>
        /// <returns>True if a fullsync needs to be done. False for deletion of Clinical details for Analysis Request</returns>
        private bool ProceedWithFullSync(string csvClinicalDetails)
        {
            if (!string.IsNullOrEmpty(csvClinicalDetails))
            {
                return true;
            }
            return false;
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
