namespace CD4.UI.View
{
    partial class ClinicaDetailsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicaDetailsView));
            this.gridControlScientist = new DevExpress.XtraGrid.GridControl();
            this.gridViewClinicalDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnClinicalDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.textEditClinicalDetail = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlScientist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClinicalDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditClinicalDetail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlScientist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlScientist.Location = new System.Drawing.Point(0, 0);
            this.gridControlScientist.MainView = this.gridViewClinicalDetails;
            this.gridControlScientist.Name = "gridControlCodifiedValues";
            this.gridControlScientist.Size = new System.Drawing.Size(397, 262);
            this.gridControlScientist.TabIndex = 0;
            this.gridControlScientist.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewClinicalDetails});
            // 
            // gridViewCodifiedResults
            // 
            this.gridViewClinicalDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnClinicalDetails});
            this.gridViewClinicalDetails.GridControl = this.gridControlScientist;
            this.gridViewClinicalDetails.Name = "gridViewCodifiedResults";
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 58;
            // 
            // gridColumnClinicalDetails
            // 
            this.gridColumnClinicalDetails.Caption = "Clinical Detail";
            this.gridColumnClinicalDetails.FieldName = "ClinicalDetail";
            this.gridColumnClinicalDetails.Name = "gridColumnClinicalDetails";
            this.gridColumnClinicalDetails.Visible = true;
            this.gridColumnClinicalDetails.VisibleIndex = 1;
            this.gridColumnClinicalDetails.Width = 321;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlScientist);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.simpleButtonSave);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditId);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditClinicalDetail);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(640, 262);
            this.splitContainerControl.SplitterPosition = 397;
            this.splitContainerControl.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButtonSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonSave.Location = new System.Drawing.Point(26, 203);
            this.simpleButtonSave.Name = "simpleButton2";
            this.simpleButtonSave.Size = new System.Drawing.Size(173, 34);
            this.simpleButtonSave.TabIndex = 3;
            // 
            // textEditId
            // 
            this.textEditId.Enabled = false;
            this.textEditId.Location = new System.Drawing.Point(26, 35);
            this.textEditId.Name = "textEditId";
            this.textEditId.Properties.NullText = "Id";
            this.textEditId.Properties.NullValuePrompt = "Id";
            this.textEditId.Size = new System.Drawing.Size(173, 20);
            this.textEditId.TabIndex = 1;
            // 
            // textEditClinicalDetail
            // 
            this.textEditClinicalDetail.Location = new System.Drawing.Point(26, 177);
            this.textEditClinicalDetail.Name = "textEditClinicalDetail";
            this.textEditClinicalDetail.Properties.NullText = "Please enter the clinical detail";
            this.textEditClinicalDetail.Properties.NullValuePrompt = "Please enter the clinical detail";
            this.textEditClinicalDetail.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditClinicalDetail.Size = new System.Drawing.Size(173, 20);
            this.textEditClinicalDetail.TabIndex = 0;
            // 
            // ClinicaDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 262);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "ClinicaDetailsView";
            this.Text = "ClinicaDetailsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlScientist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClinicalDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditClinicalDetail.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlScientist;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewClinicalDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClinicalDetails;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.TextEdit textEditClinicalDetail;
    }
}