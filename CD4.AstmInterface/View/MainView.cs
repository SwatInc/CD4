using CD4.AstmInterface.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.AstmInterface.View
{
    public partial class MainView : Form
    {
        private ILogger<MainView> _logger;
        private MainViewModel _viewModel;
        public MainView(ILogger<MainView> logger, MainViewModel viewModel)
        {
            InitializeComponent();
            _logger = logger;
            _viewModel = viewModel;
            //_viewModel = new MainViewModel();
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

            propertyGrid1.PropertyValueChanged += PropertyGrid1_PropertyValueChanged;

            _logger.LogInformation("Startup complete");
        }

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _viewModel.Settings.Save();
        }
    }
}
