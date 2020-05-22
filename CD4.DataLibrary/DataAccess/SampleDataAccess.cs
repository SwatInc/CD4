using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class SampleDataAccess : DataAccessBase, ISampleDataAccess
    {
        public async Task<bool> UpdateSample(SampleUpdateDatabaseModel sample)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleWithCin]";
            return await SelectInsertOrUpdate<bool, SampleUpdateDatabaseModel>(storedProcedure, sample);
        }
    }
}
