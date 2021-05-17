using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class SampleTypeDataAccess : DataAccessBase, ISampleTypeDataAccess
    {
        public async Task<List<SampleTypeModel>> GetAllDSampleTypesAsync()
        {
            try
            {
                var storedProcedure = "usp_GetAllSampleTypes";
                var sampleTypes = await LoadDataAsync<SampleTypeModel>(storedProcedure);
                return sampleTypes;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
