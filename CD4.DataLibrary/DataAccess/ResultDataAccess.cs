using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ResultDataAccess : DataAccessBase, IResultDataAccess
    {
        private readonly IStatusDataAccess _statusData;
        private readonly IReferenceRangeDataAccess _referenceRangeDataAccess;
        private readonly ISampleDataAccess _sampleDataAccess;

        public ResultDataAccess(IStatusDataAccess statusData,
            IReferenceRangeDataAccess referenceRangeDataAccess,
            ISampleDataAccess sampleDataAccess)
        {
            this._statusData = statusData;
            _referenceRangeDataAccess = referenceRangeDataAccess;
            _sampleDataAccess = sampleDataAccess;
        }

        /// <summary>
        /// Manages inserts the specified test lists into database and removes a specified test list from the database for a particualar CIN by calling appropriate methods
        /// </summary>
        /// <param name="testsToInsert">List of tests to insert</param>
        /// <param name="testsToRemove">List of tests to remove</param>
        /// <param name="cin">The CIN for which tests are to be inserted or deleted or both</param>
        /// <returns>Returns true or false indicating the successfull/unsuccessfull completion of the insert/delete operation</returns>
        public async Task<bool> ManageRequestedTestsDataAsync
            (List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin, int loggedInUserId)
        {
            var testToInsertTable = await GetTestsTableAsync(testsToInsert, cin);
            var testToRemoveTable = await GetTestsTableAsync(testsToRemove, cin);

            //determine whether to create, delete or sync result table data
            if (testsToInsert.Count > 0 && testsToRemove.Count > 0)
            {
                //sync data
                var syncData = new
                {
                    TestsToInsert = testToInsertTable,
                    TestsToRemove = testToRemoveTable,
                    UserId = loggedInUserId
                };

                await SyncResultTableDataAsync(syncData);
                return true;
            }
            else if (testsToInsert.Count > 0)
            {
                var insertData = new
                {
                    TestsToInsert = testToInsertTable,
                    UserId = loggedInUserId
                };
                return await InsertResultTableDataAsync(insertData);
            }
            else if (testsToRemove.Count > 0)
            {
                var removeData = new
                {
                    TestsToRemove = testToRemoveTable,
                    UserId = loggedInUserId
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
            (List<TestsModel> tests, string cin)
        {
            //Declare datatable instance and add the columns required for UDT
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");

            try
            {

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

        /// <summary>
        /// Inserts a result to the result Id specified and enters an audit trail for the sample.
        /// </summary>
        /// <param name="resultId">The result Id of the record to update.</param>
        /// <param name="result">the resut to update</param>
        /// <param name="testStatus">This is the CURRENT test status. NOT the status required for the tests after insert</param>
        /// <param name="userId">logged in user Id</param>
        /// <returns>returns the resulting UpdatedResultAndStatusModel</returns>
        public async Task<UpdatedResultAndStatusModel> InsertUpdateResultByResultIdAsync(int resultId, string result, int testStatus, int userId)
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
            var statusId = _statusData.GetToValidateStatusId();
            //prepare the parameter to pass to the query.
            var parameter = new { Result = result, ResultId = resultId, StatusId = statusId, ReferenceCode = referenceCode, UsersId = userId };
            //insert result and result status
            try
            {
                return await SelectInsertOrUpdateAsync<UpdatedResultAndStatusModel, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UpdatedResultAndStatusModel> InterfaceUpdateResultByTestIdAndCinAsync
            (int testId,string cin, string result,string batchId,string referenceCode, int userId)
        {
            //get test status from database
            int testStatusId;
            try
            {
                testStatusId = await _statusData.GetTestStatusByTestIdAndCin(testId, cin);
                if (testStatusId == 0)
                {
                    throw new Exception("Cannot determine test status. Cannot update result.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            //check whether the test status is acceptable for result entry
            var InvalidTestStatusMessage = IsTestStatusValidForResultEntry(testStatusId);
            if (!string.IsNullOrEmpty(InvalidTestStatusMessage))
            {
                throw new Exception(InvalidTestStatusMessage);
            }
            //Set the stored procedure to call
            var storedProcedure = "[dbo].[usp_InterfaceResultByTestCodeAndCin]";
            //Make a database query to get Id for Status equivalent to "ToValidate".
            var statusId = _statusData.GetToValidateStatusId();
            //prepare the parameter to pass to the query.
            var parameter = new 
            { 
                Result = result,
                TestId = testId, 
                Cin = cin,
                BatchId = batchId,
                StatusId = statusId,
                ReferenceCode = referenceCode,
                UsersId = userId 
            };
            //insert result and result status
            try
            {
                return await SelectInsertOrUpdateAsync<UpdatedResultAndStatusModel, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }
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
                    return "Cannot enter a result to a sample/test which is not accepted to the laboratory.";
                case (int)Status.Collected:
                    return "Cannot enter a result to a sample/test which is not accepted to the laboratory.";
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

        public async Task<bool> UpdateSampleStatusByResultId(int resultId, int sampleStatus, int loggedInUserId)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleStatusResultId]";
            var parameter = new { ResultId = resultId, SampleStatus = sampleStatus, UserId = loggedInUserId };
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
                CommentListId = commentListId,
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

        public async Task<List<ResultHistoryModel>> GetResultHistoryAync
            (int resultId, int analysisRequestId)
        {
            var parameters = new { ResultId = resultId, AnalysisRequestId = analysisRequestId };
            var storedProcedure = "[dbo].[usp_GetTestHistoryByResultId]";

            try
            {
                return await LoadDataWithParameterAsync<ResultHistoryModel, dynamic>
                    (storedProcedure, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SampleAndResultStatusAndResultModel> CancelResultValidation(int resultId, string cin, int userId)
        {
            var storedProcedure = "[dbo].[usp_CancelTestValidation]";
            var parameters = new { ResultId = resultId, Cin = cin, UsersId = userId };

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

        public async Task ManageReflexTests(List<TestsModel> reflexTests, string cin, int loggedInUserId)
        {
            try
            {
                //getting sample status
                var status = await _sampleDataAccess.GetSampleStatusAsync(cin);
                var testToInsertTable = await GetTestsTableAsync(reflexTests, cin);
                var paramters = new { TestsToInsert = testToInsertTable, UserId = loggedInUserId, InitialTestsStatus = status };

                switch (status)
                {
                    case 1: //registered

                        break;
                    case 2: //collected

                        break;
                    case 3: //Received
                        break;
                    case 4: //To validate
                        paramters = new { TestsToInsert = testToInsertTable, UserId = loggedInUserId, InitialTestsStatus = 3 };

                        break;
                    case 5: //validated
                        throw new Exception("Cannot add reflex tests to a validated sample.");
                    case 6: //Processing
                        paramters = new { TestsToInsert = testToInsertTable, UserId = loggedInUserId, InitialTestsStatus = 3 };

                        break;
                    case 7: //Rejected
                        throw new Exception("Cannot add reflex tests to a rejected sample.");
                    case 8: //Removed
                        throw new Exception("Cannot add reflex tests to a removed sample.");
                    default:
                        throw new Exception($"Cannnot determine sample status for sample number: [ {cin} ]");
                }

                await InsertResultTableDataAsync(paramters);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UpdatedResultAndStatusModel>> GetResultAndResultStatusDataByCin(string cin)
        {
            var storedProcedure = "[dbo].[usp_FetchResultWithStatusDataByCin]";
            var parameters = new { Cin = cin };
            try
            {
                return await LoadDataWithParameterAsync<UpdatedResultAndStatusModel, dynamic>
                    (storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}