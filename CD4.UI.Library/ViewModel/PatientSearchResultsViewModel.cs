using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class PatientSearchResultsViewModel : INotifyPropertyChanged, IPatientSearchResultsViewModel
    {
        private readonly IMapper mapper;
        private readonly IPatientDataAccess patientDataAccess;

        public event EventHandler<PatientModel> PatientSelected;
        public BindingList<PatientModel> SearchResults { get; set; }

        private List<PatientModel> DemoPatientData { get; set; }
        public string SearchTerm { get; set; }
        public SearchTermType SearchType { get; set; }

        public enum SearchTermType
        {
            PatientName,
            NidPp
        }

        public PatientSearchResultsViewModel(IMapper mapper, IPatientDataAccess patientDataAccess)
        {
            SearchResults = new BindingList<PatientModel>();
            DemoPatientData = new List<PatientModel>();
            this.mapper = mapper;
            this.patientDataAccess = patientDataAccess;

            //InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            var p1 = new PatientModel()
            {
                Id = 1,
                Fullname = "Ahmed Hussain",
                NidPp = "A123456",
                Birthdate = DateTime.Parse("1991-02-14"),
                Gender="MALE",
                Atoll = "Addu",
                Island = "Hithadhoo",
                Country="Maldives",
                Address ="Some Address",
                PhoneNumber="2652377"
            };

            var p2 = new PatientModel()
            {
                Id = 2,
                Fullname = "Aminath Hussain",
                NidPp = "A987654",
                Birthdate = DateTime.Parse("1991-02-14"),
                Gender = "FEMALE",
                Atoll = "Addu",
                Island = "Hithadhoo",
                Country = "Maldives",
                Address = "Some Some Address",
                PhoneNumber = "78748568"

                
            };

            DemoPatientData.Add(p1);
            DemoPatientData.Add(p2);
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public async Task SearchByPatientNameAsync()
        {
            List<DataLibrary.Models.PatientModel> results = new List<DataLibrary.Models.PatientModel>();
            switch (SearchType)
            {
                case SearchTermType.PatientName:
                    results = await patientDataAccess.GetPatientByPartialName(SearchTerm);
                    break;
                case SearchTermType.NidPp:
                    results = await patientDataAccess.GetPatientByNidPp(SearchTerm);
                    break;
                default:
                    break;
            }
            ManageSearchResults(mapper.Map<List<PatientModel>>(results));
        }
        public void UserSelectedPatient(PatientModel row)
        {
            PatientSelected?.Invoke(this, row);
        }
        private void ManageSearchResults(IEnumerable<PatientModel> results)
        {
            if (results is null)
            {
                PatientSelected?.Invoke(this,null);
                return; 
            }
            SearchResults.Clear();

            //If result yeilds one or zero(close results window), choose the one
            if(results.Count() == 1 )
            {
                PatientSelected?.Invoke(this, results.FirstOrDefault());
                    return;
            }

            if (results.Count() == 0)
            {
                PatientSelected?.Invoke(this, null);
                return;
            }

            //If results yeld more than one, let the user choose.
            foreach (var item in results)
            {
                SearchResults.Add(item);
            }
        }

    }
}
