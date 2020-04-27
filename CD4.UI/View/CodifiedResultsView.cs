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
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class CodifiedResultsView : XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private ICodifiedResultsViewModel _viewModel { get; }

        public CodifiedResultsView(ICodifiedResultsViewModel viewModel)
        {
            InitializeComponent();
            
            _viewModel = viewModel;
            InitializeBinding();

            //Listen for events
            gridViewCodifiedResults.FocusedRowChanged += GridViewCodifiedResults_FocusedRowChanged;
            simpleButtonSave.Click += _viewModel.SavePhrase;
            _viewModel.PushingMessages += _viewModel_PushingMessages;

        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

            gridControlCodifiedValues.DataSource = _viewModel.CodifiedValuesList;

            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditCodfiedValue.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.CodifiedValue)));

        }

        private void GridViewCodifiedResults_FocusedRowChanged
            (object sender, FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewCodifiedResults)} row clicked.");
            var SelectedId = (int)gridViewCodifiedResults.GetRowCellValue(e.FocusedRowHandle, "Id");
            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedCodifiedData(SelectedId);
        }
    }
}