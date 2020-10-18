namespace CD4.UI.UserControls
{
    partial class GraphsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.testHistoryChartControl = new DevExpress.XtraCharts.ChartControl();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.rangeTrackBarControl = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.toggleSwitchResultsAndResultsWithDates = new DevExpress.XtraEditors.ToggleSwitch();
            this.checkEditEnableGraphLabels = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.testHistoryChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchResultsAndResultsWithDates.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditEnableGraphLabels.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // testHistoryChartControl
            // 
            this.testHistoryChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testHistoryChartControl.Legend.Name = "Default Legend";
            this.testHistoryChartControl.Location = new System.Drawing.Point(0, 0);
            this.testHistoryChartControl.Name = "testHistoryChartControl";
            this.testHistoryChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.testHistoryChartControl.Size = new System.Drawing.Size(547, 308);
            this.testHistoryChartControl.TabIndex = 1;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Horizontal = false;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.rangeTrackBarControl);
            this.splitContainerControl.Panel1.Controls.Add(this.toggleSwitchResultsAndResultsWithDates);
            this.splitContainerControl.Panel1.Controls.Add(this.checkEditEnableGraphLabels);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.testHistoryChartControl);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(547, 406);
            this.splitContainerControl.SplitterPosition = 93;
            this.splitContainerControl.TabIndex = 2;
            // 
            // rangeTrackBarControl
            // 
            this.rangeTrackBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rangeTrackBarControl.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(0, 0);
            this.rangeTrackBarControl.Location = new System.Drawing.Point(12, 38);
            this.rangeTrackBarControl.Name = "rangeTrackBarControl";
            this.rangeTrackBarControl.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.rangeTrackBarControl.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rangeTrackBarControl.Properties.ShowLabels = true;
            this.rangeTrackBarControl.Size = new System.Drawing.Size(514, 45);
            this.rangeTrackBarControl.TabIndex = 2;
            // 
            // toggleSwitchResultsAndResultsWithDates
            // 
            this.toggleSwitchResultsAndResultsWithDates.EditValue = true;
            this.toggleSwitchResultsAndResultsWithDates.Location = new System.Drawing.Point(150, 11);
            this.toggleSwitchResultsAndResultsWithDates.Name = "toggleSwitchResultsAndResultsWithDates";
            this.toggleSwitchResultsAndResultsWithDates.Properties.OffText = "Results";
            this.toggleSwitchResultsAndResultsWithDates.Properties.OnText = "Results with Result Dates";
            this.toggleSwitchResultsAndResultsWithDates.Size = new System.Drawing.Size(205, 24);
            this.toggleSwitchResultsAndResultsWithDates.TabIndex = 1;
            // 
            // checkEditEnableGraphLabels
            // 
            this.checkEditEnableGraphLabels.EditValue = true;
            this.checkEditEnableGraphLabels.Location = new System.Drawing.Point(12, 13);
            this.checkEditEnableGraphLabels.Name = "checkEditEnableGraphLabels";
            this.checkEditEnableGraphLabels.Properties.Caption = "Enable Graph Labels";
            this.checkEditEnableGraphLabels.Size = new System.Drawing.Size(132, 19);
            this.checkEditEnableGraphLabels.TabIndex = 0;
            // 
            // GraphsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Name = "GraphsUserControl";
            this.Size = new System.Drawing.Size(547, 406);
            ((System.ComponentModel.ISupportInitialize)(this.testHistoryChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchResultsAndResultsWithDates.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditEnableGraphLabels.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl testHistoryChartControl;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchResultsAndResultsWithDates;
        private DevExpress.XtraEditors.CheckEdit checkEditEnableGraphLabels;
        private DevExpress.XtraEditors.RangeTrackBarControl rangeTrackBarControl;
    }
}
