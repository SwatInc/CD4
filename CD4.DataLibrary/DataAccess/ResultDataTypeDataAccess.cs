using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ResultDataTypeDataAccess : DataAccessBase, IResultDataTypeDataAccess
    {
        public async Task<List<ResultDataTypeModel>> GetAllResultDataTypesAsync()
        {
            try
            {
                var storedProcedure = "usp_GetAllResultDataTypes";
                var dataTypes = await LoadDataAsync<ResultDataTypeModel>(storedProcedure);
                return dataTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
