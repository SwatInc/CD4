using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ProfilesView : DevExpress.XtraEditors.XtraForm
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
            listBoxControlProfiles.SelectedValueChanged += ListBoxControlProfiles_SelectedValueChanged;
        }

        private void ListBoxControlProfiles_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxControlProfiles.CausesValidation = true;
            //this looses the focus and validates the control
            listBoxControlProfiles.Enabled = false;
            listBoxControlProfiles.Enabled = true;

            _viewModel.SelectedProfileChanged();
        }

        private void SimpleButtonAddToProfile_Click(object sender, EventArgs e)
        {
            var a = JsonConvert.SerializeObject(_viewModel.SelectedProfile, Formatting.Indented);
            var b = JsonConvert.SerializeObject(_viewModel.SelectedTest, Formatting.Indented);

            XtraMessageBox.Show($"{a}\n\n{b}");

            //add to Profile tests on clicking the button

            
        }

        private void InitializeBinding()
        {
            #region Listbox Profiles Datasource
            listBoxControlProfiles.DataSource = _viewModel.ProfileList;
            listBoxControlProfiles.DisplayMember = nameof(ProfileConfigModel.Profile);
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