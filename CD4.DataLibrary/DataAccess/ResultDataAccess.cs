using CD4.DataLibrary.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ResultDataAccess : DataAccessBase, IResultDataAccess
    {
        public async Task<bool> SyncRequestedTestData
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

            return await InsertOrUpdate<bool, dynamic>(storedProcedure, syncData);
        }

        public static SqlMapper.ICustomQueryParameter GetTestsTable(List<TestsModel> tests, string cin)
        {
            var returnTable = new DataTable();
            returnTable.Columns.Add("TestId");
            returnTable.Columns.Add("Sample_Cin");

            foreach (var item in tests)
            {
                returnTable.Rows.Add(item.Id, cin);
            }
            return returnTable.AsTableValuedParameter("ResultTableInsertDataUDT");
        }
    }
}
