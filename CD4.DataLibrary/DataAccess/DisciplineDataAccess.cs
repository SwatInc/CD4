using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class DisciplineDataAccess : DataAccessBase, IDisciplineDataAccess
    {
        public async Task<List<DisciplineModel>> GetAllDisciplinesAsync()
        {
            try
            {
                var storedProcedure = "usp_GetAllDisciplines";
                var disciplines = await LoadDataAsync<DisciplineModel>(storedProcedure);
                return disciplines;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
