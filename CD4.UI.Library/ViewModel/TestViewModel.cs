﻿using CD4.UI.Library.Model;
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
            SelectedDiscipline = selectedDiscipline.Id;
            SelectedTest.Description = selectedRow.Description;
            SelectedSampleType = selectedSampleType.Id;
            SelectedDataType = selectedRowTestDataType.Id;
            SelectedTest.Mask = selectedRow.Mask;
            if (selectedUnit != null) { SelectedUnit = selectedUnit.Id; }
            SelectedTest.Code = selectedRow.Code;
            SelectedTest.IsReportable = selectedRow.IsReportable;
            SelectedTest.DefaultCommented = selectedRow.DefaultCommented;
        }

        public void SaveTest(object sender, EventArgs e)
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

                PushingMessages(this, $"Saved test {SelectedTest.Description}");
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
                //update

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
