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
    public partial class CodifiedResultsView : XtraForm
    {
        private  ICodifiedResultsViewModel _viewModel { get; }

        public CodifiedResultsView(ICodifiedResultsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

    }
}