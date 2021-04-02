using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class BatchedNdaTrackingViewModel : INotifyPropertyChanged, IBatchedNdaTrackingViewModel
    {
        #region Private Properties
        private DateTime? fromDate;
        private DateTime? toDate;
        private DateTime? selectedReportTime;
        private ScientistModel calQcValidatedUser;
        private ScientistModel analysedUser;
        private StatusModel selectedStatus;
        #endregion

        #region Default Constructor
        public BatchedNdaTrackingViewModel()
        {
            NdaTracingData = new BindingList<NdaTrackingModel>();
            Statuses = new List<StatusModel>();
            Scientists = new List<ScientistModel>();

            InitializeDemo();
        }

        #endregion


        #region Public Properties

        #region Datasources
        public BindingList<NdaTrackingModel> NdaTracingData { get; set; }
        public List<StatusModel> Statuses { get; set; }
        public List<ScientistModel> Scientists { get; set; }
        #endregion

        #region Search Criteria
        public DateTime? FromDate
        {
            get => fromDate; set
            {
                fromDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime? ToDate
        {
            get => toDate; set
            {
                toDate = value;
                OnPropertyChanged();
            }
        }
        public StatusModel SelectedStatus
        {
            get => selectedStatus; set
            {
                selectedStatus = value;
                Debug.WriteLine(JsonConvert.SerializeObject(value));
                OnPropertyChanged();
            }
        }
        #endregion

        #region Tracking
        public DateTime? SelectedReportDate
        {
            get => selectedReportTime; set
            {
                selectedReportTime = value;
                Debug.WriteLine($"Selected Report date: {value}");
                OnPropertyChanged();
            }
        }
        public ScientistModel CalQcValidatedUser
        {
            get => calQcValidatedUser; set
            {
                calQcValidatedUser = value;
                Debug.WriteLine(JsonConvert.SerializeObject(value));
                OnPropertyChanged();
            }
        }
        public ScientistModel AnalysedUser
        {
            get => analysedUser; set
            {
                analysedUser = value;
                Debug.WriteLine(JsonConvert.SerializeObject(value));
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion

        #region Private Methods
        private void InitializeDemo()
        {
            var trackingData = new NdaTrackingModel()
            {
                InstituteAssignedPatientId = 13215645,
                Cin = "ML37645873",
                Status = Properties.Resources.Validated,
                TestedBy = "Ahmed Ibrahim",
                CalQcValidatedBy = "Ibrahim Hussain",
                CollectedDate = DateTime.Today,
                ReceivedDate = DateTime.Today,
                ProcessedDate = DateTime.Today,
                ValidatedDateTime = DateTimeOffset.UtcNow,
                ReportedDate = DateTime.Today
            };

            NdaTracingData.Add(trackingData);

            //toggle from and to date to null between then to todays date

            if (FromDate is null)
            {
                FromDate = DateTime.Today;
                ToDate = DateTime.Today;
            }
            else
            {
                FromDate = null;
                ToDate = null;
            }

            //Add sample statuses
            if (Statuses.Count == 0)
            {
                Statuses.Add(new StatusModel() { Id = 1, Status = "Registered" });
                Statuses.Add(new StatusModel() { Id = 2, Status = "Collected" });
                Statuses.Add(new StatusModel() { Id = 3, Status = "Accepted" });
                Statuses.Add(new StatusModel() { Id = 4, Status = "Validated" });
            }

            //adding all usernames for selecting Analysed By and Processed by
            Scientists.Add(new ScientistModel() { Id = 1, Scientist = "Ibrahim Hussain" });
            Scientists.Add(new ScientistModel() { Id = 2, Scientist = "Ahmed Hisan" });
        }
        #endregion

        #region Pulic Method
        public async Task ExecuteSearchAsync()
        {
            InitializeDemo();
            Debug.WriteLine($"Tracking Data count: {NdaTracingData.Count}");

            //check whether changing a property updates the databound grid
            var counter = 0;
            foreach (var item in NdaTracingData)
            {
                item.Cin = $"{item.Cin}{counter}";
                counter++;
            }
        }
        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
