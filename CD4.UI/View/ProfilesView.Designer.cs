namespace CD4.UI.View
{
    partial class ProfilesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfilesView));
            this.listBoxControlProfiles = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControlProfiles = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlAllTests = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlTests = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControlProfileTests = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlProfileTests = new DevExpress.XtraEditors.ListBoxControl();
            this.simpleButtonAddToProfile = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemoveFromProfile = new DevExpress.XtraEditors.SimpleButton();
            this.textEditProfileName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlProfiles)).BeginInit();
            this.groupControlProfiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAllTests)).BeginInit();
            this.groupControlAllTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlProfileTests)).BeginInit();
            this.groupControlProfileTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlProfileTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProfileName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxControlProfiles
            // 
            this.listBoxControlProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlProfiles.Location = new System.Drawing.Point(2, 20);
            this.listBoxControlProfiles.Name = "listBoxControlProfiles";
            this.listBoxControlProfiles.Size = new System.Drawing.Size(145, 214);
            this.listBoxControlProfiles.TabIndex = 0;
            // 
            // groupControlProfiles
            // 
            this.groupControlProfiles.Controls.Add(this.listBoxControlProfiles);
            this.groupControlProfiles.Location = new System.Drawing.Point(6, 6);
            this.groupControlProfiles.Name = "groupControlProfiles";
            this.groupControlProfiles.Size = new System.Drawing.Size(149, 236);
            this.groupControlProfiles.TabIndex = 1;
            this.groupControlProfiles.Text = "Profiles";
            // 
            // simpleButtonAddNew
            // 
            this.simpleButtonAddNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAddNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonAddNew.ImageOptions.SvgImage")));
            this.simpleButtonAddNew.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonAddNew.Location = new System.Drawing.Point(8, 246);
            this.simpleButtonAddNew.Name = "simpleButtonAddNew";
            this.simpleButtonAddNew.Size = new System.Drawing.Size(29, 24);
            this.simpleButtonAddNew.TabIndex = 2;
            // 
            // simpleButtonEdit
            // 
            this.simpleButtonEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonEdit.ImageOptions.SvgImage")));
            this.simpleButtonEdit.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonEdit.Location = new System.Drawing.Point(43, 246);
            this.simpleButtonEdit.Name = "simpleButtonEdit";
            this.simpleButtonEdit.Size = new System.Drawing.Size(29, 24);
            this.simpleButtonEdit.TabIndex = 3;
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonDelete.ImageOptions.SvgImage")));
            this.simpleButtonDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonDelete.Location = new System.Drawing.Point(78, 246);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(29, 24);
            this.simpleButtonDelete.TabIndex = 4;
            // 
            // groupControlAllTests
            // 
            this.groupControlAllTests.Controls.Add(this.listBoxControlTests);
            this.groupControlAllTests.Location = new System.Drawing.Point(161, 6);
            this.groupControlAllTests.Name = "groupControlAllTests";
            this.groupControlAllTests.Size = new System.Drawing.Size(149, 236);
            this.groupControlAllTests.TabIndex = 2;
            this.groupControlAllTests.Text = "All Tests";
            // 
            // listBoxControlTests
            // 
            this.listBoxControlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlTests.Location = new System.Drawing.Point(2, 20);
            this.listBoxControlTests.Name = "listBoxControlTests";
            this.listBoxControlTests.Size = new System.Drawing.Size(145, 214);
            this.listBoxControlTests.TabIndex = 0;
            // 
            // groupControlProfileTests
            // 
            this.groupControlProfileTests.Controls.Add(this.listBoxControlProfileTests);
            this.groupControlProfileTests.Location = new System.Drawing.Point(349, 6);
            this.groupControlProfileTests.Name = "groupControlProfileTests";
            this.groupControlProfileTests.Size = new System.Drawing.Size(149, 236);
            this.groupControlProfileTests.TabIndex = 3;
            this.groupControlProfileTests.Text = "Profile Tests";
            // 
            // listBoxControlProfileTests
            // 
            this.listBoxControlProfileTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlProfileTests.Location = new System.Drawing.Point(2, 20);
            this.listBoxControlProfileTests.Name = "listBoxControlProfileTests";
            this.listBoxControlProfileTests.Size = new System.Drawing.Size(145, 214);
            this.listBoxControlProfileTests.TabIndex = 0;
            // 
            // simpleButtonAddToProfile
            // 
            this.simpleButtonAddToProfile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAddToProfile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonAddToProfile.ImageOptions.SvgImage")));
            this.simpleButtonAddToProfile.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonAddToProfile.Location = new System.Drawing.Point(315, 98);
            this.simpleButtonAddToProfile.Name = "simpleButtonAddToProfile";
            this.simpleButtonAddToProfile.Size = new System.Drawing.Size(29, 24);
            this.simpleButtonAddToProfile.TabIndex = 5;
            // 
            // simpleButtonRemoveFromProfile
            // 
            this.simpleButtonRemoveFromProfile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonRemoveFromProfile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonRemoveFromProfile.ImageOptions.SvgImage")));
            this.simpleButtonRemoveFromProfile.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonRemoveFromProfile.Location = new System.Drawing.Point(315, 128);
            this.simpleButtonRemoveFromProfile.Name = "simpleButtonRemoveFromProfile";
            this.simpleButtonRemoveFromProfile.Size = new System.Drawing.Size(29, 24);
            this.simpleButtonRemoveFromProfile.TabIndex = 6;
            // 
            // textEditProfileName
            // 
            this.textEditProfileName.Location = new System.Drawing.Point(8, 248);
            this.textEditProfileName.Name = "textEditProfileName";
            this.textEditProfileName.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEditProfileName.Properties.NullText = "Profile description";
            this.textEditProfileName.Properties.NullValuePrompt = "Profile description";
            this.textEditProfileName.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditProfileName.Size = new System.Drawing.Size(115, 20);
            this.textEditProfileName.TabIndex = 7;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSave.ImageOptions.SvgImage")));
            this.simpleButtonSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonSave.Location = new System.Drawing.Point(128, 248);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(24, 20);
            this.simpleButtonSave.TabIndex = 8;
            // 
            // ProfilesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 278);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.textEditProfileName);
            this.Controls.Add(this.simpleButtonRemoveFromProfile);
            this.Controls.Add(this.simpleButtonAddToProfile);
            this.Controls.Add(this.groupControlProfileTests);
            this.Controls.Add(this.groupControlAllTests);
            this.Controls.Add(this.simpleButtonDelete);
            this.Controls.Add(this.simpleButtonEdit);
            this.Controls.Add(this.simpleButtonAddNew);
            this.Controls.Add(this.groupControlProfiles);
            this.Name = "ProfilesView";
            this.Text = "Profiles Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlProfiles)).EndInit();
            this.groupControlProfiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlAllTests)).EndInit();
            this.groupControlAllTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlProfileTests)).EndInit();
            this.groupControlProfileTests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlProfileTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditProfileName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl listBoxControlProfiles;
        private DevExpress.XtraEditors.GroupControl groupControlProfiles;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddNew;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraEditors.GroupControl groupControlAllTests;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlTests;
        private DevExpress.XtraEditors.GroupControl groupControlProfileTests;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlProfileTests;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddToProfile;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemoveFromProfile;
        private DevExpress.XtraEditors.TextEdit textEditProfileName;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
    }
}