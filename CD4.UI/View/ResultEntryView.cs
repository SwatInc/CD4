using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        private readonly IResultEntryViewModel _viewModel;
        System.Windows.Forms.Timer dataRefreshTimer = new System.Windows.Forms.Timer() { Enabled = true, Interval = 1000 };

        public event EventHandler<string> GenerateReportByCin;

        public ResultEntryView(IResultEntryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            SizeChanged += OnSizeChangedAdjustSplitContainers;
            labelControlCin.DoubleClick += CopyCinToClipBoard;
            gridViewSamples.FocusedRowChanged += SelectedSampleChanged;
            gridViewTests.FocusedRowChanged += SelectedTestChanged;
            dataRefreshTimer.Tick += RefreshViewData;
            simpleButtonReport.Click += SimpleButtonReport_Click;
            simpleButtonLoadWorksheet.Click += LoadWorkSheet;
            _viewModel.RequestDataRefreshed += RefreshViewData;
            _viewModel.PushingMessages += _viewModel_PushingMessages;
            gridViewSamples.PopupMenuShowing += ShowSamplePopupMenu;
            gridViewTests.PopupMenuShowing += ShowTestPopupMenu;
            this.KeyUp += ResultEntryView_KeyUp;
            lookUpEditSampleStatusFilter.EditValueChanged += LookUpEditSampleStatusFilter_EditValueChanged;
        }

        /// <summary>
        /// Bind keyboard shortcuts
        /// </summary>
        private async void ResultEntryView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.ShiftKey:
                    break;
                case Keys.ControlKey:
                    break;
                case Keys.F1:
                    break;
                case Keys.F2:
                    break;
                case Keys.F3:
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    break;
                case Keys.F8:
                    break;
                case Keys.F9:
                    break;
                case Keys.F11: //Validate selected test on pressing F11
                    //get the selected row handle
                    var selectedRowHandle = gridViewTests.FocusedRowHandle;
                    //Ignore if no row is selected.
                    if (selectedRowHandle >= 0)
                    {
                        //Get selected result model
                        var resultModel = (ResultModel)gridViewTests.GetRow(selectedRowHandle);
                        await _viewModel.ValidateTest(resultModel);
                    }
                    break;
                case Keys.F12:
                    break;
                case Keys.F13:
                    break;
                case Keys.F14:
                    break;
                case Keys.F15:
                    break;
                case Keys.F16:
                    break;
                case Keys.F17:
                    break;
                case Keys.F18:
                    break;
                case Keys.F19:
                    break;
                case Keys.F20:
                    break;
                case Keys.F21:
                    break;
                case Keys.F22:
                    break;
                case Keys.F23:
                    break;
                case Keys.F24:
                    break;
                case Keys.NumLock:
                    break;
                case Keys.Scroll:
                    break;
                case Keys.LShiftKey:
                    break;
                case Keys.RShiftKey:
                    break;
                case Keys.LControlKey:
                    break;
                case Keys.RControlKey:
                    break;
                case Keys.Shift:
                    break;
                case Keys.Control:
                    break;
                case Keys.Alt:
                    break;
                default:
                    break;
            }
        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        /// <summary>
        /// Show a popup menu when gridview Samples is clicked.
        /// </summary>
        private void ShowSamplePopupMenu(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                //row handle
                var rowHandle = e.HitInfo.RowHandle;
                //grid which raised the event
                var sampleGrid = (GridView)sender;
                //sample menu items
                var sampleMenuItems = CreateSampleMenuItemsCollection(sampleGrid, rowHandle);
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                //add all menu items for sample grid view context menu
                foreach (var item in sampleMenuItems)
                {
                    e.Menu.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Show a popup menu when gridview test is clicked.
        /// </summary>
        private void ShowTestPopupMenu(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                //row handle
                var rowHandle = e.HitInfo.RowHandle;
                //grid which raised the event
                var sampleGrid = (GridView)sender;
                //sample menu items
                var sampleMenuItems = CreateTestMenuItemsCollection(sampleGrid, rowHandle);
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                //add all menu items for sample grid view context menu
                foreach (var item in sampleMenuItems)
                {
                    e.Menu.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Return a menu item for validating sample
        /// </summary>
        /// <returns>menu item</returns>
        DXMenuItem CreateMenuItemValidateSample(GridView view, int rowHandle)
        {
            //create validate menu item add a handler
            DXMenuItem menuItem = new DXMenuItem("Validate Sample [ F7 ]", new EventHandler(OnValidateSampleClick));
            //Tag the row handle and view onto the menu item
            menuItem.Tag = new RowInfo(view, rowHandle);
            return menuItem;
        }

        /// <summary>
        /// Generates menu items for the whole sample menu.
        /// </summary>
        /// <param name="view">Sample grid view</param>
        /// <param name="rowHandle">Clicked row handle</param>
        /// <returns>List of menu items for sample grid view</returns>
        List<DXMenuItem> CreateSampleMenuItemsCollection(GridView view, int rowHandle)
        {
            var menuItems = new List<DXMenuItem>();
            menuItems.Add(new DXMenuItem("Validate Sample [ F7 ]", new EventHandler(OnValidateSampleClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Reject Sample [ Shift+F11 ]", new EventHandler(OnRejectSampleClick)) { Tag = new RowInfo(view, rowHandle) });
            return menuItems;
        }

        /// <summary>
        /// Generates menu items for the selected test of the sample.
        /// </summary>
        /// <param name="view">Test grid view for selected tests</param>
        /// <param name="rowHandle">Clicked row handle</param>
        /// <returns>List of menu items for tests grid view</returns>
        List<DXMenuItem> CreateTestMenuItemsCollection(GridView view, int rowHandle)
        {
            var menuItems = new List<DXMenuItem>();
            menuItems.Add(new DXMenuItem("Validate Test [ F11 ]", new EventHandler(OnValidateTestClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Reject Test [ Shift+F11 ]", new EventHandler(OnRejectTestClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Show test history [  ]", new EventHandler(OnShowTestHistoryClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Show reruns [ F6 ]", new EventHandler(OnShowRerunsClick)) { Tag = new RowInfo(view, rowHandle) });
            return menuItems;
        }

        /// <summary>
        /// call view model to show test reruns
        /// </summary>
        private void OnShowRerunsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// call view model to show test history
        /// </summary>
        private void OnShowTestHistoryClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// call the view model to reject the test
        /// </summary>
        private void OnRejectTestClick(object sender, EventArgs e)
        {
            var testToReject = GetTestForMenu(sender, e);
            Debug.WriteLine($"Rejecting Test: {testToReject.Cin}, Test: {testToReject.Test}, Result: {testToReject.Result}");
        }

        /// <summary>
        /// Call the view model to validate the test
        /// </summary>
        private async void OnValidateTestClick(object sender, EventArgs e)
        {
            var testToValidate = GetTestForMenu(sender, e);
            Debug.WriteLine($"validating Test: {testToValidate.Cin}, Test: {testToValidate.Test}, Result: {testToValidate.Result}");

            await _viewModel.ValidateTest(testToValidate);
        }

        /// <summary>
        /// Call the view model to validate the sample
        /// </summary>
        async void OnValidateSampleClick(object sender, EventArgs e)
        {
            var sampleToValidate = GetSampleForMenu(sender, e);
            Debug.WriteLine("validating sample: " + sampleToValidate.Cin);
            //Call the view model to mark the sample and applicable associated tests as validated.
            await _viewModel.ValidateSample(sampleToValidate);
        }

        /// <summary>
        /// Call the view model to reject the sample
        /// </summary>
        void OnRejectSampleClick(object sender, EventArgs e)
        {
            var sampleToReject = GetSampleForMenu(sender, e);
            Debug.WriteLine("Rejecting sample: " + sampleToReject.Cin);
        }

        /// <summary>
        /// Gets the sample for the passed in grid and row handle
        /// </summary>
        /// <param name="sender">Object with gridView and row handle assigned to Tag property</param>
        /// <param name="e">empty</param>
        /// <returns>RequestSampleModel for the row handle for the grid</returns>
        RequestSampleModel GetSampleForMenu(object sender, EventArgs e)
        {
            //Get the menu item 
            var menu = (DXMenuItem)sender;
            //get the row info
            var rowInfo = (RowInfo)menu.Tag;
            //Get the request sample model and return
            return (RequestSampleModel)rowInfo.View.GetRow(rowInfo.RowHandle);

        }

        /// <summary>
        /// Returns the test that curresponds to the the row handle passed in.
        /// </summary>
        /// <param name="sender">Object with gridView and row handle assigned to Tag property</param>
        /// <param name="e">empty</param>
        /// <returns>ResultModel for the row handle for the grid</returns>
        ResultModel GetTestForMenu(object sender, EventArgs e)
        {
            //Get the menu item 
            var menu = (DXMenuItem)sender;
            //get the row info
            var rowInfo = (RowInfo)menu.Tag;
            //Get the request sample model and return
            return (ResultModel)rowInfo.View.GetRow(rowInfo.RowHandle);
        }

        /// <summary>
        /// Sets the selected status to viewmodel variable
        /// </summary>
        private void LookUpEditSampleStatusFilter_EditValueChanged(object sender, EventArgs e)
        {
            //gets the selected datarow from lookupedit and set it to viewModel variable
            _viewModel.SelectedStatus = (StatusModel)(lookUpEditSampleStatusFilter.GetSelectedDataRow());
        }

        private async void LoadWorkSheet(object sender, EventArgs e)
        {
            try
            {
                await _viewModel.GetWorkSheet();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void SimpleButtonReport_Click(object sender, EventArgs e)
        {
            //Get the Cin of the selected record.
            var cin = GetSelectedCin();
            //Ask to select a record, if no record is selected.
            if (cin is null)
            {
                XtraMessageBox.Show("Please select a sample to view the report!");
            }

            //Raise an event indicating that a sample report is requested.
            GenerateReportByCin?.Invoke(this, cin);
        }

        /// <summary>
        /// The datagrids does not show view model data without refresh. This method refreshes the view. The is NOT a refresh from database.
        /// </summary>
        private void RefreshViewData(object sender, EventArgs e)
        {
            dataRefreshTimer.Enabled = false;
            gridControlSamples.RefreshDataSource();
            gridControlTests.RefreshDataSource();
        }

        private void CopyCinToClipBoard(object sender, EventArgs e)
        {
            Clipboard.SetText(labelControlCin.Text);
        }

        private async void SelectedTestChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var selectedTest = (ResultModel)gridViewTests.GetRow(e.FocusedRowHandle);
            await _viewModel.SetTestCodifiedPhrasesAsync(selectedTest);
        }

        private async void SelectedSampleChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var selectedSample = (RequestSampleModel)gridViewSamples.GetRow(e.FocusedRowHandle);
            await _viewModel.SetSelectedSampleAsync(selectedSample);
        }

        /// <summary>
        /// Gets the selected Cin
        /// </summary>
        /// <returns>Returns selected Cin or null</returns>
        private string GetSelectedCin()
        {
            //Get row handles of selected rows
            var selectedRowHandles = gridViewSamples.GetSelectedRows();
            //return null if no rows selected
            if (selectedRowHandles.Length == 0)
            {
                return null;
            }
            //Get the row at handle 0
            var selectedRow = (RequestSampleModel)gridViewSamples.GetRow(selectedRowHandles[0]);
            //return Cin
            return selectedRow.Cin;
        }

        private void InitializeBinding()
        {
            #region Samples
            gridControlSamples.DataSource = _viewModel.RequestData;
            #endregion

            #region Tests / Result data
            gridControlTests.DataSource = _viewModel.SelectedResultData;
            #endregion

            #region Selected Samples data

            labelControlPatientName.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.PatientName),
                true, DataSourceUpdateMode.OnPropertyChanged));

            labelControlNationalId.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.NationalId)));

            labelControlAgeSex.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.AgeSex)));

            labelControlBirthdate.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.BirthDateString)));

            labelControlPhoneNumber.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.PhoneNumber)));

            labelControlAtollIslandCountry.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.AtollIslandCountry)));

            labelControlCin.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Cin)));

            labelControlEpisodeNumber.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.EpisodeNumber)));

            labelControlSite.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Site)));

            labelControlAddress.DataBindings.Add
                (new Binding("Text", _viewModel.SelectedRequestData, nameof(RequestSampleModel.Address)));

            //Clinical Details
            listBoxControlClinicalDetails.DataSource = _viewModel.SelectedClinicalDetails;
            #endregion

            #region Bind Results
            gridControlTests.DataSource = _viewModel.SelectedResultData;
            repositoryItemLookUpEditCodifiedPhrases.DataSource = _viewModel.CodifiedPhrasesForSelectedTest;
            repositoryItemLookUpEditCodifiedPhrases.DisplayMember = nameof(CodifiedResultsModel.CodifiedValue);
            repositoryItemLookUpEditCodifiedPhrases.ValueMember = nameof(CodifiedResultsModel.CodifiedValue);
            #endregion

            #region FiltersAndFunctions

            dateEditLoadWorksheetFrom.DataBindings.Add(new Binding("EditValue", _viewModel, nameof(_viewModel.LoadWorksheetFromDate)));

            //Wire up the datasource for lookUpEditSampleStatusFilter
            lookUpEditSampleStatusFilter.Properties.DataSource = _viewModel.AllStatus;
            lookUpEditSampleStatusFilter.Properties.DisplayMember = nameof(StatusModel.Status);
            lookUpEditSampleStatusFilter.Properties.ValueMember = nameof(StatusModel.Id);

            //bind the enable/disable functionality of "Load Worksheet" button
            simpleButtonLoadWorksheet.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.IsloadWorkSheetButtonEnabled)));
            #endregion

            #region Loading Animations
            progressPanelSamples.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.IsLoadingAnimationEnabled)));
            progressPanelTests.DataBindings.Add(new Binding("Visible", _viewModel, nameof(_viewModel.IsLoadingAnimationEnabled)));
            #endregion
        }

        private void OnSizeChangedAdjustSplitContainers(object sender, EventArgs e)
        {
            //set splitter for adjusting Top (patient) panel
            splitContainerControlPatient.SplitterPosition = 90;

            //set splitter for adjusting functions panel
            var height = this.splitContainerControlFunctions.Size.Height;
            splitContainerControlFunctions.SplitterPosition = (int)((decimal)height - 90m);
        }

    }

    class RowInfo
    {
        public RowInfo(GridView view, int rowHandle)
        {
            this.RowHandle = rowHandle;
            this.View = view;
        }
        public GridView View;
        public int RowHandle;
    }
}