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
        public event EventHandler<PatientModel> PatientSelected;
        public BindingList<PatientModel> SearchResults { get; set; }

        private List<PatientModel> DemoPatientData { get; set; }
        public string PatientNameForSearch { get; set; }

        public PatientSearchResultsViewModel()
        {
            SearchResults = new BindingList<PatientModel>();
            DemoPatientData = new List<PatientModel>();

            InitializeDemoData();

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
            var results = await Task.Run(async() => 
            {
                await Task.Delay(3000);
                return DemoPatientData.Where((p) => p.Fullname.Trim().ToLower().Contains(PatientNameForSearch.Trim().ToLower()));
            }).ConfigureAwait(true);

            ManageSearchResults(results);
        }
        public void UserSelectedPatient(PatientModel row)
        {
            PatientSelected?.Invoke(this, row);
        }
        private void ManageSearchResults(IEnumerable<PatientModel> results)
        {
            //display to user for choosing.
            SearchResults.Clear();
            if (results is null) return;
            foreach (var item in results)
            {
                SearchResults.Add(item);
            }
        }

    }
}
