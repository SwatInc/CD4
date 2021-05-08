using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Helpers;
using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using CD4.UI.Report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class OrderEntryView : XtraForm
    {
        private readonly IOrderEntryViewModel _viewModel;
        private readonly IMapper _mapper;
        private readonly IPatientDataAccess _dataAccess;
        private readonly IUserAuthEvaluator _authEvaluator;
        private readonly ILabNotesViewModel _labNotesViewModel;
        private readonly IBarcodeHelper _barcodeHelper;

        public OrderEntryView(IOrderEntryViewModel viewModel,
            IMapper mapper,
            IPatientDataAccess dataAccess,
            IUserAuthEvaluator authEvaluator,
            ILabNotesViewModel labNotesViewModel,
            IBarcodeHelper barcodeHelper)
        {
            InitializeComponent();
            //Evaluate user authorisation
            _viewModel = viewModel;
            _mapper = mapper;
            _dataAccess = dataAccess;
            _authEvaluator = authEvaluator;
            _labNotesViewModel = labNotesViewModel;
            _barcodeHelper = barcodeHelper;
            InitializeDataBinding();

            lookUpEditTests.Validated += LookUpEditTests_Validated;
            simpleButtonRemoveTest.Click += RemoveTestFromAR;
            simpleButtonSearch.Click += OnPatientSearch;
            KeyUp += ManageKeyUpEvents;
            _viewModel.PushingMessages += OnPushMessage;
            _viewModel.PropertyChanged += OnPropertyChanged;
            simpleButtonConfirm.Click += OnConfirmAnalysisRequest;
            simpleButtonSearchRequest.Click += OnSearchRequest;
            simpleButtonPrintBarcode.Click += SimpleButtonPrintBarcode_Click;
            simpleButtonGetNextCin.Click += GenerateNextSampleNumber;
            simpleButtonViewNotes.Click += OpenViewNotesDialog;
            textEditNidPp.LostFocus += InitiatePatientSearchOnNidPp_LostFocus;
        }

        private void OpenViewNotesDialog(object sender, EventArgs e)
        {
            var notesView = new LabNotesView(_labNotesViewModel);
            notesView.SetSampleNumber(_viewModel.Cin);
            notesView.ShowDialog();
            //_viewModel.GetNotesCountAsync(cin);  this is the actual way..., but I am gonna cheat here. No need for a database call
           // _viewModel.SetNotesCountManually(notesView.DialogResult.ToString());

        }

        private void InitiatePatientSearchOnNidPp_LostFocus(object sender, EventArgs e)
        {
            var tempNidPp = _viewModel.NidPp;
            if (string.IsNullOrEmpty(tempNidPp)) return;
            OnPatientSearch(sender, e);
            if (string.IsNullOrEmpty(_viewModel.NidPp)) { _viewModel.NidPp = tempNidPp; }
        }

        private async void GenerateNextSampleNumber(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.GenerateNextSampleNumber();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while generating new sample number.\n\n{ex.Message}");
            }
        }

        //**************** DUBLICATED CODE ON RESULT ENTRY VIEW *************************
        private async void SimpleButtonPrintBarcode_Click(object sender, EventArgs e)
        {
            //If the print barcode function returns false then don't try marking the sample as collected.
            if (!await PrintBarcodeAsync()) { return; }

            try
            {
                await _viewModel.MarkSampleCollected();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while marking the sample as collected\n\n{ex.Message}",
                    "Mark Sample as collected", MessageBoxButtons.OK);
            }
        }

        private async void OnSearchRequest(object sender, EventArgs e)
        {
            try
            {
                await InitializeRequestSearchByCinAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async Task InitializeRequestSearchByCinAsync()
        {
            try
            {
                await _viewModel.SearchRequestByCinAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private async void OnConfirmAnalysisRequest(object sender, EventArgs e)
        {
            try
            {
                var demographicsConfirmRequired = await _viewModel.OrderRequiresNidPpConfirmationAsync();
                if (demographicsConfirmRequired.IsConfirmationRequired)
                {
                    _viewModel.LoadingStaticDataStatus = true;
                    var dialog = new PatientDetailsConfirmationView(demographicsConfirmRequired);
                    dialog.ShowDialog();
                    if (dialog.DialogResult == DialogResult.Cancel)
                    {
                        _viewModel.LoadingStaticDataStatus = false;
                        return;
                    }
                    _viewModel.LoadingStaticDataStatus = false;

                }
            }
            catch (Exception)
            {
                //ignore
            }

            try
            {
                var status = await _viewModel.ConfirmAnalysisRequest();
                if (status)
                {
                    XtraMessageBox.Show("The analysis request is confirmed!");
                }
                else
                {
                    XtraMessageBox.Show("Failed to confirm analysis request!");
                }

            }
            catch (NullReferenceException)
            {
                XtraMessageBox.Show("Please make sure that all the required fields are completed.");
            }
            catch (Exception ex)
            {
                // REMOVE THIS. HANDLES THIS PROPERLY IN DATALAYER
                if (ex.Message.Contains("NULL") && ex.Message.Contains("TimeStamp") && ex.Message.Contains("CD4Data.dbo.TrackingHistory"))
                {
                    XtraMessageBox.Show($"Analysis request confirmed. The sample collected date was not specified though\n{ex.Message}");
                    return;
                }
                else
                {
                    XtraMessageBox.Show(ex.Message);
                    //XtraMessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void OnPushMessage(object sender, string e)
        {
            MessageBox.Show(e);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Handle LoadingStaticData property
            if (e.PropertyName == nameof(_viewModel.LoadingStaticDataStatus))
            {
                switch (_viewModel.LoadingStaticDataStatus)
                {
                    case true:
                        ChangeLoadingDataUiState(true);
                        break;
                    case false:
                        ChangeLoadingDataUiState(false);
                        break;
                    default:
                }
            }
        }

        private void ChangeLoadingDataUiState(bool uiState)
        {
            if (uiState)
            {
                progressPanelTestData.Visible = true;
                progressPanelPatientData.Visible = true;
                progressPanelRequest.Visible = true;

                progressPanelTestData.Dock = DockStyle.Fill;
                progressPanelPatientData.Dock = DockStyle.Fill;
                progressPanelRequest.Dock = DockStyle.Fill;

            }

            if (!uiState)
            {
                progressPanelTestData.Visible = false;
                progressPanelPatientData.Visible = false;
                progressPanelRequest.Visible = false;

                progressPanelTestData.Dock = DockStyle.None;
                progressPanelPatientData.Dock = DockStyle.None;
                progressPanelRequest.Dock = DockStyle.None;
            }
        }

        private void OnPatientSearch(object sender, EventArgs e)
        {
            OpenPatientSearchView();
        }

        private void RemoveTestFromAR(object sender, EventArgs e)
        {
            var rowsSelected = gridViewRequestedTests.GetSelectedRows();
            if (rowsSelected.Length > 0)
            {
                if (XtraMessageBox.Show($"Do you want to selected {rowsSelected.Length} tests?",
                    "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    gridViewRequestedTests.DeleteSelectedRows();
                }
            }

        }

        private async void ManageKeyUpEvents(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:

                    if (!_authEvaluator.IsFunctionAuthorized(simpleButtonRemoveTest.Tag.ToString())) return;
                    //change focus to make sure that everything is validated.
                    simpleButtonRemoveTest.Focus();
                    //execute remove test.
                    RemoveTestFromAR(this, EventArgs.Empty);
                    break;
                case Keys.F6:

                    if (!_authEvaluator.IsFunctionAuthorized(simpleButtonConfirm.Tag.ToString())) return;
                    //change focus to confim to which validates any control that has focus and thereby updating view model
                    simpleButtonConfirm.Focus();
                    //execute confim analysis request.
                    OnConfirmAnalysisRequest(this, EventArgs.Empty);
                    break;
                case Keys.F2:

                    if (!_authEvaluator.IsFunctionAuthorized(simpleButtonSearch.Tag.ToString())) return;

                    //change focus to search button to which validates any control that has focus and thereby updating view model
                    simpleButtonSearch.Focus();
                    //execute search
                    OnPatientSearch(this, EventArgs.Empty);
                    break;
                case Keys.F7:

                    if (!_authEvaluator.IsFunctionAuthorized(simpleButtonSearchRequest.Tag.ToString())) return;

                    //change focus to search request button to which validates any control that has focus and thereby updating view model
                    simpleButtonSearchRequest.Focus();

                    try
                    {
                        //execute search
                        await InitializeRequestSearchByCinAsync();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }

                    break;
                default:
                    break;
            }
        }

        private void DeleteSelectedRow()
        {
            //Get SelectedRows
            var selectedRowHandles = gridViewRequestedTests.GetSelectedRows();
            if (selectedRowHandles.Length == 0) return;

            //Ask ViewModel to remove them
            foreach (var rowHandle in selectedRowHandles)
            {
                var row = (TestModel)(gridViewRequestedTests.GetRow(rowHandle));
                _viewModel.RemoveTestModelFromAddedTests(row);
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

        private void InitializeDataBinding()
        {
            #region Request Data
            //Cin
            textEditCin.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Cin), false,
                DataSourceUpdateMode.OnPropertyChanged));
            //Cin Error Text
            textEditCin.DataBindings.Add
                (new Binding("ErrorText", _viewModel, nameof(_viewModel.CinErrorText), false,
                DataSourceUpdateMode.OnPropertyChanged));

            //Site and Selected Site
            lookUpEditSite.Properties.DataSource = _viewModel.Sites;
            lookUpEditSite.Properties.DisplayMember = nameof(SitesModel.Site);
            lookUpEditSite.Properties.ValueMember = nameof(SitesModel.Id);
            lookUpEditSite.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedSiteId)));

            //Collection Date
            dateEditCollectedDate.DataBindings.Add
                ("EditValue", _viewModel, nameof(_viewModel.SampleCollectionDate), true,
                DataSourceUpdateMode.OnPropertyChanged);

            //Request Date
            dateEditSampleReceived.DataBindings.Add
                ("EditValue", _viewModel, nameof(_viewModel.SampleReceivedDate), true,
                DataSourceUpdateMode.OnPropertyChanged);

            //sample priority
            toggleSwitchSamplePriority.DataBindings.Add(new Binding("IsOn", _viewModel, nameof(_viewModel.IsSamplePriority), true,
                DataSourceUpdateMode.OnPropertyChanged));

            #endregion

            #region Patient Data
            //National ID / Passport
            textEditNidPp.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.NidPp), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Fullname
            textEditFullname.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Fullname), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Genders and Selected gender
            lookUpEditGender.Properties.DataSource = _viewModel.Gender;
            lookUpEditGender.Properties.DisplayMember = nameof(GenderModel.Gender);
            lookUpEditGender.Properties.ValueMember = nameof(GenderModel.Id);
            lookUpEditGender.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedGenderId)));

            //Age
            textEditAge.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Age), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Phone Number
            textEditPhoneNumber.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.PhoneNumber), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Birthdate... calculate age on view model.
            dateEditBirthdate.DataBindings.Add
                ("EditValue", _viewModel, nameof(_viewModel.Birthdate), true,
                DataSourceUpdateMode.OnValidation);

            //Address
            textEditAddress.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Address), true,
                DataSourceUpdateMode.OnPropertyChanged));

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

            //Countries and Selected Country
            lookUpEditCountry.Properties.DataSource = _viewModel.Countries;
            lookUpEditCountry.Properties.DisplayMember = nameof(CountryModel.Country);
            lookUpEditCountry.Properties.ValueMember = nameof(CountryModel.Id);
            lookUpEditCountry.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedCountryId)));

            //Institute Assigned Patient ID
            textEditInstituteAssignedPatientId.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.InstituteAssignedPatientId), true,
                DataSourceUpdateMode.OnPropertyChanged));
            #endregion

            #region Clinical Details
            gridControlClinicalDetails.DataSource = _viewModel.ClinicalDetails;
            #endregion

            #region Test data
            //Tests and profiles lookupEdit datasource
            lookUpEditTests.Properties.DataSource = _viewModel.AllTestsData;
            lookUpEditTests.Properties.ValueMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);
            lookUpEditTests.Properties.DisplayMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);

            //Tests and profiles lookupEdit Editvalue
            lookUpEditTests.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.TestToAdd)));

            //Selected Tests DataGrid
            gridControlRequestedTests.DataSource = _viewModel.AddedTests;

            //Episode Number
            textEditEpisodeNumber.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.EpisodeNumber),
                true, DataSourceUpdateMode.OnPropertyChanged));
            #endregion

        }

        private void OpenPatientSearchView()
        {
            var searchTerm = GetSearchTerm();
            if (string.IsNullOrEmpty(searchTerm))
            {
                XtraMessageBox.Show("<b>Patient fullname</b> <u>OR</u> <b>ID card / passport</b> is required for search!",
                    "Search Requirement",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Exclamation,
                    allowHtmlText: DevExpress.Utils.DefaultBoolean.True);
                return;
            }
            var searchViewModel = new PatientSearchResultsViewModel(_mapper, _dataAccess)
            {
                SearchTerm = searchTerm,
                SearchType = GetSearchType()
            };
            //IMPORTANT: Needs to subscribe for this event from viewModel before initializing the view to avoid catching events from 
            //view model after the view gets disposed.
            searchViewModel.PatientSelected += SearchViewModel_PatientSelected;

            var searchView = new PatientSearchResultsView(searchViewModel)
            {
                MdiParent = this.MdiParent,
                StartPosition = FormStartPosition.CenterParent
            };
            searchView.FormClosed += SearchView_FormClosed;
            if (!searchView.IsDisposed)
            {
                searchView.Show();
            }

        }

        private PatientSearchResultsViewModel.SearchTermType GetSearchType()
        {
            if (_viewModel.NidPp != null)
            {
                return PatientSearchResultsViewModel.SearchTermType.NidPp;
            }
            return PatientSearchResultsViewModel.SearchTermType.PatientName;
        }

        private string GetSearchTerm()
        {
            if (!string.IsNullOrEmpty(_viewModel.NidPp))
            {
                _viewModel.Fullname = null;
                return _viewModel.NidPp;
            }
            return _viewModel.Fullname;
        }

        private void SearchView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).Dispose();
        }

        private void SearchViewModel_PatientSelected(object sender, PatientModel e)
        {
            _viewModel.OnReceiveSearchResults(e);
        }

        /// <summary>
        /// loads barcode data from database and tries to print the barcodes
        /// NOTE: *********************************************  DUBLICATE CODE EXISTS ON RESULT ENTRY VIEW ************************
        /// </summary>
        /// <returns>True if able to load barcode data from database, even if the printing step fails.</returns>
        private async Task<bool> PrintBarcodeAsync()
        {
            List<BarcodeDataModel> barcodeData;
            try
            {
                barcodeData = await _viewModel.GetBarcodeDataAsync();
                return _barcodeHelper.PrintSingleSampleBarcode(barcodeData, _viewModel.Cin);
            }
            catch (System.Drawing.Printing.InvalidPrinterException ex) 
            {
                XtraMessageBox.Show($"Cannot print the barcode. The sample will be marked as collected if status is registered. Please find the error(s) below\n{ex.Message}");
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }

        }

        private void dateEditBirthdate_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}