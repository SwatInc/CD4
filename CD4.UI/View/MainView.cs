using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.ViewModel;
using CD4.UI.UiSpecificModels;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IReportsDataAccess reportsDataAccess;
        private readonly IUserAuthEvaluator _authEvaluator;

        public event EventHandler<int> SelectedDisciplineChanged;

        private IMainViewModel _viewModel { get; }

        public MainView(IMainViewModel viewModel, IReportsDataAccess reportsDataAccess, IUserAuthEvaluator authEvaluator)
        {
            InitializeComponent();
            //this.popupMenu.AddItem(this.barButtonItemChangePassword);
            this.popupMenuDiscipline.AddItem(this.barButtonItemCountries);
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            _viewModel = viewModel;
            this.reportsDataAccess = reportsDataAccess;
            _authEvaluator = authEvaluator;

            //load auth UI
            LoadAuthenticationUi();

            #region Event Subscriptions

            //Configuration Tab buttons
            barButtonItemCodifiedResults.ItemClick += OpenCodifiedResultsView;
            barButtonItemCountries.ItemClick += OpenCountriesConfigView;
            barButtonItemGender.ItemClick += OpenGenderConfigView;
            barButtonItemIslandAtoll.ItemClick += OpenAtollAndIslandsConfigView;
            barButtonItemScientist.ItemClick += OpenScientistConfigView;
            barButtonItemClinicalDetails.ItemClick += OpenClinicalDetailsConfigView;
            barButtonItemSites.ItemClick += OpenSitesConfigView;
            barButtonItemTests.ItemClick += OpenTestsConfigView;
            barButtonItemProfiles.ItemClick += OpenProfilesConfigView;

            //General Tab Buttons
            barButtonItemOrderEntry.ItemClick += OpenOrderEntryView;
            barButtonItemResultEntry.ItemClick += OpenResultEntryView;
            barButtonItemAcceptSamples.ItemClick += OpenAcceptSampleView;
            barButtonItemBulkImportOrders.ItemClick += OpenBulkOrdersView;

            //profile Tab Buttons
            barButtonItemChangePassword.ItemClick += OpenChangePasswordView;
            #endregion

            //load app wide static data from database
            LoadAppWideStaticData().GetAwaiter().GetResult();

            //this.barButtonItem2.ItemClick += BarButtonItem2_ItemClick;
            this.MdiChildActivate += MainView_MdiChildActivate;

            SetDisciplineRibbonOptions();
        }

        private void OpenBulkOrdersView(object sender, ItemClickEventArgs e)
        {
            OpenMdiForm<BulkOrdersImportView>();
        }

        /// <summary>
        /// Creates and adds discipline popup menu buttons to the popup menu and hook to their click events
        /// </summary>
        private void SetDisciplineRibbonOptions()
        {
            if(Properties.Resources.IsMultipleDisciplinesEnabled == "0") 
            {
                return;
            }

            //read discipline data
            var disciplineMenu = JsonConvert.DeserializeObject<List<DiscplineMenuModel>>(Properties.Resources.popupMenuDisciplines);
            //create barbuttonItems
            foreach (var item in disciplineMenu)
            {
                var button = new BarButtonItem()
                {
                    Name = item.Name,
                    Caption = item.Caption,
                    Tag = item.Tag,
                    ButtonStyle = BarButtonStyle.Default,
                    RibbonStyle = RibbonItemStyles.Large
                };

                button.ImageOptions.Image = _viewModel.GetDisciplineImage(item.Image);

                button.ItemClick += OnChangedSelectedDiscipline;
                popupMenuDiscipline.AddItem(button);
            }

            ribbonPageDiscipline.Visible = true;
        }

        private void OnChangedSelectedDiscipline(object sender, ItemClickEventArgs e)
        {
            
            var barButton = (BarBaseButtonItem)e.Item;
            //change the barButtonItemAllDisciplines image and caption
            barButtonItemDisciplineSelector.Caption = barButton.Caption;
            barButtonItemDisciplineSelector.ImageOptions.Image  = barButton.ImageOptions.Image;

            //inform listeners about about the change with discipline Id
            SelectedDisciplineChanged?.Invoke(this, (int)barButton.Tag);
        }
        private void MainView_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
            {
                this.ribbonPageDiscipline.Visible = false;
                return;
            }
            if (this.ActiveMdiChild.Name == "ResultEntryView" && Properties.Resources.IsMultipleDisciplinesEnabled != "0")
            {
                this.ribbonPageDiscipline.Visible = true;
            }
            else
            {
                this.ribbonPageDiscipline.Visible = false;
            }

        }

        private async Task LoadAppWideStaticData()
        {
            //Load workstation printer information
            try
            {
                var printerData = await _viewModel.GetApplicationWideStaticData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void OpenAcceptSampleView(object sender, ItemClickEventArgs e)
        {
            OpenMdiForm<AcceptSampleView>();
        }

        private void OpenChangePasswordView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<ChangePasswordView>();
        }

        private void LoadAuthenticationUi()
        {
            this.OpenMdiForm<AuthenticationView>();
            this.ribbon.Visible = false;
        }

        private void OpenResultEntryView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<ResultEntryView>();
        }

        private void OpenOrderEntryView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<OrderEntryView>();
        }

        private void OpenProfilesConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<ProfilesView>();
        }

        #region Open Config Forms
        private void OpenTestsConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<TestsView>();
        }

        private void OpenSitesConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<SitesView>();
        }

        private void OpenClinicalDetailsConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<ClinicaDetailsView>();
        }

        private void OpenScientistConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<ScientistsView>();
        }

        private void OpenAtollAndIslandsConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<AtollIslandView>();
        }

        private void OpenGenderConfigView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<GenderView>();
        }

        private void OpenCodifiedResultsView(object sender, ItemClickEventArgs e)
        {
            this.OpenMdiForm<CodifiedResultsView>();
        }

        private void OpenCountriesConfigView(object sender, ItemClickEventArgs e)
        {
            OpenMdiForm<CountriesView>();
        }

        #endregion

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = (XtraForm)sender;
            form.Dispose();
            GC.Collect();
        }

        public void OpenMdiForm<T>(string parameter = null) where T : Form
        {

            var form = FormFactory.Create<T>();
            //subscribe for required form events
            if (typeof(T) == typeof(ResultEntryView))
            {
                //cast form as ResultEntryView
                var resultView = (ResultEntryView)Convert.ChangeType(form, typeof(ResultEntryView));
                //subscribe for events
                //GenerateReportByCin event
                resultView.GenerateReportByCin += ResultView_OnGenerateReportByCin;

            }

            //Check whether the form is authentication form
            if (typeof(T) == typeof(AuthenticationView))
            {
                //cast T as authenticationView
                var authView = (AuthenticationView)Convert.ChangeType(form, typeof(AuthenticationView));
                //subscribe for the required event
                authView.UserAuthorized += AuthView_UserAuthorized;
            }
            //if parameter is not null, assign it to form tag
            if (!string.IsNullOrEmpty(parameter)) { form.Tag = parameter; }
            form.MdiParent = this;
            //check for authorization
            if (!_authEvaluator.EvaluateAuthForItem<Form>(form))
            {
                XtraMessageBox.Show($"You are not authorised to for {form.Tag}. Please contact your administrator if you require authorisation.");
                return;
            }
            form.Show();
            form.FormClosed += Form_FormClosed;
        }

        private async void AuthView_UserAuthorized(object sender, Library.Model.AuthorizeDetailEventArgs e)
        {
            //Todo: assign this via MainViewModel by databinding
            barStaticItemUsernameAndRole.Caption = $"Welcome {e.FullName} ({e.UserRole})";
            EvaluateMainViewAuth();

            try
            {
                //Get result alert configuration
                var alertData = await _viewModel.GetResultAlertData();
                ResultAlertModelCollection.ResultAlertData.AddRange(alertData);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while loading result alert data.\n{ex.Message}");
            }
        }

        private void EvaluateMainViewAuth()
        {

            //handle ribbon pages auth
            foreach (var page in ribbon.Pages)
            {
                var pageTag = ((RibbonPage)page).Tag.ToString();
                if (!string.IsNullOrEmpty(pageTag))
                {
                    if (!_authEvaluator.IsFunctionAuthorized(pageTag, false)) ((RibbonPage)page).Visible = false;
                }
            }

            //handle ribbon auth
            var ribbonTag = ribbon.Tag.ToString();
            if (!string.IsNullOrEmpty(ribbonTag))
            {
                ribbon.Visible = _authEvaluator.IsFunctionAuthorized(ribbonTag);
            }
        }

        private void ResultView_OnGenerateReportByCin(object sender, string cin)
        {
            //open report view
            // this.OpenMdiForm<ReportView>(cin);

            var reportView = new ReportView(reportsDataAccess, cin, _viewModel.GetloggedInUserId()) { MdiParent = this };
            reportView.Show();
        }
    }
}