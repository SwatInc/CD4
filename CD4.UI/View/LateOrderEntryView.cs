using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class LateOrderEntryView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILateOrderEntryViewModel _viewModel;

        public LateOrderEntryView(ILateOrderEntryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBindings();

            lookUpEditTests.Validated += LookUpEditTests_Validated;

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Handle LoadingStaticData property
            if (e.PropertyName == nameof(_viewModel.LoadingStaticDataStatus))
            {
                switch (_viewModel.LoadingStaticDataStatus)
                {
                    case true:
                        ChangeLoadingDataUiState(true);
                        break;
                    case false:
                        ChangeLoadingDataUiState(false);
                        break;
                    default:
                }
            }
        }

        private void ChangeLoadingDataUiState(bool uiState)
        {
            if (uiState)
            {
                progressPanelTestData.Visible = true;
                progressPanelTestData.Dock = DockStyle.Fill;
            }

            if (!uiState)
            {
                progressPanelTestData.Visible = false;
                progressPanelTestData.Dock = DockStyle.None;
            }
        }

        private void InitializeBindings()
        {
            //Tests and profiles lookupEdit datasource
            lookUpEditTests.Properties.DataSource = _viewModel.AllTestsData;
            lookUpEditTests.Properties.ValueMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);
            lookUpEditTests.Properties.DisplayMember = nameof(ProfilesAndTestsDatasourceOeModel.Description);

            //Tests and profiles lookupEdit Editvalue
            lookUpEditTests.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.TestToAdd)));

            //Selected Tests DataGrid
            gridControlRequestedTests.DataSource = _viewModel.AddedTests;

        }

        private async void LookUpEditTests_Validated(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.ManageAddTestToRequestAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}