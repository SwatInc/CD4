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
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class SitesView : XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private readonly ISitesViewModel _viewModel;

        public SitesView(ISitesViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            InitializeBinding();

            _viewModel.PushingMessages += _viewModel_PushingMessages;
            simpleButtonSave.Click += _viewModel.SaveSite;
            gridViewSites.FocusedRowChanged += GridViewSites_FocusedRowChanged;

        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

            gridControlCodifiedValues.DataSource = _viewModel.SiteList;

            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditSite.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Site)));
        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        private void GridViewSites_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewSites)} row clicked.");
            var SelectedId = (int)gridViewSites.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedSiteData(SelectedId);

        }



    }
}