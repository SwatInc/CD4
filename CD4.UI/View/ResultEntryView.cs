using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraGrid.Views.Base;
using CD4.UI.Library.Model;
using System.Diagnostics;

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        private readonly IResultEntryViewModel _viewModel;
        System.Windows.Forms.Timer dataRefreshTimer = new System.Windows.Forms.Timer() { Enabled = true, Interval = 1000};

        public event EventHandler<string> GenerateReportByCin;

        public ResultEntryView(IResultEntryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            SizeChanged += OnSizeChangedAdjustSplitContainers;
            labelControlCin.DoubleClick += CopyCinToClipBoard;
            gridViewSamples.FocusedRowChanged += SelectedSampleChanged;
            gridViewTests.FocusedRowChanged += SelectedTestChanged;
            dataRefreshTimer.Tick += RefreshViewData;
            simpleButtonReport.Click += SimpleButtonReport_Click;
            simpleButtonLoadWorksheet.Click += LoadWorkSheet;
            _viewModel.RequestDataRefreshed += RefreshViewData;
            lookUpEditSampleStatusFilter.EditValueChanged += LookUpEditSampleStatusFilter_EditValueChanged;
        }

        /// <summary>
        /// Sets the selected status to viewmodel variable
        /// </summary>
        private void LookUpEditSampleStatusFilter_EditValueChanged(object sender, EventArgs e)
        {
            //gets the selected datarow from lookupedit and set it to viewModel variable
            _viewModel.SelectedStatus = (StatusModel)(lookUpEditSampleStatusFilter.GetSelectedDataRow());
        }

        private async void LoadWorkSheet(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.GetWorkSheet();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SimpleButtonReport_Click(object sender, EventArgs e)
        {
            //Get the Cin of the selected record.
            var cin = GetSelectedCin();
            //Ask to select a record, if no record is selected.
            if (cin is null)
            {
                XtraMessageBox.Show("Please select a sample to view the report!");
            }

            //Raise an event indicating that a sample report is requested.
            GenerateReportByCin?.Invoke(this, cin);
        }

        /// <summary>
        /// The datagrids does not show view model data without refresh. This method refreshes the view. The is NOT a refresh from database.
        /// </summary>
        private void RefreshViewData(object sender, EventArgs e)
        {
            dataRefreshTimer.Enabled = false;
            gridControlSamples.RefreshDataSource();
            gridControlTests.RefreshDataSource();
        }

        private void CopyCinToClipBoard(object sender, EventArgs e)
        {
            Clipboard.SetText(labelControlCin.Text);
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

        /// <summary>
        /// Gets the selected Cin
        /// </summary>
        /// <returns>Returns selected Cin or null</returns>
        private string GetSelectedCin()
        {
            //Get row handles of selected rows
            var selectedRowHandles = gridViewSamples.GetSelectedRows();
            //return null if no rows selected
            if (selectedRowHandles.Length==0)
            {
                return null;
            }
            //Get the row at handle 0
            var selectedRow = (RequestSampleModel)gridViewSamples.GetRow(selectedRowHandles[0]);
            //return Cin
            return selectedRow.Cin;
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

            #region FiltersAndFunctions

            dateEditLoadWorksheetFrom.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.LoadWorksheetFromDate)));

            //Wire up the datasource for lookUpEditSampleStatusFilter
            lookUpEditSampleStatusFilter.Properties.DataSource = _viewModel.AllStatus;
            lookUpEditSampleStatusFilter.Properties.DisplayMember = nameof(StatusModel.Status);
            lookUpEditSampleStatusFilter.Properties.ValueMember = nameof(StatusModel.Id);
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