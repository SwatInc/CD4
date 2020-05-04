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
            this.splitContainerControlPatient = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlSelectedPatientRequestClinicalDetailsArea = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControlFunctions = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlSamplesAndTest = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControlFunctions = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlPatient)).BeginInit();
            this.splitContainerControlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedPatientRequestClinicalDetailsArea)).BeginInit();
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
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Location = new System.Drawing.Point(0, 0);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Name = "groupControlSelectedPatientRequestClinicalDetailsArea";
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Size = new System.Drawing.Size(839, 90);
            this.groupControlSelectedPatientRequestClinicalDetailsArea.TabIndex = 0;
            this.groupControlSelectedPatientRequestClinicalDetailsArea.Text = "Selected Patient, Request and Clinical Details Information";
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
            this.splitContainerControlSamplesAndTest.SplitterPosition = 258;
            this.splitContainerControlSamplesAndTest.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(258, 224);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(576, 224);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
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
    }
}