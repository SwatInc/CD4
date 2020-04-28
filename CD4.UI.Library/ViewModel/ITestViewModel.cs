using CD4.UI.Library.Model;
using System;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ITestViewModel
    {
        TestModel SelectedTest { get; set; }
        BindingList<TestModel> TestList { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedTest(int selectedId);
        void SaveTest(object sender, EventArgs e);
    }
}