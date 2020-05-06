using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class OrderEntryView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IOrderEntryViewModel _viewModel;

        public OrderEntryView(IOrderEntryViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeDataBinding();

            //simpleButtonSearch.Click += SimpleButtonSearch_Click;
            lookUpEditTests.Validated += LookUpEditTests_Validated;
            simpleButtonRemoveTest.Click += RemoveTestFromAR;
            simpleButtonSearch.Click += SimpleButtonSearch_Click1;
            KeyUp += RemoveTestFromAR; ;
        }

        private void SimpleButtonSearch_Click1(object sender, EventArgs e)
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

        //private void SimpleButtonSearch_Click(object sender, System.EventArgs e)
        //{
        //    var a = JsonConvert.SerializeObject(_viewModel, Formatting.Indented);
        //    Clipboard.SetText(a);
        //}

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
            var searchViewModel = new PatientSearchResultsViewModel() 
            { PatientNameForSearch = textEditFullname.Text };

            var searchView = new PatientSearchResultsView(searchViewModel)
            {
                MdiParent = this.MdiParent,
                StartPosition = FormStartPosition.CenterParent
            };
            searchViewModel.PatientSelected += SearchViewModel_PatientSelected;
            searchView.Show();
            searchView.FormClosed += SearchView_FormClosed;

        }

        private void SearchView_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).Dispose();
        }

        private void SearchViewModel_PatientSelected(object sender, PatientModel e)
        {
            throw new NotImplementedException();
        }
    }
}