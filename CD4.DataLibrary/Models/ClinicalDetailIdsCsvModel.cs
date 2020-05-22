using System.Linq;

namespace CD4.DataLibrary.Models
{
    class ClinicalDetailIdsCsvModel
    {
        private string csvClinicalDetails;
        private int[] clinicalDetailIds { get; set; }

        public string CsvClinicalDetails
        {
            get => csvClinicalDetails; set
            {
                csvClinicalDetails = value;
                InitializeClinicalDetailIdsArray();
            }
        }
        public int[] GetClinicalDetailIds()
        {
            return clinicalDetailIds;
        }
        private void InitializeClinicalDetailIdsArray()
        {
            clinicalDetailIds = csvClinicalDetails.Split(',')
                .Select(id => int.Parse(id)).ToArray();
        }

    }
}
