
namespace CD4.ExcelInterface.QuantStudio5
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
            this.components = new System.ComponentModel.Container();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItemExportToLIS = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItemAutoExport = new DevExpress.XtraBars.BarCheckItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabPaneLogs = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageQueue = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridControlQueue = new DevExpress.XtraGrid.GridControl();
            this.gridViewQueue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabNavigationPageLogs = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridControlLogs = new DevExpress.XtraGrid.GridControl();
            this.gridViewLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneLogs)).BeginInit();
            this.tabPaneLogs.SuspendLayout();
            this.tabNavigationPageQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueue)).BeginInit();
            this.tabNavigationPageLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemExportToLIS,
            this.barCheckItemAutoExport});
            this.barManager.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemExportToLIS),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItemAutoExport)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItemExportToLIS
            // 
            this.barButtonItemExportToLIS.Caption = "Export To LIS";
            this.barButtonItemExportToLIS.Id = 0;
            this.barButtonItemExportToLIS.Name = "barButtonItemExportToLIS";
            // 
            // barCheckItemAutoExport
            // 
            this.barCheckItemAutoExport.Caption = "Auto Export";
            this.barCheckItemAutoExport.Id = 1;
            this.barCheckItemAutoExport.Name = "barCheckItemAutoExport";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(823, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 348);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(823, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 319);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(823, 29);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 319);
            // 
            // tabPaneLogs
            // 
            this.tabPaneLogs.Controls.Add(this.tabNavigationPageQueue);
            this.tabPaneLogs.Controls.Add(this.tabNavigationPageLogs);
            this.tabPaneLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPaneLogs.Location = new System.Drawing.Point(0, 29);
            this.tabPaneLogs.Name = "tabPaneLogs";
            this.tabPaneLogs.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageQueue,
            this.tabNavigationPageLogs});
            this.tabPaneLogs.RegularSize = new System.Drawing.Size(823, 319);
            this.tabPaneLogs.SelectedPage = this.tabNavigationPageQueue;
            this.tabPaneLogs.Size = new System.Drawing.Size(823, 319);
            this.tabPaneLogs.TabIndex = 4;
            this.tabPaneLogs.Text = "Logs";
            // 
            // tabNavigationPageQueue
            // 
            this.tabNavigationPageQueue.Caption = "Queue";
            this.tabNavigationPageQueue.Controls.Add(this.gridControlQueue);
            this.tabNavigationPageQueue.Name = "tabNavigationPageQueue";
            this.tabNavigationPageQueue.Size = new System.Drawing.Size(823, 292);
            // 
            // gridControlQueue
            // 
            this.gridControlQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlQueue.Location = new System.Drawing.Point(0, 0);
            this.gridControlQueue.MainView = this.gridViewQueue;
            this.gridControlQueue.MenuManager = this.barManager;
            this.gridControlQueue.Name = "gridControlQueue";
            this.gridControlQueue.Size = new System.Drawing.Size(823, 292);
            this.gridControlQueue.TabIndex = 0;
            this.gridControlQueue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQueue});
            // 
            // gridViewQueue
            // 
            this.gridViewQueue.GridControl = this.gridControlQueue;
            this.gridViewQueue.Name = "gridViewQueue";
            // 
            // tabNavigationPageLogs
            // 
            this.tabNavigationPageLogs.Caption = "Logs & Actions";
            this.tabNavigationPageLogs.Controls.Add(this.gridControlLogs);
            this.tabNavigationPageLogs.Name = "tabNavigationPageLogs";
            this.tabNavigationPageLogs.Size = new System.Drawing.Size(823, 292);
            // 
            // gridControlLogs
            // 
            this.gridControlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLogs.Location = new System.Drawing.Point(0, 0);
            this.gridControlLogs.MainView = this.gridViewLogs;
            this.gridControlLogs.MenuManager = this.barManager;
            this.gridControlLogs.Name = "gridControlLogs";
            this.gridControlLogs.Size = new System.Drawing.Size(823, 292);
            this.gridControlLogs.TabIndex = 0;
            this.gridControlLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLogs});
            // 
            // gridViewLogs
            // 
            this.gridViewLogs.GridControl = this.gridControlLogs;
            this.gridViewLogs.Name = "gridViewLogs";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 348);
            this.Controls.Add(this.tabPaneLogs);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneLogs)).EndInit();
            this.tabPaneLogs.ResumeLayout(false);
            this.tabNavigationPageQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQueue)).EndInit();
            this.tabNavigationPageLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToLIS;
        private DevExpress.XtraBars.BarCheckItem barCheckItemAutoExport;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Navigation.TabPane tabPaneLogs;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageQueue;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageLogs;
        private DevExpress.XtraGrid.GridControl gridControlQueue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQueue;
        private DevExpress.XtraGrid.GridControl gridControlLogs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLogs;
    }
}