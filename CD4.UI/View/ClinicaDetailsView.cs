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
    public partial class ClinicaDetailsView : XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly IClinicalDetailsViewModel _viewModel;

        public ClinicaDetailsView(IClinicalDetailsViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            gridViewClinicalDetails.FocusedRowChanged += GridViewClinicalDetails_FocusedRowChanged;
            simpleButtonSave.Click += _viewModel.SaveCountry;
            _viewModel.PushingMessages += _viewModel_PushingMessages;


        }


        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }


        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

             gridControlScientist.DataSource = _viewModel.ClinicalDetailsList;
            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditClinicalDetail.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.ClinicalDetail)));

        }

        private void GridViewClinicalDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewClinicalDetails)} row clicked.");
            var SelectedId = (int)gridViewClinicalDetails.GetRowCellValue(e.FocusedRowHandle, "Id");
            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedClinicalDetailsData(SelectedId);

        }

    }
}