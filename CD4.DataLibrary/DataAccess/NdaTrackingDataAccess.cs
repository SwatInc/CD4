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

        public async Task<List<CinAndReportDateModel>> UpsertReportDateAsync(List<string> cins, DateTime reportDate, int loggedInUserId)
        {
            var storedProcedure = "[dbo].[usp_UpsertReportDateForNdaTracking]";
            var parameters = new
            {
                SampleCins = GetCinTable(cins),
                ReportDate = reportDate.ToString("yyyyMMdd"),
                LoggedInUserId = loggedInUserId
            };

            try
            {
                var data = await LoadDataWithParameterAsync<CinAndReportDateModel, dynamic>(storedProcedure, parameters);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CinAndFullnameModel>> UpsertQcCalValidatedUserAsync
            (List<string> cins, int loggedInUserId, int actionUserId)
        {
            var storedProcedure = "[dbo].[usp_UpsertQcCalValidatedUser]";
            var parameter = new
            {
                SampleCins = GetCinTable(cins),
                UserId = actionUserId,
                LoggedInUserId = loggedInUserId
            };

            try
            {
                return await LoadDataWithParameterAsync
                    <CinAndFullnameModel, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<List<CinAndFullnameModel>> UpsertAnalysedUserAsync
            (List<string> cins, int loggedInUserId, int actionUserId)
        {
            var storedProcedure = "[dbo].[usp_UpsertAnalyzedUser]";
            var parameter = new
            {
                SampleCins = GetCinTable(cins),
                UserId = actionUserId,
                LoggedInUserId = loggedInUserId
            };

            try
            {
                return await LoadDataWithParameterAsync
                    <CinAndFullnameModel, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task UpsertSampleReceivedUserIdAsync(string cin, int sampleReceivedUserId, int loggedInUser)
        {
            var storedProcedure = "[dbo].[usp_UpsertSampleReceivedUser]";
            var parameters = new {SampleCin = cin,  SampleReceivedUserId = sampleReceivedUserId, LoggedInUserId = loggedInUser };
            try
            {
                _ = await SelectInsertOrUpdateAsync<dynamic, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
