using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class TestViewModel : INotifyPropertyChanged, ITestViewModel
    {
        #region Private Properties

        private int selectedDataType;
        private int selectedDiscipline;
        private int sampleType;
        private int selectedUnit;
        private readonly IAssayDataAccess _assayDataAccess;
        private readonly IDisciplineDataAccess _disciplineDataAccess;
        private readonly ISampleTypeDataAccess _sampleTypeDataAccess;
        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IResultDataTypeDataAccess _resultDataTypeDataAccess;
        private readonly IMapper _mapper;

        #endregion

        #region Events
        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        public event EventHandler OnInitialize;
        public event EventHandler<TestsInsertModel> OnInitiateTestInsert;
        public event EventHandler<TestUpdateModel> OnInitiateTestUpdate;

        #endregion


        public TestViewModel(IAssayDataAccess assayDataAccess
            , IDisciplineDataAccess disciplineDataAccess
            , ISampleTypeDataAccess sampleTypeDataAccess
            , IUnitDataAccess unitDataAccess
            , IResultDataTypeDataAccess resultDataTypeDataAccess
            , IMapper mapper)
        {
            this.TestList = new BindingList<TestModel>();
            DisciplineList = new List<DisciplineModel>();
            SampleTypesList = new List<SampleTypeModel>();
            UnitList = new List<UnitModel>();
            this.SelectedTest = new TestModel();
            this.ResultDataTypes = new List<ResultDataTypeModel>();
            //this.SelectedDataType = new ResultDataTypeModel();
            //InitializeDemoData();
            this.PropertyChanged += TestViewModel_PropertyChanged;
            this._assayDataAccess = assayDataAccess;
            this._disciplineDataAccess = disciplineDataAccess;
            this._sampleTypeDataAccess = sampleTypeDataAccess;
            this._unitDataAccess = unitDataAccess;
            this._resultDataTypeDataAccess = resultDataTypeDataAccess;
            this._mapper = mapper;

            OnInitialize += TestViewModel_OnInitialize;
            OnInitiateTestInsert += TestViewModel_OnInitiateTestInsert;
            OnInitiateTestUpdate += TestViewModel_OnInitiateTestUpdate;

            OnInitialize?.Invoke(this, EventArgs.Empty);

        }

        private async void TestViewModel_OnInitiateTestUpdate(object sender, TestUpdateModel e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(TestsInsertModel),
                    "The model passed in for test update is null.");
            }

            //map the model to data layer model
            var mappedUpdateModel = _mapper.Map<DataLibrary.Models.TestUpdateModel>(e);
            try
            {
                //call data layer to insert the assay
                var updatedTest = await _assayDataAccess.AssayUpdateAsync(mappedUpdateModel);
                //map the updated model to UI library model
                var mappedUpdateddTest = _mapper.Map<TestModel>(updatedTest);
                //Display inserted or updated test on UI
                DisplayInsertedUpdatedTestOnUI(mappedUpdateddTest);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void TestViewModel_OnInitiateTestInsert(object sender, TestsInsertModel e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(TestsInsertModel),
                    "The model passed in for test insert is null.");
            }

            //map the model to data layer model
            var mappedInsertModel = _mapper.Map<DataLibrary.Models.TestsInsertModel>(e);
            try
            {
                //call data layer to insert the assay
                var insertedTest = await _assayDataAccess.InsertTestAsync(mappedInsertModel);
                //map the inserted model to UI library model
                var mappedInsertedTest = _mapper.Map<TestModel>(insertedTest);
                //Display inserted or updated test on UI
                DisplayInsertedUpdatedTestOnUI(mappedInsertedTest);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DisplayInsertedUpdatedTestOnUI(TestModel mappedInsertedModel)
        {
            //look for the test Id loaded tests list
            var test = TestList.FirstOrDefault((x) => x.Id == mappedInsertedModel.Id);

            //remove the test if exists... and add the mappedInsertedModel
            //This will effectively update the UI
            if (test != null)
            {
                TestList.Remove(test);
            }

            TestList.Add(mappedInsertedModel);

        }

        private async void TestViewModel_OnInitialize(object sender, EventArgs e)
        {
            //load disciplines, sample types, units, result data types
            await LoadAllDisciplinesAsync();
            await LoadAllSampleTypesAsync();
            await LoadAllUnitsAsync();
            await LoadAllResultDataTypesAsync();
            await LoadAllAssaysAsync();
        }

        private async Task LoadAllDisciplinesAsync()
        {
            try
            {
                var disciplines = await _disciplineDataAccess.GetAllDisciplinesAsync();
                var mapped = _mapper.Map<List<DisciplineModel>>(disciplines);
                DisciplineList.AddRange(mapped);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }

        private async Task LoadAllSampleTypesAsync()
        {
            try
            {
                var sampleTypes = await _sampleTypeDataAccess.GetAllDSampleTypesAsync();
                var mapped = _mapper.Map<List<SampleTypeModel>>(sampleTypes);
                SampleTypesList.AddRange(mapped);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }

        private async Task LoadAllUnitsAsync()
        {
            try
            {
                var units = await _unitDataAccess.GetAllUnitsAsync();
                var mappedUnits = _mapper.Map<List<UnitModel>>(units);
                UnitList.AddRange(mappedUnits);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }
        private async Task LoadAllResultDataTypesAsync()
        {
            try
            {
                var dataTypes = await _resultDataTypeDataAccess.GetAllResultDataTypesAsync();
                var mappedDataTypes = _mapper.Map<List<ResultDataTypeModel>>(dataTypes);
                ResultDataTypes.AddRange(mappedDataTypes);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }
        private async Task LoadAllAssaysAsync()
        {
            try
            {
                var assays = await _assayDataAccess.GetAllAssaysAsync();
                var mappedAssays = _mapper.Map<List<TestModel>>(assays);
                TestList.Clear();

                foreach (var item in mappedAssays)
                {
                    TestList.Add(item);
                }
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void TestViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("Property changed: " + e.PropertyName);
        }

        private void InitializeDemoData()
        {
            var egene = new TestModel() { Id = 1, Discipline = "Molecular Biology", Description = "E Gene", SampleType = "SWAB", ResultDataType = "Numeric", Mask = "###.00", Unit = "%", IsReportable = true, Code = "", DefaultCommented = false };
            var rdrpgene = new TestModel() { Id = 2, Discipline = "Molecular Biology", Description = "RdRP Gene", SampleType = "SWAB", ResultDataType = "Numeric", Mask = "###.00", Unit = " ", IsReportable = false, Code = "P", DefaultCommented = false };

            DisciplineList.Add(new DisciplineModel() { Id = 1, Discipline = "Haematology", Code = "H" });
            DisciplineList.Add(new DisciplineModel() { Id = 2, Discipline = "Molecular Biology", Code = "M" });
            DisciplineList.Add(new DisciplineModel() { Id = 3, Discipline = "Biochemistry", Code = "B" });

            SampleTypesList.Add(new SampleTypeModel() { Id = 1, Description = "SERUM" });
            SampleTypesList.Add(new SampleTypeModel() { Id = 2, Description = "EDTA WHOLE BLOOD" });
            SampleTypesList.Add(new SampleTypeModel() { Id = 3, Description = "SWAB" });

            UnitList.Add(new UnitModel() { Id = 1, Unit = "NA" });
            UnitList.Add(new UnitModel() { Id = 2, Unit = "%" });
            UnitList.Add(new UnitModel() { Id = 3, Unit = "mg/dL" });

            this.TestList.Add(egene);
            this.TestList.Add(rdrpgene);

            var numeric = new ResultDataTypeModel() { Id = 1, DataType = "Numeric" };
            var codified = new ResultDataTypeModel() { Id = 2, DataType = "Codified" };
            var Textual = new ResultDataTypeModel() { Id = 3, DataType = "Textual" };

            this.ResultDataTypes.Add(numeric);
            this.ResultDataTypes.Add(Textual);
            this.ResultDataTypes.Add(codified);

        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public Properties
        public BindingList<TestModel> TestList { get; set; }
        public List<DisciplineModel> DisciplineList { get; set; }
        public List<SampleTypeModel> SampleTypesList { get; set; }
        public List<ResultDataTypeModel> ResultDataTypes { get; set; }
        public List<UnitModel> UnitList { get; set; }

        public TestModel SelectedTest { get; set; }
        public int SelectedDataType
        {
            get => selectedDataType; set
            {
                selectedDataType = value;
                SelectedTest.ResultDataType = ResultDataTypes.Find((r) => r.Id == value)?.DataType;
                OnPropertyChanged();
            }
        }
        public int SelectedDiscipline
        {
            get => selectedDiscipline; set
            {
                selectedDiscipline = value;
                SelectedTest.Discipline = DisciplineList.Find((d) => d.Id == value)?.Discipline;
                OnPropertyChanged();
            }
        }
        public int SelectedSampleType
        {
            get => sampleType; set
            {
                sampleType = value;
                SelectedTest.SampleType = SampleTypesList.Find((s) => s.Id == value)?.Description;
                OnPropertyChanged();
            }
        }
        public int SelectedUnit
        {
            get => selectedUnit; set
            {
                selectedUnit = value;
                SelectedTest.Unit = UnitList.Find((u) => u.Id == value)?.Unit;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Public Methods
        public void DisplaySelectedTest(int selectedId)
        {
            var selectedRow = TestList.SingleOrDefault(c => c.Id == selectedId);
            var selectedRowTestDataType = ResultDataTypes.SingleOrDefault(r => r.DataType == selectedRow.ResultDataType);
            var selectedDiscipline = DisciplineList.Find(d => d.Discipline == selectedRow.Discipline);
            var selectedSampleType = SampleTypesList.Find(s => s.Description == selectedRow.SampleType);
            var selectedUnit = UnitList.Find(u => u.Unit == selectedRow.Unit);

            SelectedTest.Id = selectedRow.Id;
            if (selectedDiscipline != null)
            {
                SelectedDiscipline = selectedDiscipline.Id;
            }
            else { SelectedDiscipline = -1; }

            SelectedTest.Description = selectedRow.Description;

            if (selectedSampleType != null)
            {
                SelectedSampleType = selectedSampleType.Id;
            }
            else { SelectedSampleType = -1; }

            if (selectedSampleType != null)
            {
                SelectedSampleType = selectedSampleType.Id;
            }
            else { SelectedSampleType = -1; }

            if (selectedRowTestDataType != null)
            {
                SelectedDataType = selectedRowTestDataType.Id;
            }
            else { SelectedDataType = -1; }

            SelectedTest.Mask = selectedRow.Mask;
            if (selectedUnit != null) { SelectedUnit = selectedUnit.Id; }
            SelectedTest.Code = selectedRow.Code;
            SelectedTest.IsReportable = selectedRow.IsReportable;
            SelectedTest.DefaultCommented = selectedRow.DefaultCommented;
        }

        public void ProcessSaveTest(object sender, EventArgs e)
        {
            var TestDatabaseCopy = TestList.SingleOrDefault(t => t.Description == SelectedTest.Description);

            var a = SelectedDataType;

            //checking whether all fields are provided
            if (TestModel.HaveNulls(SelectedTest) && SelectedDataType != 0)
            {
                PushingMessages(this, "Please make sure that all the fields are complete.");
                return;
            }

            //save new test
            if (TestDatabaseCopy is null)
            {
                PushingLogs?.Invoke(this, $"Saving test {SelectedTest.Description}\n{JsonConvert.SerializeObject(SelectedTest)}");
                ProcessTestInsert();
                return;
            }

            //udpate test
            if (SelectedTest.Equals(TestDatabaseCopy))
            {
                PushingMessages?.Invoke(this, $"The test {SelectedTest.Description} is already present on system!");
                PushingLogs?.Invoke(this, $"Save reqested for the exact same copy as database. Abort save. \n {JsonConvert.SerializeObject(SelectedTest)}");

            }
            else
            {
                PushingMessages?.Invoke(this, $"Updated test {SelectedTest.Description}");
                //update... make sure that the selected tests Id is grater than 0 
                if (SelectedTest.Id < 1) { return; }
                ProcessTestUpdate();
            }


        }

        private void ProcessTestUpdate()
        {
            try
            {
                //build the insert model
                var updateModel = new TestUpdateModel()
                {
                    Id = SelectedTest.Id,
                    DisciplineId = SelectedDiscipline,
                    Description = SelectedTest.Description,
                    SampleTypeId = SelectedSampleType,
                    ResultDataTypeId = SelectedDataType,
                    Mask = SelectedTest.Mask,
                    UnitId = SelectedUnit,
                    Reportable = SelectedTest.IsReportable,
                    Code = SelectedTest.Code,
                    DefaultCommented = SelectedTest.DefaultCommented
                };

                OnInitiateTestUpdate?.Invoke(this, updateModel);

                //clear the test entry fields
                PrepareForNewTestEntry(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }

        }

        private void ProcessTestInsert()
        {
            try
            {
                //build the insert model
                var insertModel = new TestsInsertModel()
                {
                    DisciplineId = SelectedDiscipline,
                    Description = SelectedTest.Description,
                    SampleTypeId = SelectedSampleType,
                    ResultDataTypeId = SelectedDataType,
                    Mask = SelectedTest.Mask,
                    UnitId = SelectedUnit,
                    Reportable = SelectedTest.IsReportable,
                    Code = SelectedTest.Code,
                    DefaultCommented = SelectedTest.DefaultCommented
                };

                //raise event to save
                OnInitiateTestInsert?.Invoke(this, insertModel);
                //clear the test entry fields
                PrepareForNewTestEntry(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                PushingMessages?.Invoke(this, ex.Message);
                PushingLogs?.Invoke(this, $"{ex.Message}\n{ex.StackTrace}");
            }
        }

        /// <summary>
        /// Clears the data entry fields to allow the user to enter desired values for saving
        /// </summary>
        public void PrepareForNewTestEntry(object sender, EventArgs e)
        {
            //NOTE: for UI combo boxes, set the selected Id to -1 to make them select nothing/clear selected.

            SelectedTest.Id = -1;
            SelectedDiscipline = -1;
            SelectedTest.Description = "";
            SelectedSampleType = -1;
            SelectedDataType = -1;
            SelectedTest.Mask = "";
            SelectedUnit = -1;
            SelectedTest.Code = "";
            SelectedTest.IsReportable = false;
            SelectedTest.DefaultCommented = false;

        }
        #endregion

        #region Private Methods
        private void update(TestModel update)
        {
            PushingLogs?.Invoke(this, $"Updating test {SelectedTest.Description}");
            PushingLogs?.Invoke(this, $"Updated test {SelectedTest.Description}");
        }
        #endregion

    }
}
