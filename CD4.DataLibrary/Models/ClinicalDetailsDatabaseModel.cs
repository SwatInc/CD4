using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class ClinicalDetailsDatabaseModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public int ClinicalDetailsId { get; set; }

        public static bool AreEqual(List<ClinicalDetailsSelectionModel> clinicalDetails, List<ClinicalDetailsDatabaseModel> databaseModel)
        {
            var selectedDetails = clinicalDetails.Where((c) => c.IsSelected);

            if (selectedDetails.Count() != databaseModel.Count())
            {
                return false;
            }

            foreach (var detail in databaseModel)
            {
                var selectedDetail = clinicalDetails.Where((c) => c.IsSelected && c.Id == detail.ClinicalDetailsId).FirstOrDefault();
                if (selectedDetail is null)
                { 
                    return false; 
                }
            }

            return true;
        }
    }

}
