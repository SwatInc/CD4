using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;

namespace CD4.UI.View
{
    public partial class TestsView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ITestViewModel _viewModel;

        public TestsView(ITestViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
        }

    }
}