using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.ViewModel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IReportsDataAccess reportsDataAccess;

        private IMainViewModel _viewModel { get; }

        public MainView(IMainViewModel viewModel, IReportsDataAccess reportsDataAccess)
        {
            InitializeComponent();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            _viewModel = viewModel;
            this.reportsDataAccess = reportsDataAccess;

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
            #endregion

        }

        private void LoadAuthenticationUi()
        {
            this.OpenMdiForm<AuthenticationView>();
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

            //if parameter is not null, assign it to form tag
            form.Tag = parameter;
            form.MdiParent = this;
            form.Show();
            
            form.FormClosed += Form_FormClosed;

        }

        private void ResultView_OnGenerateReportByCin(object sender, string cin)
        {
            //open report view
            // this.OpenMdiForm<ReportView>(cin);

            var reportView = new ReportView(reportsDataAccess, cin) { MdiParent = this};
            reportView.Show();
        }
    }
}