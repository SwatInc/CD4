using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;

namespace CD4.UI.View
{
    public partial class TestsView : XtraForm
    {
        private readonly ITestViewModel _viewModel;
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        public TestsView(ITestViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            _viewModel.PushingMessages += _viewModel_PushingMessages;
            simpleButtonSave.Click += _viewModel.SaveTest;
            this.gridViewTests.FocusedRowChanged += GridViewTests_FocusedRowChanged;
        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");
            gridControlCodifiedValues.DataSource = _viewModel.TestList;

            //ID
            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Id)));
            this.textEditDescription.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Description)));
            this.lookUpEditTestDataType.Properties.DataSource = _viewModel.ResultDataTypes;
            this.textEditResultMask.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Mask)));
            this.checkEditIsReportable.DataBindings.Add(new Binding("Checked", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.IsReportable)));

        }

        private void GridViewTests_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if row handle is -1, no row is focused.
            if (e.FocusedRowHandle == -1) return;

            _log.Info($"{nameof(gridViewTests)} row clicked.");
            var SelectedId = (int)gridViewTests.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedTest(SelectedId);

        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }
    }
}