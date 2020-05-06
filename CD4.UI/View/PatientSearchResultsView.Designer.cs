namespace CD4.UI.View
{
    partial class PatientSearchResultsView
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
            this.gridControlPatientSearchResults = new DevExpress.XtraGrid.GridControl();
            this.gridViewPatientSearchResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPatientSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPatientSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPatientSearchResults
            // 
            this.gridControlPatientSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPatientSearchResults.Location = new System.Drawing.Point(0, 0);
            this.gridControlPatientSearchResults.MainView = this.gridViewPatientSearchResults;
            this.gridControlPatientSearchResults.Name = "gridControlPatientSearchResults";
            this.gridControlPatientSearchResults.Size = new System.Drawing.Size(719, 268);
            this.gridControlPatientSearchResults.TabIndex = 0;
            this.gridControlPatientSearchResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPatientSearchResults});
            // 
            // gridViewPatientSearchResults
            // 
            this.gridViewPatientSearchResults.GridControl = this.gridControlPatientSearchResults;
            this.gridViewPatientSearchResults.Name = "gridViewPatientSearchResults";
            this.gridViewPatientSearchResults.OptionsBehavior.Editable = false;
            // 
            // PatientSearchResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 268);
            this.Controls.Add(this.gridControlPatientSearchResults);
            this.Name = "PatientSearchResultsView";
            this.Text = "PatientSearchResultsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPatientSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPatientSearchResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPatientSearchResults;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPatientSearchResults;
    }
}