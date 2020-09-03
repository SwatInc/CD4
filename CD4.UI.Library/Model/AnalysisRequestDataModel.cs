using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class AnalysisRequestDataModel
    {
        #region Request Fields
        public string Cin { get; set; }
        public int SelectedSiteId { get; set; }
        public DateTimeOffset SampleCollectionDate { get; set; }
        public DateTimeOffset SampleReceivedDate { get; set; }

        #endregion

        #region Patient details
        public string NationalIdPassport { get; set; }
        public string Fullname { get; set; }
        public int GenderId { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public int AtollId { get; set; } //IslandId is not required
        public int CountryId { get; set; }

        #endregion

        #region Clinical Details, Tests, Episode Number
        public List<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }
        public List<TestModel> Tests { get; set; }
        public string EpisodeNumber { get; set; }

        #endregion
    }
}
