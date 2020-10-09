﻿using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ResultDataAccess : DataAccessBase, IResultDataAccess
    {
        private readonly IStatusDataAccess statusData;
        private readonly IReferenceRangeDataAccess _referenceRangeDataAccess;

        public ResultDataAccess(IStatusDataAccess statusData, IReferenceRangeDataAccess referenceRangeDataAccess)
        {
            this.statusData = statusData;
            _referenceRangeDataAccess = referenceRangeDataAccess;
        }

        /// <summary>
        /// Manages inserts the specified test lists into database and removes a specified test list from the database for a particualar CIN by calling appropriate methods
        /// </summary>
        /// <param name="testsToInsert">List of tests to insert</param>
        /// <param name="testsToRemove">List of tests to remove</param>
        /// <param name="cin">The CIN for which tests are to be inserted or deleted or both</param>
        /// <returns>Returns true or false indicating the successfull/unsuccessfull completion of the insert/delete operation</returns>
        public async Task<bool> ManageRequestedTestsDataAsync
            (List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin)
        {
            var testToInsertTable = await GetTestsTableAsync(testsToInsert, cin, statusData);
            var testToRemoveTable = await GetTestsTableAsync(testsToRemove, cin, statusData);

            //determine whether to create, delete or sync result table data
            if (testsToInsert.Count > 0 && testsToRemove.Count > 0)
            {
                //sync data
                var syncData = new
                {
                    TestsToInsert = testToInsertTable,
                    TestsToRemove = testToRemoveTable,
                    UserId = 1
                };

                await SyncResultTableDataAsync(syncData);
                return true;
            }
            else if (testsToInsert.Count > 0)
            {
                var insertData = new
                {
                    TestsToInsert = testToInsertTable,
                    UserId = 1
                };
                return await InsertResultTableDataAsync(insertData);
            }
            else if (testsToRemove.Count > 0)
            {
                var removeData = new
                {
                    TestsToRemove = testToRemoveTable,
                    UserId = 1
                };
                return await RemoveResultTableDataAsync(removeData);

            }
            else
            {
                throw new Exception("No tests inserted or removed!");
            }


        }

        /// <summary>
        /// Adds and removes the specified test records to the Results table
        /// </summary>
        /// <param name="syncData"></param>
        /// <returns>Task of bool indicating success/failure</returns>
        private async Task<bool> SyncResultTableDataAsync(dynamic syncData)
        {
            var storedProcedure = "[dbo].[usp_SyncResultsTableData]";
            try
            {
                await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, syncData);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async Task<bool> InsertResultTableDataAsync(dynamic insertData)
        {
            var storedProcedure = "[dbo].[usp_InsertResultsTableData]";
            return await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, insertData);

        }

        private async Task<bool> RemoveResultTableDataAsync(dynamic removeData)
        {
            var storedProcedure = "[dbo].[usp_RemoveResultsTableData]";
            return await SelectInsertOrUpdateAsync<bool, dynamic>(storedProcedure, removeData);

        }

        /// <summary>
        /// Create an instance of TableValueParameter of ResultTableInsertDataUDT
        /// </summary>
        /// <param name="tests">Tests requested</param>
        /// <param name="cin">Sample cin</param>
        /// <returns>an instance of TableValueParameter of ResultTableInsertDataUDT as ICustomQueryParameter</returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task<SqlMapper.ICustomQueryParameter> GetTestsTableAsync
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            (List<TestsModel> tests, string cin, IStatusDataAccess statusData)
        {
            //Declare datatable instance and add the columns required for UDT
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");

            try
            {
                //Fetch Status Id for "Registered Status"
                var statusId = statusData.GetRegisteredStatusId();

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

        public async Task<UpdatedResultAndStatusModel> InsertUpdateResultByResultIdAsync(int resultId, string result, int testStatus)
        {
            var referenceData = await _referenceRangeDataAccess.GetReferenceRangeByResultIdAsync(resultId);
            var referenceCode = referenceData.GetResultReferenceCode(result, resultId);
            //check whether the test status is acceptable for result entry
            var InvalidTestStatusMessage = IsTestStatusValidForResultEntry(testStatus);
            if (!string.IsNullOrEmpty(InvalidTestStatusMessage))
            {
                throw new Exception(InvalidTestStatusMessage);
            }
            //Set the stored procedure to call
            var storedProcedure = "[dbo].[usp_UpdateResultByResultId]";
            //Make a database query to get Id for Status equivalent to "ToValidate".
            var statusId = statusData.GetToValidateStatusId();
            //prepare the parameter to pass to the query.
            var parameter = new { Result = result, ResultId = resultId, StatusId = statusId, ReferenceCode = referenceCode, UsersId = 1 };
            //insert result and result status
            return await SelectInsertOrUpdateAsync<UpdatedResultAndStatusModel, dynamic>(storedProcedure, parameter);
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

        /// <summary>
        /// Reject test by result Id
        /// </summary>
        /// <param name="resultId">The result Id for the test</param>
        /// <param name="cin">The CIN of the sample for which the test belongs to</param>
        /// <param name="commentListId">The comment to be inserted to the test</param>
        /// <param name="userId">The user Id of the logged in user</param>
        /// <returns>An instance of SampleAndResultStatusAndResultModel</returns>
        public async Task<SampleAndResultStatusAndResultModel> RejectTestByResultId(int resultId, string cin, int commentListId, int userId)
        {
            var storedProcedure = "[dbo].[usp_RejectTest]";
            var parameters = new
            {
                ResultId = resultId,
                Cin = cin,
                CommentListId  = commentListId,
                UserId = userId
            };

            try
            {
                var output = await QueryMultiple_GetModelAndListWithParameterAsync<StatusUpdatedSampleModel, UpdatedResultAndStatusModel, dynamic>
                    (storedProcedure, parameters);

                return new SampleAndResultStatusAndResultModel()
                {
                    SampleData = output.T1,
                    ResultStatus = output.U1
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Cancel test rejection by result Id
        /// </summary>
        /// <param name="resultId">The result Id of the test to cancel rejection</param>
        /// <param name="userId">The Id of the user doing the rejection</param>
        /// <returns>An instance of sample and test data in SampleAndResultStatusAndResultModel</returns>
        public async Task<SampleAndResultStatusAndResultModel> CancelTestRejectionByResultId(int resultId, int userId)
        {
            var storedProcedure = "[dbo].[usp_CancelTestRejectionByResultId]";
            var parameters = new
            {
                ResultId = resultId,
                UserId = userId
            };

            try
            {
                var output = await QueryMultiple_GetModelAndListWithParameterAsync<StatusUpdatedSampleModel, UpdatedResultAndStatusModel, dynamic>
                    (storedProcedure, parameters);

                return new SampleAndResultStatusAndResultModel()
                {
                    SampleData = output.T1,
                    ResultStatus = output.U1
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}