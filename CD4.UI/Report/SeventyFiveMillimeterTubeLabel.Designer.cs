namespace CD4.UI.Report
{
    partial class SeventyFiveMillimeterTubeLabel
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCodeAccessionNumber = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Fullname = new DevExpress.XtraReports.Parameters.Parameter();
            this.NidPp = new DevExpress.XtraReports.Parameters.Parameter();
            this.Age = new DevExpress.XtraReports.Parameters.Parameter();
            this.Birthdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.AccessionNumber = new DevExpress.XtraReports.Parameters.Parameter();
            this.SampleCollectedDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Seq = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Discipline = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrBarCodeAccessionNumber,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 343.9583F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Age")});
            this.xrLabel6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(367.1943F, 46.07277F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(119F, 44.30889F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.88887F, 256.1628F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(61.73611F, 40.78111F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Col:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SampleCollectedDate")});
            this.xrLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(72.62497F, 256.1628F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(294.5694F, 40.7811F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextFormatString = "{0:d}";
            // 
            // xrBarCodeAccessionNumber
            // 
            this.xrBarCodeAccessionNumber.Dpi = 254F;
            this.xrBarCodeAccessionNumber.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?AccessionNumber")});
            this.xrBarCodeAccessionNumber.LocationFloat = new DevExpress.Utils.PointFloat(46.16664F, 90.38166F);
            this.xrBarCodeAccessionNumber.Name = "xrBarCodeAccessionNumber";
            this.xrBarCodeAccessionNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254F);
            this.xrBarCodeAccessionNumber.ShowText = false;
            this.xrBarCodeAccessionNumber.SizeF = new System.Drawing.SizeF(410F, 125F);
            this.xrBarCodeAccessionNumber.StylePriority.UseTextAlignment = false;
            code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCodeAccessionNumber.Symbology = code128Generator1;
            this.xrBarCodeAccessionNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Birthdate")});
            this.xrLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(200.2014F, 46.07277F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(166.9929F, 44.3089F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextFormatString = "{0:d}";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?NidPp")});
            this.xrLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(12.34722F, 46.07277F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(187.8542F, 44.3089F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Fullname")});
            this.xrLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.88887F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(475.3055F, 46.07277F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // Fullname
            // 
            this.Fullname.Description = "The fullname of the patient";
            this.Fullname.Name = "Fullname";
            // 
            // NidPp
            // 
            this.NidPp.Description = "The national ID card number or Passport";
            this.NidPp.Name = "NidPp";
            // 
            // Age
            // 
            this.Age.Description = "The age of the patient";
            this.Age.Name = "Age";
            // 
            // Birthdate
            // 
            this.Birthdate.Description = "The birthdate of the patient";
            this.Birthdate.Name = "Birthdate";
            this.Birthdate.Type = typeof(System.DateTime);
            // 
            // AccessionNumber
            // 
            this.AccessionNumber.Description = "The accession number for the sample";
            this.AccessionNumber.Name = "AccessionNumber";
            // 
            // SampleCollectedDate
            // 
            this.SampleCollectedDate.Description = "The sample collected date";
            this.SampleCollectedDate.Name = "SampleCollectedDate";
            this.SampleCollectedDate.Type = typeof(System.DateTime);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?AccessionNumber")});
            this.xrLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(46.16664F, 215.3816F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(409.9999F, 40.78108F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Seq
            // 
            this.Seq.Description = "The sequence number, this is the equivalent of the lab number";
            this.Seq.Name = "Seq";
            this.Seq.Type = typeof(int);
            this.Seq.ValueInfo = "0";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Seq")});
            this.xrLabel8.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(367.1943F, 256.1627F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(119F, 40.78113F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Discipline
            // 
            this.Discipline.Description = "The department to which the sample belongs to";
            this.Discipline.Name = "Discipline";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Discipline")});
            this.xrLabel9.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(12.34722F, 296.9438F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(473.8471F, 47.01447F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "xrLabel9";
            // 
            // SeventyFiveMillimeterTubeLabel
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageColor = System.Drawing.Color.Transparent;
            this.PageHeight = 300;
            this.PageWidth = 500;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Fullname,
            this.NidPp,
            this.Age,
            this.Birthdate,
            this.AccessionNumber,
            this.SampleCollectedDate,
            this.Seq,
            this.Discipline});
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCodeAccessionNumber;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter Fullname;
        private DevExpress.XtraReports.Parameters.Parameter NidPp;
        private DevExpress.XtraReports.Parameters.Parameter Age;
        private DevExpress.XtraReports.Parameters.Parameter Birthdate;
        private DevExpress.XtraReports.Parameters.Parameter AccessionNumber;
        private DevExpress.XtraReports.Parameters.Parameter SampleCollectedDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.Parameters.Parameter Seq;
        private DevExpress.XtraReports.Parameters.Parameter Discipline;
    }
}
