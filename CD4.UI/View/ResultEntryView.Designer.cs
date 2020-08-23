﻿using DevExpress.XtraEditors;

namespace CD4.UI.View
{
    partial class ResultEntryView
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

            this.labelControlNationalId = new DevExpress.XtraEditors.LabelControl();
            this.labelControlAgeSex = new DevExpress.XtraEditors.LabelControl();
            this.labelControlBirthdate = new DevExpress.XtraEditors.LabelControl();
            this.labelControlPhoneNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControlAddress = new DevExpress.XtraEditors.LabelControl();
            this.labelControlAtollIslandCountry = new DevExpress.XtraEditors.LabelControl();
            this.labelControlEpisodeNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCin = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSite = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControlPatient = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlSelectedPatientRequestClinicalDetailsArea = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlClinicalDetails = new DevExpress.XtraEditors.ListBoxControl();
            this.splitContainerControlFunctions = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlSamplesAndTest = new DevExpress.XtraEditors.SplitContainerControl();
            this.progressPanelSamples = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControlSamples = new DevExpress.XtraGrid.GridControl();
            this.gridViewSamples = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCollectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSequence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSampleStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.progressPanelTests = new DevExpress.XtraWaitForm.ProgressPanel();
            this.gridControlTests = new DevExpress.XtraGrid.GridControl();
            this.gridViewTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditCodifiedPhrases = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumnStatusIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReferenceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsDeltaOk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlFunctions = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditSampleStatusFilter = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButtonLoadWorksheet = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEditLoadWorksheetFrom = new DevExpress.XtraEditors.DateEdit();
            this.simpleButtonReport = new DevExpress.XtraEditors.SimpleButton();
            labelControlPatientName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPatient)).BeginInit();
            this.splitContainerControlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedPatientRequestClinicalDetailsArea)).BeginInit();
            this.groupControlSelectedPatientRequestClinicalDetailsArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlClinicalDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlFunctions)).BeginInit();
            this.splitContainerControlFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlSamplesAndTest)).BeginInit();
            this.splitContainerControlSamplesAndTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCodifiedPhrases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).BeginInit();
            this.groupControlFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleStatusFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLoadWorksheetFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLoadWorksheetFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlNationalId
            // 
            this.labelControlNationalId.Location = new System.Drawing.Point(12, 50);
            this.labelControlNationalId.Name = "labelControlNationalId";
            this.labelControlNationalId.Size = new System.Drawing.Size(49, 13);
            this.labelControlNationalId.TabIndex = 1;
            this.labelControlNationalId.Text = "NationalId";
            // 
            // labelControlAgeSex
            // 
            this.labelControlAgeSex.Location = new System.Drawing.Point(12, 69);
            this.labelControlAgeSex.Name = "labelControlAgeSex";
            this.labelControlAgeSex.Size = new System.Drawing.Size(47, 13);
            this.labelControlAgeSex.TabIndex = 2;
            this.labelControlAgeSex.Text = "Age / Sex";
            // 
            // labelControlBirthdate
            // 
            this.labelControlBirthdate.Location = new System.Drawing.Point(167, 50);
            this.labelControlBirthdate.Name = "labelControlBirthdate";
            this.labelControlBirthdate.Size = new System.Drawing.Size(44, 13);
            this.labelControlBirthdate.TabIndex = 3;
            this.labelControlBirthdate.Text = "Birthdate";
            // 
            // labelControlPhoneNumber
            // 
            this.labelControlPhoneNumber.Location = new System.Drawing.Point(167, 69);
            this.labelControlPhoneNumber.Name = "labelControlPhoneNumber";
            this.labelControlPhoneNumber.Size = new System.Drawing.Size(67, 13);
            this.labelControlPhoneNumber.TabIndex = 4;
            this.labelControlPhoneNumber.Text = "PhoneNumber";
            // 
            // labelControlAddress
            // 
            this.labelControlAddress.Location = new System.Drawing.Point(280, 50);
            this.labelControlAddress.Name = "labelControlAddress";
            this.labelControlAddress.Size = new System.Drawing.Size(39, 13);
            this.labelControlAddress.TabIndex = 5;
            this.labelControlAddress.Text = "Address";
            // 
            // labelControlAtollIslandCountry
            // 
            this.labelControlAtollIslandCountry.Location = new System.Drawing.Point(280, 69);
            this.labelControlAtollIslandCountry.Name = "labelControlAtollIslandCountry";
            this.labelControlAtollIslandCountry.Size = new System.Drawing.Size(103, 13);
            this.labelControlAtollIslandCountry.TabIndex = 6;
            this.labelControlAtollIslandCountry.Text = "Atoll, Island, Country";
            // 
            // labelControlEpisodeNumber
            // 
            this.labelControlEpisodeNumber.Location = new System.Drawing.Point(472, 50);
            this.labelControlEpisodeNumber.Name = "labelControlEpisodeNumber";
            this.labelControlEpisodeNumber.Size = new System.Drawing.Size(74, 13);
            this.labelControlEpisodeNumber.TabIndex = 8;
            this.labelControlEpisodeNumber.Text = "EpisodeNumber";
            // 
            // labelControlCin
            // 
            this.labelControlCin.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlCin.Appearance.Options.UseFont = true;
            this.labelControlCin.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlCin.AppearanceDisabled.Options.UseFont = true;
            this.labelControlCin.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlCin.AppearanceHovered.Options.UseFont = true;
            this.labelControlCin.AppearancePressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelControlCin.AppearancePressed.Options.UseFont = true;
            this.labelControlCin.Location = new System.Drawing.Point(472, 23);
            this.labelControlCin.Name = "labelControlCin";
            this.labelControlCin.Size = new System.Drawing.Size(107, 21);
            this.labelControlCin.TabIndex = 10;
            this.labelControlCin.Text = "SELECTED CIN";
            // 
            // labelControlSite
            // 
            this.labelControlSite.Location = new System.Drawing.Point(472, 69);
            this.labelControlSite.Name = "labelControlSite";
            this.labelControlSite.Size = new System.Drawing.Size(18, 13);
            this.labelControlSite.TabIndex = 11;
            this.labelControlSite.Text = "Site";
            // 
            // splitContainerControlPatient
            // 
            this.splitContainerControlPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlPatient.Horizontal = false;
            this.splitContainerControlPatient.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlPatient.Name = "splitContainerControlPatient";
            this.splitContainerControlPatient.Panel1.Controls.Add(this.groupControlSelectedPatientRequestClinicalDetailsArea);
            this.splitContainerControlPatient.Panel1.Text = "Panel1";
            this.splitContainerControlPatient.Panel2.Controls.Add(this.splitContainerControlFunctions);
            this.splitContainerControlPatient.Panel2.Text = "Panel2";
            this.splitContainerControlPatient.Size = new System.Drawing.Size(839, 401);
            this.splitContainerControlPatient.SplitterPosition = 90;
            this.splitContainerControlPatient.TabIndex = 0;
            // 
            // groupControlSelectedPatientRequestClinicalDetailsArea
            // 
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlSite);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlCin);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.listBoxControlClinicalDetails);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlEpisodeNumber);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlAtollIslandCountry);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlAddress);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlPhoneNumber);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlBirthdate);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlAgeSex);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.labelControlNationalId);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlPatientName);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Location = new System.Drawing.Point(0, 0);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Name = "groupControlSelectedPatientRequestClinicalDetailsArea";
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Size = new System.Drawing.Size(839, 90);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.TabIndex = 0;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Text = "Selected Patient, Request and Clinical Details Information";
            // 
            // listBoxControlClinicalDetails
            // 
            this.listBoxControlClinicalDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxControlClinicalDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxControlClinicalDetails.Appearance.Options.UseBackColor = true;
            this.listBoxControlClinicalDetails.HorizontalScrollbar = true;
            this.listBoxControlClinicalDetails.Location = new System.Drawing.Point(613, 21);
            this.listBoxControlClinicalDetails.Name = "listBoxControlClinicalDetails";
            this.listBoxControlClinicalDetails.Size = new System.Drawing.Size(223, 66);
            this.listBoxControlClinicalDetails.TabIndex = 9;
            // 
            // labelControlPatientName
            // 
            labelControlPatientName.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.Appearance.Options.UseFont = true;
            labelControlPatientName.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearanceDisabled.Options.UseFont = true;
            labelControlPatientName.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearanceHovered.Options.UseFont = true;
            labelControlPatientName.AppearancePressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearancePressed.Options.UseFont = true;
            labelControlPatientName.Location = new System.Drawing.Point(12, 23);
            labelControlPatientName.Name = "labelControlPatientName";
            labelControlPatientName.Size = new System.Drawing.Size(118, 21);
            labelControlPatientName.TabIndex = 0;
            labelControlPatientName.Text = "PATIENT NAME";
            // 
            // splitContainerControlFunctions
            // 
            this.splitContainerControlFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlFunctions.Horizontal = false;
            this.splitContainerControlFunctions.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlFunctions.Name = "splitContainerControlFunctions";
            this.splitContainerControlFunctions.Panel1.Controls.Add(this.splitContainerControlSamplesAndTest);
            this.splitContainerControlFunctions.Panel1.Text = "Panel1";
            this.splitContainerControlFunctions.Panel2.Controls.Add(this.groupControlFunctions);
            this.splitContainerControlFunctions.Panel2.Text = "Panel2";
            this.splitContainerControlFunctions.Size = new System.Drawing.Size(839, 306);
            this.splitContainerControlFunctions.SplitterPosition = 224;
            this.splitContainerControlFunctions.TabIndex = 0;
            // 
            // splitContainerControlSamplesAndTest
            // 
            this.splitContainerControlSamplesAndTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlSamplesAndTest.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlSamplesAndTest.Name = "splitContainerControlSamplesAndTest";
            this.splitContainerControlSamplesAndTest.Panel1.Controls.Add(this.progressPanelSamples);
            this.splitContainerControlSamplesAndTest.Panel1.Controls.Add(this.gridControlSamples);
            this.splitContainerControlSamplesAndTest.Panel1.Text = "Panel1";
            this.splitContainerControlSamplesAndTest.Panel2.Controls.Add(this.progressPanelTests);
            this.splitContainerControlSamplesAndTest.Panel2.Controls.Add(this.gridControlTests);
            this.splitContainerControlSamplesAndTest.Panel2.Text = "Panel2";
            this.splitContainerControlSamplesAndTest.Size = new System.Drawing.Size(839, 224);
            this.splitContainerControlSamplesAndTest.SplitterPosition = 400;
            this.splitContainerControlSamplesAndTest.TabIndex = 0;
            // 
            // progressPanelSamples
            // 
            this.progressPanelSamples.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelSamples.Appearance.Options.UseBackColor = true;
            this.progressPanelSamples.BarAnimationElementThickness = 2;
            this.progressPanelSamples.Caption = "Please Wait";
            this.progressPanelSamples.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelSamples.Description = "Loading samples ...";
            this.progressPanelSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanelSamples.Location = new System.Drawing.Point(0, 0);
            this.progressPanelSamples.Name = "progressPanelSamples";
            this.progressPanelSamples.Size = new System.Drawing.Size(400, 224);
            this.progressPanelSamples.TabIndex = 2;
            // 
            // gridControlSamples
            // 
            this.gridControlSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSamples.Location = new System.Drawing.Point(0, 0);
            this.gridControlSamples.MainView = this.gridViewSamples;
            this.gridControlSamples.Name = "gridControlSamples";
            this.gridControlSamples.Size = new System.Drawing.Size(400, 224);
            this.gridControlSamples.TabIndex = 1;
            this.gridControlSamples.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSamples});
            // 
            // gridViewSamples
            // 
            this.gridViewSamples.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCin,
            this.gridColumnReceivedDate,
            this.gridColumnCollectedDate,
            this.gridColumnSequence,
            this.gridColumnSampleStatus});
            this.gridViewSamples.GridControl = this.gridControlSamples;
            this.gridViewSamples.Name = "gridViewSamples";
            this.gridViewSamples.OptionsBehavior.Editable = false;
            // 
            // gridColumnCin
            // 
            this.gridColumnCin.Caption = "CIN";
            this.gridColumnCin.FieldName = "Cin";
            this.gridColumnCin.Name = "gridColumnCin";
            this.gridColumnCin.Visible = true;
            this.gridColumnCin.VisibleIndex = 2;
            this.gridColumnCin.Width = 100;
            // 
            // gridColumnReceivedDate
            // 
            this.gridColumnReceivedDate.Caption = "Rec. Date";
            this.gridColumnReceivedDate.FieldName = "ReceivedDate";
            this.gridColumnReceivedDate.Name = "gridColumnReceivedDate";
            this.gridColumnReceivedDate.Visible = true;
            this.gridColumnReceivedDate.VisibleIndex = 3;
            this.gridColumnReceivedDate.Width = 100;
            // 
            // gridColumnCollectedDate
            // 
            this.gridColumnCollectedDate.Caption = "Col. Date";
            this.gridColumnCollectedDate.FieldName = "CollectionDate";
            this.gridColumnCollectedDate.Name = "gridColumnCollectedDate";
            this.gridColumnCollectedDate.Visible = true;
            this.gridColumnCollectedDate.VisibleIndex = 4;
            this.gridColumnCollectedDate.Width = 110;
            // 
            // gridColumnSequence
            // 
            this.gridColumnSequence.Caption = "Seq.";
            this.gridColumnSequence.FieldName = "Id";
            this.gridColumnSequence.Name = "gridColumnSequence";
            this.gridColumnSequence.Visible = true;
            this.gridColumnSequence.VisibleIndex = 0;
            this.gridColumnSequence.Width = 40;
            // 
            // gridColumnSampleStatus
            // 
            this.gridColumnSampleStatus.Caption = " ";
            this.gridColumnSampleStatus.FieldName = "StatusIcon";
            this.gridColumnSampleStatus.Name = "gridColumnSampleStatus";
            this.gridColumnSampleStatus.Visible = true;
            this.gridColumnSampleStatus.VisibleIndex = 1;
            this.gridColumnSampleStatus.Width = 32;
            // 
            // progressPanelTests
            // 
            this.progressPanelTests.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelTests.Appearance.Options.UseBackColor = true;
            this.progressPanelTests.BarAnimationElementThickness = 2;
            this.progressPanelTests.Caption = "Please Wait";
            this.progressPanelTests.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelTests.Description = "Loading tests ...";
            this.progressPanelTests.Location = new System.Drawing.Point(230, 134);
            this.progressPanelTests.Name = "progressPanelTests";
            this.progressPanelTests.Size = new System.Drawing.Size(204, 90);
            this.progressPanelTests.TabIndex = 3;
            // 
            // gridControlTests
            // 
            this.gridControlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTests.Location = new System.Drawing.Point(0, 0);
            this.gridControlTests.MainView = this.gridViewTests;
            this.gridControlTests.Name = "gridControlTests";
            this.gridControlTests.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditCodifiedPhrases});
            this.gridControlTests.Size = new System.Drawing.Size(434, 224);
            this.gridControlTests.TabIndex = 0;
            this.gridControlTests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTests});
            // 
            // gridViewTests
            // 
            this.gridViewTests.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTestName,
            this.gridColumnResult,
            this.gridColumnStatusIcon,
            this.gridColumnUnit,
            this.gridColumnReferenceCode,
            this.gridColumnIsDeltaOk});
            this.gridViewTests.GridControl = this.gridControlTests;
            this.gridViewTests.Name = "gridViewTests";
            this.gridViewTests.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnTestName
            // 
            this.gridColumnTestName.Caption = "Test";
            this.gridColumnTestName.FieldName = "Test";
            this.gridColumnTestName.Name = "gridColumnTestName";
            this.gridColumnTestName.OptionsColumn.AllowEdit = false;
            this.gridColumnTestName.Visible = true;
            this.gridColumnTestName.VisibleIndex = 0;
            this.gridColumnTestName.Width = 109;
            // 
            // gridColumnResult
            // 
            this.gridColumnResult.Caption = "Result";
            this.gridColumnResult.ColumnEdit = this.repositoryItemLookUpEditCodifiedPhrases;
            this.gridColumnResult.FieldName = "Result";
            this.gridColumnResult.Name = "gridColumnResult";
            this.gridColumnResult.Visible = true;
            this.gridColumnResult.VisibleIndex = 2;
            this.gridColumnResult.Width = 101;
            // 
            // repositoryItemLookUpEditCodifiedPhrases
            // 
            this.repositoryItemLookUpEditCodifiedPhrases.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemLookUpEditCodifiedPhrases.AutoHeight = false;
            this.repositoryItemLookUpEditCodifiedPhrases.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditCodifiedPhrases.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodifiedValue", "Codified Values")});
            this.repositoryItemLookUpEditCodifiedPhrases.Name = "repositoryItemLookUpEditCodifiedPhrases";
            this.repositoryItemLookUpEditCodifiedPhrases.NullText = "";
            this.repositoryItemLookUpEditCodifiedPhrases.ShowHeader = false;
            this.repositoryItemLookUpEditCodifiedPhrases.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // gridColumnStatusIcon
            // 
            this.gridColumnStatusIcon.Caption = " ";
            this.gridColumnStatusIcon.FieldName = "StatusIcon";
            this.gridColumnStatusIcon.Name = "gridColumnStatusIcon";
            this.gridColumnStatusIcon.Visible = true;
            this.gridColumnStatusIcon.VisibleIndex = 1;
            this.gridColumnStatusIcon.Width = 36;
            // 
            // gridColumnUnit
            // 
            this.gridColumnUnit.Caption = "Unit";
            this.gridColumnUnit.FieldName = "Unit";
            this.gridColumnUnit.Name = "gridColumnUnit";
            this.gridColumnUnit.Visible = true;
            this.gridColumnUnit.VisibleIndex = 3;
            this.gridColumnUnit.Width = 170;
            // 
            // gridColumnReferenceCode
            // 
            this.gridColumnReferenceCode.Caption = "Ref. Code";
            this.gridColumnReferenceCode.FieldName = "ReferenceCode";
            this.gridColumnReferenceCode.Name = "gridColumnReferenceCode";
            this.gridColumnReferenceCode.Visible = true;
            this.gridColumnReferenceCode.VisibleIndex = 4;
            // 
            // gridColumnIsDeltaOk
            // 
            this.gridColumnIsDeltaOk.Caption = "Is Delta OK";
            this.gridColumnIsDeltaOk.FieldName = "IsDeltaOk";
            this.gridColumnIsDeltaOk.Name = "gridColumnIsDeltaOk";
            // 
            // groupControlFunctions
            // 
            this.groupControlFunctions.Controls.Add(this.lookUpEditSampleStatusFilter);
            this.groupControlFunctions.Controls.Add(this.simpleButtonLoadWorksheet);
            this.groupControlFunctions.Controls.Add(this.label1);
            this.groupControlFunctions.Controls.Add(this.dateEditLoadWorksheetFrom);
            this.groupControlFunctions.Controls.Add(this.simpleButtonReport);
            this.groupControlFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlFunctions.Location = new System.Drawing.Point(0, 0);
            this.groupControlFunctions.Name = "groupControlFunctions";
            this.groupControlFunctions.Size = new System.Drawing.Size(839, 77);
            this.groupControlFunctions.TabIndex = 1;
            this.groupControlFunctions.Text = "Functions";
            // 
            // lookUpEditSampleStatusFilter
            // 
            this.lookUpEditSampleStatusFilter.Location = new System.Drawing.Point(193, 45);
            this.lookUpEditSampleStatusFilter.Name = "lookUpEditSampleStatusFilter";
            this.lookUpEditSampleStatusFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSampleStatusFilter.Properties.NullText = "Please select sample status...";
            this.lookUpEditSampleStatusFilter.Properties.NullValuePrompt = "Please select sample status...";
            this.lookUpEditSampleStatusFilter.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditSampleStatusFilter.Properties.ShowNullValuePromptWhenFocused = true;
            this.lookUpEditSampleStatusFilter.Size = new System.Drawing.Size(190, 20);
            this.lookUpEditSampleStatusFilter.TabIndex = 7;
            // 
            // simpleButtonLoadWorksheet
            // 
            this.simpleButtonLoadWorksheet.Location = new System.Drawing.Point(635, 43);
            this.simpleButtonLoadWorksheet.Name = "simpleButtonLoadWorksheet";
            this.simpleButtonLoadWorksheet.Size = new System.Drawing.Size(108, 23);
            this.simpleButtonLoadWorksheet.TabIndex = 6;
            this.simpleButtonLoadWorksheet.Text = "Load Worksheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Sample date";
            // 
            // dateEditLoadWorksheetFrom
            // 
            this.dateEditLoadWorksheetFrom.EditValue = null;
            this.dateEditLoadWorksheetFrom.Location = new System.Drawing.Point(12, 45);
            this.dateEditLoadWorksheetFrom.Name = "dateEditLoadWorksheetFrom";
            this.dateEditLoadWorksheetFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLoadWorksheetFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLoadWorksheetFrom.Properties.NullText = "Please select the sample date...";
            this.dateEditLoadWorksheetFrom.Properties.NullValuePrompt = "Please select the sample date...";
            this.dateEditLoadWorksheetFrom.Properties.NullValuePromptShowForEmptyValue = true;
            this.dateEditLoadWorksheetFrom.Size = new System.Drawing.Size(175, 20);
            this.dateEditLoadWorksheetFrom.TabIndex = 1;
            // 
            // simpleButtonReport
            // 
            this.simpleButtonReport.Location = new System.Drawing.Point(750, 43);
            this.simpleButtonReport.Name = "simpleButtonReport";
            this.simpleButtonReport.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonReport.TabIndex = 0;
            this.simpleButtonReport.Text = "Report";
            // 
            // ResultEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 401);
            this.Controls.Add(this.splitContainerControlPatient);
            this.KeyPreview = true;
            this.Name = "ResultEntryView";
            this.Text = "ResultEntryView";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPatient)).EndInit();
            this.splitContainerControlPatient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedPatientRequestClinicalDetailsArea)).EndInit();
            this.groupControlSelectedPatientRequestClinicalDetailsArea.ResumeLayout(false);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlClinicalDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlFunctions)).EndInit();
            this.splitContainerControlFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlSamplesAndTest)).EndInit();
            this.splitContainerControlSamplesAndTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditCodifiedPhrases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).EndInit();
            this.groupControlFunctions.ResumeLayout(false);
            this.groupControlFunctions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleStatusFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLoadWorksheetFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLoadWorksheetFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlPatient;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlFunctions;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlSamplesAndTest;
        private DevExpress.XtraGrid.GridControl gridControlSamples;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSamples;
        private DevExpress.XtraGrid.GridControl gridControlTests;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTests;
        private DevExpress.XtraEditors.GroupControl groupControlSelectedPatientRequestClinicalDetailsArea;
        private DevExpress.XtraEditors.GroupControl groupControlFunctions;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlClinicalDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCollectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTestName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSequence;
        private DevExpress.XtraEditors.LabelControl labelControlNationalId;
        private DevExpress.XtraEditors.LabelControl labelControlAgeSex;
        private DevExpress.XtraEditors.LabelControl labelControlBirthdate;
        private DevExpress.XtraEditors.LabelControl labelControlPhoneNumber;
        private DevExpress.XtraEditors.LabelControl labelControlAddress;
        private DevExpress.XtraEditors.LabelControl labelControlAtollIslandCountry;
        private DevExpress.XtraEditors.LabelControl labelControlEpisodeNumber;
        private DevExpress.XtraEditors.LabelControl labelControlCin;
        private DevExpress.XtraEditors.LabelControl labelControlSite;
        private DevExpress.XtraEditors.LabelControl labelControlPatientName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditCodifiedPhrases;
        private SimpleButton simpleButtonReport;
        private DateEdit dateEditLoadWorksheetFrom;
        private SimpleButton simpleButtonLoadWorksheet;
        private LookUpEdit lookUpEditSampleStatusFilter;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatusIcon;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSampleStatus;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelSamples;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelTests;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReferenceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsDeltaOk;
    }
}