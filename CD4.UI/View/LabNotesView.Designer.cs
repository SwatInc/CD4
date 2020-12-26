
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
            this.groupControlSampleNotes = new DevExpress.XtraEditors.GroupControl();
            this.groupControlAddSampleNotes = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).BeginInit();
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
            this.splitContainerControl1.SplitterPosition = 85;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControlSampleNotes
            // 
            this.groupControlSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlSampleNotes.Name = "groupControlSampleNotes";
            this.groupControlSampleNotes.Size = new System.Drawing.Size(580, 207);
            this.groupControlSampleNotes.TabIndex = 0;
            this.groupControlSampleNotes.Text = "Sample Notes";
            // 
            // groupControlAddSampleNotes
            // 
            this.groupControlAddSampleNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlAddSampleNotes.Location = new System.Drawing.Point(0, 0);
            this.groupControlAddSampleNotes.Name = "groupControlAddSampleNotes";
            this.groupControlAddSampleNotes.Size = new System.Drawing.Size(580, 85);
            this.groupControlAddSampleNotes.TabIndex = 0;
            this.groupControlAddSampleNotes.Text = "Add SampleNotes";
            // 
            // LabNotesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 297);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "LabNotesView";
            this.Text = "LabNotesView";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSampleNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddSampleNotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControlAddSampleNotes;
        private DevExpress.XtraEditors.GroupControl groupControlSampleNotes;
    }
}