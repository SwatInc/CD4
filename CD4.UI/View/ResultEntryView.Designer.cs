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
            DevExpress.XtraEditors.LabelControl labelControl1;
            DevExpress.XtraEditors.LabelControl labelControl2;
            DevExpress.XtraEditors.LabelControl labelControl3;
            DevExpress.XtraEditors.LabelControl labelControl4;
            DevExpress.XtraEditors.LabelControl labelControl5;
            DevExpress.XtraEditors.LabelControl labelControl6;
            DevExpress.XtraEditors.LabelControl labelControl8;
            DevExpress.XtraEditors.LabelControl labelControl7;
            DevExpress.XtraEditors.LabelControl labelControl9;
            this.splitContainerControlPatient = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlSelectedPatientRequestClinicalDetailsArea = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.splitContainerControlFunctions = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlSamplesAndTest = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControlFunctions = new DevExpress.XtraEditors.GroupControl();
            this.gridColumnCin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReceivedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCollectedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSequence = new DevExpress.XtraGrid.Columns.GridColumn();
            labelControlPatientName = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            labelControl9 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPatient)).BeginInit();
            this.splitContainerControlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedPatientRequestClinicalDetailsArea)).BeginInit();
            this.groupControlSelectedPatientRequestClinicalDetailsArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlFunctions)).BeginInit();
            this.splitContainerControlFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlSamplesAndTest)).BeginInit();
            this.splitContainerControlSamplesAndTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlPatientName
            // 
            labelControlPatientName.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.Appearance.Options.UseFont = true;
            labelControlPatientName.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearanceDisabled.Options.UseFont = true;
            labelControlPatientName.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearanceHovered.Options.UseFont = true;
            labelControlPatientName.AppearancePressed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            labelControlPatientName.AppearancePressed.Options.UseFont = true;
            labelControlPatientName.Location = new System.Drawing.Point(12, 23);
            labelControlPatientName.Name = "labelControlPatientName";
            labelControlPatientName.Size = new System.Drawing.Size(118, 21);
            labelControlPatientName.TabIndex = 0;
            labelControlPatientName.Text = "PATIENT NAME";
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(12, 50);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(49, 13);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "NationalId";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(12, 69);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(47, 13);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "Age / Sex";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(167, 50);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(44, 13);
            labelControl3.TabIndex = 3;
            labelControl3.Text = "Birthdate";
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(167, 69);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(67, 13);
            labelControl4.TabIndex = 4;
            labelControl4.Text = "PhoneNumber";
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(280, 50);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(39, 13);
            labelControl5.TabIndex = 5;
            labelControl5.Text = "Address";
            // 
            // labelControl6
            // 
            labelControl6.Location = new System.Drawing.Point(280, 69);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(103, 13);
            labelControl6.TabIndex = 6;
            labelControl6.Text = "Atoll, Island, Country";
            // 
            // labelControl8
            // 
            labelControl8.Location = new System.Drawing.Point(472, 50);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new System.Drawing.Size(74, 13);
            labelControl8.TabIndex = 8;
            labelControl8.Text = "EpisodeNumber";
            // 
            // labelControl7
            // 
            labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl7.Appearance.Options.UseFont = true;
            labelControl7.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl7.AppearanceDisabled.Options.UseFont = true;
            labelControl7.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl7.AppearanceHovered.Options.UseFont = true;
            labelControl7.AppearancePressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            labelControl7.AppearancePressed.Options.UseFont = true;
            labelControl7.Location = new System.Drawing.Point(472, 23);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(107, 21);
            labelControl7.TabIndex = 10;
            labelControl7.Text = "SELECTED CIN";
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
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl9);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl7);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(this.listBoxControl1);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl8);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl6);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl5);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl4);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl3);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl2);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Controls.Add(labelControl1);
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
            this.listBoxControl1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxControl1.Appearance.Options.UseBackColor = true;
            this.listBoxControl1.HorizontalScrollbar = true;
            this.listBoxControl1.Location = new System.Drawing.Point(613, 21);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(223, 66);
            this.listBoxControl1.TabIndex = 9;
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
            this.splitContainerControlSamplesAndTest.Panel1.Controls.Add(this.gridControl2);
            this.splitContainerControlSamplesAndTest.Panel1.Text = "Panel1";
            this.splitContainerControlSamplesAndTest.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControlSamplesAndTest.Panel2.Text = "Panel2";
            this.splitContainerControlSamplesAndTest.Size = new System.Drawing.Size(839, 224);
            this.splitContainerControlSamplesAndTest.SplitterPosition = 400;
            this.splitContainerControlSamplesAndTest.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(400, 224);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCin,
            this.gridColumnReceivedDate,
            this.gridColumnCollectedDate,
            this.gridColumnSequence});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(434, 224);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTestName,
            this.gridColumnResult});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // labelControl9
            // 
            labelControl9.Location = new System.Drawing.Point(472, 69);
            labelControl9.Name = "labelControl9";
            labelControl9.Size = new System.Drawing.Size(18, 13);
            labelControl9.TabIndex = 11;
            labelControl9.Text = "Site";
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
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlFunctions)).EndInit();
            this.splitContainerControlFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlSamplesAndTest)).EndInit();
            this.splitContainerControlSamplesAndTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFunctions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlPatient;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlFunctions;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlSamplesAndTest;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControlSelectedPatientRequestClinicalDetailsArea;
        private DevExpress.XtraEditors.GroupControl groupControlFunctions;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReceivedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCollectedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTestName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResult;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSequence;
    }
}