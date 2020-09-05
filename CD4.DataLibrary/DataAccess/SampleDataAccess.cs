﻿using CD4.DataLibrary.Models;
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
            return await SelectInsertOrUpdateAsync<bool, SampleUpdateDatabaseModel>(storedProcedure, sample);
        }

        public async Task<List<AuditTrailModel>> GetAuditTrailByCinAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetAuditTrailByCin]";
            var parameter = new { Cin = cin };
            return  await LoadDataWithParameterAsync<AuditTrailModel, dynamic>(storedProcedure, parameter);
        }
    }
}
