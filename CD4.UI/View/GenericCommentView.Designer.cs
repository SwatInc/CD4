namespace CD4.UI.View
{
    partial class GenericCommentView
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
            this.xtraTabControlComments = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageSelectReason = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageComments = new DevExpress.XtraTab.XtraTabPage();
            this.progressPanelLoadingReasons = new DevExpress.XtraWaitForm.ProgressPanel();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlUserInstruction = new DevExpress.XtraEditors.LabelControl();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.listBoxControlRejectionReasons = new DevExpress.XtraEditors.ListBoxControl();
            this.gridControlExistingComments = new DevExpress.XtraGrid.GridControl();
            this.gridViewExistingComments = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlComments)).BeginInit();
            this.xtraTabControlComments.SuspendLayout();
            this.xtraTabPageSelectReason.SuspendLayout();
            this.xtraTabPageComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRejectionReasons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExistingComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExistingComments)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlComments
            // 
            this.xtraTabControlComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlComments.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlComments.Name = "xtraTabControlComments";
            this.xtraTabControlComments.SelectedTabPage = this.xtraTabPageSelectReason;
            this.xtraTabControlComments.Size = new System.Drawing.Size(527, 248);
            this.xtraTabControlComments.TabIndex = 6;
            this.xtraTabControlComments.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSelectReason,
            this.xtraTabPageComments});
            // 
            // xtraTabPageSelectReason
            // 
            this.xtraTabPageSelectReason.Controls.Add(this.progressPanelLoadingReasons);
            this.xtraTabPageSelectReason.Controls.Add(this.simpleButtonCancel);
            this.xtraTabPageSelectReason.Controls.Add(this.simpleButtonOk);
            this.xtraTabPageSelectReason.Controls.Add(this.labelControlUserInstruction);
            this.xtraTabPageSelectReason.Controls.Add(this.searchControl1);
            this.xtraTabPageSelectReason.Controls.Add(this.listBoxControlRejectionReasons);
            this.xtraTabPageSelectReason.Name = "xtraTabPageSelectReason";
            this.xtraTabPageSelectReason.Size = new System.Drawing.Size(521, 220);
            this.xtraTabPageSelectReason.Text = "Select Reason";
            // 
            // xtraTabPageComments
            // 
            this.xtraTabPageComments.Controls.Add(this.gridControlExistingComments);
            this.xtraTabPageComments.Name = "xtraTabPageComments";
            this.xtraTabPageComments.Size = new System.Drawing.Size(521, 220);
            this.xtraTabPageComments.Text = "Comments";
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
            this.progressPanelLoadingReasons.Location = new System.Drawing.Point(136, 103);
            this.progressPanelLoadingReasons.Name = "progressPanelLoadingReasons";
            this.progressPanelLoadingReasons.Size = new System.Drawing.Size(224, 75);
            this.progressPanelLoadingReasons.TabIndex = 11;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButtonCancel.Location = new System.Drawing.Point(439, 26);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonCancel.TabIndex = 10;
            this.simpleButtonCancel.Text = "Cancel";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(358, 26);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOk.TabIndex = 9;
            this.simpleButtonOk.Text = "Ok";
            // 
            // labelControlUserInstruction
            // 
            this.labelControlUserInstruction.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlUserInstruction.Appearance.Options.UseFont = true;
            this.labelControlUserInstruction.Location = new System.Drawing.Point(6, 3);
            this.labelControlUserInstruction.Name = "labelControlUserInstruction";
            this.labelControlUserInstruction.Size = new System.Drawing.Size(145, 20);
            this.labelControlUserInstruction.TabIndex = 8;
            this.labelControlUserInstruction.Text = "label User Instruction";
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.listBoxControlRejectionReasons;
            this.searchControl1.Location = new System.Drawing.Point(6, 29);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.listBoxControlRejectionReasons;
            this.searchControl1.Properties.NullValuePrompt = "Search for comments ...";
            this.searchControl1.Size = new System.Drawing.Size(253, 20);
            this.searchControl1.TabIndex = 7;
            // 
            // listBoxControlRejectionReasons
            // 
            this.listBoxControlRejectionReasons.Location = new System.Drawing.Point(0, 56);
            this.listBoxControlRejectionReasons.Name = "listBoxControlRejectionReasons";
            this.listBoxControlRejectionReasons.Size = new System.Drawing.Size(521, 164);
            this.listBoxControlRejectionReasons.TabIndex = 6;
            // 
            // gridControlExistingComments
            // 
            this.gridControlExistingComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlExistingComments.Location = new System.Drawing.Point(0, 0);
            this.gridControlExistingComments.MainView = this.gridViewExistingComments;
            this.gridControlExistingComments.Name = "gridControlExistingComments";
            this.gridControlExistingComments.Size = new System.Drawing.Size(521, 220);
            this.gridControlExistingComments.TabIndex = 0;
            this.gridControlExistingComments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewExistingComments});
            // 
            // gridViewExistingComments
            // 
            this.gridViewExistingComments.GridControl = this.gridControlExistingComments;
            this.gridViewExistingComments.Name = "gridViewExistingComments";
            this.gridViewExistingComments.OptionsView.ShowGroupPanel = false;
            // 
            // GenericCommentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 248);
            this.ControlBox = false;
            this.Controls.Add(this.xtraTabControlComments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GenericCommentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Title";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlComments)).EndInit();
            this.xtraTabControlComments.ResumeLayout(false);
            this.xtraTabPageSelectReason.ResumeLayout(false);
            this.xtraTabPageSelectReason.PerformLayout();
            this.xtraTabPageComments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlRejectionReasons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlExistingComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewExistingComments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlComments;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSelectReason;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelLoadingReasons;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.LabelControl labelControlUserInstruction;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlRejectionReasons;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageComments;
        private DevExpress.XtraGrid.GridControl gridControlExistingComments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewExistingComments;
    }
}