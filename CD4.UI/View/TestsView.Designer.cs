namespace CD4.UI.View
{
    partial class TestsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestsView));
            this.gridControlCodifiedValues = new DevExpress.XtraGrid.GridControl();
            this.gridViewTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResultDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsReportable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.checkEditIsReportable = new DevExpress.XtraEditors.CheckEdit();
            this.textEditResultMask = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditTestDataType = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.textEditDescription = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsReportable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditResultMask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTestDataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlCodifiedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCodifiedValues.Location = new System.Drawing.Point(0, 0);
            this.gridControlCodifiedValues.MainView = this.gridViewTests;
            this.gridControlCodifiedValues.Name = "gridControlCodifiedValues";
            this.gridControlCodifiedValues.Size = new System.Drawing.Size(574, 279);
            this.gridControlCodifiedValues.TabIndex = 0;
            this.gridControlCodifiedValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTests});
            // 
            // gridViewTests
            // 
            this.gridViewTests.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnDescription,
            this.gridColumnResultDataType,
            this.gridColumnIsReportable,
            this.gridColumnMask});
            this.gridViewTests.GridControl = this.gridControlCodifiedValues;
            this.gridViewTests.Name = "gridViewTests";
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 45;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 1;
            this.gridColumnDescription.Width = 195;
            // 
            // gridColumnResultDataType
            // 
            this.gridColumnResultDataType.Caption = "Result Type";
            this.gridColumnResultDataType.FieldName = "ResultDataType";
            this.gridColumnResultDataType.Name = "gridColumnResultDataType";
            this.gridColumnResultDataType.Visible = true;
            this.gridColumnResultDataType.VisibleIndex = 2;
            this.gridColumnResultDataType.Width = 113;
            // 
            // gridColumnIsReportable
            // 
            this.gridColumnIsReportable.Caption = "Is Reportable";
            this.gridColumnIsReportable.FieldName = "IsReportable";
            this.gridColumnIsReportable.Name = "gridColumnIsReportable";
            this.gridColumnIsReportable.Visible = true;
            this.gridColumnIsReportable.VisibleIndex = 4;
            this.gridColumnIsReportable.Width = 80;
            // 
            // gridColumnMask
            // 
            this.gridColumnMask.Caption = "Mask";
            this.gridColumnMask.FieldName = "Mask";
            this.gridColumnMask.Name = "gridColumnMask";
            this.gridColumnMask.Visible = true;
            this.gridColumnMask.VisibleIndex = 3;
            this.gridColumnMask.Width = 123;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlCodifiedValues);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditIsReportable);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditResultMask);
            this.splitContainerControl.Panel2.Controls.Add(this.lookUpEditTestDataType);
            this.splitContainerControl.Panel2.Controls.Add(this.simpleButtonSave);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditId);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditDescription);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(795, 279);
            this.splitContainerControl.SplitterPosition = 574;
            this.splitContainerControl.TabIndex = 2;
            // 
            // checkEditIsReportable
            // 
            this.checkEditIsReportable.Location = new System.Drawing.Point(17, 200);
            this.checkEditIsReportable.Name = "checkEditIsReportable";
            this.checkEditIsReportable.Properties.Caption = "Reportable ?";
            this.checkEditIsReportable.Size = new System.Drawing.Size(102, 19);
            this.checkEditIsReportable.TabIndex = 6;
            // 
            // textEditResultMask
            // 
            this.textEditResultMask.Location = new System.Drawing.Point(17, 174);
            this.textEditResultMask.Name = "textEditResultMask";
            this.textEditResultMask.Properties.NullText = "Please enter the result mask";
            this.textEditResultMask.Properties.NullValuePrompt = "Please enter the result mask";
            this.textEditResultMask.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditResultMask.Size = new System.Drawing.Size(173, 20);
            this.textEditResultMask.TabIndex = 5;
            // 
            // lookUpEditTestDataType
            // 
            this.lookUpEditTestDataType.Location = new System.Drawing.Point(17, 148);
            this.lookUpEditTestDataType.Name = "lookUpEditTestDataType";
            this.lookUpEditTestDataType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEditTestDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTestDataType.Properties.DropDownRows = 3;
            this.lookUpEditTestDataType.Properties.NullText = "Select the test data type";
            this.lookUpEditTestDataType.Properties.NullValuePrompt = "Select the test data type";
            this.lookUpEditTestDataType.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditTestDataType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditTestDataType.Properties.ShowHeader = false;
            this.lookUpEditTestDataType.Size = new System.Drawing.Size(173, 20);
            this.lookUpEditTestDataType.TabIndex = 4;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSave.ImageOptions.SvgImage")));
            this.simpleButtonSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonSave.Location = new System.Drawing.Point(17, 233);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(173, 34);
            this.simpleButtonSave.TabIndex = 3;
            // 
            // textEditId
            // 
            this.textEditId.Enabled = false;
            this.textEditId.Location = new System.Drawing.Point(17, 24);
            this.textEditId.Name = "textEditId";
            this.textEditId.Properties.NullText = "Id";
            this.textEditId.Properties.NullValuePrompt = "Id";
            this.textEditId.Size = new System.Drawing.Size(173, 20);
            this.textEditId.TabIndex = 1;
            // 
            // textEditDescription
            // 
            this.textEditDescription.Location = new System.Drawing.Point(17, 122);
            this.textEditDescription.Name = "textEditDescription";
            this.textEditDescription.Properties.NullText = "Please enter the test description";
            this.textEditDescription.Properties.NullValuePrompt = "Please enter the test Description";
            this.textEditDescription.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditDescription.Size = new System.Drawing.Size(173, 20);
            this.textEditDescription.TabIndex = 0;
            // 
            // TestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 279);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "TestsView";
            this.Text = "TestsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsReportable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditResultMask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTestDataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCodifiedValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTests;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.TextEdit textEditResultMask;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTestDataType;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.TextEdit textEditDescription;
        private DevExpress.XtraEditors.CheckEdit checkEditIsReportable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResultDataType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsReportable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMask;
    }
}