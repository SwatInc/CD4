
namespace CD4.UI.View
{
    partial class LateOrderEntryView
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
            this.groupControlSelectedTestData = new DevExpress.XtraEditors.GroupControl();
            this.gridControlRequestedTests = new DevExpress.XtraGrid.GridControl();
            this.gridViewRequestedTests = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControlTestSelection = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonDeleteSelectedRows = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.progressPanelTestData = new DevExpress.XtraWaitForm.ProgressPanel();
            this.simpleButtonConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditTests = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedTestData)).BeginInit();
            this.groupControlSelectedTestData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRequestedTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRequestedTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTestSelection)).BeginInit();
            this.groupControlTestSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTests.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlSelectedTestData
            // 
            this.groupControlSelectedTestData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlSelectedTestData.Controls.Add(this.gridControlRequestedTests);
            this.groupControlSelectedTestData.Location = new System.Drawing.Point(3, 3);
            this.groupControlSelectedTestData.Name = "groupControlSelectedTestData";
            this.groupControlSelectedTestData.Size = new System.Drawing.Size(350, 218);
            this.groupControlSelectedTestData.TabIndex = 1;
            this.groupControlSelectedTestData.Text = "Selected Tests Data";
            // 
            // gridControlRequestedTests
            // 
            this.gridControlRequestedTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRequestedTests.Location = new System.Drawing.Point(2, 20);
            this.gridControlRequestedTests.MainView = this.gridViewRequestedTests;
            this.gridControlRequestedTests.Name = "gridControlRequestedTests";
            this.gridControlRequestedTests.Size = new System.Drawing.Size(346, 196);
            this.gridControlRequestedTests.TabIndex = 0;
            this.gridControlRequestedTests.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRequestedTests});
            // 
            // gridViewRequestedTests
            // 
            this.gridViewRequestedTests.GridControl = this.gridControlRequestedTests;
            this.gridViewRequestedTests.Name = "gridViewRequestedTests";
            this.gridViewRequestedTests.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewRequestedTests.OptionsBehavior.Editable = false;
            this.gridViewRequestedTests.OptionsSelection.MultiSelect = true;
            this.gridViewRequestedTests.OptionsView.ShowGroupPanel = false;
            // 
            // groupControlTestSelection
            // 
            this.groupControlTestSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlTestSelection.Controls.Add(this.progressPanelTestData);
            this.groupControlTestSelection.Controls.Add(this.simpleButtonDeleteSelectedRows);
            this.groupControlTestSelection.Controls.Add(this.simpleButtonClose);
            this.groupControlTestSelection.Controls.Add(this.simpleButtonConfirm);
            this.groupControlTestSelection.Controls.Add(this.lookUpEditTests);
            this.groupControlTestSelection.Location = new System.Drawing.Point(357, 3);
            this.groupControlTestSelection.Name = "groupControlTestSelection";
            this.groupControlTestSelection.Size = new System.Drawing.Size(196, 218);
            this.groupControlTestSelection.TabIndex = 2;
            this.groupControlTestSelection.Tag = "ResultEntry.ReflexTesting";
            this.groupControlTestSelection.Text = "Test Selection";
            // 
            // simpleButtonDeleteSelectedRows
            // 
            this.simpleButtonDeleteSelectedRows.Location = new System.Drawing.Point(101, 157);
            this.simpleButtonDeleteSelectedRows.Name = "simpleButtonDeleteSelectedRows";
            this.simpleButtonDeleteSelectedRows.Size = new System.Drawing.Size(82, 23);
            this.simpleButtonDeleteSelectedRows.TabIndex = 18;
            this.simpleButtonDeleteSelectedRows.Tag = "";
            this.simpleButtonDeleteSelectedRows.Text = "Delete [ Del ]";
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Location = new System.Drawing.Point(101, 186);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(82, 23);
            this.simpleButtonClose.TabIndex = 17;
            this.simpleButtonClose.Tag = "";
            this.simpleButtonClose.Text = "Close [ F4 ]";
            // 
            // progressPanelTestData
            // 
            this.progressPanelTestData.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanelTestData.Appearance.Options.UseBackColor = true;
            this.progressPanelTestData.BarAnimationElementThickness = 2;
            this.progressPanelTestData.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressPanelTestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanelTestData.Location = new System.Drawing.Point(2, 20);
            this.progressPanelTestData.Name = "progressPanelTestData";
            this.progressPanelTestData.Size = new System.Drawing.Size(192, 196);
            this.progressPanelTestData.TabIndex = 0;
            this.progressPanelTestData.TabStop = false;
            this.progressPanelTestData.Text = "Request data";
            this.progressPanelTestData.Visible = false;
            // 
            // simpleButtonConfirm
            // 
            this.simpleButtonConfirm.Location = new System.Drawing.Point(13, 186);
            this.simpleButtonConfirm.Name = "simpleButtonConfirm";
            this.simpleButtonConfirm.Size = new System.Drawing.Size(82, 23);
            this.simpleButtonConfirm.TabIndex = 16;
            this.simpleButtonConfirm.Tag = "OrderEntry.Confirm";
            this.simpleButtonConfirm.Text = "Confirm [ F6 ]";
            // 
            // lookUpEditTests
            // 
            this.lookUpEditTests.Location = new System.Drawing.Point(16, 35);
            this.lookUpEditTests.Name = "lookUpEditTests";
            this.lookUpEditTests.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditTests.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.lookUpEditTests.Properties.NullText = "Select Tests";
            this.lookUpEditTests.Properties.NullValuePrompt = "Select Tests";
            this.lookUpEditTests.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookUpEditTests.Properties.ShowHeader = false;
            this.lookUpEditTests.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditTests.Properties.ValidateOnEnterKey = true;
            this.lookUpEditTests.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditTests.TabIndex = 1;
            // 
            // LateOrderEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 224);
            this.ControlBox = false;
            this.Controls.Add(this.groupControlSelectedTestData);
            this.Controls.Add(this.groupControlTestSelection);
            this.KeyPreview = true;
            this.Name = "LateOrderEntryView";
            this.Text = "Add Tests / Profile Tests";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSelectedTestData)).EndInit();
            this.groupControlSelectedTestData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRequestedTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRequestedTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTestSelection)).EndInit();
            this.groupControlTestSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditTests.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlSelectedTestData;
        private DevExpress.XtraGrid.GridControl gridControlRequestedTests;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRequestedTests;
        private DevExpress.XtraEditors.GroupControl groupControlTestSelection;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanelTestData;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditTests;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConfirm;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteSelectedRows;
    }
}