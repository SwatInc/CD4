namespace CD4.UI.View
{
    partial class AcceptSampleView
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
            this.progressPanelAccept = new DevExpress.XtraWaitForm.ProgressPanel();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.textEditAcceptBarcode = new DevExpress.XtraEditors.TextEdit();
            this.labelNotification = new System.Windows.Forms.Label();
            this.labelNoOfBarcodesRead = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAcceptBarcode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressPanelAccept
            // 
            this.progressPanelAccept.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelAccept.Appearance.Options.UseBackColor = true;
            this.progressPanelAccept.BarAnimationElementThickness = 2;
            this.progressPanelAccept.Caption = "Please Wait";
            this.progressPanelAccept.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelAccept.Description = "Accepting the sample...";
            this.progressPanelAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanelAccept.Location = new System.Drawing.Point(0, 0);
            this.progressPanelAccept.Name = "progressPanelAccept";
            this.progressPanelAccept.Size = new System.Drawing.Size(395, 125);
            this.progressPanelAccept.TabIndex = 5;
            this.progressPanelAccept.Text = "progressPanelAccept";
            // 
            // labelInstruction
            // 
            this.labelInstruction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruction.Location = new System.Drawing.Point(3, 4);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(392, 27);
            this.labelInstruction.TabIndex = 4;
            this.labelInstruction.Text = "Please read the barcode to accept the sample.";
            this.labelInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEditAcceptBarcode
            // 
            this.textEditAcceptBarcode.Location = new System.Drawing.Point(102, 39);
            this.textEditAcceptBarcode.Name = "textEditAcceptBarcode";
            this.textEditAcceptBarcode.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditAcceptBarcode.Properties.Appearance.Options.UseFont = true;
            this.textEditAcceptBarcode.Size = new System.Drawing.Size(189, 32);
            this.textEditAcceptBarcode.TabIndex = 3;
            // 
            // labelNotification
            // 
            this.labelNotification.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotification.Location = new System.Drawing.Point(0, 97);
            this.labelNotification.Name = "labelNotification";
            this.labelNotification.Size = new System.Drawing.Size(395, 26);
            this.labelNotification.TabIndex = 6;
            this.labelNotification.Text = "[Barcode] accepted successfully";
            this.labelNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNoOfBarcodesRead
            // 
            this.labelNoOfBarcodesRead.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoOfBarcodesRead.Location = new System.Drawing.Point(0, 71);
            this.labelNoOfBarcodesRead.Name = "labelNoOfBarcodesRead";
            this.labelNoOfBarcodesRead.Size = new System.Drawing.Size(395, 26);
            this.labelNoOfBarcodesRead.TabIndex = 7;
            this.labelNoOfBarcodesRead.Text = "No. Read: [8]";
            this.labelNoOfBarcodesRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AcceptSampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 125);
            this.Controls.Add(this.progressPanelAccept);
            this.Controls.Add(this.labelNoOfBarcodesRead);
            this.Controls.Add(this.labelNotification);
            this.Controls.Add(this.labelInstruction);
            this.Controls.Add(this.textEditAcceptBarcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "AcceptSampleView";
            this.Tag = "AcceptSamplesView";
            this.Text = "AcceptSampleView";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AcceptSampleView_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.textEditAcceptBarcode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanelAccept;
        private System.Windows.Forms.Label labelInstruction;
        private DevExpress.XtraEditors.TextEdit textEditAcceptBarcode;
        private System.Windows.Forms.Label labelNotification;
        private System.Windows.Forms.Label labelNoOfBarcodesRead;
    }
}