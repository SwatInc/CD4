namespace CD4.UI.View
{
    partial class PrinterSettings
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
            DevExpress.XtraGrid.Views.Grid.GridView gridViewSavedPrinters;
            this.xtraTabControlPrinterSettings = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControlSavedPrintersList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlSavedPrinters = new DevExpress.XtraGrid.GridControl();
            this.labelControlWorkStation = new DevExpress.XtraEditors.LabelControl();
            gridViewSavedPrinters = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPrinterSettings)).BeginInit();
            this.xtraTabControlPrinterSettings.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSavedPrintersList)).BeginInit();
            this.groupControlSavedPrintersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSavedPrinters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewSavedPrinters)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlPrinterSettings
            // 
            this.xtraTabControlPrinterSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlPrinterSettings.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlPrinterSettings.Name = "xtraTabControlPrinterSettings";
            this.xtraTabControlPrinterSettings.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControlPrinterSettings.Size = new System.Drawing.Size(415, 268);
            this.xtraTabControlPrinterSettings.TabIndex = 0;
            this.xtraTabControlPrinterSettings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControlSavedPrintersList);
            this.xtraTabPage1.Controls.Add(this.lookUpEdit2);
            this.xtraTabPage1.Controls.Add(this.lookUpEdit1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(409, 240);
            this.xtraTabPage1.Text = "System Printer Settings";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(409, 240);
            this.xtraTabPage2.Text = "All Printers";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(260, 13);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "Select Printer Type";
            this.lookUpEdit1.Size = new System.Drawing.Size(138, 20);
            this.lookUpEdit1.TabIndex = 0;
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.Location = new System.Drawing.Point(11, 13);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Properties.NullText = "Detected Local Printers List";
            this.lookUpEdit2.Size = new System.Drawing.Size(243, 20);
            this.lookUpEdit2.TabIndex = 1;
            // 
            // groupControlSavedPrintersList
            // 
            this.groupControlSavedPrintersList.Controls.Add(this.labelControlWorkStation);
            this.groupControlSavedPrintersList.Controls.Add(this.gridControlSavedPrinters);
            this.groupControlSavedPrintersList.Location = new System.Drawing.Point(11, 39);
            this.groupControlSavedPrintersList.Name = "groupControlSavedPrintersList";
            this.groupControlSavedPrintersList.Size = new System.Drawing.Size(387, 194);
            this.groupControlSavedPrintersList.TabIndex = 2;
            this.groupControlSavedPrintersList.Text = "Saved Printers";
            // 
            // gridControlSavedPrinters
            // 
            this.gridControlSavedPrinters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSavedPrinters.Location = new System.Drawing.Point(2, 20);
            this.gridControlSavedPrinters.MainView = gridViewSavedPrinters;
            this.gridControlSavedPrinters.Name = "gridControlSavedPrinters";
            this.gridControlSavedPrinters.Size = new System.Drawing.Size(383, 172);
            this.gridControlSavedPrinters.TabIndex = 0;
            this.gridControlSavedPrinters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridViewSavedPrinters});
            // 
            // gridViewSavedPrinters
            // 
            gridViewSavedPrinters.GridControl = this.gridControlSavedPrinters;
            gridViewSavedPrinters.Name = "gridViewSavedPrinters";
            gridViewSavedPrinters.OptionsView.ShowGroupPanel = false;
            // 
            // labelControlWorkStation
            // 
            this.labelControlWorkStation.Location = new System.Drawing.Point(95, 3);
            this.labelControlWorkStation.Name = "labelControlWorkStation";
            this.labelControlWorkStation.Size = new System.Drawing.Size(86, 13);
            this.labelControlWorkStation.TabIndex = 1;
            this.labelControlWorkStation.Text = "WorkStationName";
            // 
            // PrinterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 268);
            this.Controls.Add(this.xtraTabControlPrinterSettings);
            this.Name = "PrinterSettings";
            this.Text = "PrinterSettings";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPrinterSettings)).EndInit();
            this.xtraTabControlPrinterSettings.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSavedPrintersList)).EndInit();
            this.groupControlSavedPrintersList.ResumeLayout(false);
            this.groupControlSavedPrintersList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSavedPrinters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(gridViewSavedPrinters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlPrinterSettings;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl groupControlSavedPrintersList;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private DevExpress.XtraGrid.GridControl gridControlSavedPrinters;
        private DevExpress.XtraEditors.LabelControl labelControlWorkStation;
    }
}