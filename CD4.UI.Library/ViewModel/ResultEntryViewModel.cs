﻿using CD4.UI.Library.Model;
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
        public ResultEntryViewModel()
        {
            RequestData = new List<RequestSampleModel>();
            SelectedResultData = new BindingList<ResultModel>();
            SelectedRequestData = new RequestSampleModel();
            AllResultData = new List<ResultModel>();
            GenerateDemoData();
        }

        private void GenerateDemoData()
        {
            #region Request Data
            var rq1 = new RequestSampleModel()
            {
                 Id=1,
                 AnalysisRequestId=1,
                 Cin = "nCoV-1236/20",
                 CollectionDate=DateTime.Today,
                 ReceivedDate = DateTime.Today,
                 PatientName = "Ahmed Hussain",
                 NationalId = "A29837",
                 AgeSex="30Y 3M 27D / MALE",
                 Birthdate=DateTime.Today,
                 PhoneNumber="71261888",
                 Address="Some Adddress",
                 AtollIslandCountry="L. Gan, Maldives",
                 EpisodeNumber="SW7289889",
                 Site="FARUKOLHU",
                 ClinicalDetails="Fever, Cough"
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
                AtollIslandCountry = "L. Gan, Maldives",
                EpisodeNumber = "SW7289889",
                Site = "FARUKOLHU",
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
                Cin = "",
                Test = "E Gene",
                Result = "",
                DataType = "Numeric"
            };
            var rs1_2 = new ResultModel()
            {
                Id = 1,
                AnalysisRequestId = 1,
                Cin = "",
                Test = "RdRp",
                Result = "",
                DataType = "Numeric"
            };

            AllResultData.Add(rs1_1);
            AllResultData.Add(rs1_2);
            #endregion
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

        #endregion

        #region Public Methods

        public void SetSelectedSample(RequestSampleModel requestSampleData)
        {
            if (requestSampleData is null) return;
            SelectedRequestData = requestSampleData;
        }

        #endregion
    }
}
