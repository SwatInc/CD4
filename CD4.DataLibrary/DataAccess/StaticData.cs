using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class StaticData : DataAccessBase
    {
        public void LoadAll()
        {
        }

        private List<T> LoadStaticData<T>(string storedProcedure)
        {
            List<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = connection.Query<T>(storedProcedure, CommandType.StoredProcedure).ToList();
            }

            return results;
        }

        public List<SitesModel> GetAllSites()
        {
            string storedProcedure = "usp_GetAllSites";
            try
            {
                return LoadStaticData<SitesModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CountryModel> GetAllCountries()
        {
            string storedProcedure = "usp_GetAllCountries";
            try
            {
                return LoadStaticData<CountryModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GenderModel> GetAllGender()
        {
            string storedProcedure = "usp_GetAllGenders";
            try
            {
                return LoadStaticData<GenderModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AtollIslandModel> GetAllAtollsAndIslands()
        {
            string storedProcedure = "usp_GetAllAtollAndIslands";
            try
            {
                return LoadStaticData<AtollIslandModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClinicalDetailsModel> GetAllClinicalDetails()
        {
            string storedProcedure = "usp_GetAllClinicalDetails";
            try
            {
                return LoadStaticData<ClinicalDetailsModel>(storedProcedure);
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
