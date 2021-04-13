
namespace CD4.UI.View
{
    partial class BatchedNdaTrackingView
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
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlNdaTracking = new DevExpress.XtraGrid.GridControl();
            this.gridViewNdaTracking = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlSearchCriteria = new DevExpress.XtraEditors.GroupControl();
            this.dateEditFromDate = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonLoadTrackingSearchData = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditToDate = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditSampleStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabControlNdaTracking = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageReportDate = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditReportDateForBatch = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonSaveNdaTrackingReportDate = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageCalQcValidated = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditQcCalValidatedUser = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabPageAnalysedBy = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButtonSaveNdaTrackingAnalysedUser = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditAnalysedUser = new DevExpress.XtraEditors.LookUpEdit();
            this.gridColumnPatientId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatusIconId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAnalysedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQcCalvalidatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCollectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnValidatedDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReportedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNdaTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNdaTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSearchCriteria)).BeginInit();
            this.groupControlSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlNdaTracking)).BeginInit();
            this.xtraTabControlNdaTracking.SuspendLayout();
            this.xtraTabPageReportDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDateForBatch.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDateForBatch.Properties)).BeginInit();
            this.xtraTabPageCalQcValidated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditQcCalValidatedUser.Properties)).BeginInit();
            this.xtraTabPageAnalysedBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAnalysedUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Horizontal = false;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlNdaTracking);
            this.splitContainerControl.Panel1.Text = "Grid";
            this.splitContainerControl.Panel2.Controls.Add(this.splitContainerControl1);
            this.splitContainerControl.Panel2.Text = "Functions";
            this.splitContainerControl.Size = new System.Drawing.Size(918, 469);
            this.splitContainerControl.SplitterPosition = 137;
            this.splitContainerControl.TabIndex = 0;
            // 
            // gridControlNdaTracking
            // 
            this.gridControlNdaTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNdaTracking.Location = new System.Drawing.Point(0, 0);
            this.gridControlNdaTracking.MainView = this.gridViewNdaTracking;
            this.gridControlNdaTracking.Name = "gridControlNdaTracking";
            this.gridControlNdaTracking.Size = new System.Drawing.Size(918, 322);
            this.gridControlNdaTracking.TabIndex = 0;
            this.gridControlNdaTracking.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNdaTracking});
            // 
            // gridViewNdaTracking
            // 
            this.gridViewNdaTracking.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPatientId,
            this.gridColumnSid,
            this.gridColumnStatusIconId,
            this.gridColumnStatus,
            this.gridColumnAnalysedBy,
            this.gridColumnQcCalvalidatedBy,
            this.gridColumnCollectedDate,
            this.gridColumnValidatedDateTime,
            this.gridColumnReportedDate});
            this.gridViewNdaTracking.GridControl = this.gridControlNdaTracking;
            this.gridViewNdaTracking.Name = "gridViewNdaTracking";
            this.gridViewNdaTracking.OptionsSelection.MultiSelect = true;
            this.gridViewNdaTracking.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewNdaTracking.OptionsView.RowAutoHeight = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControlSearchCriteria);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlNdaTracking);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(918, 137);
            this.splitContainerControl1.SplitterPosition = 429;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // groupControlSearchCriteria
            // 
            this.groupControlSearchCriteria.Controls.Add(this.dateEditFromDate);
            this.groupControlSearchCriteria.Controls.Add(this.simpleButtonLoadTrackingSearchData);
            this.groupControlSearchCriteria.Controls.Add(this.dateEditToDate);
            this.groupControlSearchCriteria.Controls.Add(this.lookUpEditSampleStatus);
            this.groupControlSearchCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSearchCriteria.Location = new System.Drawing.Point(0, 0);
            this.groupControlSearchCriteria.Name = "groupControlSearchCriteria";
            this.groupControlSearchCriteria.Size = new System.Drawing.Size(429, 137);
            this.groupControlSearchCriteria.TabIndex = 0;
            this.groupControlSearchCriteria.Text = "Search Criteria";
            // 
            // dateEditFromDate
            // 
            this.dateEditFromDate.EditValue = null;
            this.dateEditFromDate.Location = new System.Drawing.Point(22, 34);
            this.dateEditFromDate.Name = "dateEditFromDate";
            this.dateEditFromDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFromDate.Properties.NullText = "Select From date";
            this.dateEditFromDate.Properties.NullValuePrompt = "Select From date";
            this.dateEditFromDate.Properties.NullValuePromptShowForEmptyValue = true;
            this.dateEditFromDate.Size = new System.Drawing.Size(125, 20);
            this.dateEditFromDate.TabIndex = 4;
            // 
            // simpleButtonLoadTrackingSearchData
            // 
            this.simpleButtonLoadTrackingSearchData.Location = new System.Drawing.Point(22, 89);
            this.simpleButtonLoadTrackingSearchData.Name = "simpleButtonLoadTrackingSearchData";
            this.simpleButtonLoadTrackingSearchData.Size = new System.Drawing.Size(107, 23);
            this.simpleButtonLoadTrackingSearchData.TabIndex = 7;
            this.simpleButtonLoadTrackingSearchData.Text = "Load [ Ctrl+L ]";
            // 
            // dateEditToDate
            // 
            this.dateEditToDate.EditValue = null;
            this.dateEditToDate.Location = new System.Drawing.Point(153, 34);
            this.dateEditToDate.Name = "dateEditToDate";
            this.dateEditToDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditToDate.Properties.NullText = "Select To date";
            this.dateEditToDate.Properties.NullValuePrompt = "Select To date";
            this.dateEditToDate.Properties.NullValuePromptShowForEmptyValue = true;
            this.dateEditToDate.Properties.ShowNullValuePromptWhenFocused = true;
            this.dateEditToDate.Size = new System.Drawing.Size(125, 20);
            this.dateEditToDate.TabIndex = 5;
            // 
            // lookUpEditSampleStatus
            // 
            this.lookUpEditSampleStatus.Location = new System.Drawing.Point(22, 60);
            this.lookUpEditSampleStatus.Name = "lookUpEditSampleStatus";
            this.lookUpEditSampleStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSampleStatus.Properties.NullText = "Please select sample status";
            this.lookUpEditSampleStatus.Properties.NullValuePrompt = "Please select sample status";
            this.lookUpEditSampleStatus.Size = new System.Drawing.Size(256, 20);
            this.lookUpEditSampleStatus.TabIndex = 6;
            // 
            // xtraTabControlNdaTracking
            // 
            this.xtraTabControlNdaTracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlNdaTracking.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlNdaTracking.Name = "xtraTabControlNdaTracking";
            this.xtraTabControlNdaTracking.SelectedTabPage = this.xtraTabPageReportDate;
            this.xtraTabControlNdaTracking.Size = new System.Drawing.Size(479, 137);
            this.xtraTabControlNdaTracking.TabIndex = 0;
            this.xtraTabControlNdaTracking.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageReportDate,
            this.xtraTabPageCalQcValidated,
            this.xtraTabPageAnalysedBy});
            // 
            // xtraTabPageReportDate
            // 
            this.xtraTabPageReportDate.Controls.Add(this.labelControl1);
            this.xtraTabPageReportDate.Controls.Add(this.dateEditReportDateForBatch);
            this.xtraTabPageReportDate.Controls.Add(this.simpleButtonSaveNdaTrackingReportDate);
            this.xtraTabPageReportDate.Name = "xtraTabPageReportDate";
            this.xtraTabPageReportDate.Size = new System.Drawing.Size(477, 108);
            this.xtraTabPageReportDate.Text = "Report Date";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(394, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Please select the date to be set as \"Report date\" on DoA Report for the batch";
            // 
            // dateEditReportDateForBatch
            // 
            this.dateEditReportDateForBatch.EditValue = null;
            this.dateEditReportDateForBatch.Location = new System.Drawing.Point(14, 40);
            this.dateEditReportDateForBatch.Name = "dateEditReportDateForBatch";
            this.dateEditReportDateForBatch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDateForBatch.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditReportDateForBatch.Properties.NullText = "Select report date...";
            this.dateEditReportDateForBatch.Properties.NullValuePrompt = "Select report date...";
            this.dateEditReportDateForBatch.Size = new System.Drawing.Size(241, 20);
            this.dateEditReportDateForBatch.TabIndex = 9;
            // 
            // simpleButtonSaveNdaTrackingReportDate
            // 
            this.simpleButtonSaveNdaTrackingReportDate.Location = new System.Drawing.Point(14, 66);
            this.simpleButtonSaveNdaTrackingReportDate.Name = "simpleButtonSaveNdaTrackingReportDate";
            this.simpleButtonSaveNdaTrackingReportDate.Size = new System.Drawing.Size(107, 23);
            this.simpleButtonSaveNdaTrackingReportDate.TabIndex = 8;
            this.simpleButtonSaveNdaTrackingReportDate.Text = "Save [ Ctrl+S ]";
            // 
            // xtraTabPageCalQcValidated
            // 
            this.xtraTabPageCalQcValidated.Controls.Add(this.simpleButtonSaveNdaTrackingQcCalValidatedUser);
            this.xtraTabPageCalQcValidated.Controls.Add(this.labelControl2);
            this.xtraTabPageCalQcValidated.Controls.Add(this.lookUpEditQcCalValidatedUser);
            this.xtraTabPageCalQcValidated.Name = "xtraTabPageCalQcValidated";
            this.xtraTabPageCalQcValidated.Size = new System.Drawing.Size(477, 108);
            this.xtraTabPageCalQcValidated.Text = "Cal and QC Validated By";
            // 
            // simpleButtonSaveNdaTrackingQcCalValidatedUser
            // 
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser.Location = new System.Drawing.Point(14, 66);
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser.Name = "simpleButtonSaveNdaTrackingQcCalValidatedUser";
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser.Size = new System.Drawing.Size(107, 23);
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser.TabIndex = 12;
            this.simpleButtonSaveNdaTrackingQcCalValidatedUser.Text = "Save [ Ctrl+S ]";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(402, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Please select the user who validated QC and calibrations for the current batch.";
            // 
            // lookUpEditQcCalValidatedUser
            // 
            this.lookUpEditQcCalValidatedUser.Location = new System.Drawing.Point(14, 40);
            this.lookUpEditQcCalValidatedUser.Name = "lookUpEditQcCalValidatedUser";
            this.lookUpEditQcCalValidatedUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditQcCalValidatedUser.Properties.NullText = "Select user...";
            this.lookUpEditQcCalValidatedUser.Size = new System.Drawing.Size(241, 20);
            this.lookUpEditQcCalValidatedUser.TabIndex = 1;
            // 
            // xtraTabPageAnalysedBy
            // 
            this.xtraTabPageAnalysedBy.Controls.Add(this.simpleButtonSaveNdaTrackingAnalysedUser);
            this.xtraTabPageAnalysedBy.Controls.Add(this.labelControl3);
            this.xtraTabPageAnalysedBy.Controls.Add(this.lookUpEditAnalysedUser);
            this.xtraTabPageAnalysedBy.Name = "xtraTabPageAnalysedBy";
            this.xtraTabPageAnalysedBy.Size = new System.Drawing.Size(477, 108);
            this.xtraTabPageAnalysedBy.Text = "Analysed By";
            // 
            // simpleButtonSaveNdaTrackingAnalysedUser
            // 
            this.simpleButtonSaveNdaTrackingAnalysedUser.Location = new System.Drawing.Point(14, 66);
            this.simpleButtonSaveNdaTrackingAnalysedUser.Name = "simpleButtonSaveNdaTrackingAnalysedUser";
            this.simpleButtonSaveNdaTrackingAnalysedUser.Size = new System.Drawing.Size(107, 23);
            this.simpleButtonSaveNdaTrackingAnalysedUser.TabIndex = 15;
            this.simpleButtonSaveNdaTrackingAnalysedUser.Text = "Save [ Ctrl+S ]";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(367, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Please select the user who processed the samples for the current batch.";
            // 
            // lookUpEditAnalysedUser
            // 
            this.lookUpEditAnalysedUser.Location = new System.Drawing.Point(14, 40);
            this.lookUpEditAnalysedUser.Name = "lookUpEditAnalysedUser";
            this.lookUpEditAnalysedUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAnalysedUser.Properties.NullText = "Select user...";
            this.lookUpEditAnalysedUser.Size = new System.Drawing.Size(241, 20);
            this.lookUpEditAnalysedUser.TabIndex = 13;
            // 
            // gridColumnPatientId
            // 
            this.gridColumnPatientId.Caption = "Patient ID";
            this.gridColumnPatientId.FieldName = "InstituteAssignedPatientId";
            this.gridColumnPatientId.Name = "gridColumnPatientId";
            this.gridColumnPatientId.Visible = true;
            this.gridColumnPatientId.VisibleIndex = 1;
            // 
            // gridColumnSid
            // 
            this.gridColumnSid.Caption = "Sample ID";
            this.gridColumnSid.FieldName = "Cin";
            this.gridColumnSid.Name = "gridColumnSid";
            this.gridColumnSid.Visible = true;
            this.gridColumnSid.VisibleIndex = 2;
            // 
            // gridColumnStatusIconId
            // 
            this.gridColumnStatusIconId.FieldName = "StatusIconId";
            this.gridColumnStatusIconId.Name = "gridColumnStatusIconId";
            // 
            // gridColumnStatus
            // 
            this.gridColumnStatus.Caption = "Status";
            this.gridColumnStatus.FieldName = "Status";
            this.gridColumnStatus.Name = "gridColumnStatus";
            this.gridColumnStatus.Visible = true;
            this.gridColumnStatus.VisibleIndex = 3;
            // 
            // gridColumnAnalysedBy
            // 
            this.gridColumnAnalysedBy.Caption = "Analysed By";
            this.gridColumnAnalysedBy.FieldName = "AnalysedBy";
            this.gridColumnAnalysedBy.Name = "gridColumnAnalysedBy";
            this.gridColumnAnalysedBy.Visible = true;
            this.gridColumnAnalysedBy.VisibleIndex = 4;
            // 
            // gridColumnQcCalvalidatedBy
            // 
            this.gridColumnQcCalvalidatedBy.Caption = "QC & Cal Val. user";
            this.gridColumnQcCalvalidatedBy.FieldName = "CalQcValidatedBy";
            this.gridColumnQcCalvalidatedBy.Name = "gridColumnQcCalvalidatedBy";
            this.gridColumnQcCalvalidatedBy.Visible = true;
            this.gridColumnQcCalvalidatedBy.VisibleIndex = 5;
            // 
            // gridColumnCollectedDate
            // 
            this.gridColumnCollectedDate.Caption = "Collected Date";
            this.gridColumnCollectedDate.FieldName = "CollectedDate";
            this.gridColumnCollectedDate.Name = "gridColumnCollectedDate";
            this.gridColumnCollectedDate.Visible = true;
            this.gridColumnCollectedDate.VisibleIndex = 6;
            // 
            // gridColumnValidatedDateTime
            // 
            this.gridColumnValidatedDateTime.Caption = "Validated Date";
            this.gridColumnValidatedDateTime.FieldName = "ValidatedDateTime";
            this.gridColumnValidatedDateTime.Name = "gridColumnValidatedDateTime";
            this.gridColumnValidatedDateTime.Visible = true;
            this.gridColumnValidatedDateTime.VisibleIndex = 7;
            // 
            // gridColumnReportedDate
            // 
            this.gridColumnReportedDate.Caption = "Reported Date";
            this.gridColumnReportedDate.FieldName = "ReportedDate";
            this.gridColumnReportedDate.Name = "gridColumnReportedDate";
            this.gridColumnReportedDate.Visible = true;
            this.gridColumnReportedDate.VisibleIndex = 8;
            // 
            // BatchedNdaTrackingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 469);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "BatchedNdaTrackingView";
            this.Text = "Batched NDA Tracking";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNdaTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNdaTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSearchCriteria)).EndInit();
            this.groupControlSearchCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlNdaTracking)).EndInit();
            this.xtraTabControlNdaTracking.ResumeLayout(false);
            this.xtraTabPageReportDate.ResumeLayout(false);
            this.xtraTabPageReportDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDateForBatch.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditReportDateForBatch.Properties)).EndInit();
            this.xtraTabPageCalQcValidated.ResumeLayout(false);
            this.xtraTabPageCalQcValidated.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditQcCalValidatedUser.Properties)).EndInit();
            this.xtraTabPageAnalysedBy.ResumeLayout(false);
            this.xtraTabPageAnalysedBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAnalysedUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraGrid.GridControl gridControlNdaTracking;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNdaTracking;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControlSearchCriteria;
        private DevExpress.XtraEditors.DateEdit dateEditFromDate;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLoadTrackingSearchData;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSampleStatus;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlNdaTracking;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageReportDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateEditReportDateForBatch;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveNdaTrackingReportDate;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageCalQcValidated;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveNdaTrackingQcCalValidatedUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAnalysedBy;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSaveNdaTrackingAnalysedUser;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditToDate;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditQcCalValidatedUser;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAnalysedUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPatientId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatusIconId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAnalysedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQcCalvalidatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCollectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnValidatedDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReportedDate;
    }
}