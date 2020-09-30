namespace CD4.UI.View
{
    partial class RejectionCommentView
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
            this.listBoxControlRejectionReasons = new DevExpress.XtraEditors.ListBoxControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.progressPanelLoadingReasons = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRejectionReasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControlRejectionReasons
            // 
            this.listBoxControlRejectionReasons.Location = new System.Drawing.Point(12, 65);
            this.listBoxControlRejectionReasons.Name = "listBoxControlRejectionReasons";
            this.listBoxControlRejectionReasons.Size = new System.Drawing.Size(467, 138);
            this.listBoxControlRejectionReasons.TabIndex = 0;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.listBoxControlRejectionReasons;
            this.searchControl1.Location = new System.Drawing.Point(12, 38);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.listBoxControlRejectionReasons;
            this.searchControl1.Properties.NullValuePrompt = "Search for comments ...";
            this.searchControl1.Size = new System.Drawing.Size(253, 20);
            this.searchControl1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(253, 20);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Please select the reason for rejection.";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(323, 36);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOk.TabIndex = 3;
            this.simpleButtonOk.Text = "Ok";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(404, 36);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 4;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // progressPanelLoadingReasons
            // 
            this.progressPanelLoadingReasons.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelLoadingReasons.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanelLoadingReasons.Appearance.Options.UseBackColor = true;
            this.progressPanelLoadingReasons.Appearance.Options.UseFont = true;
            this.progressPanelLoadingReasons.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.progressPanelLoadingReasons.AppearanceCaption.Options.UseFont = true;
            this.progressPanelLoadingReasons.AppearanceDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.progressPanelLoadingReasons.AppearanceDescription.Options.UseFont = true;
            this.progressPanelLoadingReasons.BarAnimationElementThickness = 2;
            this.progressPanelLoadingReasons.Caption = "Please Wait";
            this.progressPanelLoadingReasons.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelLoadingReasons.Description = "Loading rejection reasons ...";
            this.progressPanelLoadingReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanelLoadingReasons.Location = new System.Drawing.Point(0, 0);
            this.progressPanelLoadingReasons.Name = "progressPanelLoadingReasons";
            this.progressPanelLoadingReasons.Size = new System.Drawing.Size(493, 216);
            this.progressPanelLoadingReasons.TabIndex = 5;
            // 
            // RejectionCommentView
            // 
            this.AcceptButton = this.simpleButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.simpleButtonCancel;
            this.ClientSize = new System.Drawing.Size(493, 216);
            this.ControlBox = false;
            this.Controls.Add(this.progressPanelLoadingReasons);
            this.Controls.Add(this.simpleButtonCancel);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.listBoxControlRejectionReasons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RejectionCommentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cause for rejection";
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRejectionReasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControlRejectionReasons;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelLoadingReasons;
    }
}