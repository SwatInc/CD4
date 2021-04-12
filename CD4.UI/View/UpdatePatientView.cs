using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class UpdatePatientView : XtraForm
    {
        private readonly IUpdatePatientViewModel _viewModel;

        public UpdatePatientView(IUpdatePatientViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeDataBinding();
            textEditNidPp.KeyDown += LoadPatientOnNidPp;
            simpleButtonSave.Click += SaveUpdatedPatientData;
        }

        private async void SaveUpdatedPatientData(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.UpdatePatientAsync();
                XtraMessageBox.Show("Patient Updated!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex, Formatting.Indented));
            }
        }

        private void LoadPatientOnNidPp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter)) { return; }
            if (string.IsNullOrEmpty(_viewModel.NidPp)) { return; }
            try
            {
                _viewModel.LoadPatientByNidPp();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject((ex), Formatting.Indented));
            }
        }

        private void InitializeDataBinding()
        {
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
            lookUpEditCountry.Properties.DataSource = _viewModel.Nationalities;
            lookUpEditCountry.Properties.DisplayMember = nameof(CountryModel.Country);
            lookUpEditCountry.Properties.ValueMember = nameof(CountryModel.Id);
            lookUpEditCountry.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedNationalityId)));

            //institute assigned patient Id
            textEditInstituteAssignedPatientId.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.InstituteAssignedPatientId)
                , true, DataSourceUpdateMode.OnPropertyChanged));
            #endregion
        }
    }
}