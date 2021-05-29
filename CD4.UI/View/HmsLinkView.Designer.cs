
namespace CD4.UI.View
{
    partial class HmsLinkView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HmsLinkView));
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem2 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControlPatientDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewPatient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnNidPp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBirthdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPatientId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAtoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsland = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.barEditItemMemoNumber = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEditMemoNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barToggleSwitchItemRequestPriority = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlRequestedAnalyses = new DevExpress.XtraGrid.GridControl();
            this.gridViewRequestedAnalyses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnBillItemDetailEntryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnServiceDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPatientDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMemoNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRequestedAnalyses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRequestedAnalyses)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 34);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.progressPanel);
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlPatientDetails);
            this.splitContainerControl.Panel1.Text = "PatientDetails";
            this.splitContainerControl.Panel2.Controls.Add(this.gridControlRequestedAnalyses);
            this.splitContainerControl.Panel2.Text = "AnalysisRequested";
            this.splitContainerControl.Size = new System.Drawing.Size(736, 315);
            this.splitContainerControl.SplitterPosition = 300;
            this.splitContainerControl.TabIndex = 4;
            // 
            // progressPanel
            // 
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.BarAnimationElementThickness = 2;
            this.progressPanel.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanel.Location = new System.Drawing.Point(310, 155);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(18, 18);
            this.progressPanel.TabIndex = 1;
            this.progressPanel.Text = "progressPanel";
            // 
            // gridControlPatientDetails
            // 
            this.gridControlPatientDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPatientDetails.Location = new System.Drawing.Point(0, 0);
            this.gridControlPatientDetails.MainView = this.gridViewPatient;
            this.gridControlPatientDetails.MenuManager = this.barManager;
            this.gridControlPatientDetails.Name = "gridControlPatientDetails";
            this.gridControlPatientDetails.Size = new System.Drawing.Size(431, 315);
            this.gridControlPatientDetails.TabIndex = 0;
            this.gridControlPatientDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPatient});
            // 
            // gridViewPatient
            // 
            this.gridViewPatient.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnNidPp,
            this.gridColumnFullName,
            this.gridColumnGender,
            this.gridColumnBirthdate,
            this.gridColumnPatientId,
            this.gridColumnAddress,
            this.gridColumnAge,
            this.gridColumnAtoll,
            this.gridColumnIsland,
            this.gridColumnPhoneNumber});
            this.gridViewPatient.GridControl = this.gridControlPatientDetails;
            this.gridViewPatient.Name = "gridViewPatient";
            this.gridViewPatient.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnNidPp
            // 
            this.gridColumnNidPp.Caption = "Nat. Id / Passport";
            this.gridColumnNidPp.FieldName = "NidPp";
            this.gridColumnNidPp.Name = "gridColumnNidPp";
            this.gridColumnNidPp.Visible = true;
            this.gridColumnNidPp.VisibleIndex = 1;
            // 
            // gridColumnFullName
            // 
            this.gridColumnFullName.Caption = "Patient Name";
            this.gridColumnFullName.FieldName = "Fullname";
            this.gridColumnFullName.Name = "gridColumnFullName";
            this.gridColumnFullName.Visible = true;
            this.gridColumnFullName.VisibleIndex = 2;
            // 
            // gridColumnGender
            // 
            this.gridColumnGender.Caption = "Gender";
            this.gridColumnGender.FieldName = "Gender";
            this.gridColumnGender.Name = "gridColumnGender";
            this.gridColumnGender.Visible = true;
            this.gridColumnGender.VisibleIndex = 3;
            // 
            // gridColumnBirthdate
            // 
            this.gridColumnBirthdate.Caption = "Birthdate";
            this.gridColumnBirthdate.FieldName = "Birthdate";
            this.gridColumnBirthdate.Name = "gridColumnBirthdate";
            this.gridColumnBirthdate.Visible = true;
            this.gridColumnBirthdate.VisibleIndex = 4;
            // 
            // gridColumnPatientId
            // 
            this.gridColumnPatientId.Caption = "Patient Id";
            this.gridColumnPatientId.FieldName = "InstituteAssignedPatientId";
            this.gridColumnPatientId.Name = "gridColumnPatientId";
            this.gridColumnPatientId.Visible = true;
            this.gridColumnPatientId.VisibleIndex = 0;
            // 
            // gridColumnAddress
            // 
            this.gridColumnAddress.Caption = "Address";
            this.gridColumnAddress.FieldName = "Address";
            this.gridColumnAddress.Name = "gridColumnAddress";
            this.gridColumnAddress.Visible = true;
            this.gridColumnAddress.VisibleIndex = 6;
            // 
            // gridColumnAge
            // 
            this.gridColumnAge.Caption = "Age";
            this.gridColumnAge.FieldName = "Age";
            this.gridColumnAge.Name = "gridColumnAge";
            this.gridColumnAge.Visible = true;
            this.gridColumnAge.VisibleIndex = 5;
            // 
            // gridColumnAtoll
            // 
            this.gridColumnAtoll.Caption = "Atoll";
            this.gridColumnAtoll.FieldName = "Atoll";
            this.gridColumnAtoll.Name = "gridColumnAtoll";
            this.gridColumnAtoll.Visible = true;
            this.gridColumnAtoll.VisibleIndex = 7;
            // 
            // gridColumnIsland
            // 
            this.gridColumnIsland.Caption = "Island";
            this.gridColumnIsland.FieldName = "Island";
            this.gridColumnIsland.Name = "gridColumnIsland";
            this.gridColumnIsland.Visible = true;
            this.gridColumnIsland.VisibleIndex = 8;
            // 
            // gridColumnPhoneNumber
            // 
            this.gridColumnPhoneNumber.Caption = "Phone Number";
            this.gridColumnPhoneNumber.FieldName = "PhoneNumber";
            this.gridColumnPhoneNumber.Name = "gridColumnPhoneNumber";
            this.gridColumnPhoneNumber.Visible = true;
            this.gridColumnPhoneNumber.VisibleIndex = 9;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItemMemoNumber,
            this.barButtonItemImport,
            this.barToggleSwitchItemRequestPriority});
            this.barManager.MaxItemId = 8;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEditMemoNumber});
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemMemoNumber, "", false, true, true, 202),
            new DevExpress.XtraBars.LinkPersistInfo(this.barToggleSwitchItemRequestPriority),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemImport)});
            this.bar.OptionsBar.UseWholeRow = true;
            this.bar.Text = "Tools";
            // 
            // barEditItemMemoNumber
            // 
            this.barEditItemMemoNumber.Caption = "Memo Number";
            this.barEditItemMemoNumber.Edit = this.repositoryItemTextEditMemoNumber;
            this.barEditItemMemoNumber.Id = 2;
            this.barEditItemMemoNumber.Name = "barEditItemMemoNumber";
            toolTipTitleItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage")));
            toolTipTitleItem1.Text = "Scan memo number";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Scan memo number to search for the\r\nanalysis request with test requested.";
            toolTipTitleItem2.LeftIndent = 6;
            toolTipTitleItem2.Text = "HMS Link Search";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            superToolTip1.Items.Add(toolTipSeparatorItem1);
            superToolTip1.Items.Add(toolTipTitleItem2);
            this.barEditItemMemoNumber.SuperTip = superToolTip1;
            // 
            // repositoryItemTextEditMemoNumber
            // 
            this.repositoryItemTextEditMemoNumber.AutoHeight = false;
            this.repositoryItemTextEditMemoNumber.Name = "repositoryItemTextEditMemoNumber";
            this.repositoryItemTextEditMemoNumber.NullText = "Scan memo number here..";
            // 
            // barToggleSwitchItemRequestPriority
            // 
            this.barToggleSwitchItemRequestPriority.Caption = "Request Priority";
            this.barToggleSwitchItemRequestPriority.Id = 7;
            this.barToggleSwitchItemRequestPriority.Name = "barToggleSwitchItemRequestPriority";
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.Caption = "Import";
            this.barButtonItemImport.Id = 3;
            this.barButtonItemImport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemImport.ImageOptions.SvgImage")));
            this.barButtonItemImport.Name = "barButtonItemImport";
            this.barButtonItemImport.ShortcutKeyDisplayString = "Ctrl+I";
            toolTipTitleItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage1")));
            toolTipTitleItem3.Text = "Import Analysis Request";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "This action will import an analyses from\r\nHMS billing to CD4 LIMS, generate and\r\n" +
    "collect samples.";
            toolTipTitleItem4.LeftIndent = 6;
            toolTipTitleItem4.Text = "Prints barcodes for generated samples";
            superToolTip2.Items.Add(toolTipTitleItem3);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipSeparatorItem2);
            superToolTip2.Items.Add(toolTipTitleItem4);
            this.barButtonItemImport.SuperTip = superToolTip2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(736, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 349);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(736, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 315);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(736, 34);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 315);
            // 
            // gridControlRequestedAnalyses
            // 
            this.gridControlRequestedAnalyses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRequestedAnalyses.Location = new System.Drawing.Point(0, 0);
            this.gridControlRequestedAnalyses.MainView = this.gridViewRequestedAnalyses;
            this.gridControlRequestedAnalyses.MenuManager = this.barManager;
            this.gridControlRequestedAnalyses.Name = "gridControlRequestedAnalyses";
            this.gridControlRequestedAnalyses.Size = new System.Drawing.Size(300, 315);
            this.gridControlRequestedAnalyses.TabIndex = 1;
            this.gridControlRequestedAnalyses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRequestedAnalyses});
            // 
            // gridViewRequestedAnalyses
            // 
            this.gridViewRequestedAnalyses.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnBillItemDetailEntryId,
            this.gridColumnServiceCode,
            this.gridColumnServiceDescription});
            this.gridViewRequestedAnalyses.GridControl = this.gridControlRequestedAnalyses;
            this.gridViewRequestedAnalyses.Name = "gridViewRequestedAnalyses";
            this.gridViewRequestedAnalyses.OptionsSelection.MultiSelect = true;
            this.gridViewRequestedAnalyses.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewRequestedAnalyses.OptionsView.ShowGroupPanel = false;
            this.gridViewRequestedAnalyses.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnBillItemDetailEntryId, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnBillItemDetailEntryId
            // 
            this.gridColumnBillItemDetailEntryId.Caption = "#";
            this.gridColumnBillItemDetailEntryId.FieldName = "BillItemDetailEntryId";
            this.gridColumnBillItemDetailEntryId.Name = "gridColumnBillItemDetailEntryId";
            this.gridColumnBillItemDetailEntryId.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridColumnBillItemDetailEntryId.Visible = true;
            this.gridColumnBillItemDetailEntryId.VisibleIndex = 1;
            this.gridColumnBillItemDetailEntryId.Width = 42;
            // 
            // gridColumnServiceCode
            // 
            this.gridColumnServiceCode.Caption = "Code";
            this.gridColumnServiceCode.FieldName = "ItemCode";
            this.gridColumnServiceCode.Name = "gridColumnServiceCode";
            this.gridColumnServiceCode.Visible = true;
            this.gridColumnServiceCode.VisibleIndex = 2;
            this.gridColumnServiceCode.Width = 50;
            // 
            // gridColumnServiceDescription
            // 
            this.gridColumnServiceDescription.Caption = "Service";
            this.gridColumnServiceDescription.FieldName = "ItemDescription";
            this.gridColumnServiceDescription.Name = "gridColumnServiceDescription";
            this.gridColumnServiceDescription.Visible = true;
            this.gridColumnServiceDescription.VisibleIndex = 3;
            this.gridColumnServiceDescription.Width = 157;
            // 
            // HmsLinkView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 349);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HmsLinkView";
            this.Text = "HMS Link";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPatientDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditMemoNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRequestedAnalyses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRequestedAnalyses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarEditItem barEditItemMemoNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditMemoNumber;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlPatientDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPatient;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
        private DevExpress.XtraGrid.GridControl gridControlRequestedAnalyses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRequestedAnalyses;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNidPp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGender;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBirthdate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatientId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAge;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAtoll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsland;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBillItemDetailEntryId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnServiceDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhoneNumber;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItemRequestPriority;
    }
}