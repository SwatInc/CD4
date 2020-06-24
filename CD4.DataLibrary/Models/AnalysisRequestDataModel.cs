using CD4.DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class AnalysisRequestDataModel
    {
        public AnalysisRequestDataModel()
        {
            StatusId = 1;
        }
        #region Request Fields
        public string Cin { get; set; }
        public int SiteId { get; set; }
        public DateTime? SampleCollectionDate { get; set; }
        public DateTime? SampleReceivedDate { get; set; }

        #endregion

        #region Patient details
        public string NationalIdPassport { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public int GenderId { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Address { get; set; }
        public string Atoll { get; set; }
        public string Island { get; set; }
        public int AtollId { get; set; }
        public string Country { get; set; }
        public int CountryId { get; set; }

        #endregion

        #region Clinical Details, Tests, Episode Number
        public List<ClinicalDetailsSelectionModel> ClinicalDetails { get; set; }
        public List<TestsModel> Tests { get; set; }
        public string EpisodeNumber { get; set; }
        public int StatusId { get; set; }

        #endregion
    }
}
