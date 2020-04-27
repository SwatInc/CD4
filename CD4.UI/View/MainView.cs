using CD4.UI.Library.ViewModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IMainViewModel _viewModel { get; }

        public MainView(IMainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            barButtonItemCodifiedResults.ItemClick += OpenConfiguration;
        }

        private void OpenConfiguration(object sender, ItemClickEventArgs e)
        {
            var form = FormFactory.Create<CodifiedResultsView>();

            form.MdiParent = this;
            form.Show();
            form.FormClosed += Form_FormClosed;
        }

        private void Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            var form = (XtraForm)sender;
            form.Dispose();
            GC.Collect();
        }


    }
}