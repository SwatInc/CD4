using CD4.UI.Library.Model;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class TestViewModel : INotifyPropertyChanged, ITestViewModel
    {
        public event EventHandler<string> PushingLogs;
        public event EventHandler<string> PushingMessages;

        public TestViewModel()
        {
            this.TestList = new BindingList<TestModel>();
            this.SelectedTest = new TestModel();
            InitializeDemoData();
        }

        private void InitializeDemoData()
        {
            var egene = new TestModel() { Id = 1, Description = "E Gene", ResultDataType = "Numeric", Mask = "###.00", IsReportable = true };
            var rdrpgene = new TestModel() { Id = 1, Description = "RdRP Gene", ResultDataType = "Numeric", Mask = "###.00", IsReportable = true };

            this.TestList.Add(egene);
            this.TestList.Add(rdrpgene);
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

        public void DisplaySelectedTest(int selectedId)
        {
            var selectedRow = this.TestList.SingleOrDefault(c => c.Id == selectedId);
            SelectedTest.Id = selectedRow.Id;
            SelectedTest.Description = selectedRow.Description;
            SelectedTest.ResultDataType = selectedRow.ResultDataType;
            SelectedTest.Mask = selectedRow.Mask;
            SelectedTest.IsReportable = selectedRow.IsReportable;
        }

        public void SaveTest(object sender, EventArgs e)
        {
            var TestDatabaseCopy = TestList.SingleOrDefault(t => t.Description == SelectedTest.Description);

            if (TestModel.HaveNulls(SelectedTest))
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

        private void update(TestModel update)
        {
            PushingLogs?.Invoke(this, $"Updating test {SelectedTest.Description}");
            PushingLogs?.Invoke(this, $"Updated test {SelectedTest.Description}");
        }
    }
}
