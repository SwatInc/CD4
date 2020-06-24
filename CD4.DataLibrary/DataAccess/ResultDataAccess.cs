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
        public async Task<bool> SyncRequestedTestDataAsync
            (List<TestsModel> testsToInsert, List<TestsModel> testsToRemove, string cin)
        {
            var testToInsertTable = GetTestsTable(testsToInsert, cin);
            var testToRemoveTable = GetTestsTable(testsToRemove, cin);
            var storedProcedure = "[dbo].[usp_SyncResultsTableData]";

            var syncData = new
            {
                TestsToInsert = testToInsertTable,
                TestsToRemove = testToRemoveTable
            };

            return await SelectInsertOrUpdate<bool, dynamic>(storedProcedure, syncData);
        }

        public static SqlMapper.ICustomQueryParameter GetTestsTable(List<TestsModel> tests, string cin)
        {
            var statusId = 1;
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");
            returnTable.Columns.Add("StatusId");

            foreach (var item in tests)
            {
                returnTable.Rows.Add(item.Id,cin, statusId);
            }
            return returnTable.AsTableValuedParameter("ResultTableInsertDataUDT");
        }

        public async Task<bool> InsertUpdateResultByResultIdAsync(int resultId, string result)
        {
            var storedProcedure = "[dbo].[usp_UpdateResultByResultId]";
            var parameter = new { Result = result, ResultId = resultId };

            var output = await SelectInsertOrUpdate<bool, dynamic>(storedProcedure, parameter);
            return output;
        }
    }
}
