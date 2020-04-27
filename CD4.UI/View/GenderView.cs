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
using DevExpress.XtraGrid.Views.Base;

namespace CD4.UI.View
{
    public partial class GenderView : XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly IGenderViewModel _viewModel;

        public GenderView(IGenderViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            this.gridViewCountries.FocusedRowChanged += this.gridViewCountries_FocusedRowChanged;
            _viewModel.PushingMessages += _viewModel_PushingMessages;
            simpleButtonSave.Click += _viewModel.SaveGender;

        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

            gridControlCodifiedValues.DataSource = _viewModel.GenderList;

            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditGender.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Gender)));
        }

        private void gridViewCountries_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewCountries)} row clicked.");
            var SelectedId = (int)gridViewCountries.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedData(SelectedId);
        }
    }
}