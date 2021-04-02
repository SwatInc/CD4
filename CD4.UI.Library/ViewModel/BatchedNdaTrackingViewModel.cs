using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
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
        private readonly IStatusDataAccess _statusDataAccess;
        private readonly IMapper _mapper;
        private readonly IStaticDataDataAccess _staticDataDataAccess;
        private readonly INdaTrackingDataAccess _ndaTrackingDataAccess;

        #endregion

        private event EventHandler InitializeDatasources;

        #region Default Constructor
        public BatchedNdaTrackingViewModel(IStatusDataAccess statusDataAccess,
             IMapper mapper,
             IStaticDataDataAccess staticDataDataAccess,
             INdaTrackingDataAccess ndaTrackingDataAccess)
        {
            NdaTrackingData = new BindingList<NdaTrackingModel>();
            Statuses = new List<StatusModel>();
            Scientists = new List<ScientistModel>();
            _statusDataAccess = statusDataAccess;
            _mapper = mapper;
            _staticDataDataAccess = staticDataDataAccess;
            _ndaTrackingDataAccess = ndaTrackingDataAccess;

            //InitializeDemo();
            InitializeDatasources += OnInitaializeDatasources;
            InitializeDatasources?.Invoke(this, EventArgs.Empty);
        }

        private async void OnInitaializeDatasources(object sender, EventArgs e)
        {
            try
            {
                //load all datasources
                await LoadAllStatusAsync();
                await LoadAllScientistsAsync();
                await LoadSamplesWithDefaultConfigAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading datasources. Please see the details below.\n{ex.Message}");
            }
        }

        private async Task LoadSamplesWithDefaultConfigAsync()
        {
            NdaTrackingData.Clear();
            var results = await _ndaTrackingDataAccess.LoadSearchResults(DateTime.Today.AddDays(-5), DateTime.Today, 5);
            foreach (var item in results)
            {
                NdaTrackingData.Add(_mapper.Map<NdaTrackingModel>(item));
            }
        }

        private async Task LoadAllScientistsAsync()
        {
            var scientists = await _staticDataDataAccess.GetAllScientistsAsync();
            Scientists.AddRange(_mapper.Map<List<ScientistModel>>(scientists));
        }

        private async Task LoadAllStatusAsync()
        {
            var statuses = await _statusDataAccess.GetAllStatus();
            Statuses.AddRange(_mapper.Map<List<StatusModel>>(statuses));
        }

        #endregion


        #region Public Properties

        #region Datasources
        public BindingList<NdaTrackingModel> NdaTrackingData { get; set; }
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
                AnalysedBy = "Ahmed Ibrahim",
                CalQcValidatedBy = "Ibrahim Hussain",
                CollectedDate = DateTime.Today,
                ReceivedDate = DateTime.Today,
                ValidatedDateTime = DateTimeOffset.UtcNow,
                ReportedDate = DateTime.Today
            };

            NdaTrackingData.Add(trackingData);

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
            Debug.WriteLine($"Tracking Data count: {NdaTrackingData.Count}");

            //check whether changing a property updates the databound grid
            var counter = 0;
            foreach (var item in NdaTrackingData)
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
