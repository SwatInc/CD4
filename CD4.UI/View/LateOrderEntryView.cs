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
        [Browsable(false)] public new bool DialogResult { get; set; }


        public LateOrderEntryView(ILateOrderEntryViewModel viewModel,List<ResultModel> testsAlreadyPresentOnSample)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBindings();
            _viewModel.SetCurrentTestsOnSample(testsAlreadyPresentOnSample);

            lookUpEditTests.Validated += LookUpEditTests_Validated;
            simpleButtonConfirm.Click += ConfirmTests;
            simpleButtonClose.Click += CloseWithoutSaving;
            this.KeyUp += LateOrderEntryView_KeyUp;
            simpleButtonDeleteSelectedRows.Click += SimpleButtonDeleteSelectedRows_Click;

        }

        private void SimpleButtonDeleteSelectedRows_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows();
        }

        private void LateOrderEntryView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    ConfirmTests(this, EventArgs.Empty);
                    break;
                case Keys.F4:
                    CloseWithoutSaving(this, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    DeleteSelectedRows();
                    break;
                default:
                    break;
            }
        }

        private void DeleteSelectedRows()
        {
            gridViewRequestedTests.DeleteSelectedRows();
        }

        private void CloseWithoutSaving(object sender, EventArgs e)
        {
            DialogResult = false;
            _viewModel.AddedTests.Clear();
            Close();
        }

        private async void ConfirmTests(object sender, EventArgs e)
        {
            try
            {
               var success = await _viewModel.ConfirmAnalysisRequestAync();
                if (success)
                {
                    XtraMessageBox.Show("Added the tests successfully");
                }
                else
                {
                    XtraMessageBox.Show("An error occured while adding the selected tests to the sample");
                }

                CloseOnSuccess();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while adding reflex tests.\n\n{ex.Message}");
                CloseWithoutSaving(this, EventArgs.Empty);
            }
        }

        private void CloseOnSuccess()
        {
            DialogResult = true;
            _viewModel.AddedTests.Clear();
            Close();
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