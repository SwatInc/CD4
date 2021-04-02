using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class NdaTrackingDataAccess : DataAccessBase, INdaTrackingDataAccess
    {
        /// <summary>
        /// Inclusive search between the specified dates including all samples from start date to all samples at the end of the end date.
        /// </summary>
        /// <param name="fromDate">The start date. The results will include results from specified date</param>
        /// <param name="toDate">The end date. The results will include all results from specified date</param>
        /// <param name="sampleStatus">The status of the sample </param>
        /// <returns>Task<List<NdaTrackingDataAccess>></returns>
        public async Task<List<NdaTrackingModel>> LoadSearchResults(DateTime fromDate, DateTime toDate, int sampleStatus)
        {
            var storedProcedure = "[dbo].[usp_LoadSampleDataForNda]";
            var parameters = new
            {
                FromDate = fromDate.ToString("yyyyMMdd"),
                ToDate = toDate.AddDays(1).ToString("yyyyMMdd"),
                SampleStatusId = sampleStatus
            };

            try
            {
                return await LoadDataWithParameterAsync<NdaTrackingModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
