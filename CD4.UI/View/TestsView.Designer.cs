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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestsView));
            this.gridControlCodifiedValues = new DevExpress.XtraGrid.GridControl();
            this.gridViewTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResultDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsReportable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscipline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSampleType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDefaultCommented = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.lookUpEditUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEditDefaultCommented = new DevExpress.XtraEditors.CheckEdit();
            this.textEditCode = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditSampleType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDiscipline = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEditIsReportable = new DevExpress.XtraEditors.CheckEdit();
            this.textEditResultMask = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditTestDataType = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.textEditDescription = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar = new DevExpress.XtraBars.Bar();
            this.barButtonItemNewTest = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDefaultCommented.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDiscipline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsReportable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditResultMask.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTestDataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlCodifiedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCodifiedValues.Location = new System.Drawing.Point(0, 0);
            this.gridControlCodifiedValues.MainView = this.gridViewTests;
            this.gridControlCodifiedValues.Name = "gridControlCodifiedValues";
            this.gridControlCodifiedValues.Size = new System.Drawing.Size(1019, 430);
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
            this.gridColumnMask,
            this.gridColumnDiscipline,
            this.gridColumnSampleType,
            this.gridColumnUnit,
            this.gridColumnCode,
            this.gridColumnDefaultCommented});
            this.gridViewTests.GridControl = this.gridControlCodifiedValues;
            this.gridViewTests.Name = "gridViewTests";
            this.gridViewTests.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewTests.OptionsBehavior.Editable = false;
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 24;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 2;
            this.gridColumnDescription.Width = 88;
            // 
            // gridColumnResultDataType
            // 
            this.gridColumnResultDataType.Caption = "Result Type";
            this.gridColumnResultDataType.FieldName = "ResultDataType";
            this.gridColumnResultDataType.Name = "gridColumnResultDataType";
            this.gridColumnResultDataType.Visible = true;
            this.gridColumnResultDataType.VisibleIndex = 4;
            this.gridColumnResultDataType.Width = 63;
            // 
            // gridColumnIsReportable
            // 
            this.gridColumnIsReportable.Caption = "Is Reportable";
            this.gridColumnIsReportable.FieldName = "IsReportable";
            this.gridColumnIsReportable.Name = "gridColumnIsReportable";
            this.gridColumnIsReportable.Visible = true;
            this.gridColumnIsReportable.VisibleIndex = 7;
            this.gridColumnIsReportable.Width = 51;
            // 
            // gridColumnMask
            // 
            this.gridColumnMask.Caption = "Mask";
            this.gridColumnMask.FieldName = "Mask";
            this.gridColumnMask.Name = "gridColumnMask";
            this.gridColumnMask.Visible = true;
            this.gridColumnMask.VisibleIndex = 5;
            this.gridColumnMask.Width = 69;
            // 
            // gridColumnDiscipline
            // 
            this.gridColumnDiscipline.Caption = "Discipline";
            this.gridColumnDiscipline.FieldName = "Discipline";
            this.gridColumnDiscipline.Name = "gridColumnDiscipline";
            this.gridColumnDiscipline.Visible = true;
            this.gridColumnDiscipline.VisibleIndex = 1;
            this.gridColumnDiscipline.Width = 50;
            // 
            // gridColumnSampleType
            // 
            this.gridColumnSampleType.Caption = "Sample Type";
            this.gridColumnSampleType.FieldName = "SampleType";
            this.gridColumnSampleType.Name = "gridColumnSampleType";
            this.gridColumnSampleType.Visible = true;
            this.gridColumnSampleType.VisibleIndex = 3;
            this.gridColumnSampleType.Width = 76;
            // 
            // gridColumnUnit
            // 
            this.gridColumnUnit.Caption = "Unit";
            this.gridColumnUnit.FieldName = "Unit";
            this.gridColumnUnit.Name = "gridColumnUnit";
            this.gridColumnUnit.Visible = true;
            this.gridColumnUnit.VisibleIndex = 6;
            this.gridColumnUnit.Width = 38;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Code";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 8;
            this.gridColumnCode.Width = 50;
            // 
            // gridColumnDefaultCommented
            // 
            this.gridColumnDefaultCommented.Caption = "Default Comment";
            this.gridColumnDefaultCommented.FieldName = "DefaultCommented";
            this.gridColumnDefaultCommented.Name = "gridColumnDefaultCommented";
            this.gridColumnDefaultCommented.Visible = true;
            this.gridColumnDefaultCommented.VisibleIndex = 9;
            this.gridColumnDefaultCommented.Width = 58;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlCodifiedValues);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.lookUpEditUnit);
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditDefaultCommented);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditCode);
            this.splitContainerControl.Panel2.Controls.Add(this.lookUpEditSampleType);
            this.splitContainerControl.Panel2.Controls.Add(this.lookUpEditDiscipline);
            this.splitContainerControl.Panel2.Controls.Add(this.checkEditIsReportable);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditResultMask);
            this.splitContainerControl.Panel2.Controls.Add(this.lookUpEditTestDataType);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditId);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditDescription);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1229, 430);
            this.splitContainerControl.SplitterPosition = 205;
            this.splitContainerControl.TabIndex = 2;
            // 
            // lookUpEditUnit
            // 
            this.lookUpEditUnit.Location = new System.Drawing.Point(17, 226);
            this.lookUpEditUnit.Name = "lookUpEditUnit";
            this.lookUpEditUnit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEditUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditUnit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Unit")});
            this.lookUpEditUnit.Properties.DropDownRows = 3;
            this.lookUpEditUnit.Properties.NullText = "Unit";
            this.lookUpEditUnit.Properties.NullValuePrompt = "Unit";
            this.lookUpEditUnit.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditUnit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditUnit.Properties.ShowHeader = false;
            this.lookUpEditUnit.Size = new System.Drawing.Size(173, 20);
            this.lookUpEditUnit.TabIndex = 12;
            // 
            // checkEditDefaultCommented
            // 
            this.checkEditDefaultCommented.Location = new System.Drawing.Point(17, 311);
            this.checkEditDefaultCommented.Name = "checkEditDefaultCommented";
            this.checkEditDefaultCommented.Properties.Caption = "Default Commented ?";
            this.checkEditDefaultCommented.Size = new System.Drawing.Size(173, 19);
            this.checkEditDefaultCommented.TabIndex = 11;
            // 
            // textEditCode
            // 
            this.textEditCode.Location = new System.Drawing.Point(17, 254);
            this.textEditCode.Name = "textEditCode";
            this.textEditCode.Properties.NullText = "Code";
            this.textEditCode.Properties.NullValuePrompt = "Code";
            this.textEditCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditCode.Size = new System.Drawing.Size(173, 20);
            this.textEditCode.TabIndex = 9;
            // 
            // lookUpEditSampleType
            // 
            this.lookUpEditSampleType.Location = new System.Drawing.Point(17, 148);
            this.lookUpEditSampleType.Name = "lookUpEditSampleType";
            this.lookUpEditSampleType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEditSampleType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSampleType.Properties.DropDownRows = 3;
            this.lookUpEditSampleType.Properties.NullText = "Sample Type";
            this.lookUpEditSampleType.Properties.NullValuePrompt = "Sample Type";
            this.lookUpEditSampleType.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditSampleType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditSampleType.Properties.ShowHeader = false;
            this.lookUpEditSampleType.Size = new System.Drawing.Size(173, 20);
            this.lookUpEditSampleType.TabIndex = 8;
            // 
            // lookUpEditDiscipline
            // 
            this.lookUpEditDiscipline.Location = new System.Drawing.Point(17, 96);
            this.lookUpEditDiscipline.Name = "lookUpEditDiscipline";
            this.lookUpEditDiscipline.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEditDiscipline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDiscipline.Properties.DropDownRows = 3;
            this.lookUpEditDiscipline.Properties.NullText = "Discipline";
            this.lookUpEditDiscipline.Properties.NullValuePrompt = "Discipline";
            this.lookUpEditDiscipline.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditDiscipline.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditDiscipline.Properties.ShowHeader = false;
            this.lookUpEditDiscipline.Size = new System.Drawing.Size(173, 20);
            this.lookUpEditDiscipline.TabIndex = 7;
            // 
            // checkEditIsReportable
            // 
            this.checkEditIsReportable.Location = new System.Drawing.Point(17, 286);
            this.checkEditIsReportable.Name = "checkEditIsReportable";
            this.checkEditIsReportable.Properties.Caption = "Reportable ?";
            this.checkEditIsReportable.Size = new System.Drawing.Size(102, 19);
            this.checkEditIsReportable.TabIndex = 6;
            // 
            // textEditResultMask
            // 
            this.textEditResultMask.Location = new System.Drawing.Point(17, 200);
            this.textEditResultMask.Name = "textEditResultMask";
            this.textEditResultMask.Properties.NullText = "Mask";
            this.textEditResultMask.Properties.NullValuePrompt = "Mask";
            this.textEditResultMask.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditResultMask.Size = new System.Drawing.Size(173, 20);
            this.textEditResultMask.TabIndex = 5;
            // 
            // lookUpEditTestDataType
            // 
            this.lookUpEditTestDataType.Location = new System.Drawing.Point(17, 174);
            this.lookUpEditTestDataType.Name = "lookUpEditTestDataType";
            this.lookUpEditTestDataType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lookUpEditTestDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTestDataType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataType", "ResultDataType")});
            this.lookUpEditTestDataType.Properties.DropDownRows = 3;
            this.lookUpEditTestDataType.Properties.NullText = "Result Data Type";
            this.lookUpEditTestDataType.Properties.NullValuePrompt = "Result Data Type";
            this.lookUpEditTestDataType.Properties.NullValuePromptShowForEmptyValue = true;
            this.lookUpEditTestDataType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditTestDataType.Properties.ShowHeader = false;
            this.lookUpEditTestDataType.Size = new System.Drawing.Size(173, 20);
            this.lookUpEditTestDataType.TabIndex = 4;
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
            this.textEditDescription.Properties.NullText = "Test Description";
            this.textEditDescription.Properties.NullValuePrompt = "Test Description";
            this.textEditDescription.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditDescription.Size = new System.Drawing.Size(173, 20);
            this.textEditDescription.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemNewTest,
            this.barButtonItemSave});
            this.barManager1.MaxItemId = 3;
            // 
            // bar
            // 
            this.bar.BarName = "Tools";
            this.bar.DockCol = 0;
            this.bar.DockRow = 0;
            this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemNewTest),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSave)});
            this.bar.Offset = 1119;
            this.bar.Text = "Tools";
            // 
            // barButtonItemNewTest
            // 
            this.barButtonItemNewTest.Caption = "New Test";
            this.barButtonItemNewTest.Id = 1;
            this.barButtonItemNewTest.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemNewTest.ImageOptions.SvgImage")));
            this.barButtonItemNewTest.Name = "barButtonItemNewTest";
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "Save";
            this.barButtonItemSave.Id = 2;
            this.barButtonItemSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSave.ImageOptions.SvgImage")));
            this.barButtonItemSave.Name = "barButtonItemSave";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1229, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 461);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1229, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 430);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1229, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 430);
            // 
            // TestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 461);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TestsView";
            this.Text = "TestsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDefaultCommented.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSampleType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDiscipline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsReportable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditResultMask.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTestDataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlCodifiedValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTests;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.TextEdit textEditResultMask;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTestDataType;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.TextEdit textEditDescription;
        private DevExpress.XtraEditors.CheckEdit checkEditIsReportable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResultDataType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsReportable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMask;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscipline;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSampleType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDefaultCommented;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSampleType;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDiscipline;
        private DevExpress.XtraEditors.CheckEdit checkEditDefaultCommented;
        private DevExpress.XtraEditors.TextEdit textEditCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditUnit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNewTest;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}