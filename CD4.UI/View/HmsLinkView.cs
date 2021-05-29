using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class HmsLinkView : XtraForm
    {
        private readonly IHmsLinkViewModel _viewModel;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        public HmsLinkView(IHmsLinkViewModel hmsLinkViewModel, AuthorizeDetailEventArgs authorizeDetail)
        {
            InitializeComponent();
            _viewModel = hmsLinkViewModel;
            _authorizeDetail = authorizeDetail;
            InitializeBinding();

            repositoryItemTextEditMemoNumber.KeyDown += CheckForMemoNumber;
            barToggleSwitchItemRequestPriority.CheckedChanged += RequestPriorityChanged;
            barButtonItemImport.ItemClick += ConfirmAnalysisRequest;

            //initialize request priority
            RequestPriorityChanged(this, EventArgs.Empty);
        }

        private async void ConfirmAnalysisRequest(object sender, ItemClickEventArgs e)
        {
            try
            {
                var selectedAnalyses = new List<HmsLinkDataModel>();
                var selectedRowHandles = gridViewRequestedAnalyses.GetSelectedRows();
                foreach (var handle in selectedRowHandles)
                {
                   selectedAnalyses.Add((HmsLinkDataModel)gridViewRequestedAnalyses.GetRow(handle));
                }
                if (selectedAnalyses.Count == 0) { XtraMessageBox.Show("Please select the tests import"); return; }
                await _viewModel.ConfirmAnalysisRequest(selectedAnalyses, _authorizeDetail.UserId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while trying to save Analysis Request\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private void RequestPriorityChanged(object sender, EventArgs e)
        {
            _viewModel.IsRequestPriority = barToggleSwitchItemRequestPriority.Checked;
            if (barToggleSwitchItemRequestPriority.Checked)
            {
                barToggleSwitchItemRequestPriority.Caption = "Stat Request";
                return;
            }
            barToggleSwitchItemRequestPriority.Caption = "Routine Request";
        }

        private async void CheckForMemoNumber(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Enter)
            {

                var item = sender as TextEdit;
                var memoNumber = item.EditValue.ToString();

                _viewModel.ResetUi();
                if (string.IsNullOrEmpty(memoNumber)) { return; }

                var isInt = int.TryParse(memoNumber, out var intMemoNumber);
                if (!isInt) { XtraMessageBox.Show("Invalid memo number. Please verify that the memo number is an integer."); return; }

                await _viewModel.FetchAnalysisRequestForMemoNumberAsync(intMemoNumber);

                //change priority to routine
                barToggleSwitchItemRequestPriority.Checked = false;
            }
        }

        private void InitializeBinding()
        {
            gridControlPatientDetails.DataSource = _viewModel.Patient;
            gridControlRequestedAnalyses.DataSource = _viewModel.AnalysisRequests;

            progressPanel.DataBindings
                .Add(new Binding("Visible", _viewModel, nameof(_viewModel.LoadingStaticDataStatus)));
        }

    }
}