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
    public partial class ScientistsView : XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly IScientistViewModel _viewModel;

        public ScientistsView(IScientistViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            _viewModel.PushingMessages += _viewModel_PushingMessages;
            this.gridViewScientists.FocusedRowChanged += GridViewScientists_FocusedRowChanged;
            simpleButtonSave.Click += _viewModel.SaveScientist;
        }



        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }


        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

            gridControlCodifiedValues.DataSource = _viewModel.ScientistList;

            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditScientist.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Scientist)));
        }

        private void GridViewScientists_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewScientists)} row clicked.");
            var SelectedId = (int)gridViewScientists.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedData(SelectedId);

        }

    }
}