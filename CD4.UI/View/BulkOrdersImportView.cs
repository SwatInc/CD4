using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class BulkOrdersImportView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IBulkOrdersImportViewModel _viewModel;

        public BulkOrdersImportView(IBulkOrdersImportViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            simpleButtonBrowse.Click += PromptForFile;
            KeyUp += BulkOrdersImportView_KeyUp;
        }

        private void BulkOrdersImportView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:
                    if (e.Modifiers == Keys.Control)
                    {
                        PromptForFile(this, EventArgs.Empty);
                    }
                    break;
                default:
                    break;
            }
        }

        private void InitializeBinding()
        {
            //receipt number
            textEditReceiptNumber.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.ReceiptNumber),
                false,DataSourceUpdateMode.OnPropertyChanged));
            //site
            lookUpEditSite.Properties.DataSource = _viewModel.Sites;
            lookUpEditSite.Properties.DisplayMember = nameof(SitesModel.Site);
            lookUpEditSite.Properties.ValueMember = nameof(SitesModel.Id);
            lookUpEditSite.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedSiteId)));

            //Atolls and Selected Atoll
            lookUpEditAtoll.Properties.DataSource = _viewModel.Atolls;
            lookUpEditAtoll.Properties.DisplayMember = nameof(AtollModel.Atoll);
            lookUpEditAtoll.Properties.ValueMember = nameof(AtollModel.Atoll);
            lookUpEditAtoll.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedAtoll), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Islands and Selected Island
            lookUpEditIsland.Properties.DataSource = _viewModel.Islands;
            lookUpEditIsland.Properties.DisplayMember = nameof(IslandModel.Island);
            lookUpEditIsland.Properties.ValueMember = nameof(IslandModel.Island);
            lookUpEditIsland.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedIsland)));

            //Tests and profiles lookupEdit datasource
            lookUpEditTests.Properties.DataSource = _viewModel.AllTestsData;
            lookUpEditTests.Properties.ValueMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);
            lookUpEditTests.Properties.DisplayMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);

            //Tests and profiles lookupEdit Editvalue
            lookUpEditTests.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.TestToAdd)));

            //Selected Tests DataGrid
            gridControlRequestedTests.DataSource = _viewModel.AddedTests;

            //grid control excel data
            gridControlExcelData.DataSource = _viewModel.BulkDataList;
        }

        private void PromptForFile(object sender, EventArgs e)
        {
            if (xtraOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _viewModel.ExcelFilePath = xtraOpenFileDialog.FileName;
                    labelImportFilePathDisplay.Text = $"{labelImportFilePathDisplay.Tag}{_viewModel.ExcelFilePath}";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error reading file path.\n{ex.Message}");
                }
            }
        }
    }
}