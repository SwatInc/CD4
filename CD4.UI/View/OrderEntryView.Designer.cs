namespace CD4.UI.View
{
    partial class OrderEntryView
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditSite = new DevExpress.XtraEditors.LookUpEdit();
            this.dateEditCollectedDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditSampleReceived = new DevExpress.XtraEditors.DateEdit();
            this.groupControlPatientData = new DevExpress.XtraEditors.GroupControl();
            this.textEditFullname = new DevExpress.XtraEditors.TextEdit();
            this.textEditAddress = new DevExpress.XtraEditors.TextEdit();
            this.textEditNidPp = new DevExpress.XtraEditors.TextEdit();
            this.lookUpEditAtoll = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditIsland = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditCountry = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCollectedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCollectedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSampleReceived.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSampleReceived.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPatientData)).BeginInit();
            this.groupControlPatientData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFullname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNidPp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAtoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditIsland.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCountry.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEditSampleReceived);
            this.groupControl1.Controls.Add(this.dateEditCollectedDate);
            this.groupControl1.Controls.Add(this.lookUpEditSite);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(196, 141);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Request Data";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(12, 30);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEdit1.Properties.NullText = "CIN";
            this.textEdit1.Properties.NullValuePrompt = "CIN";
            this.textEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEdit1.Size = new System.Drawing.Size(167, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // lookUpEditSite
            // 
            this.lookUpEditSite.Location = new System.Drawing.Point(12, 56);
            this.lookUpEditSite.Name = "lookUpEditSite";
            this.lookUpEditSite.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditSite.Properties.NullText = "Select Site";
            this.lookUpEditSite.Properties.NullValuePrompt = "Select Site";
            this.lookUpEditSite.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditSite.TabIndex = 1;
            // 
            // dateEditCollectedDate
            // 
            this.dateEditCollectedDate.EditValue = null;
            this.dateEditCollectedDate.Location = new System.Drawing.Point(12, 82);
            this.dateEditCollectedDate.Name = "dateEditCollectedDate";
            this.dateEditCollectedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditCollectedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditCollectedDate.Properties.CalendarTimeProperties.Mask.EditMask = "d";
            this.dateEditCollectedDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditCollectedDate.Properties.NullText = "Sample Collection date";
            this.dateEditCollectedDate.Properties.NullValuePrompt = "Sample Collection date";
            this.dateEditCollectedDate.Size = new System.Drawing.Size(167, 20);
            this.dateEditCollectedDate.TabIndex = 1;
            // 
            // dateEditSampleReceived
            // 
            this.dateEditSampleReceived.EditValue = null;
            this.dateEditSampleReceived.Location = new System.Drawing.Point(12, 108);
            this.dateEditSampleReceived.Name = "dateEditSampleReceived";
            this.dateEditSampleReceived.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditSampleReceived.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditSampleReceived.Properties.CalendarTimeProperties.Mask.EditMask = "d";
            this.dateEditSampleReceived.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEditSampleReceived.Properties.NullText = "Sample received date";
            this.dateEditSampleReceived.Properties.NullValuePrompt = "Sample received date";
            this.dateEditSampleReceived.Size = new System.Drawing.Size(167, 20);
            this.dateEditSampleReceived.TabIndex = 2;
            // 
            // groupControlPatientData
            // 
            this.groupControlPatientData.Controls.Add(this.lookUpEditCountry);
            this.groupControlPatientData.Controls.Add(this.lookUpEditIsland);
            this.groupControlPatientData.Controls.Add(this.lookUpEditAtoll);
            this.groupControlPatientData.Controls.Add(this.textEditNidPp);
            this.groupControlPatientData.Controls.Add(this.textEditAddress);
            this.groupControlPatientData.Controls.Add(this.textEditFullname);
            this.groupControlPatientData.Location = new System.Drawing.Point(214, 12);
            this.groupControlPatientData.Name = "groupControlPatientData";
            this.groupControlPatientData.Size = new System.Drawing.Size(575, 141);
            this.groupControlPatientData.TabIndex = 3;
            this.groupControlPatientData.Text = "Patient Data";
            // 
            // textEditFullname
            // 
            this.textEditFullname.EditValue = "Fullname";
            this.textEditFullname.Location = new System.Drawing.Point(185, 30);
            this.textEditFullname.Name = "textEditFullname";
            this.textEditFullname.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEditFullname.Properties.NullText = "Fullname";
            this.textEditFullname.Properties.NullValuePrompt = "Fullname";
            this.textEditFullname.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditFullname.Size = new System.Drawing.Size(167, 20);
            this.textEditFullname.TabIndex = 3;
            // 
            // textEditAddress
            // 
            this.textEditAddress.EditValue = "Address";
            this.textEditAddress.Location = new System.Drawing.Point(392, 30);
            this.textEditAddress.Name = "textEditAddress";
            this.textEditAddress.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEditAddress.Properties.NullText = "Address";
            this.textEditAddress.Properties.NullValuePrompt = "Address";
            this.textEditAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditAddress.Size = new System.Drawing.Size(167, 20);
            this.textEditAddress.TabIndex = 4;
            // 
            // textEditNidPp
            // 
            this.textEditNidPp.EditValue = "ID Card Number / Passport";
            this.textEditNidPp.Location = new System.Drawing.Point(12, 30);
            this.textEditNidPp.Name = "textEditNidPp";
            this.textEditNidPp.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.textEditNidPp.Properties.NullText = "National ID Card / Passport";
            this.textEditNidPp.Properties.NullValuePrompt = "National ID Card / Passport";
            this.textEditNidPp.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditNidPp.Size = new System.Drawing.Size(167, 20);
            this.textEditNidPp.TabIndex = 5;
            // 
            // lookUpEditAtoll
            // 
            this.lookUpEditAtoll.Location = new System.Drawing.Point(392, 56);
            this.lookUpEditAtoll.Name = "lookUpEditAtoll";
            this.lookUpEditAtoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditAtoll.Properties.NullText = "Select Atoll";
            this.lookUpEditAtoll.Properties.NullValuePrompt = "Select Atoll";
            this.lookUpEditAtoll.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditAtoll.TabIndex = 6;
            // 
            // lookUpEditIsland
            // 
            this.lookUpEditIsland.Location = new System.Drawing.Point(392, 82);
            this.lookUpEditIsland.Name = "lookUpEditIsland";
            this.lookUpEditIsland.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditIsland.Properties.NullText = "Select Island";
            this.lookUpEditIsland.Properties.NullValuePrompt = "Select Island";
            this.lookUpEditIsland.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditIsland.TabIndex = 7;
            // 
            // lookUpEditCountry
            // 
            this.lookUpEditCountry.Location = new System.Drawing.Point(392, 108);
            this.lookUpEditCountry.Name = "lookUpEditCountry";
            this.lookUpEditCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCountry.Properties.NullText = "Select Country";
            this.lookUpEditCountry.Properties.NullValuePrompt = "Select Country";
            this.lookUpEditCountry.Size = new System.Drawing.Size(167, 20);
            this.lookUpEditCountry.TabIndex = 8;
            // 
            // OrderEntryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 412);
            this.Controls.Add(this.groupControlPatientData);
            this.Controls.Add(this.groupControl1);
            this.Name = "OrderEntryView";
            this.Text = "OrderEntryView";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditSite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCollectedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditCollectedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSampleReceived.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSampleReceived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPatientData)).EndInit();
            this.groupControlPatientData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditFullname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNidPp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditAtoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditIsland.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCountry.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dateEditSampleReceived;
        private DevExpress.XtraEditors.DateEdit dateEditCollectedDate;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditSite;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControlPatientData;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCountry;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditIsland;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditAtoll;
        private DevExpress.XtraEditors.TextEdit textEditNidPp;
        private DevExpress.XtraEditors.TextEdit textEditAddress;
        private DevExpress.XtraEditors.TextEdit textEditFullname;
    }
}