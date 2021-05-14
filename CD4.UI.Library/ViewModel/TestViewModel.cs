using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class TestViewModel : INotifyPropertyChanged, ITestViewModel
    {
        #region Private Properties

        private int selectedDataType;
        private int selectedDiscipline;
        private int sampleType;
        private int selectedUnit;

        #endregion

        #region Events
        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;
        #endregion


        public TestViewModel()
        {
            this.TestList = new BindingList<TestModel>();
            DisciplineList = new List<DisciplineModel>();
            SampleTypesList = new List<SampleTypeModel>();
            UnitList = new List<UnitModel>();
            this.SelectedTest = new TestModel();
            this.ResultDataTypes = new List<ResultDataTypeModel>();
            //this.SelectedDataType = new ResultDataTypeModel();
            InitializeDemoData();
            this.PropertyChanged += TestViewModel_PropertyChanged;
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
            SampleTypesList.Add(new SampleTypeModel() { Id = 2, Description = "SWAB" });

            UnitList.Add(new UnitModel() { Id = 1, Unit = " " });
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
                if (selectedDataType == value) return;
                selectedDataType = value;
                OnPropertyChanged();
            }
        }
        public int SelectedDiscipline
        {
            get => selectedDiscipline; set
            {
                selectedDiscipline = value;
                OnPropertyChanged();
            }
        }
        public int SelectedSampleType
        {
            get => sampleType; set
            {
                sampleType = value;
                OnPropertyChanged();
            }
        }
        public int SelectedUnit
        {
            get => selectedUnit; set
            {
                selectedUnit = value;
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
            SelectedDiscipline = selectedDiscipline.Id;
            SelectedTest.Description = selectedRow.Description;
            SelectedSampleType = selectedSampleType.Id;
            SelectedDataType = selectedRowTestDataType.Id;
            SelectedTest.Mask = selectedRow.Mask;
            SelectedUnit = selectedUnit.Id;
            SelectedTest.Code = selectedRow.Code;
            SelectedTest.IsReportable = selectedRow.IsReportable;
            SelectedTest.DefaultCommented = selectedRow.DefaultCommented;
        }

        public void SaveTest(object sender, EventArgs e)
        {
            var TestDatabaseCopy = TestList.SingleOrDefault(t => t.Description == SelectedTest.Description);
            var selectedRowTestDataType = ResultDataTypes.SingleOrDefault(r => r.DataType == TestDatabaseCopy.ResultDataType);

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

                PushingMessages(this, $"Saved test {SelectedTest.Description}");
                return;
            }

            //udpate test
            if (SelectedTest.Equals(TestDatabaseCopy) & selectedDataType == selectedRowTestDataType.Id)
            {
                PushingMessages?.Invoke(this, $"The test {SelectedTest.Description} is already present on system!");
                PushingLogs?.Invoke(this, $"Save reqested for the exact same copy as database. Abort save. \n {JsonConvert.SerializeObject(SelectedTest)}");

            }
            else
            {
                PushingMessages?.Invoke(this, $"Updated test {SelectedTest.Description}");
                //update

            }


        }
        public void NewTest(object sender, EventArgs e)
        {

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
