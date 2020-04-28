namespace CD4.UI.View
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemCodifiedResults = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCountries = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemGender = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIslandAtoll = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemScientist = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClinicalDetails = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSites = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTests = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemCodifiedResults,
            this.barButtonItemCountries,
            this.barButtonItemGender,
            this.barButtonItemIslandAtoll,
            this.barButtonItemScientist,
            this.barButtonItemClinicalDetails,
            this.barButtonItemSites,
            this.barButtonItemTests});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(915, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItemCodifiedResults
            // 
            this.barButtonItemCodifiedResults.Caption = "Codified Results";
            this.barButtonItemCodifiedResults.Id = 1;
            this.barButtonItemCodifiedResults.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCodifiedResults.ImageOptions.SvgImage")));
            this.barButtonItemCodifiedResults.Name = "barButtonItemCodifiedResults";
            this.barButtonItemCodifiedResults.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCountries
            // 
            this.barButtonItemCountries.Caption = "Countries";
            this.barButtonItemCountries.Id = 2;
            this.barButtonItemCountries.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCountries.ImageOptions.SvgImage")));
            this.barButtonItemCountries.Name = "barButtonItemCountries";
            this.barButtonItemCountries.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemGender
            // 
            this.barButtonItemGender.Caption = "Gender";
            this.barButtonItemGender.Id = 3;
            this.barButtonItemGender.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemGender.ImageOptions.SvgImage")));
            this.barButtonItemGender.Name = "barButtonItemGender";
            this.barButtonItemGender.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemIslandAtoll
            // 
            this.barButtonItemIslandAtoll.Caption = "Atolls and Island";
            this.barButtonItemIslandAtoll.Id = 4;
            this.barButtonItemIslandAtoll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemIslandAtoll.ImageOptions.SvgImage")));
            this.barButtonItemIslandAtoll.Name = "barButtonItemIslandAtoll";
            this.barButtonItemIslandAtoll.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemScientist
            // 
            this.barButtonItemScientist.Caption = "Scientists";
            this.barButtonItemScientist.Id = 5;
            this.barButtonItemScientist.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemScientist.ImageOptions.SvgImage")));
            this.barButtonItemScientist.Name = "barButtonItemScientist";
            this.barButtonItemScientist.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemClinicalDetails
            // 
            this.barButtonItemClinicalDetails.Caption = "Clinical Details";
            this.barButtonItemClinicalDetails.Id = 6;
            this.barButtonItemClinicalDetails.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemClinicalDetails.ImageOptions.SvgImage")));
            this.barButtonItemClinicalDetails.Name = "barButtonItemClinicalDetails";
            this.barButtonItemClinicalDetails.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemSites
            // 
            this.barButtonItemSites.Caption = "Sites";
            this.barButtonItemSites.Id = 7;
            this.barButtonItemSites.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSites.ImageOptions.SvgImage")));
            this.barButtonItemSites.Name = "barButtonItemSites";
            this.barButtonItemSites.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemTests
            // 
            this.barButtonItemTests.Caption = "Tests";
            this.barButtonItemTests.Id = 9;
            this.barButtonItemTests.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemTests.ImageOptions.SvgImage")));
            this.barButtonItemTests.Name = "barButtonItemTests";
            this.barButtonItemTests.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Configuration";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemCodifiedResults);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemCountries);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemGender);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemIslandAtoll);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemScientist);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemClinicalDetails);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemSites);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemTests);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Configuration";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 433);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(915, 31);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 464);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCodifiedResults;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCountries;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGender;
        private DevExpress.XtraBars.BarButtonItem barButtonItemIslandAtoll;
        private DevExpress.XtraBars.BarButtonItem barButtonItemScientist;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClinicalDetails;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSites;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTests;
    }
}