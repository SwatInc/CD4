using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CD4.UI.Library.ViewModel;

namespace CD4.UI.View
{
    public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IMainViewModel _viewModel { get; }

        public MainView(IMainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            barButtonItemConfiguaration.ItemClick += OpenConfiguration;
        }

        private void OpenConfiguration(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}