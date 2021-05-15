using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface ITestViewModel
    {
        TestModel SelectedTest { get; set; }
        BindingList<TestModel> TestList { get; set; }
        List<ResultDataTypeModel> ResultDataTypes { get; set; }
        int SelectedDataType { get; set; }
        List<DisciplineModel> DisciplineList { get; set; }
        List<SampleTypeModel> SampleTypesList { get; set; }
        int SelectedDiscipline { get; set; }
        int SelectedSampleType { get; set; }
        int SelectedUnit { get; set; }
        List<UnitModel> UnitList { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler<string> PushingLogs;
        event EventHandler<string> PushingMessages;

        void DisplaySelectedTest(int selectedId);
        void PrepareForNewTestEntry(object sender, EventArgs e);
        void SaveTest(object sender, EventArgs e);
    }
}