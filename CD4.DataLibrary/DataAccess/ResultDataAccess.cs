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
                TestsToRemove = testToRemoveTable
            };

            return await SelectInsertOrUpdate<bool, dynamic>(storedProcedure, syncData);
        }

        /// <summary>
        /// Create an instance of TableValueParameter of ResultTableInsertDataUDT
        /// </summary>
        /// <param name="tests">Tests requested</param>
        /// <param name="cin">Sample cin</param>
        /// <returns>an instance of TableValueParameter of ResultTableInsertDataUDT as ICustomQueryParameter</returns>
        public static async Task<SqlMapper.ICustomQueryParameter> GetTestsTableAsync(List<TestsModel> tests, string cin, IStatusDataAccess statusData)
        {
            //Declare datatable instance and add the columns required for UDT
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");
            returnTable.Columns.Add("StatusId");

            try
            {
                //Fetch Status Id for "Registered Status"
                var statusId =  statusData.GetRegisteredStatusId();

                //Add rows to the Datatable declared, and return
                foreach (var item in tests)
                {
                    returnTable.Rows.Add(item.Id, cin, statusId);
                }
                return returnTable.AsTableValuedParameter("ResultTableInsertDataUDT");
            }
            catch (Exception)
            {
                //throw the exception right out! It will be handled down the line.
                throw;
            }


        }

        public async Task<bool> InsertUpdateResultByResultIdAsync(int resultId, string result)
        {
            //Set the stored procedure to call
            var storedProcedure = "[dbo].[usp_UpdateResultByResultId]";
            //Make a database query to get Id for Status equivalent to "ToValidate".
            var statusId =  statusData.GetToValidateStatusId();
            //prepare the parameter to pass to the query.
            var parameter = new { Result = result, ResultId = resultId, StatusId = statusId };
            //insert result and result status
            var output = await SelectInsertOrUpdate<bool, dynamic>(storedProcedure, parameter);
            //Set the sample status
            var sampleStatus = await statusData.DetermineSampleStatus(resultId);
            var IsSampleStatusSet = await UpdateSampleStatusByResultId(resultId, sampleStatus);
            return output;
        }

        public async Task<bool> UpdateSampleStatusByResultId(int resultId, int sampleStatus)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleStatusResultId]";
            var parameter = new { ResultId = resultId, SampleStatus = sampleStatus };
            return await SelectInsertOrUpdate<bool, dynamic>(storedProcedure, parameter);
        }
    }
}
