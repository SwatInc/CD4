using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class BulkImportsStaticDataModel
    {
        public BulkImportsStaticDataModel()
        {
            Genders = new List<GenderModel>();
            AtollsAndIslands = new List<AtollIslandModel>();
            Sites = new List<SitesModel>();
            Countries = new List<CountryModel>();
            ClinicalDetails = new List<ClinicalDetailsModel>();
            Tests = new List<ProfilesAndTestModelOeModel>();
            ProfileTests = new List<ProfileTestsDatabaseModel>();
        }
        public List<GenderModel> Genders { get; set; }
        public List<AtollIslandModel> AtollsAndIslands { get; set; }
        public List<SitesModel> Sites { get; set; }
        public List<CountryModel> Countries { get; set; }
        public List<ClinicalDetailsModel> ClinicalDetails { get; set; }
        public List<ProfilesAndTestModelOeModel> Tests { get; set; }
        public List<ProfileTestsDatabaseModel> ProfileTests { get; set; }


    }
}
