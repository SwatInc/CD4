
namespace CD4.ExcelInterface
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tabPaneLogs = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageQueue = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPageLogs = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.simpleButtonExportToCD4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInterpretData = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlLogsDisplay = new DevExpress.XtraGrid.GridControl();
            this.gridViewLogsDisplay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpEditSelectTestKit = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControlQueue = new DevExpress.XtraGrid.GridControl();
            this.gridViewQueue = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneLogs)).BeginInit();
            this.tabPaneLogs.SuspendLayout();
            this.tabNavigationPageQueue.SuspendLayout();
            this.tabNavigationPageLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogsDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogsDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectTestKit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneLogs
            // 
            this.tabPaneLogs.Controls.Add(this.tabNavigationPageQueue);
            this.tabPaneLogs.Controls.Add(this.tabNavigationPageLogs);
            this.tabPaneLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneLogs.Location = new System.Drawing.Point(0, 0);
            this.tabPaneLogs.Name = "tabPaneLogs";
            this.tabPaneLogs.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageQueue,
            this.tabNavigationPageLogs});
            this.tabPaneLogs.RegularSize = new System.Drawing.Size(989, 361);
            this.tabPaneLogs.SelectedPage = this.tabNavigationPageQueue;
            this.tabPaneLogs.Size = new System.Drawing.Size(989, 361);
            this.tabPaneLogs.TabIndex = 1;
            this.tabPaneLogs.Text = "Logs & Actions";
            // 
            // tabNavigationPageQueue
            // 
            this.tabNavigationPageQueue.Caption = "Queue";
            this.tabNavigationPageQueue.Controls.Add(this.gridControlQueue);
            this.tabNavigationPageQueue.Name = "tabNavigationPageQueue";
            this.tabNavigationPageQueue.Size = new System.Drawing.Size(989, 334);
            // 
            // tabNavigationPageLogs
            // 
            this.tabNavigationPageLogs.Caption = "Logs & Actions";
            this.tabNavigationPageLogs.Controls.Add(this.lookUpEditSelectTestKit);
            this.tabNavigationPageLogs.Controls.Add(this.simpleButtonInterpretData);
            this.tabNavigationPageLogs.Controls.Add(this.simpleButtonExportToCD4);
            this.tabNavigationPageLogs.Controls.Add(this.gridControlLogsDisplay);
            this.tabNavigationPageLogs.Name = "tabNavigationPageLogs";
            this.tabNavigationPageLogs.Size = new System.Drawing.Size(989, 334);
            // 
            // simpleButtonExportToCD4
            // 
            this.simpleButtonExportToCD4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonExportToCD4.Location = new System.Drawing.Point(876, 6);
            this.simpleButtonExportToCD4.Name = "simpleButtonExportToCD4";
            this.simpleButtonExportToCD4.Size = new System.Drawing.Size(104, 23);
            this.simpleButtonExportToCD4.TabIndex = 3;
            this.simpleButtonExportToCD4.Text = "Export To CD4";
            // 
            // simpleButtonInterpretData
            // 
            this.simpleButtonInterpretData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonInterpretData.Location = new System.Drawing.Point(766, 6);
            this.simpleButtonInterpretData.Name = "simpleButtonInterpretData";
            this.simpleButtonInterpretData.Size = new System.Drawing.Size(104, 23);
            this.simpleButtonInterpretData.TabIndex = 5;
            this.simpleButtonInterpretData.Text = "Interpret Data";
            // 
            // gridControlLogsDisplay
            // 
            this.gridControlLogsDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLogsDisplay.Location = new System.Drawing.Point(0, 0);
            this.gridControlLogsDisplay.MainView = this.gridViewLogsDisplay;
            this.gridControlLogsDisplay.Name = "gridControlLogsDisplay";
            this.gridControlLogsDisplay.Size = new System.Drawing.Size(989, 334);
            this.gridControlLogsDisplay.TabIndex = 2;
            this.gridControlLogsDisplay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLogsDisplay});
            // 
            // gridViewLogsDisplay
            // 
            this.gridViewLogsDisplay.GridControl = this.gridControlLogsDisplay;
            this.gridViewLogsDisplay.Name = "gridViewLogsDisplay";
            // 
            // lookUpEditSelectTestKit
            // 
            this.lookUpEditSelectTestKit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUpEditSelectTestKit.Location = new System.Drawing.Point(614, 8);
            this.lookUpEditSelectTestKit.Name = "lookUpEditSelectTestKit";
            this.lookUpEditSelectTestKit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSelectTestKit.Properties.DisplayMember = "Kit";
            this.lookUpEditSelectTestKit.Properties.ValueMember = "Id";
            this.lookUpEditSelectTestKit.Size = new System.Drawing.Size(146, 20);
            this.lookUpEditSelectTestKit.TabIndex = 6;
            // 
            // gridControlQueue
            // 
            this.gridControlQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQueue.Location = new System.Drawing.Point(0, 0);
            this.gridControlQueue.MainView = this.gridViewQueue;
            this.gridControlQueue.Name = "gridControlQueue";
            this.gridControlQueue.Size = new System.Drawing.Size(989, 334);
            this.gridControlQueue.TabIndex = 2;
            this.gridControlQueue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQueue});
            // 
            // gridViewQueue
            // 
            this.gridViewQueue.GridControl = this.gridControlQueue;
            this.gridViewQueue.Name = "gridViewQueue";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 361);
            this.Controls.Add(this.tabPaneLogs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneLogs)).EndInit();
            this.tabPaneLogs.ResumeLayout(false);
            this.tabNavigationPageQueue.ResumeLayout(false);
            this.tabNavigationPageLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogsDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogsDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSelectTestKit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneLogs;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageQueue;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageLogs;
        private DevExpress.XtraGrid.GridControl gridControlLogsDisplay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogsDisplay;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExportToCD4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonInterpretData;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSelectTestKit;
        private DevExpress.XtraGrid.GridControl gridControlQueue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQueue;
    }
}

