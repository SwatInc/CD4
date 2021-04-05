using CD4.AstmInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.AstmInterface.View
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel;
        public MainView()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
        }
    }
}
