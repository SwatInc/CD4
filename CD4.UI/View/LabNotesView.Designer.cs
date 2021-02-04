
namespace CD4.UI.View
{
    partial class LabNotesView
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControlAddSampleNotes = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlInstructionLabel = new DevExpress.XtraEditors.LabelControl();
            this.textEditSampleNote = new DevExpress.XtraEditors.TextEdit();
            this.groupControlSampleNotes = new DevExpress.XtraEditors.GroupControl();
            this.gridControlSampleNotes = new DevExpress.XtraGrid.GridControl();
            this.gridViewSampleNotes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.progressPanelNotes = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).BeginInit();
            this.groupControlAddSampleNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSampleNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).BeginInit();
            this.groupControlSampleNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSampleNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSampleNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControlAddSampleNotes);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlSampleNotes);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(742, 366);
            this.splitContainerControl1.SplitterPosition = 88;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControlAddSampleNotes
            // 
            this.groupControlAddSampleNotes.Controls.Add(this.simpleButtonSave);
            this.groupControlAddSampleNotes.Controls.Add(this.labelControlInstructionLabel);
            this.groupControlAddSampleNotes.Controls.Add(this.textEditSampleNote);
            this.groupControlAddSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlAddSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlAddSampleNotes.Name = "groupControlAddSampleNotes";
            this.groupControlAddSampleNotes.Size = new System.Drawing.Size(742, 88);
            this.groupControlAddSampleNotes.TabIndex = 0;
            this.groupControlAddSampleNotes.Text = "Add Sample Notes";
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Location = new System.Drawing.Point(489, 47);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonSave.TabIndex = 2;
            this.simpleButtonSave.Text = "Save [ F6 ]";
            // 
            // labelControlInstructionLabel
            // 
            this.labelControlInstructionLabel.Location = new System.Drawing.Point(12, 30);
            this.labelControlInstructionLabel.Name = "labelControlInstructionLabel";
            this.labelControlInstructionLabel.Size = new System.Drawing.Size(259, 13);
            this.labelControlInstructionLabel.TabIndex = 1;
            this.labelControlInstructionLabel.Text = "Please press enter after entering a note for sample";
            // 
            // textEditSampleNote
            // 
            this.textEditSampleNote.Location = new System.Drawing.Point(12, 49);
            this.textEditSampleNote.Name = "textEditSampleNote";
            this.textEditSampleNote.Size = new System.Drawing.Size(453, 20);
            this.textEditSampleNote.TabIndex = 0;
            // 
            // groupControlSampleNotes
            // 
            this.groupControlSampleNotes.Controls.Add(this.gridControlSampleNotes);
            this.groupControlSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlSampleNotes.Name = "groupControlSampleNotes";
            this.groupControlSampleNotes.Size = new System.Drawing.Size(742, 273);
            this.groupControlSampleNotes.TabIndex = 0;
            this.groupControlSampleNotes.Text = "Sample Notes";
            // 
            // gridControlSampleNotes
            // 
            this.gridControlSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSampleNotes.Location = new System.Drawing.Point(2, 20);
            this.gridControlSampleNotes.MainView = this.gridViewSampleNotes;
            this.gridControlSampleNotes.Name = "gridControlSampleNotes";
            this.gridControlSampleNotes.Size = new System.Drawing.Size(738, 251);
            this.gridControlSampleNotes.TabIndex = 0;
            this.gridControlSampleNotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSampleNotes});
            // 
            // gridViewSampleNotes
            // 
            this.gridViewSampleNotes.GridControl = this.gridControlSampleNotes;
            this.gridViewSampleNotes.Name = "gridViewSampleNotes";
            this.gridViewSampleNotes.OptionsView.ShowGroupPanel = false;
            // 
            // progressPanelNotes
            // 
            this.progressPanelNotes.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelNotes.Appearance.Options.UseBackColor = true;
            this.progressPanelNotes.BarAnimationElementThickness = 2;
            this.progressPanelNotes.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelNotes.Location = new System.Drawing.Point(0, 322);
            this.progressPanelNotes.Name = "progressPanelNotes";
            this.progressPanelNotes.Size = new System.Drawing.Size(216, 44);
            this.progressPanelNotes.TabIndex = 1;
            this.progressPanelNotes.Text = "progressPanel1";
            // 
            // LabNotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 366);
            this.Controls.Add(this.progressPanelNotes);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "LabNotesView";
            this.Text = "LabNotesView";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).EndInit();
            this.groupControlAddSampleNotes.ResumeLayout(false);
            this.groupControlAddSampleNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSampleNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).EndInit();
            this.groupControlSampleNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSampleNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSampleNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControlAddSampleNotes;
        private DevExpress.XtraEditors.GroupControl groupControlSampleNotes;
        private DevExpress.XtraEditors.LabelControl labelControlInstructionLabel;
        private DevExpress.XtraEditors.TextEdit textEditSampleNote;
        private DevExpress.XtraGrid.GridControl gridControlSampleNotes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSampleNotes;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelNotes;
    }
}