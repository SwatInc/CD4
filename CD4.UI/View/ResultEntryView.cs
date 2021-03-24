using CD4.Entensibility.ReportingFramework;
using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using CD4.UI.UiSpecificModels;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        private readonly IResultEntryViewModel _viewModel;
        private readonly IRejectionCommentViewModel _rejectionCommentViewModel;
        private readonly IUserAuthEvaluator _authEvaluator;
        private readonly ILateOrderEntryViewModel _lateOrderEntryViewModel;
        private readonly ILabNotesViewModel _labNotesViewModel;
        private readonly ILoadMultipleExtensions _reportExtensions;
        System.Windows.Forms.Timer dataRefreshTimer = new System.Windows.Forms.Timer() { Enabled = true, Interval = 1000 };

        public event EventHandler<CinAndReportIdModel> GenerateReportByCin;

        public ResultEntryView(IResultEntryViewModel viewModel,
            IRejectionCommentViewModel rejectionCommentViewModel,
            IUserAuthEvaluator authEvaluator,
            ILateOrderEntryViewModel lateOrderEntryViewModel,
            ILabNotesViewModel labNotesViewModel, ILoadMultipleExtensions reportExtensions)
        {
            InitializeComponent();
            //Initialize grid columns
            SetTestGrid_Columns(ResultEntryViewModel.GridControlTestActiveDatasource.Tests);
            SetSampleGrid_Columns(ResultEntryViewModel.GridControlSampleActiveDatasource.Sample);


            _viewModel = viewModel;
            _viewModel.TestHistoryData = new List<TestHistoryModel>();
            _rejectionCommentViewModel = rejectionCommentViewModel;
            _authEvaluator = authEvaluator;
            _lateOrderEntryViewModel = lateOrderEntryViewModel;
            _labNotesViewModel = labNotesViewModel;
            _reportExtensions = reportExtensions;
            InitializeBinding();
            InitializePrintMenu();

            SizeChanged += OnSizeChangedAdjustSplitContainers;
            labelControlCin.DoubleClick += CopyCinToClipBoard;
            gridViewSamples.FocusedRowChanged += SelectedSampleChanged;
            gridViewTests.FocusedRowChanged += SelectedTestChanged;
            gridViewTests.RowCellStyle += GridViewTests_RowCellStyle;
            dataRefreshTimer.Tick += RefreshViewData;
            simpleButtonReport.Click += SimpleButtonReport_Click;
            simpleButtonLoadWorksheet.Click += LoadWorkSheet;
            simpleButtonNotes.Click += ShowSampleNotesDialog;
            exportReportOnDefaultTemplate.Click += exportReportOnDefaultTemplate_Click;
            _viewModel.RequestDataRefreshed += RefreshViewData;
            _viewModel.PushingMessages += _viewModel_PushingMessages;
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
            gridViewSamples.PopupMenuShowing += ShowSamplePopupMenu;
            gridViewTests.PopupMenuShowing += ShowTestPopupMenu;
            KeyUp += ResultEntryView_KeyUp;
            lookUpEditSampleStatusFilter.EditValueChanged += LookUpEditSampleStatusFilter_EditValueChanged;

            ParentChanged += ResultEntryView_ParentChanged;

            gridViewSamples.ColumnFilterChanged += OnSampleSearchComplete_RefreshPatientRibbonAndSelectedTests;
            DisableResultEntryReadWriteAccessForUnauthorizedUsers();
        }

        private void exportReportOnDefaultTemplate_Click(object sender, EventArgs e)
        {

            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ExportReport")) return;
            SimulateMenuClick_DefaultReportExport();
        }

        private void SimulateMenuClick_DefaultReportExport() 
        {
            SimpleButtonReport_Click(new DXMenuItem(), EventArgs.Empty);
        }

        /// <summary>
        /// Initializes print menu depending on the templates avalilable from plug-ins / AR template extensions installed on system
        /// </summary>
        private void InitializePrintMenu()
        {
            var menu = new DXPopupMenu();
            foreach (var template in _reportExtensions.ReportTemplates)
            {
                foreach (var item in template.GetExtensionInformation())
                {
                    if (item.ReportType == ReportType.Barcode) continue;
                    menu.Items.Add(new DXMenuItem(item.TemplateName, SimpleButtonReport_Click) { Tag = item.Index });
                }
            }
            exportReportOnDefaultTemplate.DropDownControl = menu;
        }

        private void DisableResultEntryReadWriteAccessForUnauthorizedUsers()
        {
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntryView.ReadWriteAccess"))
            {
                gridViewTests.OptionsBehavior.Editable = false;
                Text = "Result Entry View [Read Only]";
            };

        }

        private void ShowSampleNotesDialog(object sender, EventArgs e)
        {
            var notesView = new LabNotesView(_labNotesViewModel);
            notesView.SetSampleNumber(((SimpleButton)sender).Tag?.ToString());
            notesView.ShowDialog();
            //_viewModel.GetNotesCountAsync(cin);  this is the actual way..., but I am gonna cheat here. No need for a database call
            _viewModel.SetNotesCountManually(notesView.DialogResult.ToString());
        }

        /// <summary>
        /// Occurs when a column's filter condition changes. This event also raises when the Find Panel finishes its search.
        /// This refreshes the patient details ribbon and selected tests to reflect the newly selected sample on search
        /// </summary>
        private void OnSampleSearchComplete_RefreshPatientRibbonAndSelectedTests(object sender, EventArgs e)
        {
            RefreshPatientPanelAndSelectedSampleTestsManually();
        }

        private void ResultEntryView_ParentChanged(object sender, EventArgs e)
        {
            if (MdiParent is null) return;
            if (MdiParent.GetType() != typeof(MainView)) return;
            var mainView = (MainView)this.MdiParent;
            mainView.SelectedDisciplineChanged += OnDisciplineSwitched;
        }

        private void OnDisciplineSwitched(object sender, int disciplineId)
        {
            Debug.WriteLine("Selected discipline changed to " + disciplineId);
            _viewModel.SelectedDisciplineId = disciplineId;
        }

        /// <summary>
        /// manual UI reaction to view model changes.
        /// </summary>
        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //handle GridControlTest datasource changes
            if (e.PropertyName == nameof(_viewModel.GridTestActiveDatasource))
            {
                ChangeGridControlTestDatasource(_viewModel.GridTestActiveDatasource);
            }

            //handle GridControlSample datasource changes
            if (e.PropertyName == nameof(_viewModel.GridTestActiveDatasource))
            {
                ChangeGridControlSampleDatasource(_viewModel.GridSampleActiveDatasource);
            }
        }

        /// <summary>
        /// Changes the datasource of gridControlTest
        /// </summary>
        /// <param name="gridTestActiveDatasource">Active data source name</param>
        private void ChangeGridControlTestDatasource(ResultEntryViewModel.GridControlTestActiveDatasource gridTestActiveDatasource)
        {
            //exit test history mode if in test history mode.
            switch (gridTestActiveDatasource)
            {
                case ResultEntryViewModel.GridControlTestActiveDatasource.Tests:
                    SetTestGrid_Columns(gridTestActiveDatasource);
                    gridControlTests.DataSource = _viewModel.SelectedResultData;
                    break;
                case ResultEntryViewModel.GridControlTestActiveDatasource.AuditTrail:
                    SetTestGrid_Columns(gridTestActiveDatasource);
                    gridControlTests.DataSource = _viewModel.SampleAuditTrail;
                    break;
                case ResultEntryViewModel.GridControlTestActiveDatasource.None:
                    SetTestGrid_Columns(gridTestActiveDatasource);
                    gridControlTests.DataSource = null;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// toggles controls visibility to show graphUserControl and hide grid control test or vice-versa depending on the IsTestHistoryMode
        /// </summary>
        /// <param name="IsTestHistoryMode">Pass true if state is in test history mode else pass false.</param>
        private void ToggleUiVisibilityToTestHistoryMode(bool IsTestHistoryMode)
        {
            if (IsTestHistoryMode)
            {
                gridControlTests.Visible = false;
                graphsUserControl.Visible = true;
            }

            if (!IsTestHistoryMode)
            {
                gridControlTests.Visible = true;
                graphsUserControl.Visible = false;
            }
        }

        private void ChangeGridControlSampleDatasource(ResultEntryViewModel.GridControlSampleActiveDatasource gridControlSampleActiveDatasource)
        {
            switch (gridControlSampleActiveDatasource)
            {
                case ResultEntryViewModel.GridControlSampleActiveDatasource.Sample:
                    SetSampleGrid_Columns(gridControlSampleActiveDatasource);
                    gridControlSamples.DataSource = _viewModel.RequestData;
                    ToggleUiVisibilityToTestHistoryMode(false);

                    break;
                case ResultEntryViewModel.GridControlSampleActiveDatasource.TestHistory:
                    SetSampleGrid_Columns(gridControlSampleActiveDatasource);
                    gridControlSamples.DataSource = _viewModel.TestHistoryData;
                    ToggleUiVisibilityToTestHistoryMode(true);

                    break;
                default:
                    break;
            }
        }

        private void SetSampleGrid_Columns(ResultEntryViewModel.GridControlSampleActiveDatasource columnType)
        {
            //clear any existing columns
            gridViewSamples.Columns.Clear();
            var gridColumns = new List<GridColumnModel>();

            //select the columns depending on active datasource
            switch (columnType)
            {
                case ResultEntryViewModel.GridControlSampleActiveDatasource.Sample:
                    gridColumns = JsonConvert.DeserializeObject<List<GridColumnModel>>(Properties.Resources.SampleColumns);
                    break;
                case ResultEntryViewModel.GridControlSampleActiveDatasource.TestHistory:
                    gridColumns = JsonConvert.DeserializeObject<List<GridColumnModel>>(Properties.Resources.TestHistoryColumns);
                    break;
                default:
                    break;
            }

            foreach (var column in gridColumns)
            {
                var sampleColumn = new GridColumn
                {
                    Caption = column.Caption,
                    FieldName = column.FieldName,
                    Visible = column.Visible
                };
                sampleColumn.OptionsColumn.AllowEdit = column.AllowEdit;

                if (sampleColumn.Visible)
                {
                    sampleColumn.VisibleIndex = column.VisibleIndex;
                    sampleColumn.Width = column.Width;
                }

                gridViewSamples.Columns.Add(sampleColumn);
            }
        }

        /// <summary>
        /// Clears the gridViewTests, loads column definition for gridViewTests from config and add the columns to grid
        /// </summary>
        private void SetTestGrid_Columns(ResultEntryViewModel.GridControlTestActiveDatasource columnType)
        {
            //clear any existing columns
            gridViewTests.Columns.Clear();
            //dont set new columns if the active data source is set to none
            if (columnType == ResultEntryViewModel.GridControlTestActiveDatasource.None) return;

            //get result columns data from settings
            List<GridColumnModel> gridColumns = new List<GridColumnModel>();
            switch (columnType)
            {
                case ResultEntryViewModel.GridControlTestActiveDatasource.Tests:
                    gridColumns = JsonConvert.DeserializeObject<List<GridColumnModel>>(Properties.Resources.TestColumns);
                    break;
                case ResultEntryViewModel.GridControlTestActiveDatasource.AuditTrail:
                    gridColumns = JsonConvert.DeserializeObject<List<GridColumnModel>>(Properties.Resources.AuditColumns);
                    break;
                default:
                    break;
            }
            foreach (var column in gridColumns)
            {
                var sampleColumn = new GridColumn
                {
                    Caption = column.Caption,
                    FieldName = column.FieldName,
                    Visible = column.Visible,
                    Name = column.Name
                };
                sampleColumn.OptionsColumn.AllowEdit = column.AllowEdit;

                if (sampleColumn.Visible)
                {
                    sampleColumn.VisibleIndex = column.VisibleIndex;
                    sampleColumn.Width = column.Width;
                }

                if (sampleColumn.Name == "gridColumnResult")
                {
                    sampleColumn.ColumnEdit = this.repositoryItemLookUpEditCodifiedPhrases;
                }

                gridViewTests.Columns.Add(sampleColumn);
            }
        }

        /// <summary>
        /// Handles style changes to cells depending on factors like reference range, delta checks QCs
        /// </summary>
        private void GridViewTests_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            //get the reference column value.
            var refCode = (string)(view.GetRowCellValue(e.RowHandle, "ReferenceCode"));

            if (e.Column.FieldName == "Result")
            {

                if (refCode == "NM")
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.FontStyleDelta = FontStyle.Regular;
                }

                if (refCode == "AT")
                {
                    e.Appearance.ForeColor = Color.FromArgb(196, 196, 0); // kinda yellow / not too bright
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }

                if (refCode == "PA")
                {
                    e.Appearance.ForeColor = Color.Brown;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }

                if (refCode == "HP")
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }

                if (refCode == "NA")
                {
                    e.Appearance.ForeColor = Color.Blue;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }

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
                case Keys.F7://validate selected sample on pressing F7

                    //get the selected row handle
                    var selectedRowhandle = gridViewSamples.FocusedRowHandle;
                    //Ignore if no row is selected
                    if (selectedRowhandle >= 0)
                    {
                        //if test not displayed.., return
                        if (_viewModel.GridTestActiveDatasource != ResultEntryViewModel.GridControlTestActiveDatasource.Tests) return;

                        //check if the user is authorised
                        if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ValidateSampleOrTest")) return;

                        //Get the selected sample.
                        var sampleToValidate = (RequestSampleModel)gridViewSamples.GetRow(selectedRowhandle);
                        await _viewModel.ValidateSample(sampleToValidate);
                    }
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
                        //if test not displayed.., return
                        if (_viewModel.GridTestActiveDatasource != ResultEntryViewModel.GridControlTestActiveDatasource.Tests) return;

                        //check if the user is authorised
                        if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ValidateSampleOrTest")) return;

                        //Get selected result model
                        var resultToValidate = (ResultModel)gridViewTests.GetRow(selectedRowHandle);
                        await _viewModel.ValidateTest(resultToValidate);
                    }
                    break;
                case Keys.F12:
                    //if tests for selected sample are not displayed...
                    if (_viewModel.GridTestActiveDatasource != ResultEntryViewModel.GridControlTestActiveDatasource.Tests)
                    {
                        //if datasource is null(testHistory mode), do not try to toggle the datasource
                        if (_viewModel.GridTestActiveDatasource == ResultEntryViewModel.GridControlTestActiveDatasource.None) return;

                        //Toggle view to display tests and return
                        _viewModel.GridTestActiveDatasource = ResultEntryViewModel.GridControlTestActiveDatasource.Tests;
                        return;
                    }

                    //check if the user is authorised
                    if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ViewAuditTrail")) return;

                    //display audit trail for selected sample
                    var senderItem = new DXMenuItem() { Tag = new RowInfo(gridViewSamples, gridViewSamples.FocusedRowHandle) };
                    OnSampleAuditTrailClick(senderItem, EventArgs.Empty);
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
                case Keys.Escape:
                    //if in test history mode, exit test history mode.
                    if (_viewModel.GridSampleActiveDatasource == ResultEntryViewModel.GridControlSampleActiveDatasource.TestHistory)
                    {
                        _viewModel.GridSampleActiveDatasource = ResultEntryViewModel.GridControlSampleActiveDatasource.Sample;
                        _viewModel.GridTestActiveDatasource = ResultEntryViewModel.GridControlTestActiveDatasource.Tests;
                    }

                    break;
                case Keys.Control:
                    break;
                case Keys.Alt:
                    break;
                case Keys.P: //handle Ctrl+P (Print report)

                    if (e.Modifiers == Keys.Control)
                    {
                        //check if the user is authorised
                        if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.PrintReport")) return;

                        SimpleButtonReport_Click(simpleButtonReport, EventArgs.Empty);
                    }
                    break;
                case Keys.E:
                    if (e.Modifiers == Keys.Control)
                    {
                        //check if the user is authorised
                        if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ExportReport")) return;
                        SimulateMenuClick_DefaultReportExport();
                    }
                    break;
                case Keys.Insert:
                    var senderItemForReflexTests = new DXMenuItem()
                    {
                        Tag = new RowInfo(gridViewSamples, gridViewSamples.FocusedRowHandle)
                    };

                    OnAddTestsToSampleAsync(senderItemForReflexTests, EventArgs.Empty);

                    break;
                case Keys.N:
                    if (e.Modifiers == Keys.Control)
                    {
                        //view notes
                        ShowSampleNotesDialog(simpleButtonNotes, EventArgs.Empty);
                    }
                    break;
                case Keys.L:
                    if (e.Modifiers == Keys.Control)
                    {
                        //load worksheet
                        LoadWorkSheet(simpleButtonLoadWorksheet, EventArgs.Empty);
                    }
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
            //this popup menu dhoulf appear only if the sample list is displayed
            if (_viewModel.GridSampleActiveDatasource != ResultEntryViewModel.GridControlSampleActiveDatasource.Sample) return;

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
            //show the menu only if the data displayed is that of results
            if (((GridView)sender).DataSource.GetType() != _viewModel.SelectedResultData.GetType()) return;

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
            menuItems.Add(new DXMenuItem("Reject Sample [ Shift+F11 ]", new EventHandler(OnRejectSampleClickAsync)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Cancel Sample Rejection [ Ctlr+Shift+F11 ]", new EventHandler(OnCancelRejectSampleClickAsync)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Sample Audit Trail [ F12 ]", new EventHandler(OnSampleAuditTrailClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Add Test(s) [ Insert ]", new EventHandler(OnAddTestsToSampleAsync)) { Tag = new RowInfo(view, rowHandle) });
            return menuItems;
        }

        private async void OnAddTestsToSampleAsync(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ReflexTesting")) { return; }


            var sample = GetSampleForMenu(sender, e);
            var resultData = _viewModel.GetResultData(sample.Cin);
            var reflexTestDialog = new LateOrderEntryView(_lateOrderEntryViewModel, resultData)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            reflexTestDialog.ShowDialog();
            if (reflexTestDialog.DialogResult)
            {
                try
                {
                    await _viewModel.RefreshResultDataOnUiAsync(sample.Cin);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }


        }

        private async void OnCancelRejectSampleClickAsync(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.CancelSampleOrTestRejection")) { return; }

            var sample = GetSampleForMenu(sender, e);
            Debug.WriteLine("Cancelling sample rejection: " + sample.Cin);

            if (_viewModel.CanCancelSampleRejection(sample))
            {
                try
                {
                    await _viewModel.CancelSampleRejection(sample.Cin);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot cancel sample rejection since the sample is not rejected or does not have any rejected tests");
            }

        }

        /// <summary>
        /// Fetches and displays sample audit trail on GridControlTests
        /// </summary>
        private async void OnSampleAuditTrailClick(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ViewAuditTrail")) return;

            //get selected item on grid
            var sample = GetSampleForMenu(sender, e);
            try
            {
                //pass to view model to fetch auditTrail
                await _viewModel.GetSampleAuditTrailByCinAsync(sample.Cin);
                //set the audit trail as the datasource on the grid: GridControlTest 
                _viewModel.GridTestActiveDatasource = ResultEntryViewModel.GridControlTestActiveDatasource.AuditTrail;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

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
            menuItems.Add(new DXMenuItem("Cancel Test Validation []", new EventHandler(OnCancelTestValidationClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Reject Test [ Shift+F11 ]", new EventHandler(OnRejectTestClick)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Cancel Test Rejection [ Shift+F11 ]", new EventHandler(OnTestRejectionCancellationClickAsync)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Show test history [  ]", new EventHandler(OnShowTestHistoryClickAsync)) { Tag = new RowInfo(view, rowHandle) });
            menuItems.Add(new DXMenuItem("Show reruns [ F6 ]", new EventHandler(OnShowRerunsClick)) { Tag = new RowInfo(view, rowHandle) });
            return menuItems;
        }

        private async void OnCancelTestValidationClick(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.CancelTestValidation")) return;

            var TestData = GetTestForMenu(sender, e);
            if (_viewModel.CanCancelTestValidation(TestData))
            {
                try
                {
                    await _viewModel.CancelTestValidation(TestData);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error cancelling test validation\n{ex.Message}");
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot cancel test validation!");
            }

        }

        private async void OnTestRejectionCancellationClickAsync(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.CancelSampleOrTestRejection")) return;

            var TestData = GetTestForMenu(sender, e);
            if (_viewModel.CanCancelTestRejection(TestData))
            {
                try
                {
                    await _viewModel.CancelTestRejection(TestData);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error cancelling test rejection\n{ex.Message}");
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot cancel test rejection, the test is not rejected!");
            }

        }

        /// <summary>
        /// call view model to show test reruns
        /// </summary>
        private void OnShowRerunsClick(object sender, EventArgs e)
        {
            XtraMessageBox.Show("This feature has not been implemented yet.\nFeature: Show test Reruns");
        }

        /// <summary>
        /// call view model to show test history
        /// </summary>
        private async void OnShowTestHistoryClickAsync(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ShowTestHistory")) return;

            //shows the loading animation before initiating data access calls. This might take some time.
            _viewModel.IsLoadingAnimationEnabled = true;
            //Get the selected test record.
            var testRecord = GetTestForMenu(sender, e);
            try
            {
                //call view model to request for test history data.
                var data = await _viewModel.GetResultHistoryAsync(testRecord);
                //initialize add data to a new TestHistoryModel required to pass data to graphUserControl
                _viewModel.TestHistoryData.Clear();
                foreach (var item in data)
                {
                    _viewModel.TestHistoryData.Add(new TestHistoryModel()
                    {
                        Number = item.Id,
                        Result = double.Parse(item.Result),
                        ResultDate = item.ResultDate,
                        TestName = testRecord.Test
                    });
                }
                this.graphsUserControl.InitializeChart(_viewModel.TestHistoryData,
                    UserControls.GraphsUserControl.ResultType.Numeric,
                    testRecord.Unit);

                //change sample and test grid datasources
                _viewModel.GridSampleActiveDatasource = ResultEntryViewModel.GridControlSampleActiveDatasource.TestHistory;
                _viewModel.GridTestActiveDatasource = ResultEntryViewModel.GridControlTestActiveDatasource.None;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                _viewModel.IsLoadingAnimationEnabled = false;
            }


        }

        /// <summary>
        /// call the view model to reject the test
        /// </summary>
        private async void OnRejectTestClick(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.RejectSampleOrTest")) return;

            var testToReject = GetTestForMenu(sender, e);
            Debug.WriteLine($"Rejecting Test: {testToReject.Cin}, Test: {testToReject.Test}, Result: {testToReject.Result}");

            //Check whether the test can be rejected
            var canReject = _viewModel.CanRejectTest(testToReject);
            if (!canReject)
            {
                XtraMessageBox.Show($"Test, {testToReject.Test}, cannot be rejected because it is either registered or validated or rejected.");
                return;
            }
            try
            {
                _rejectionCommentViewModel.ReasonType = RejectionReasonType.Test; //assign test rejection reasons from list
                var dialog = new RejectionCommentView(_rejectionCommentViewModel);
                dialog.ShowDialog();
                if (dialog.DialogResult != null)
                {
                    if (dialog.DialogResult > 0)
                    {
                        await _viewModel.RejectTestAsync(testToReject, (int)dialog.DialogResult);
                    }
                }
                dialog.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Call the view model to validate the test
        /// </summary>
        private async void OnValidateTestClick(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ValidateSampleOrTest")) return;

            var testToValidate = GetTestForMenu(sender, e);
            Debug.WriteLine($"validating Test: {testToValidate.Cin}, Test: {testToValidate.Test}, Result: {testToValidate.Result}");

            await _viewModel.ValidateTest(testToValidate);
        }

        /// <summary>
        /// Call the view model to validate the sample
        /// </summary>
        async void OnValidateSampleClick(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.ValidateSampleOrTest")) return;

            var sampleToValidate = GetSampleForMenu(sender, e);
            Debug.WriteLine("validating sample: " + sampleToValidate.Cin);
            //Call the view model to mark the sample and applicable associated tests as validated.
            await _viewModel.ValidateSample(sampleToValidate);
        }

        /// <summary>
        /// Call the view model to reject the sample
        /// </summary>
        async void OnRejectSampleClickAsync(object sender, EventArgs e)
        {
            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.RejectSampleOrTest")) return;

            var sampleToReject = GetSampleForMenu(sender, e);
            Debug.WriteLine("Rejecting sample: " + sampleToReject.Cin);
            //Check whether the sample can be rejected
            var canReject = _viewModel.CanRejectSample(sampleToReject);
            if (!canReject)
            {
                XtraMessageBox.Show($"Sample, {sampleToReject.Cin}, cannot be rejected because it is either registered or validated or rejected.");
                return;
            }
            try
            {
                _rejectionCommentViewModel.ReasonType = RejectionReasonType.Sample;
                var dialog = new RejectionCommentView(_rejectionCommentViewModel);
                dialog.ShowDialog();
                if (dialog.DialogResult != null)
                {
                    if (dialog.DialogResult > 0)
                    {
                        await _viewModel.RejectSampleAsync(sampleToReject.Cin, (int)dialog.DialogResult);
                    }
                }
                dialog.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
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
                RefreshPatientPanelAndSelectedSampleTestsManually();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void RefreshPatientPanelAndSelectedSampleTestsManually()
        {
            SelectedSampleChanged(gridViewSamples, new FocusedRowChangedEventArgs(0, gridViewSamples.FocusedRowHandle));
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

            //check if the user is authorised
            if (!_authEvaluator.IsFunctionAuthorized("ResultEntry.PrintReport")) return;

            if (!DecideToContinuePrinting(cin)) return;

            //get the instance of XtraReport to generate report with..
            var reportId = GetReportIndex(sender);

            if (sender.GetType() == typeof(SimpleButton))
            {
                GenerateReportByCin?.Invoke(this, new CinAndReportIdModel() { Cin = cin, ReportIndex = reportId, Action = ReportActionModel.Print });
            }
            else
            {
                GenerateReportByCin?.Invoke(this, new CinAndReportIdModel() { Cin = cin, ReportIndex = reportId, Action = ReportActionModel.Export });
            }
            //Raise an event indicating that a sample report is requested.
        }

        private int GetReportIndex(object sender)
        {
            // determine whether the initial event is raised by a menu item...
            if (sender.GetType() == typeof(DXMenuItem))
            {
                //if raised by menu, try to get the report Id
                var reportId = ((DXMenuItem)sender).Tag?.ToString();
                var isInt = int.TryParse(reportId, out var parsedReportId);

                //if the report ID is successfully identified, then return the Id....
                if (isInt) { return parsedReportId; }

                //proceed to return default


            }

            if (sender.GetType() == typeof(SimpleButton))
            {
                return 1;
            }

            //try to get the report Id for the default report
            foreach (var template in _reportExtensions.ReportTemplates)
            {
                foreach (var item in template.GetExtensionInformation())
                {
                    if (item.ReportType == ReportType.Barcode) { continue; }

                    //look for a report with a name that contains 'Default'
                    if (item.TemplateName.ToLower().Contains("default")) { return item.Index; }
                }
            }

            throw new Exception("Cannot determine report template to use and, cannot find a template marked as default.");
        }

        private bool DecideToContinuePrinting(string cin)
        {
            var desicion = false;
            //Is the application locally(on workstation) configured to show result alert notifications?
            if (Properties.Resources.IsResultAlertEnabledOnReportPrint != "1") return desicion;

            //Get all test names and results associated with the cin
            var resultData = _viewModel.GetResultData(cin);
            var alertMessages = GetApplicableAlertMessages(resultData);

            //display the messages
            if (!string.IsNullOrEmpty(alertMessages))
            {
                var userResponse = XtraMessageBox.Show($"Result alert notification triggered. Please read the following message(s).\n{alertMessages}"
                    , "Result Print Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, allowHtmlText: DevExpress.Utils.DefaultBoolean.True);
                if (userResponse == DialogResult.Yes) { desicion = true; }
            }
            else
            {
                desicion = true;
            }

            return desicion;
        }

        private string GetApplicableAlertMessages(List<ResultModel> resultData)
        {
            string alertMessages = "";
            foreach (var result in resultData)
            {
                var alertData = ResultAlertModelCollection.ResultAlertData.Find((x) => x.TestName == result.Test);
                if (alertData is null) continue;

                switch (alertData.ResultType)
                {
                    case "CODIFIED":
                        if (alertData.Result == result.Result) { alertMessages += alertData.AlertMessage + "\n"; }
                        break;
                    case "NUMERIC":
                        //remove any possible > or < from the result
                        var processedResult = result.Result.Replace('>', ' ').Replace('<', ' ').Trim();
                        double validatedNumericResult;
                        double validatedNumericResultComparer;

                        var numericResult = double.TryParse(processedResult, out validatedNumericResult);
                        var isCompareResultNumeric = double.TryParse(alertData.Result, out validatedNumericResultComparer);

                        if (!numericResult || !isCompareResultNumeric) continue;

                        switch (alertData.Operator)
                        {
                            case "=":
                                if (validatedNumericResultComparer == validatedNumericResult) { alertMessages += alertData.AlertMessage + "\n"; }
                                break;
                            case ">=":
                                if (validatedNumericResultComparer >= validatedNumericResult) { alertMessages += alertData.AlertMessage + "\n"; }
                                break;
                            case "<":
                                if (validatedNumericResultComparer < validatedNumericResult) { alertMessages += alertData.AlertMessage + "\n"; }
                                break;
                            case "<=":
                                if (validatedNumericResultComparer <= validatedNumericResult) { alertMessages += alertData.AlertMessage + "\n"; }
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }
            }
            return alertMessages;
        }

        /// <summary>
        /// The datagrids does not show view model data without refresh. This method refreshes the view. The is NOT a refresh from database.
        /// </summary>
        private void RefreshViewData(object sender, EventArgs e)
        {
            dataRefreshTimer.Enabled = false;
            gridControlSamples.RefreshDataSource();
            gridControlTests.RefreshDataSource();

            Debug.WriteLine(sender.GetType().FullName);
        }

        private void CopyCinToClipBoard(object sender, EventArgs e)
        {
            Clipboard.SetText(labelControlCin.Text);
        }

        private async void SelectedTestChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if dsplayed data on grid is not tests... return
            if (_viewModel.GridTestActiveDatasource != ResultEntryViewModel.GridControlTestActiveDatasource.Tests) return;
            var selectedTest = (ResultModel)gridViewTests.GetRow(e.FocusedRowHandle);
            await _viewModel.SetTestCodifiedPhrasesAsync(selectedTest);
        }

        private async void SelectedSampleChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //Do not do anything if is test history view mode
            if (gridControlSamples.DataSource != _viewModel.RequestData) return;
            //if tests data is not displayed on tests grid...
            if (_viewModel.GridTestActiveDatasource != ResultEntryViewModel.GridControlTestActiveDatasource.Tests)
            {
                //display tests data on the grid
                _viewModel.GridTestActiveDatasource = ResultEntryViewModel.GridControlTestActiveDatasource.Tests;
            }

            var selectedSample = (RequestSampleModel)gridViewSamples.GetRow(e.FocusedRowHandle);
            try
            {
                await _viewModel.SetSelectedSampleAsync(selectedSample);
                await GetNotesCountAsync(selectedSample?.Cin);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

        }

        public async Task GetNotesCountAsync(string cin)
        {
            if (string.IsNullOrEmpty(cin)) { _viewModel.NotesCountButtonLabel = "View Notes [ 0 ]"; }

            try
            {
                simpleButtonNotes.Tag = cin;
                await _viewModel.GetNotesCountAsync(cin);
            }
            catch (Exception ex)
            {
                _viewModel.NotesCountButtonLabel = "View Notes [ 0 ]";
                XtraMessageBox.Show($"Unable to load sample notes data.\n{ex.Message}");
            }
        }

        /// <summary>
        /// Gets the selected Cin
        /// </summary>
        /// <returns>Returns selected Cin or null</returns>
        private string GetSelectedCin()
        {
            if (gridControlSamples.DataSource != _viewModel.RequestData) return null;
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

            simpleButtonNotes.DataBindings.Add
                (new Binding("Text", _viewModel, nameof(_viewModel.NotesCountButtonLabel), false, DataSourceUpdateMode.OnPropertyChanged));
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
            splitContainerControlFunctions.SplitterPosition = (int)(height - 90m);

            //set splitter for sample and test functions panel
            splitContainerControlSamplesAndTest.SplitterPosition = (int)(0.5 * Width);
        }
    }

    class RowInfo
    {
        public RowInfo(GridView view, int rowHandle)
        {
            RowHandle = rowHandle;
            View = view;
        }
        public GridView View;
        public int RowHandle;
    }
}