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
            DisplaySettingsOnUi();
        }

        private void DisplaySettingsOnUi()
        {
            PropertyGrid propertyGrid1 = new PropertyGrid();
            propertyGrid1.CommandsVisibleIfAvailable = true;
            propertyGrid1.Location = new Point(20, 20);
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.TabIndex = 1;
            propertyGrid1.AutoScaleMode = AutoScaleMode.Dpi;
            propertyGrid1.Text = "Property Grid";

            this.Controls.Add(propertyGrid1);
            propertyGrid1.SelectedObject = _viewModel.Settings;
        }
    }
}
