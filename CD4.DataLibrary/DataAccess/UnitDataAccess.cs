using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class UnitDataAccess : DataAccessBase, IUnitDataAccess
    {
        public async Task<List<UnitModel>> GetAllUnitsAsync()
        {
            try
            {
                var storedProcedure = "[dbo].[usp_GetAllUnits]";
                var units = await LoadDataAsync<UnitModel>(storedProcedure);
                return units;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
