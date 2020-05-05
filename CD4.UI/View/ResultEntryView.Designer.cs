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
            DevExpress.XtraEditors.LabelControl labelControlPatientName;
            DevExpress.XtraEditors.LabelControl labelControlNationalId;
            DevExpress.XtraEditors.LabelControl labelControlAgeSex;
            DevExpress.XtraEditors.LabelControl labelControlBirthdate;
            DevExpress.XtraEditors.LabelControl labelControlPhoneNumber;
            DevExpress.XtraEditors.LabelControl labelControlAddress;
            DevExpress.XtraEditors.LabelControl labelControlAtollIslandCountry;
            DevExpress.XtraEditors.LabelControl labelControlEpisodeNumber;
            DevExpress.XtraEditors.LabelControl labelControlCin;
            DevExpress.XtraEditors.LabelControl labelControlSite;
            this.splitContainerControlPatient = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlSelectedPatientRequestClinicalDetailsArea = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlClinicalDetails = new DevExpress.XtraEditors.ListBoxControl();
            this.splitContainerControlFunctions = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlSamplesAndTest = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlSamples = new DevExpress.XtraGrid.GridControl();
            this.gridViewSamples = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCollectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSequence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlTests = new DevExpress.XtraGrid.GridControl();
            this.gridViewTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlFunctions = new DevExpress.XtraEditors.GroupControl();
            labelControlPatientName = new DevExpress.XtraEditors.LabelControl();
            labelControlNationalId = new DevExpress.XtraEditors.LabelControl();
            labelControlAgeSex = new DevExpress.XtraEditors.LabelControl();
            labelControlBirthdate = new DevExpress.XtraEditors.LabelControl();
            labelControlPhoneNumber = new DevExpress.XtraEditors.LabelControl();
            labelControlAddress = new DevExpress.XtraEditors.LabelControl();
            labelControlAtollIslandCountry = new DevExpress.XtraEditors.LabelControl();
            labelControlEpisodeNumber = new DevExpress.XtraEditors.LabelControl();
            labelControlCin = new DevExpress.XtraEditors.LabelControl();
            labelControlSite = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).BeginInit();
            this.SuspendLayout();
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
            // labelControl1
            // 
            labelControlNationalId.Location = new System.Drawing.Point(12, 50);
            labelControlNationalId.Name = "labelControlNationalId";
            labelControlNationalId.Size = new System.Drawing.Size(49, 13);
            labelControlNationalId.TabIndex = 1;
            labelControlNationalId.Text = "NationalId";
            // 
            // labelControl2
            // 
            labelControlAgeSex.Location = new System.Drawing.Point(12, 69);
            labelControlAgeSex.Name = "labelControlAgeSex";
            labelControlAgeSex.Size = new System.Drawing.Size(47, 13);
            labelControlAgeSex.TabIndex = 2;
            labelControlAgeSex.Text = "Age / Sex";
            // 
            // labelControl3
            // 
            labelControlBirthdate.Location = new System.Drawing.Point(167, 50);
            labelControlBirthdate.Name = "labelControlBirthdate";
            labelControlBirthdate.Size = new System.Drawing.Size(44, 13);
            labelControlBirthdate.TabIndex = 3;
            labelControlBirthdate.Text = "Birthdate";
            // 
            // labelControl4
            // 
            labelControlPhoneNumber.Location = new System.Drawing.Point(167, 69);
            labelControlPhoneNumber.Name = "labelControlPhoneNumber";
            labelControlPhoneNumber.Size = new System.Drawing.Size(67, 13);
            labelControlPhoneNumber.TabIndex = 4;
            labelControlPhoneNumber.Text = "PhoneNumber";
            // 
            // labelControl5
            // 
            labelControlAddress.Location = new System.Drawing.Point(280, 50);
            labelControlAddress.Name = "labelControlAddress";
            labelControlAddress.Size = new System.Drawing.Size(39, 13);
            labelControlAddress.TabIndex = 5;
            labelControlAddress.Text = "Address";
            // 
            // labelControl6
            // 
            labelControlAtollIslandCountry.Location = new System.Drawing.Point(280, 69);
            labelControlAtollIslandCountry.Name = "labelControlAtollIslandCountry";
            labelControlAtollIslandCountry.Size = new System.Drawing.Size(103, 13);
            labelControlAtollIslandCountry.TabIndex = 6;
            labelControlAtollIslandCountry.Text = "Atoll, Island, Country";
            // 
            // labelControl8
            // 
            labelControlEpisodeNumber.Location = new System.Drawing.Point(472, 50);
            labelControlEpisodeNumber.Name = "labelControlEpisodeNumber";
            labelControlEpisodeNumber.Size = new System.Drawing.Size(74, 13);
            labelControlEpisodeNumber.TabIndex = 8;
            labelControlEpisodeNumber.Text = "EpisodeNumber";
            // 
            // labelControl7
            // 
            labelControlCin.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlCin.Appearance.Options.UseFont = true;
            labelControlCin.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlCin.AppearanceDisabled.Options.UseFont = true;
            labelControlCin.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlCin.AppearanceHovered.Options.UseFont = true;
            labelControlCin.AppearancePressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlCin.AppearancePressed.Options.UseFont = true;
            labelControlCin.Location = new System.Drawing.Point(472, 23);
            labelControlCin.Name = "labelControlCin";
            labelControlCin.Size = new System.Drawing.Size(107, 21);
            labelControlCin.TabIndex = 10;
            labelControlCin.Text = "SELECTED CIN";
            // 
            // labelControl9
            // 
            labelControlSite.Location = new System.Drawing.Point(472, 69);
            labelControlSite.Name = "labelControlSite";
            labelControlSite.Size = new System.Drawing.Size(18, 13);
            labelControlSite.TabIndex = 11;
            labelControlSite.Text = "Site";
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
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlSite);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlCin);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.listBoxControlClinicalDetails);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlEpisodeNumber);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlAtollIslandCountry);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlAddress);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlPhoneNumber);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlBirthdate);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlAgeSex);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlNationalId);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControlPatientName);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Location = new System.Drawing.Point(0, 0);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Name = "groupControlSelectedPatientRequestClinicalDetailsArea";
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Size = new System.Drawing.Size(839, 90);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.TabIndex = 0;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Text = "Selected Patient, Request and Clinical Details Information";
            // 
            // listBoxControl1
            // 
            this.listBoxControlClinicalDetails.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxControlClinicalDetails.Appearance.Options.UseBackColor = true;
            this.listBoxControlClinicalDetails.HorizontalScrollbar = true;
            this.listBoxControlClinicalDetails.Location = new System.Drawing.Point(613, 21);
            this.listBoxControlClinicalDetails.Name = "listBoxControl1";
            this.listBoxControlClinicalDetails.Size = new System.Drawing.Size(223, 66);
            this.listBoxControlClinicalDetails.TabIndex = 9;
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
            this.splitContainerControlSamplesAndTest.Panel1.Controls.Add(this.gridControlSamples);
            this.splitContainerControlSamplesAndTest.Panel1.Text = "Panel1";
            this.splitContainerControlSamplesAndTest.Panel2.Controls.Add(this.gridControlTests);
            this.splitContainerControlSamplesAndTest.Panel2.Text = "Panel2";
            this.splitContainerControlSamplesAndTest.Size = new System.Drawing.Size(839, 224);
            this.splitContainerControlSamplesAndTest.SplitterPosition = 400;
            this.splitContainerControlSamplesAndTest.TabIndex = 0;
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
            this.gridColumnSequence});
            this.gridViewSamples.GridControl = this.gridControlSamples;
            this.gridViewSamples.Name = "gridViewSamples";
            // 
            // gridColumnCin
            // 
            this.gridColumnCin.Caption = "CIN";
            this.gridColumnCin.FieldName = "Cin";
            this.gridColumnCin.Name = "gridColumnCin";
            this.gridColumnCin.Visible = true;
            this.gridColumnCin.VisibleIndex = 1;
            this.gridColumnCin.Width = 68;
            // 
            // gridColumnReceivedDate
            // 
            this.gridColumnReceivedDate.Caption = "Rec. Date";
            this.gridColumnReceivedDate.FieldName = "ReceivedDate";
            this.gridColumnReceivedDate.Name = "gridColumnReceivedDate";
            this.gridColumnReceivedDate.Visible = true;
            this.gridColumnReceivedDate.VisibleIndex = 2;
            this.gridColumnReceivedDate.Width = 68;
            // 
            // gridColumnCollectedDate
            // 
            this.gridColumnCollectedDate.Caption = "Col. Date";
            this.gridColumnCollectedDate.FieldName = "CollectionDate";
            this.gridColumnCollectedDate.Name = "gridColumnCollectedDate";
            this.gridColumnCollectedDate.Visible = true;
            this.gridColumnCollectedDate.VisibleIndex = 3;
            this.gridColumnCollectedDate.Width = 71;
            // 
            // gridColumnSequence
            // 
            this.gridColumnSequence.Caption = "Seq.";
            this.gridColumnSequence.FieldName = "Id";
            this.gridColumnSequence.Name = "gridColumnSequence";
            this.gridColumnSequence.Visible = true;
            this.gridColumnSequence.VisibleIndex = 0;
            this.gridColumnSequence.Width = 33;
            // 
            // gridControlTests
            // 
            this.gridControlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTests.Location = new System.Drawing.Point(0, 0);
            this.gridControlTests.MainView = this.gridViewTests;
            this.gridControlTests.Name = "gridControlTests";
            this.gridControlTests.Size = new System.Drawing.Size(434, 224);
            this.gridControlTests.TabIndex = 0;
            this.gridControlTests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTests});
            // 
            // gridViewTests
            // 
            this.gridViewTests.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTestName,
            this.gridColumnResult});
            this.gridViewTests.GridControl = this.gridControlTests;
            this.gridViewTests.Name = "gridViewTests";
            this.gridViewTests.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnTestName
            // 
            this.gridColumnTestName.Caption = "Test";
            this.gridColumnTestName.Name = "gridColumnTestName";
            this.gridColumnTestName.Visible = true;
            this.gridColumnTestName.VisibleIndex = 0;
            this.gridColumnTestName.Width = 98;
            // 
            // gridColumnResult
            // 
            this.gridColumnResult.Caption = "Result";
            this.gridColumnResult.Name = "gridColumnResult";
            this.gridColumnResult.Visible = true;
            this.gridColumnResult.VisibleIndex = 1;
            this.gridColumnResult.Width = 460;
            // 
            // groupControlFunctions
            // 
            this.groupControlFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlFunctions.Location = new System.Drawing.Point(0, 0);
            this.groupControlFunctions.Name = "groupControlFunctions";
            this.groupControlFunctions.Size = new System.Drawing.Size(839, 77);
            this.groupControlFunctions.TabIndex = 1;
            this.groupControlFunctions.Text = "Functions";
            // 
            // ResultEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 401);
            this.Controls.Add(this.splitContainerControlPatient);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).EndInit();
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
    }
}