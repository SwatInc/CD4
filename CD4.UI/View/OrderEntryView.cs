using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.Utils.ScrollAnnotations;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class OrderEntryView : XtraForm
    {
        private readonly IOrderEntryViewModel _viewModel;
        private readonly IMapper mapper;
        private readonly IPatientDataAccess dataAccess;

        public OrderEntryView(IOrderEntryViewModel viewModel,
            IMapper mapper, IPatientDataAccess dataAccess)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            this.mapper = mapper;
            this.dataAccess = dataAccess;
            InitializeDataBinding();

            lookUpEditTests.Validated += LookUpEditTests_Validated;
            simpleButtonRemoveTest.Click += RemoveTestFromAR;
            simpleButtonSearch.Click += SimpleButtonSearch_Click;
            KeyUp += RemoveTestFromAR; ;
            _viewModel.PushingMessages += OnPushMessage;
            _viewModel.PropertyChanged += OnPropertyChanged;

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
            if(uiState)
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

        private void SimpleButtonSearch_Click(object sender, EventArgs e)
        {
            OpenPatientSearchView();
        }

        private void RemoveTestFromAR(object sender, EventArgs e)
        {
            RemoveTestFromAR(this, new KeyEventArgs(Keys.Delete));

        }

        private void RemoveTestFromAR(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var rowsSelected = gridViewRequestedTests.GetSelectedRows();
                if (rowsSelected.Length > 0)
                {
                    if (XtraMessageBox.Show($"Do you want to selected {rowsSelected.Length} tests?",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.No)
                    {
                        DeleteSelectedRow();
                    }
                }
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

        private async void LookUpEditTests_Validated(object sender, System.EventArgs e)
        {
            await _viewModel.ManageAddTestToRequestAsync();
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
            lookUpEditAtoll.Properties.ValueMember = nameof(AtollModel.Id);
            lookUpEditAtoll.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedAtollId), true,
                DataSourceUpdateMode.OnPropertyChanged));

            //Islands and Selected Island
            lookUpEditIsland.Properties.DataSource = _viewModel.Islands;
            lookUpEditIsland.Properties.DisplayMember = nameof(IslandModel.Island);
            lookUpEditIsland.Properties.ValueMember = nameof(IslandModel.Id);
            lookUpEditIsland.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedIslandId)));

            //Countries and Selected Country
            lookUpEditCountry.Properties.DataSource = _viewModel.Countries;
            lookUpEditCountry.Properties.DisplayMember = nameof(CountryModel.Country);
            lookUpEditCountry.Properties.ValueMember = nameof(CountryModel.Id);
            lookUpEditCountry.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedCountryId)));
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
            var searchViewModel = new PatientSearchResultsViewModel(mapper, dataAccess) 
            { 
                SearchTerm = searchTerm,
                SearchType = GetSearchType()
            };

            var searchView = new PatientSearchResultsView(searchViewModel)
            {
                MdiParent = this.MdiParent,
                StartPosition = FormStartPosition.CenterParent
            };
            searchViewModel.PatientSelected += SearchViewModel_PatientSelected;
            searchView.Show();
            searchView.FormClosed += SearchView_FormClosed;

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
            if(!string.IsNullOrEmpty(_viewModel.NidPp)) 
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
    }
}