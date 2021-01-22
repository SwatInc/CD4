﻿using CD4.UI.Library.Model;
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
            simpleButtonViewErrors.Click += SimpleButtonViewErrors_Click;
            KeyUp += BulkOrdersImportView_KeyUp;
        }

        private void SimpleButtonViewErrors_Click(object sender, EventArgs e)
        {

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

            //progress panels
            progressPanelImportArea.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));
            progressPanelExcelData.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));
            progressPanelSelectedTests.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingAnimationVisible)));

            //button view errors
            simpleButtonViewErrors.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.ButtonErrorsCountlabel)));
            simpleButtonViewErrors.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.ButtonErrorsCountEnabled)));
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
    }
}