using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class StatusDataAccess : DataAccessBase, IStatusDataAccess
    {
        /// <summary>
        /// Fetches statusId for the specified status string from the database
        /// </summary>
        /// <param name="status">The status for which the Id is to be queried.</param>
        /// <returns>integer representing Status Id for the specified status</returns>
        private async Task<int> GetStatusIdByStatusAsync(string status)
        {
            //the stored procedure name to call
            var storedProcedure = "usp_GetStatusIdByStatus";
            //set up the status name parameter
            var parameter = new { Status = status };

            //call the base class to execute the stored procedure.
            var output = await SelectInsertOrUpdate<int, dynamic>(storedProcedure, parameter);
            return output;
        }

        /// <summary>
        /// Get status table PK corresponding to the status "Registered"
        /// Throws an exception if the status is not found on the database
        /// </summary>
        /// <param name="statusData">Instance of static data class</param>
        /// <returns>Integer indicating statusId for status "Registered"</returns>
        public int GetRegisteredStatusId()
        {
            return (int)Status.Registered;
        }

        /// <summary>
        /// Get status table PK corresponding to the status "ToValidate"
        /// Throws an exception if the status is not found on the database
        /// </summary>
        /// <param name="statusData">Instance of static data class</param>
        /// <returns>Integer indicating statusId for status "ToValidate"</returns>
        public int GetToValidateStatusId()
        {
            return (int)Status.ToValidate;
        }

        /// <summary>
        /// Determine the required status for sample status depending on tests status of the sample.
        /// </summary>
        /// <param name="resultId">CIN for the sample.</param>
        /// <returns>An integer representing the status to which sample status needs to be changed.</returns>
        public async Task<int> DetermineSampleStatus(int resultId)
        {
            //Get all tests statuses of the sample. Comma delimited int's
            var storedProcedure = "usp_GetSampleAndAllTestStatusByResultId";
            var parameters = new { ResultId = resultId };
            var testsStatusesCsv = await SelectInsertOrUpdate<string, dynamic>(storedProcedure, parameters);
            //make sure that the returned value is valid. sanity check
            if (testsStatusesCsv.Length == 0)
            {
                throw new Exception($"Cannot fetch tests statuses for sample: {resultId} required to change the sample status.");
            }

            //Determine new status of the sample, and return
            return DetermineNewStatusForSample(testsStatusesCsv);
        }

        /// <summary>
        /// Determines new sample status to be saved on the database, on saving a result to the database.
        /// Returns sample status as processing if atleast one test remain in "ToValidate" status
        /// Returns sample status as validated if all the tests have validated or rejected status.
        /// Otherwise gives the existing sample status.
        /// </summary>
        /// <param name="testsStatusesCsv">A CSV list of the sample status and tests statuses. Eg: SampleStatus, testsStatus, testStatus,...</param>
        /// <returns>An integer indicating new sample status.</returns>
        private int DetermineNewStatusForSample(string testsStatusesCsv)
        {
            //validate the input
            if (testsStatusesCsv is null)
            {
                throw new ArgumentNullException("Cannot determine the sample status. Test status received for sample is null");
            }
            if (testsStatusesCsv.Length == 0 || !testsStatusesCsv.Contains(","))
            {
                throw new ArgumentException("Invalid sample and tests status passed in.");
            }

            //split the CSV into an int array.
            var SampleAndTestStatus = testsStatusesCsv.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            //parse sample status to an integer
            var sampleStatus = SampleAndTestStatus[0];

            //variable to track to mark sample as validated.
            bool CanSampleBeMarkedvalidated = true;
            //determine new sample status based on test status.
            for (int i = 1; i < SampleAndTestStatus.Length - 1; i++)
            {
                //if even one tests has the ToValidate status...
                if (SampleAndTestStatus[i] == (int)Status.ToValidate)
                {
                    //Sample status will be processing.
                    return (int)Status.Processing;
                }

                //if any of the tests have status other than validated or rejected....
                if (SampleAndTestStatus[i] != (int)Status.Validated || SampleAndTestStatus[i] != (int)Status.Rejected)
                {
                    //sample cannot be marked as validated.
                    CanSampleBeMarkedvalidated = false;
                }
            }

            //if sample can be marked as valdated...
            if (CanSampleBeMarkedvalidated)
            {
                //return new status as validated.
                return (int)Status.Validated;
            }

            //if none of the above criteria matched, return the existing sample status.
            return sampleStatus;
        }

        /// <summary>
        /// Queries database to get a list of all status with their Ids.
        /// </summary>
        /// <returns>List of StatusModel with Id and Status</returns>
        public async Task<List<StatusModel>> GetAllStatus()
        {
            //the stored procedure name to call
            var storedProcedure = "[dbo].[usp_GetAllStatus]";
            var output =  await LoadDataAsync<StatusModel>(storedProcedure);
            return output.ToList();
        }

        /// <summary>
        /// Database Status table PKs must be equivalent to the Status enums' indexes
        /// </summary>
        private enum Status
        {
            Registered = 1,
            Collected,
            Received,
            ToValidate,
            Validated,
            Processing,
            Rejected
        }
    }
}
