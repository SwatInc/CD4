
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
            this.groupControlSampleNotes = new DevExpress.XtraEditors.GroupControl();
            this.textEditSampleNote = new DevExpress.XtraEditors.TextEdit();
            this.labelControlInstructionLabel = new DevExpress.XtraEditors.LabelControl();
            this.gridControlSampleNotes = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).BeginInit();
            this.groupControlAddSampleNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).BeginInit();
            this.groupControlSampleNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSampleNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSampleNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.splitContainerControl1.Size = new System.Drawing.Size(580, 297);
            this.splitContainerControl1.SplitterPosition = 88;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControlAddSampleNotes
            // 
            this.groupControlAddSampleNotes.Controls.Add(this.labelControlInstructionLabel);
            this.groupControlAddSampleNotes.Controls.Add(this.textEditSampleNote);
            this.groupControlAddSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlAddSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlAddSampleNotes.Name = "groupControlAddSampleNotes";
            this.groupControlAddSampleNotes.Size = new System.Drawing.Size(580, 88);
            this.groupControlAddSampleNotes.TabIndex = 0;
            this.groupControlAddSampleNotes.Text = "Add Sample Notes";
            // 
            // groupControlSampleNotes
            // 
            this.groupControlSampleNotes.Controls.Add(this.gridControlSampleNotes);
            this.groupControlSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlSampleNotes.Name = "groupControlSampleNotes";
            this.groupControlSampleNotes.Size = new System.Drawing.Size(580, 204);
            this.groupControlSampleNotes.TabIndex = 0;
            this.groupControlSampleNotes.Text = "Sample Notes";
            // 
            // textEditSampleNote
            // 
            this.textEditSampleNote.Location = new System.Drawing.Point(12, 49);
            this.textEditSampleNote.Name = "textEditSampleNote";
            this.textEditSampleNote.Size = new System.Drawing.Size(556, 20);
            this.textEditSampleNote.TabIndex = 0;
            // 
            // labelControlInstructionLabel
            // 
            this.labelControlInstructionLabel.Location = new System.Drawing.Point(12, 30);
            this.labelControlInstructionLabel.Name = "labelControlInstructionLabel";
            this.labelControlInstructionLabel.Size = new System.Drawing.Size(259, 13);
            this.labelControlInstructionLabel.TabIndex = 1;
            this.labelControlInstructionLabel.Text = "Please press enter after entering a note for sample";
            // 
            // gridControlSampleNotes
            // 
            this.gridControlSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSampleNotes.Location = new System.Drawing.Point(2, 20);
            this.gridControlSampleNotes.MainView = this.gridView1;
            this.gridControlSampleNotes.Name = "gridControlSampleNotes";
            this.gridControlSampleNotes.Size = new System.Drawing.Size(576, 182);
            this.gridControlSampleNotes.TabIndex = 0;
            this.gridControlSampleNotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlSampleNotes;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // LabNotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 297);
            this.Controls.Add(this.splitContainerControl1);
            this.KeyPreview = true;
            this.Name = "LabNotesView";
            this.Text = "LabNotesView";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).EndInit();
            this.groupControlAddSampleNotes.ResumeLayout(false);
            this.groupControlAddSampleNotes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).EndInit();
            this.groupControlSampleNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditSampleNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSampleNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControlAddSampleNotes;
        private DevExpress.XtraEditors.GroupControl groupControlSampleNotes;
        private DevExpress.XtraEditors.LabelControl labelControlInstructionLabel;
        private DevExpress.XtraEditors.TextEdit textEditSampleNote;
        private DevExpress.XtraGrid.GridControl gridControlSampleNotes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}