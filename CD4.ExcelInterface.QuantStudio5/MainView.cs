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

            //gridViewLogsDisplay.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //gridViewLogsDisplay.TopRowChanged += gridViewLogsDisplay_TopRowChanged;
            //simpleButtonInterpretData.Click += SimpleButtonInterpretData_Click;
            //simpleButtonExportToCD4.Click += SimpleButtonExportToCD4_Click;
        }

        private void InitializeDataBinding()
        {
        }
    }

}