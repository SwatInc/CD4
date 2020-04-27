namespace CD4.UI.View
{
    partial class AtollIslandView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtollIslandView));
            this.gridControlCodifiedValues = new DevExpress.XtraGrid.GridControl();
            this.gridViewCodifiedResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAtoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsland = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textEditIsland = new DevExpress.XtraEditors.TextEdit();
            this.groupControlAddAtoll = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.textEditAtoll = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditSelectAtoll = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditSelectIsland = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIsland.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddAtoll)).BeginInit();
            this.groupControlAddAtoll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAtoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectAtoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectIsland.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlCodifiedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCodifiedValues.Location = new System.Drawing.Point(0, 0);
            this.gridControlCodifiedValues.MainView = this.gridViewCodifiedResults;
            this.gridControlCodifiedValues.Name = "gridControlCodifiedValues";
            this.gridControlCodifiedValues.Size = new System.Drawing.Size(389, 256);
            this.gridControlCodifiedValues.TabIndex = 0;
            this.gridControlCodifiedValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCodifiedResults});
            // 
            // gridViewCodifiedResults
            // 
            this.gridViewCodifiedResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnAtoll,
            this.gridColumnIsland});
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
            this.gridColumnId.Width = 73;
            // 
            // gridColumnAtoll
            // 
            this.gridColumnAtoll.Caption = "Atoll";
            this.gridColumnAtoll.FieldName = "Atoll";
            this.gridColumnAtoll.Name = "gridColumnAtoll";
            this.gridColumnAtoll.Visible = true;
            this.gridColumnAtoll.VisibleIndex = 1;
            this.gridColumnAtoll.Width = 134;
            // 
            // gridColumnIsland
            // 
            this.gridColumnIsland.Caption = "Island";
            this.gridColumnIsland.FieldName = "Island";
            this.gridColumnIsland.Name = "gridColumnIsland";
            this.gridColumnIsland.Visible = true;
            this.gridColumnIsland.VisibleIndex = 2;
            this.gridColumnIsland.Width = 173;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlCodifiedValues);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl.Panel2.Controls.Add(this.groupControlAddAtoll);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(759, 256);
            this.splitContainerControl.SplitterPosition = 389;
            this.splitContainerControl.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lookUpEditSelectIsland);
            this.groupControl2.Controls.Add(this.lookUpEditSelectAtoll);
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Location = new System.Drawing.Point(6, 118);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(352, 133);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "3. Map Island And Atoll";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButton2.Location = new System.Drawing.Point(197, 94);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(135, 34);
            this.simpleButton2.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.textEditIsland);
            this.groupControl1.Location = new System.Drawing.Point(185, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(173, 106);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "2. Add Island";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButton1.Location = new System.Drawing.Point(18, 63);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(135, 34);
            this.simpleButton1.TabIndex = 7;
            // 
            // textEditIsland
            // 
            this.textEditIsland.Location = new System.Drawing.Point(18, 33);
            this.textEditIsland.Name = "textEditIsland";
            this.textEditIsland.Properties.NullText = "Island";
            this.textEditIsland.Properties.NullValuePrompt = "Island";
            this.textEditIsland.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditIsland.Size = new System.Drawing.Size(135, 20);
            this.textEditIsland.TabIndex = 4;
            // 
            // groupControlAddAtoll
            // 
            this.groupControlAddAtoll.Controls.Add(this.simpleButton3);
            this.groupControlAddAtoll.Controls.Add(this.textEditAtoll);
            this.groupControlAddAtoll.Location = new System.Drawing.Point(6, 6);
            this.groupControlAddAtoll.Name = "groupControlAddAtoll";
            this.groupControlAddAtoll.Size = new System.Drawing.Size(173, 106);
            this.groupControlAddAtoll.TabIndex = 8;
            this.groupControlAddAtoll.Text = "1. Add Atoll";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButton3.Location = new System.Drawing.Point(17, 63);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(135, 34);
            this.simpleButton3.TabIndex = 7;
            // 
            // textEditAtoll
            // 
            this.textEditAtoll.Location = new System.Drawing.Point(17, 33);
            this.textEditAtoll.Name = "textEditAtoll";
            this.textEditAtoll.Properties.NullText = "Atoll";
            this.textEditAtoll.Properties.NullValuePrompt = "Atoll";
            this.textEditAtoll.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditAtoll.Size = new System.Drawing.Size(135, 20);
            this.textEditAtoll.TabIndex = 4;
            // 
            // lookUpEditSelectAtoll
            // 
            this.lookUpEditSelectAtoll.Location = new System.Drawing.Point(17, 36);
            this.lookUpEditSelectAtoll.Name = "lookUpEditSelectAtoll";
            this.lookUpEditSelectAtoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSelectAtoll.Properties.NullText = "Select Atoll";
            this.lookUpEditSelectAtoll.Size = new System.Drawing.Size(315, 20);
            this.lookUpEditSelectAtoll.TabIndex = 8;
            // 
            // lookUpEditSelectIsland
            // 
            this.lookUpEditSelectIsland.Location = new System.Drawing.Point(17, 62);
            this.lookUpEditSelectIsland.Name = "lookUpEditSelectIsland";
            this.lookUpEditSelectIsland.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSelectIsland.Properties.NullText = "Select Island";
            this.lookUpEditSelectIsland.Properties.NullValuePrompt = "Select Island";
            this.lookUpEditSelectIsland.Size = new System.Drawing.Size(315, 20);
            this.lookUpEditSelectIsland.TabIndex = 9;
            // 
            // AtollIslandView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 256);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "AtollIslandView";
            this.Text = "AtollIslandView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditIsland.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAddAtoll)).EndInit();
            this.groupControlAddAtoll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditAtoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectAtoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectIsland.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCodifiedValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCodifiedResults;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAtoll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsland;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEditIsland;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.GroupControl groupControlAddAtoll;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.TextEdit textEditAtoll;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSelectIsland;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSelectAtoll;
    }
}