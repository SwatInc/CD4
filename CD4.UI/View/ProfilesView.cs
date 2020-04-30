using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ProfilesView : XtraForm
    {
        private readonly IProfilesViewModel _viewModel;

        public ProfilesView(IProfilesViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;

            InitializeBinding();
            simpleButtonAddNew.Click += _viewModel.UiPrepForAddingProfile;
            simpleButtonSave.Click += _viewModel.SaveProfile;
            simpleButtonAddToProfile.Click += SimpleButtonAddToProfile_Click;
            simpleButtonRemoveFromProfile.Click += OnRequestRemoveFromProfile;
            simpleButtonDelete.Click += OnRequestDeleteSelectedProfile;
            listBoxControlProfiles.SelectedValueChanged += ListBoxControlProfiles_SelectedValueChanged;
        }

        private async void OnRequestDeleteSelectedProfile(object sender, EventArgs e)
        {
            await _viewModel.DeleteProfile((ProfileConfigModel)listBoxControlProfiles.SelectedItem);
        }

        private async void OnRequestRemoveFromProfile(object sender, EventArgs e)
        {
            await _viewModel.RemoveProfileTestFromProfile
                ((ProfileConfigProfileTestsModel)listBoxControlProfileTests.SelectedItem);
        }

        private async void ListBoxControlProfiles_SelectedValueChanged
            (object sender, EventArgs e)
        {
            await _viewModel.SelectedProfileChanged((ProfileConfigModel)listBoxControlProfiles.SelectedItem);
        }

        private void SimpleButtonAddToProfile_Click(object sender, EventArgs e)
        {
            var selectedProfile = (ProfileConfigModel)listBoxControlProfiles.SelectedItem;
            var selectedTest = (ProfileConfigTestModel)listBoxControlTests.SelectedItem;

            _viewModel.ManageAddItemToProfile(selectedProfile, selectedTest);
        }

        private void InitializeBinding()
        {
            #region Listbox Profiles Datasource
            listBoxControlProfiles.DataSource = _viewModel.ProfileList;
            listBoxControlProfiles.DisplayMember = nameof(ProfileConfigModel.ProfileDescription);
            listBoxControlProfiles.ValueMember = nameof(ProfileConfigModel.Id);
            #endregion

            #region ListBoxProfilesSelectedItem
            listBoxControlProfiles.DataBindings.Add("SelectedItem", _viewModel, nameof(_viewModel.SelectedProfile));
            #endregion

            #region Listbox - Tests
            listBoxControlTests.DataSource = _viewModel.Tests;
            listBoxControlTests.DisplayMember = nameof(ProfileConfigTestModel.TestDescription);
            listBoxControlTests.ValueMember = nameof(ProfileConfigTestModel.Id);
            #endregion

            #region ListBox - Tests - SelectedTest
            listBoxControlTests.DataBindings.Add(new Binding("SelectedItem", _viewModel, nameof(_viewModel.SelectedTest)));
            #endregion

            #region Simple Buttons - VISIBILITY: Add, Edit, Delete, AddToProfile, RemoveFromProfile

            simpleButtonAddNew.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.OtherFunctionButtons)));
            simpleButtonEdit.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.OtherFunctionButtons)));
            simpleButtonDelete.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.OtherFunctionButtons)));
            simpleButtonAddToProfile.DataBindings.Add
                (new Binding("Enabled", _viewModel, nameof(_viewModel.OtherFunctionButtons)));
            simpleButtonRemoveFromProfile.DataBindings.Add
                (new Binding("Enabled", _viewModel, nameof(_viewModel.OtherFunctionButtons)));

            #endregion

            #region TextEditProfileName and SimpleButtonSave, VISIBILITY

            textEditProfileName.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.DataAddControlsEnabled)));
            simpleButtonSave.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.DataAddControlsEnabled)));

            #endregion

            #region TextEdit ProfileName EditValue

            textEditProfileName.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.NewProfileName)));

            #endregion

            listBoxControlProfileTests.DataSource = _viewModel.ProfileTestsForSelectedProfile;
            listBoxControlProfileTests.DisplayMember = nameof(ProfileConfigProfileTestsModel.TestDescription);
            listBoxControlProfileTests.ValueMember = nameof(ProfileConfigProfileTestsModel.Id);

        }
    }
}