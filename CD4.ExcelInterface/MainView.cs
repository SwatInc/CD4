using CD4.ExcelInterface.ViewModels;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CD4.ExcelInterface
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        private MainViewModel _viewModel;
        dynamic script;
        [Obsolete]
        public MainView()
        {
            InitializeComponent();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            _viewModel = new MainViewModel();
            InitializeDataBinding();
          
            gridViewLogsDisplay.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridViewLogsDisplay.TopRowChanged += gridViewLogsDisplay_TopRowChanged;
            simpleButtonInterpretData.Click += SimpleButtonInterpretData_Click;
            simpleButtonExportToCD4.Click += SimpleButtonExportToCD4_Click;
        }

        private async void SimpleButtonExportToCD4_Click(object sender, EventArgs e)
        {
            if (await _viewModel.ExportToUploader()) 
            {
                _viewModel.InterfaceResults.Clear();
                _viewModel.Logs.Add(new LogModel() { Log = "Successfully exported to LIS and Cleared Queue to be exported to LIS.." });
            }
        }

        private void SimpleButtonInterpretData_Click(object sender, EventArgs e)
        {
            //get the selected test kit
            var selectedTestkit = lookUpEditSelectTestKit.EditValue;

            if (selectedTestkit is null)
            {
                _viewModel.Logs.Add(new LogModel() { Log = "Please select a test kit and proceed to interpret data!" });
                return;
            }


            try
            {
                var selectedTestKitId = (int)(selectedTestkit);
                _viewModel.InterpretData(selectedTestKitId);
                _viewModel.Logs.Add(new LogModel() { Log = "Interpretation completed." });

            }
            catch (Exception ex)
            {
                _viewModel.Logs.Add(new LogModel() { Log = ex.Message });
            }
        }

        private void CheckScript()
        {
            try
            {
                int check = script.CheckScript();
                if(check == 1) { _viewModel.Logs.Add(new LogModel() { Log = "Script load successful!" }); }
            }
            catch (Exception ex)
            {
                _viewModel.Logs.Add(new LogModel() { Log = ex.Message});
                _viewModel.Logs.Add(new LogModel() { Log = "Failed to load script. Result interpretation not active." });

            }

        }

        private void gridViewLogsDisplay_TopRowChanged(object sender, EventArgs e)
        {
            gridViewLogsDisplay.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void InitializeDataBinding()
        {
            gridControlQueue.DataSource = _viewModel.InterfaceResults;
            gridControlLogsDisplay.DataSource = _viewModel.Logs;
            DataBindings.Add(new Binding("Text", _viewModel.Configuration, nameof(_viewModel.Configuration.MainFormTitle)));

            lookUpEditSelectTestKit.Properties.DataSource = _viewModel.KitNames;
            //lookUpEditSelectTestKit.Properties.DisplayMember = "Kit";
            //lookUpEditSelectTestKit.Properties.ValueMember = "Id";
        }

    }
}
