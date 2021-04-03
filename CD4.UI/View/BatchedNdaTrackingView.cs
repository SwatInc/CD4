using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class BatchedNdaTrackingView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IBatchedNdaTrackingViewModel _viewModel;

        public BatchedNdaTrackingView(IBatchedNdaTrackingViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            InitializeBinding();

            simpleButtonLoadTrackingSearchData.Click += LoadNdaTrackingData;
            simpleButtonSaveNdaTrackingReportDate.Click += SaveReportDateForBatch;
            simpleButtonSaveNdaTrackingQcCalValidatedUser.Click += SaveCalAndQcUser;
            lookUpEditSampleStatus.EditValueChanged += SampleStatusFilterChanged;
            lookUpEditQcCalValidatedUser.EditValueChanged += CalAndQcUserSelectionChanged;
            lookUpEditAnalysedUser.EditValueChanged += AnalysedUserSelectionChanged;
            lookUpEditSampleStatus.EditValueChanged += SampleStatusFilterChanged;
            _viewModel.PropertyChanged += DebugWithPropertyChanged;
        }

        private async void SaveCalAndQcUser(object sender, EventArgs e)
        {
            var data = GetSelectedSamples();
            if (data is null)
            {
                XtraMessageBox.Show("Please select the samples to set the user who validated QC and Calibrations.");
                return;
            }

            try
            {
                var output = await _viewModel.SaveQcCalValidatedUserAsync(data);
                _viewModel.UpdateUiQcCalValidatedUser(output);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error setting QC and cal validated user. Please see more details below\n{ex.Message}");
            }

        }

        private async void SaveReportDateForBatch(object sender, EventArgs e)
        {
            var data = GetSelectedSamples();
            if (data is null)
            {
                XtraMessageBox.Show("Please select the samples to set Report Date.");
                return;
            }

            try
            {
                var output  = await _viewModel.SaveReportDateAsync(data);
                _viewModel.UpdateUiReportDate(output);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while trying to save Report Date for the selected batch. Please see the details below\n{ex.Message}\n{ex.StackTrace}");
            }
        }

        private List<NdaTrackingModel> GetSelectedSamples()
        {
            var selectedRowHandles = gridViewNdaTracking.GetSelectedRows();
            if (selectedRowHandles.Length == 0)
            {
                return null;
            }
            var data = new List<NdaTrackingModel>();
            foreach (var rowHandle in selectedRowHandles)
            {
                data.Add((NdaTrackingModel)gridViewNdaTracking.GetRow(rowHandle));
            }
            return data;
        }

        #region Setting viewModels selectedValues for LookUpEdits
        private void AnalysedUserSelectionChanged(object sender, EventArgs e)
        {
            _viewModel.AnalysedUser = (ScientistModel)(lookUpEditAnalysedUser.GetSelectedDataRow());
        }

        private void CalAndQcUserSelectionChanged(object sender, EventArgs e)
        {
            _viewModel.CalQcValidatedUser = (ScientistModel)(lookUpEditQcCalValidatedUser.GetSelectedDataRow());
        }

        private void SampleStatusFilterChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedStatus = (StatusModel)(lookUpEditSampleStatus.GetSelectedDataRow());
        }
        #endregion

        private void DebugWithPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Property changed: {e.PropertyName}");
        }

        private async void LoadNdaTrackingData(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.ExecuteSearchAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occured while loading sample data. Please see the details below.\n{ex.Message}");
            }
        }

        private void InitializeBinding()
        {
            //NDA Tracking data grid control
            gridControlNdaTracking.DataSource = _viewModel.NdaTrackingData;

            #region Search Criteria
            //from date
            dateEditFromDate.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.FromDate), true));

            //to date
            dateEditToDate.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.ToDate), true));

            //Sample status
            lookUpEditSampleStatus.Properties.DataSource = _viewModel.Statuses;
            lookUpEditSampleStatus.Properties.DisplayMember = nameof(StatusModel.Status);
            lookUpEditSampleStatus.Properties.ValueMember = nameof(StatusModel.Id);
            #endregion

            #region Tracking
            //Report
            dateEditReportDateForBatch.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedReportDate), true, DataSourceUpdateMode.OnPropertyChanged));
            //analsyed user
            lookUpEditAnalysedUser.Properties.DataSource = _viewModel.Scientists;
            lookUpEditAnalysedUser.Properties.DisplayMember = nameof(ScientistModel.Scientist);
            lookUpEditAnalysedUser.Properties.ValueMember = nameof(ScientistModel.Id);
            //Cal and QC validated user
            lookUpEditQcCalValidatedUser.Properties.DataSource = _viewModel.Scientists;
            lookUpEditQcCalValidatedUser.Properties.DisplayMember = nameof(ScientistModel.Scientist);
            lookUpEditQcCalValidatedUser.Properties.ValueMember = nameof(ScientistModel.Id);
            #endregion

        }
    }
}