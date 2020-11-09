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
            this.components = new System.ComponentModel.Container();
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
            this.barButtonItemProfiles = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOrderEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemResultEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemViewProfile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemUsernameAndRole = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAcceptSamples = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGeneral = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageConfiguration = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemRatingControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemRatingControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).BeginInit();
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
            this.barButtonItemTests,
            this.barButtonItemProfiles,
            this.barButtonItemOrderEntry,
            this.barButtonItemResultEntry,
            this.barButtonItemStatistics,
            this.barButtonItemViewProfile,
            this.barButtonItemChangePassword,
            this.barStaticItemUsernameAndRole,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItemAcceptSamples});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageGeneral,
            this.ribbonPageConfiguration,
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRatingControl1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1110, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Tag = "ribbon";
            this.ribbon.Toolbar.ShowCustomizeItem = false;
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
            // barButtonItemProfiles
            // 
            this.barButtonItemProfiles.Caption = "Profiles";
            this.barButtonItemProfiles.Id = 10;
            this.barButtonItemProfiles.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemProfiles.ImageOptions.SvgImage")));
            this.barButtonItemProfiles.Name = "barButtonItemProfiles";
            this.barButtonItemProfiles.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOrderEntry
            // 
            this.barButtonItemOrderEntry.Caption = "Order Entry";
            this.barButtonItemOrderEntry.Hint = "Register samples, create test orders, collect samples";
            this.barButtonItemOrderEntry.Id = 11;
            this.barButtonItemOrderEntry.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemOrderEntry.ImageOptions.SvgImage")));
            this.barButtonItemOrderEntry.Name = "barButtonItemOrderEntry";
            this.barButtonItemOrderEntry.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemOrderEntry.Tag = "Ribbon.GeneralPage.OrderEntry";
            // 
            // barButtonItemResultEntry
            // 
            this.barButtonItemResultEntry.Caption = "Result Entry";
            this.barButtonItemResultEntry.Hint = "The worksheet for result entry and related functions";
            this.barButtonItemResultEntry.Id = 12;
            this.barButtonItemResultEntry.ImageOptions.SvgImage = global::CD4.UI.Properties.Resources.marker;
            this.barButtonItemResultEntry.Name = "barButtonItemResultEntry";
            // 
            // barButtonItemStatistics
            // 
            this.barButtonItemStatistics.Caption = "Statistics";
            this.barButtonItemStatistics.Hint = "Generate statistics reports for laboratory";
            this.barButtonItemStatistics.Id = 13;
            this.barButtonItemStatistics.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemStatistics.ImageOptions.SvgImage")));
            this.barButtonItemStatistics.Name = "barButtonItemStatistics";
            this.barButtonItemStatistics.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemViewProfile
            // 
            this.barButtonItemViewProfile.Caption = "View Profile";
            this.barButtonItemViewProfile.Id = 14;
            this.barButtonItemViewProfile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemViewProfile.ImageOptions.SvgImage")));
            this.barButtonItemViewProfile.Name = "barButtonItemViewProfile";
            // 
            // barButtonItemChangePassword
            // 
            this.barButtonItemChangePassword.Caption = "Change Password";
            this.barButtonItemChangePassword.Id = 15;
            this.barButtonItemChangePassword.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemChangePassword.ImageOptions.SvgImage")));
            this.barButtonItemChangePassword.Name = "barButtonItemChangePassword";
            // 
            // barStaticItemUsernameAndRole
            // 
            this.barStaticItemUsernameAndRole.Caption = "Welcome";
            this.barStaticItemUsernameAndRole.Id = 17;
            this.barStaticItemUsernameAndRole.Name = "barStaticItemUsernameAndRole";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.ActAsDropDown = true;
            this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem1.Caption = "Discipline";
            this.barButtonItem1.DropDownControl = this.popupMenu;
            this.barButtonItem1.Id = 18;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // popupMenu
            // 
            this.popupMenu.ItemLinks.Add(this.barButtonItem2);
            this.popupMenu.ItemLinks.Add(this.barButtonItem3);
            this.popupMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText;
            this.popupMenu.Name = "popupMenu";
            this.popupMenu.Ribbon = this.ribbon;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItemTest1";
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItemTest2";
            this.barButtonItem3.Id = 20;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAcceptSamples
            // 
            this.barButtonItemAcceptSamples.Caption = "Accept Samples";
            this.barButtonItemAcceptSamples.Hint = "This function is used to accept sample";
            this.barButtonItemAcceptSamples.Id = 21;
            this.barButtonItemAcceptSamples.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItemAcceptSamples.Name = "barButtonItemAcceptSamples";
            this.barButtonItemAcceptSamples.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGeneral
            // 
            this.ribbonPageGeneral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPageGeneral.Name = "ribbonPageGeneral";
            this.ribbonPageGeneral.Tag = "Ribbon.GeneralPage";
            this.ribbonPageGeneral.Text = "GeneralPage";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemOrderEntry);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemResultEntry);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemStatistics);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemAcceptSamples);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "General Lab Tasks";
            // 
            // ribbonPageConfiguration
            // 
            this.ribbonPageConfiguration.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPageConfiguration.Name = "ribbonPageConfiguration";
            this.ribbonPageConfiguration.Tag = "Ribbon.ConfigurationPage";
            this.ribbonPageConfiguration.Text = "Configuration";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemProfiles);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Configuration";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Tag = "Ribbon.Profile";
            this.ribbonPage1.Text = "Profile";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemViewProfile);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemChangePassword);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // repositoryItemRatingControl1
            // 
            this.repositoryItemRatingControl1.AutoHeight = false;
            this.repositoryItemRatingControl1.Name = "repositoryItemRatingControl1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemUsernameAndRole);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 510);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1110, 31);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(1110, 541);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRatingControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageConfiguration;
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
        private DevExpress.XtraBars.BarButtonItem barButtonItemProfiles;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageGeneral;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOrderEntry;
        private DevExpress.XtraBars.BarButtonItem barButtonItemResultEntry;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStatistics;
        private DevExpress.XtraBars.BarButtonItem barButtonItemViewProfile;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarStaticItem barStaticItemUsernameAndRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemRatingControl repositoryItemRatingControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAcceptSamples;
    }
}