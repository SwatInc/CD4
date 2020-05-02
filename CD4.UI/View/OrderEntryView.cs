using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using Newtonsoft.Json;
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

            simpleButtonSearch.Click += SimpleButtonSearch_Click;
        }

        private void SimpleButtonSearch_Click(object sender, System.EventArgs e)
        {
           var a = JsonConvert.SerializeObject(_viewModel,Formatting.Indented);
            Clipboard.SetText(a);
        }

        private void InitializeDataBinding()
        {
            #region Request Data
            //Cin
            textEditCin.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Cin), false,
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
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedAtollId),true,
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

        }
    }
}