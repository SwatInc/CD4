using CD4.UI.Helpers;
using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class BulkOrdersImportView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IBulkOrdersImportViewModel _viewModel;
        private readonly IBarcodeHelper _barcodeHelper;

        public BulkOrdersImportView(IBulkOrdersImportViewModel viewModel, IBarcodeHelper barcodeHelper)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _barcodeHelper = barcodeHelper;
            InitializeBinding();

            lookUpEditTests.Validated += LookUpEditTests_Validated;
            simpleButtonBrowse.Click += PromptForFile;
            simpleButtonViewErrors.Click += SimpleButtonViewErrors_Click;
            simpleButtonHideErrors.Click += SimpleButtonHideErrors_Click;
            simpleButtonConfirmUpload.Click += OnConfirmUpload;
            simpleButtonCollectSelected.Click += OnClick_CollectSelectedSamples;
            gridControlImportErrors.DataSourceChanged += GridControlImportErrors_DataSourceChanged;
            gridViewExcelData.SelectionChanged += GridViewExcelData_SelectionChanged;
            KeyUp += BulkOrdersImportView_KeyUp;
        }

        private async void OnClick_CollectSelectedSamples(object sender, EventArgs e)
        {
            var selectedRowIndexes = gridViewExcelData.GetSelectedRows();
            var selectedCins = new List<string>();
            foreach (var index in selectedRowIndexes)
            {
                selectedCins.Add(((BulkSchemaModel)(gridViewExcelData.GetRow(index))).Cin);
            }
            var collectedCins = await _viewModel.MarkMultipleSamplesCollected(selectedCins);
            XtraMessageBox.Show($"The following sample numbers are marked collected. \n{JsonConvert.SerializeObject(collectedCins)}");

            //print the collected cins
            await PrintBarcodesAsync(collectedCins);

        }

        private void GridViewExcelData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var selectedRowIndexes = gridViewExcelData.GetSelectedRows();
            var selectedRows = new List<BulkSchemaModel>();
            foreach (var index in selectedRowIndexes)
            {
                selectedRows.Add((BulkSchemaModel)(gridViewExcelData.GetRow(index)));
            }

            _viewModel.CanCollectSelectedSamples(selectedRows);
        }

        private void OnConfirmUpload(object sender, EventArgs e)
        {
            var selectedData = new List<BulkSchemaModel>();
            var selectedRowHandles = gridViewExcelData.GetSelectedRows();
            foreach (var handle in selectedRowHandles)
            {
                selectedData.Add((BulkSchemaModel)gridViewExcelData.GetRow(handle));
            }
            _viewModel.ConformUploadSelected(selectedData);
        }

        private void GridControlImportErrors_DataSourceChanged(object sender, EventArgs e)
        {
            _viewModel.ErrorsPanelVisible = !(gridControlImportErrors.DataSource is null);
        }

        private void SimpleButtonHideErrors_Click(object sender, EventArgs e)
        {
            gridControlImportErrors.DataSource = null;
        }

        private void SimpleButtonViewErrors_Click(object sender, EventArgs e)
        {
            gridControlImportErrors.DataSource = _viewModel.ErrorMessages;
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

            //
            groupControlErrorsPanel.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.ErrorsPanelVisible)));
            splitContainerControlMain.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.MainPanelVisible)));

            //progress panels
            progressPanelImportArea.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));
            progressPanelExcelData.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));
            progressPanelSelectedTests.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));

            //button view errors
            simpleButtonViewErrors.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.ButtonErrorsCountlabel)));
            simpleButtonViewErrors.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.ButtonErrorsCountEnabled)));

            //button collect samples
            simpleButtonCollectSelected.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.CanCollectSamples)));
        }

        private void PromptForFile(object sender, EventArgs e)
        {
            //confirm action if a sheet is already loaded
            if (_viewModel.ExcelFilePath?.Length > 3 && _viewModel.BulkDataList?.Count> 0)
            {
                if(XtraMessageBox.Show("An excel sheet is already loaded. Do you want to load a new data set?","Confirmation",MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

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

        private async void LookUpEditTests_Validated(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.ManageAddTestToRequestAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task<bool> PrintBarcodesAsync(List<string> cins)
        {
            List<BarcodeDataModel> barcodeData;
            try
            {
                barcodeData = await _viewModel.GetBarcodeData(cins);
                return _barcodeHelper.PrintMultipleSampleBarcode(barcodeData);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}