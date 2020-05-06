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
using DevExpress.XtraBars;

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        private readonly IResultEntryViewModel _viewModel;

        public ResultEntryView(IResultEntryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            SizeChanged += OnSizeChangedAdjustSplitContainers;
            gridViewSamples.FocusedRowChanged += SelectedSampleChanged;
            gridViewTests.FocusedRowChanged += SelectedTestChanged;
        }

        private async void SelectedTestChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var selectedTest = (ResultModel)gridViewTests.GetRow(e.FocusedRowHandle);
            await _viewModel.SetTestCodifiedPhrasesAsync(selectedTest);
        }

        private async void SelectedSampleChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var selectedSample = (RequestSampleModel)gridViewSamples.GetRow(e.FocusedRowHandle);
            await _viewModel.SetSelectedSampleAsync(selectedSample);
        }

        private void InitializeBinding()
        {
            #region Samples
            gridControlSamples.DataSource = _viewModel.RequestData;
            #endregion

            #region Tests / Result data
            gridControlTests.DataSource = _viewModel.SelectedResultData;
            #endregion

            #region Selected Samples data

            labelControlPatientName.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.PatientName),
                true,DataSourceUpdateMode.OnPropertyChanged));

            labelControlNationalId.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.NationalId)));

            labelControlAgeSex.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.AgeSex)));

            labelControlBirthdate.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Birthdate)));

            labelControlPhoneNumber.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.PhoneNumber)));

            labelControlAtollIslandCountry.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.AtollIslandCountry)));

            labelControlCin.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Cin)));

            labelControlEpisodeNumber.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.EpisodeNumber)));

            labelControlSite.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Site)));

            labelControlAddress.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Address)));

            //Clinical Details
            listBoxControlClinicalDetails.DataSource = _viewModel.SelectedClinicalDetails;
            #endregion

            #region Bind Results
            gridControlTests.DataSource = _viewModel.SelectedResultData;
            repositoryItemLookUpEditCodifiedPhrases.DataSource = _viewModel.CodifiedPhrasesForSelectedTest;
            repositoryItemLookUpEditCodifiedPhrases.DisplayMember = nameof(CodifiedResultsModel.CodifiedValue);
            repositoryItemLookUpEditCodifiedPhrases.ValueMember = nameof(CodifiedResultsModel.CodifiedValue);
            #endregion
        }

        private void OnSizeChangedAdjustSplitContainers(object sender, EventArgs e)
        {
            //set splitter for adjusting Top (patient) panel
            splitContainerControlPatient.SplitterPosition = 90;

            //set splitter for adjusting functions panel
            var height = this.splitContainerControlFunctions.Size.Height;
            splitContainerControlFunctions.SplitterPosition = (int)((decimal)height - 90m);
        }

    }
}