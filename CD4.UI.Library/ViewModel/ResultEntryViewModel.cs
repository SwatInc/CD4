using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class ResultEntryViewModel : INotifyPropertyChanged, IResultEntryViewModel
    {

        #region Default Constructor
        public ResultEntryViewModel(IWorkSheetDataAccess workSheetDataAccess)
        {
            RequestData = new List<RequestSampleModel>();
            SelectedResultData = new BindingList<ResultModel>();
            SelectedClinicalDetails = new BindingList<string>();
            SelectedRequestData = new RequestSampleModel();
            AllResultData = new List<ResultModel>();
            CodifiedPhrasesForSelectedTest = new BindingList<CodifiedResultsModel>();
            AllCodifiedPhrases = new List<CodifiedResultsModel>();
            TempCodifiedPhrasesList = new List<CodifiedResultsModel>();
            
            GenerateDemoData();
            this.workSheetDataAccess = workSheetDataAccess;
            workSheetDataAccess.GetNotValidatedWorklist(new DateTime(2019,05,01));
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public Properties
        public List<RequestSampleModel> RequestData { get; set; }
        public BindingList<ResultModel> SelectedResultData { get; set; }
        private List<ResultModel> AllResultData { get; set; }
        public RequestSampleModel SelectedRequestData { get; set; }
        public BindingList<CodifiedResultsModel> CodifiedPhrasesForSelectedTest { get; set; }
        public BindingList<string> SelectedClinicalDetails { get; set; }
        public List<CodifiedResultsModel> AllCodifiedPhrases { get; set; }
        private List<CodifiedResultsModel> TempCodifiedPhrasesList;
        private readonly IWorkSheetDataAccess workSheetDataAccess;

        #endregion

        #region Public Methods

        public async Task SetSelectedSampleAsync(RequestSampleModel requestSampleData)
        {
            if (requestSampleData is null) return;
            SelectedRequestData.Id = requestSampleData.Id;
            SelectedRequestData.NationalId = requestSampleData.NationalId;
            SelectedRequestData.PatientName = requestSampleData.PatientName;
            SelectedRequestData.PhoneNumber = requestSampleData.PhoneNumber;
            SelectedRequestData.ReceivedDate = requestSampleData.ReceivedDate;
            SelectedRequestData.Site = requestSampleData.Site;
            SelectedRequestData.Address = requestSampleData.Address;
            SelectedRequestData.AgeSex = requestSampleData.AgeSex;
            SelectedRequestData.AnalysisRequestId = requestSampleData.AnalysisRequestId;
            SelectedRequestData.AtollIslandCountry = requestSampleData.AtollIslandCountry;
            SelectedRequestData.Birthdate = requestSampleData.Birthdate;
            SelectedRequestData.Cin = requestSampleData.Cin;
            SelectedRequestData.ClinicalDetails = requestSampleData.ClinicalDetails;
            SelectedRequestData.CollectionDate = requestSampleData.CollectionDate;
            SelectedRequestData.EpisodeNumber = requestSampleData.EpisodeNumber;

            SetClinicalDetailsForSelectedSample(requestSampleData.ClinicalDetails);

            await DisplaySelectedSamplesResultsAsync(requestSampleData.Cin).ConfigureAwait(true);
        }

        public async Task SetTestCodifiedPhrasesAsync(ResultModel selectedTest)
        {

            if (selectedTest is null || selectedTest.DataType is null || selectedTest.Mask is null)
            { return; }
            CodifiedPhrasesForSelectedTest.Clear();
            TempCodifiedPhrasesList.Clear();
            if (selectedTest.DataType == "CODIFIED" && selectedTest.Mask.Contains('|'))
            {
                var codifiedPhraseIds = selectedTest.Mask.Split('|');
                TempCodifiedPhrasesList = await Task.Run(() =>
                {
                    return GetCodifiedPhrasesForIds(codifiedPhraseIds);
                }).ConfigureAwait(true);

                if (TempCodifiedPhrasesList.Count == 0) return;

                foreach (var phrase in TempCodifiedPhrasesList)
                {
                    CodifiedPhrasesForSelectedTest.Add(phrase);
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetClinicalDetailsForSelectedSample(string delimitedDetails)
        {
            SelectedClinicalDetails.Clear();
            var details = delimitedDetails.Split(',');
            if (details.Length == 0) return;

            foreach (var item in details)
            {
                SelectedClinicalDetails.Add(item.Trim());
            }

        }
        private List<CodifiedResultsModel> GetCodifiedPhrasesForIds(string[] idsCodifiedPhrase)
        {
            var returnList = new List<CodifiedResultsModel>();
            foreach (var id in idsCodifiedPhrase)
            {
                var isIsInt = int.TryParse(id, out int parsedId);
                if (isIsInt) 
                {
                    var match = AllCodifiedPhrases.Find((c) => c.Id == parsedId);
                    if (match is null) continue;
                    returnList.Add(match);
                }
            }
            return returnList;
        }
        private async Task DisplaySelectedSamplesResultsAsync(string cin)
        {
            if (cin is null) return;
            var selectedResult = await Task.Run(() =>
            {
                return AllResultData.FindAll((r) => r.Cin == cin);
            });

            if (selectedResult is null) return;
            SelectedResultData.Clear();

            foreach (var result in selectedResult)
            {
                SelectedResultData.Add(result);
            }

        }
        private void GenerateDemoData()
        {
            #region Request Data
            var rq1 = new RequestSampleModel()
            {
                Id = 1,
                AnalysisRequestId = 1,
                Cin = "nCoV-1236/20",
                CollectionDate = DateTime.Today,
                ReceivedDate = DateTime.Today,
                PatientName = "Ahmed Hussain",
                NationalId = "A29837",
                AgeSex = "30Y 3M 27D / MALE",
                Birthdate = DateTime.Today,
                PhoneNumber = "71261888",
                Address = "Some Adddress",
                AtollIslandCountry = "L. Gan, Maldives",
                EpisodeNumber = "SW7289889",
                Site = "FARUKOLHU",
                ClinicalDetails = "Fever, Cough"
            };
            var rq2 = new RequestSampleModel()
            {
                Id = 2,
                AnalysisRequestId = 2,
                Cin = "nCoV-324528/20",
                CollectionDate = DateTime.Today,
                ReceivedDate = DateTime.Today,
                PatientName = "Kamal Nasir",
                NationalId = "A2346288",
                AgeSex = "30Y 3M 27D / MALE",
                Birthdate = DateTime.Today,
                PhoneNumber = "0917266767",
                Address = "Some Some Adddress",
                AtollIslandCountry = "Hulhumale, Male', Maldives",
                EpisodeNumber = "SW989787656",
                Site = "IGMH",
                ClinicalDetails = "SOB, Fever, Cough"
            };

            RequestData.Add(rq1);
            RequestData.Add(rq2);
            #endregion

            #region AllResultsData
            var rs1_1 = new ResultModel()
            {
                Id = 1,
                AnalysisRequestId = 1,
                Cin = "nCoV-1236/20",
                Test = "E Gene",
                Result = "",
                DataType = "Numeric",
                Mask = "###.##"
            };
            var rs1_2 = new ResultModel()
            {
                Id = 1,
                AnalysisRequestId = 1,
                Cin = "nCoV-324528/20",
                Test = "RdRp",
                Result = "",
                DataType = "CODIFIED",
                Mask = "1|2"
            };

            var rs1_3 = new ResultModel()
            {
                Id = 1,
                AnalysisRequestId = 1,
                Cin = "nCoV-324528/20",
                Test = "E Gene",
                Result = "",
                DataType = "NUMERIC",
                Mask = "###.##"
            };
            AllResultData.Add(rs1_1);
            AllResultData.Add(rs1_2);
            AllResultData.Add(rs1_3);
            #endregion

            #region All Codified Phrases

            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 1, CodifiedValue = "POSITIVE" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 2, CodifiedValue = "NEGATIVE" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 3, CodifiedValue = "NOT DETECTED" });
            AllCodifiedPhrases.Add(new CodifiedResultsModel() { Id = 4, CodifiedValue = "DETECTED" });

            #endregion
        }

        #endregion

    }
}
