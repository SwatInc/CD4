namespace CD4.UI.View
{
    partial class SitesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SitesView));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlCodifiedValues = new DevExpress.XtraGrid.GridControl();
            this.gridViewCodifiedResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.textEditSite = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlCodifiedValues);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.simpleButton2);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditId);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditSite);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(510, 224);
            this.splitContainerControl.SplitterPosition = 313;
            this.splitContainerControl.TabIndex = 1;
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlCodifiedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCodifiedValues.Location = new System.Drawing.Point(0, 0);
            this.gridControlCodifiedValues.MainView = this.gridViewCodifiedResults;
            this.gridControlCodifiedValues.Name = "gridControlCodifiedValues";
            this.gridControlCodifiedValues.Size = new System.Drawing.Size(313, 224);
            this.gridControlCodifiedValues.TabIndex = 0;
            this.gridControlCodifiedValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCodifiedResults});
            // 
            // gridViewCodifiedResults
            // 
            this.gridViewCodifiedResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnSite});
            this.gridViewCodifiedResults.GridControl = this.gridControlCodifiedValues;
            this.gridViewCodifiedResults.Name = "gridViewCodifiedResults";
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
            // gridColumnSite
            // 
            this.gridColumnSite.Caption = "Site";
            this.gridColumnSite.FieldName = "Name";
            this.gridColumnSite.Name = "gridColumnSite";
            this.gridColumnSite.Visible = true;
            this.gridColumnSite.VisibleIndex = 1;
            this.gridColumnSite.Width = 321;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButton2.Location = new System.Drawing.Point(9, 179);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(173, 34);
            this.simpleButton2.TabIndex = 3;
            // 
            // textEditId
            // 
            this.textEditId.Location = new System.Drawing.Point(9, 23);
            this.textEditId.Name = "textEditId";
            this.textEditId.Properties.NullText = "Id";
            this.textEditId.Properties.NullValuePrompt = "Id";
            this.textEditId.Size = new System.Drawing.Size(173, 20);
            this.textEditId.TabIndex = 1;
            // 
            // textEditSite
            // 
            this.textEditSite.Location = new System.Drawing.Point(9, 153);
            this.textEditSite.Name = "textEditSite";
            this.textEditSite.Properties.NullText = "Please enter the site name";
            this.textEditSite.Properties.NullValuePrompt = "Please enter the site name";
            this.textEditSite.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditSite.Size = new System.Drawing.Size(173, 20);
            this.textEditSite.TabIndex = 0;
            // 
            // SitesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 224);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "SitesView";
            this.Text = "SitesView";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSite.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraGrid.GridControl gridControlCodifiedValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCodifiedResults;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSite;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.TextEdit textEditSite;
    }
}