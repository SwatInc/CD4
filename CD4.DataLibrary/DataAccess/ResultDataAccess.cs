using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ResultDataAccess : DataAccessBase, IResultDataAccess
    {
        private readonly IStatusDataAccess statusData;

        public ResultDataAccess(IStatusDataAccess statusData)
        {
            this.statusData = statusData;
        }

        /// <summary>
        /// Inserts the specified tests list into database and removes a specified test list from the database for a particualar CIN
        /// </summary>
        /// <param name="testsToInsert">List of tests to insert</param>
        /// <param name="testsToRemove">List of tests to remove</param>
        /// <param name="cin">The CIN for which tests are to be inserted or deleted or both</param>
        /// <returns>Returns true or false indicating the successfull/unsuccessfull completion of the insert/delete operation</returns>
        public async Task<bool> SyncRequestedTestDataAsync
            (List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin)
        {
            var testToInsertTable = await GetTestsTableAsync(testsToInsert, cin, statusData);
            var testToRemoveTable =await  GetTestsTableAsync(testsToRemove, cin, statusData);
            var storedProcedure = "[dbo].[usp_SyncResultsTableData]";

            var syncData = new
            {
                TestsToInsert = testToInsertTable,
                TestsToRemove = testToRemoveTable,
                UserId =1
            };

            return await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, syncData);
        }

        /// <summary>
        /// Create an instance of TableValueParameter of ResultTableInsertDataUDT
        /// </summary>
        /// <param name="tests">Tests requested</param>
        /// <param name="cin">Sample cin</param>
        /// <returns>an instance of TableValueParameter of ResultTableInsertDataUDT as ICustomQueryParameter</returns>
        public static async Task<SqlMapper.ICustomQueryParameter> GetTestsTableAsync
            (List<TestsModel> tests, string cin, IStatusDataAccess statusData)
        {
            //Declare datatable instance and add the columns required for UDT
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");

            try
            {
                //Fetch Status Id for "Registered Status"
                var statusId =  statusData.GetRegisteredStatusId();

                //Add rows to the Datatable declared, and return
                foreach (var item in tests)
                {
                    returnTable.Rows.Add(item.Id, cin);
                }
                return returnTable.AsTableValuedParameter("ResultTableInsertDataUDT");
            }
            catch (Exception)
            {
                //throw the exception right out! It will be handled down the line.
                throw;
            }


        }

        public async Task<bool> InsertUpdateResultByResultIdAsync(int resultId, string result, int testStatus)
        {
            //check whether the test status is acceptable for result entry
            var InvalidTestStatusMessage = IsTestStatusValidForResultEntry(testStatus);
            if (!string.IsNullOrEmpty(InvalidTestStatusMessage))
            {
                throw new Exception(InvalidTestStatusMessage);
            }
            //Set the stored procedure to call
            var storedProcedure = "[dbo].[usp_UpdateResultByResultId]";
            //Make a database query to get Id for Status equivalent to "ToValidate".
            var statusId =  statusData.GetToValidateStatusId();
            //prepare the parameter to pass to the query.
            var parameter = new { Result = result, ResultId = resultId, StatusId = statusId, UserId = 1 };
            //insert result and result status
            var output = await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, parameter);
            //Set the sample status
            var sampleStatus = await statusData.DetermineSampleStatus(resultId);
            var IsSampleStatusSet = await UpdateSampleStatusByResultId(resultId, sampleStatus);
            return output;
        }

        /// <summary>
        /// Can be used to determine whether the test status is acceptable for result entry.
        /// </summary>
        /// <param name="testStatus">The current status of the test for which result being attempted to save.</param>
        /// <returns>A null if ok to proceed. If not ok to proceed, a string message is returned explainig the reason that result should not be saved for the test.</returns>
        private string IsTestStatusValidForResultEntry(int testStatus)
        {
            switch (testStatus)
            {
                case (int)Status.Registered:
                    return "Cannot enter a result to a sample/test which is not collected or accepted to the laboratory.";
                case (int)Status.Collected:
                    return null; //OK to proceed with saving the result
                case (int)Status.Received:
                    return null; //OK to proceed with saving the result
                case (int)Status.ToValidate:
                    return null; //OK to proceed with saving the result
                case (int)Status.Validated:
                    return "Test already validated. Please cancel test validation to enter a new result.";
                case (int)Status.Processing:
                    return null; //OK to proceed with saving the result
                case (int)Status.Rejected:
                    return "Cannot enter a result to a rejected test.";
                default:
                    throw new ArgumentException("Test status not recognised. Cannot enter a result. Please contact LIS vendor.");
            }
        }

        public async Task<bool> UpdateSampleStatusByResultId(int resultId, int sampleStatus)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleStatusResultId]";
            var parameter = new { ResultId = resultId, SampleStatus = sampleStatus, UserId = 1 };
            return await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, parameter);
        }
    }
}
