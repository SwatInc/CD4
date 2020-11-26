
namespace CD4.UI.View
{
    partial class PatientDetailsConfirmationView
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
            this.textEditNidPp = new DevExpress.XtraEditors.TextEdit();
            this.labelInstruction = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelContactNo = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDob = new System.Windows.Forms.Label();
            this.LabelPatientName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButtonVerified = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNidPp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditNidPp
            // 
            this.textEditNidPp.Location = new System.Drawing.Point(64, 158);
            this.textEditNidPp.Name = "textEditNidPp";
            this.textEditNidPp.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditNidPp.Properties.Appearance.Options.UseFont = true;
            this.textEditNidPp.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditNidPp.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditNidPp.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.textEditNidPp.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditNidPp.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.textEditNidPp.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditNidPp.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.textEditNidPp.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditNidPp.Size = new System.Drawing.Size(329, 32);
            this.textEditNidPp.TabIndex = 4;
            // 
            // labelInstruction
            // 
            this.labelInstruction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstruction.Location = new System.Drawing.Point(9, 132);
            this.labelInstruction.Name = "labelInstruction";
            this.labelInstruction.Size = new System.Drawing.Size(438, 27);
            this.labelInstruction.TabIndex = 5;
            this.labelInstruction.Text = "Please enter National ID / Passport";
            this.labelInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelContactNo);
            this.panelControl1.Controls.Add(this.labelGender);
            this.panelControl1.Controls.Add(this.labelAge);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.labelDob);
            this.panelControl1.Controls.Add(this.LabelPatientName);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(436, 91);
            this.panelControl1.TabIndex = 6;
            // 
            // labelContactNo
            // 
            this.labelContactNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactNo.Location = new System.Drawing.Point(300, 56);
            this.labelContactNo.Name = "labelContactNo";
            this.labelContactNo.Size = new System.Drawing.Size(130, 27);
            this.labelContactNo.TabIndex = 15;
            this.labelContactNo.Text = "79765544";
            this.labelContactNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGender
            // 
            this.labelGender.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(300, 29);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(130, 27);
            this.labelGender.TabIndex = 14;
            this.labelGender.Text = "MALE";
            this.labelGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAge
            // 
            this.labelAge.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAge.Location = new System.Drawing.Point(49, 56);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(157, 27);
            this.labelAge.TabIndex = 13;
            this.labelAge.Text = "29 Y 5 M 2 D";
            this.labelAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 27);
            this.label6.TabIndex = 12;
            this.label6.Text = "Age: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDob
            // 
            this.labelDob.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDob.Location = new System.Drawing.Point(49, 29);
            this.labelDob.Name = "labelDob";
            this.labelDob.Size = new System.Drawing.Size(157, 27);
            this.labelDob.TabIndex = 11;
            this.labelDob.Text = "14-Feb-1991";
            this.labelDob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelPatientName
            // 
            this.LabelPatientName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPatientName.Location = new System.Drawing.Point(49, 2);
            this.LabelPatientName.Name = "LabelPatientName";
            this.LabelPatientName.Size = new System.Drawing.Size(382, 27);
            this.LabelPatientName.TabIndex = 10;
            this.LabelPatientName.Text = "Ahmed Ibrahim Manik";
            this.LabelPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contact No: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(217, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gender:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "DOB: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonVerified
            // 
            this.simpleButtonVerified.Location = new System.Drawing.Point(231, 211);
            this.simpleButtonVerified.Name = "simpleButtonVerified";
            this.simpleButtonVerified.Size = new System.Drawing.Size(94, 23);
            this.simpleButtonVerified.TabIndex = 7;
            this.simpleButtonVerified.Text = "Verified";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(131, 211);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(94, 23);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(12, 112);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(436, 19);
            this.separatorControl1.TabIndex = 9;
            // 
            // PatientDetailsConfirmationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 246);
            this.ControlBox = false;
            this.Controls.Add(this.textEditNidPp);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonVerified);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PatientDetailsConfirmationView";
            this.Text = "Patient Demographics Verification";
            ((System.ComponentModel.ISupportInitialize)(this.textEditNidPp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditNidPp;
        private System.Windows.Forms.Label labelInstruction;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonVerified;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private System.Windows.Forms.Label labelContactNo;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDob;
        private System.Windows.Forms.Label LabelPatientName;
    }
}