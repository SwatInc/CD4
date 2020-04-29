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
        private int selectedDataType;

        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;

        public TestViewModel()
        {
            this.TestList = new BindingList<TestModel>();
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
            var egene = new TestModel() { Id = 1, Description = "E Gene", ResultDataType = "Numeric", Mask = "###.00", IsReportable = true };
            var rdrpgene = new TestModel() { Id = 2, Description = "RdRP Gene", ResultDataType = "Numeric", Mask = "###.00", IsReportable = false };

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

        public BindingList<TestModel> TestList { get; set; }
        public TestModel SelectedTest { get; set; }
        public List<ResultDataTypeModel> ResultDataTypes { get; set; }
        public int SelectedDataType
        {
            get => selectedDataType; set
            {
                if (selectedDataType == value) return;
                selectedDataType = value;
                OnPropertyChanged();
            }
        }


        public void DisplaySelectedTest(int selectedId)
        {
            var selectedRow = this.TestList.SingleOrDefault(c => c.Id == selectedId);
            var selectedRowTestDataType = ResultDataTypes.SingleOrDefault(r => r.DataType == selectedRow.ResultDataType);

            SelectedTest.Id = selectedRow.Id;
            SelectedTest.Description = selectedRow.Description;
           this.SelectedDataType = selectedRowTestDataType.Id;
            SelectedTest.Mask = selectedRow.Mask;
            SelectedTest.IsReportable = selectedRow.IsReportable;

        }

        public void SaveTest(object sender, EventArgs e)
        {
            var TestDatabaseCopy = TestList.SingleOrDefault(t => t.Description == SelectedTest.Description);
            var selectedRowTestDataType = ResultDataTypes.SingleOrDefault(r => r.DataType == TestDatabaseCopy.ResultDataType);


            if (TestModel.HaveNulls(SelectedTest) && SelectedDataType != 0)
            {
                PushingMessages(this, "Please make sure that all the fields are complete.");
                return;
            }

            if (TestDatabaseCopy is null)
            {
                PushingLogs?.Invoke(this, $"Saving test {SelectedTest.Description}\n{JsonConvert.SerializeObject(SelectedTest)}");

                PushingMessages(this, $"Saved test {SelectedTest.Description}");
                return;
            }

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

        private void update(TestModel update)
        {
            PushingLogs?.Invoke(this, $"Updating test {SelectedTest.Description}");
            PushingLogs?.Invoke(this, $"Updated test {SelectedTest.Description}");
        }
    }
}
