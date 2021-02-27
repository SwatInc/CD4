using CD4.ExcelInterface.QuantStudio5.ViewModels;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.ExcelInterface.QuantStudio5
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

            gridViewLogs.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            gridViewLogs.TopRowChanged += gridViewLogsDisplay_TopRowChanged;
            barButtonItemExportToLIS.ItemClick += SimpleButtonExportToCD4_Click;
        }

        private async void SimpleButtonExportToCD4_Click(object sender, EventArgs e)
        {
            if (await _viewModel.ExportToUploader())
            {
                _viewModel.InterfaceResults.Clear();
                _viewModel.Logs.Add(new LogModel() { Log = "Successfully exported to LIS and Cleared Queue to be exported to LIS.." });
            }
        }

        private void CheckScript()
        {
            try
            {
                int check = script.CheckScript();
                if (check == 1) { _viewModel.Logs.Add(new LogModel() { Log = "Script load successful!" }); }
            }
            catch (Exception ex)
            {
                _viewModel.Logs.Add(new LogModel() { Log = ex.Message });
                _viewModel.Logs.Add(new LogModel() { Log = "Failed to load script. Result interpretation not active." });

            }

        }

        private void gridViewLogsDisplay_TopRowChanged(object sender, EventArgs e)
        {
            gridViewLogs.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void InitializeDataBinding()
        {
            gridControlQueue.DataSource = _viewModel.InterfaceResults;
            gridControlLogs.DataSource = _viewModel.Logs;
            DataBindings.Add(new Binding("Text", _viewModel.Configuration, nameof(_viewModel.Configuration.MainFormTitle)));

        }
    }

}