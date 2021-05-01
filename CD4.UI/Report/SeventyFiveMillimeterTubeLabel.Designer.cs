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
            this.xrLabelSampleType = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDiscipline = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelSeq = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelAccessionNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelAge = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelCollectedDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCodeAccessionNumber = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabelBirthdate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelNidpp = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.Fullname = new DevExpress.XtraReports.Parameters.Parameter();
            this.NidPp = new DevExpress.XtraReports.Parameters.Parameter();
            this.Age = new DevExpress.XtraReports.Parameters.Parameter();
            this.Birthdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.AccessionNumber = new DevExpress.XtraReports.Parameters.Parameter();
            this.SampleCollectedDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.Seq = new DevExpress.XtraReports.Parameters.Parameter();
            this.Discipline = new DevExpress.XtraReports.Parameters.Parameter();
            this.SampleType = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.EpisodeNumber = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.BorderWidth = 0F;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabelSampleType,
            this.xrLabelDiscipline,
            this.xrLabelSeq,
            this.xrLabelAccessionNumber,
            this.xrLabelAge,
            this.xrLabel5,
            this.xrLabelCollectedDate,
            this.xrBarCodeAccessionNumber,
            this.xrLabelBirthdate,
            this.xrLabelNidpp,
            this.xrLabelFullName});
            this.Detail.Name = "Detail";
            this.Detail.SnapLinePadding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseBorderWidth = false;
            // 
            // xrLabelSampleType
            // 
            this.xrLabelSampleType.Angle = 90F;
            this.xrLabelSampleType.AutoWidth = true;
            this.xrLabelSampleType.CanGrow = false;
            this.xrLabelSampleType.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SampleType")});
            this.xrLabelSampleType.Font = new System.Drawing.Font("Sitka Small", 5F);
            this.xrLabelSampleType.KeepTogether = true;
            this.xrLabelSampleType.LocationFloat = new DevExpress.Utils.PointFloat(179.5932F, 0F);
            this.xrLabelSampleType.Name = "xrLabelSampleType";
            this.xrLabelSampleType.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelSampleType.SizeF = new System.Drawing.SizeF(17.40675F, 98F);
            this.xrLabelSampleType.StylePriority.UseFont = false;
            this.xrLabelSampleType.StylePriority.UsePadding = false;
            this.xrLabelSampleType.StylePriority.UseTextAlignment = false;
            this.xrLabelSampleType.Text = "NASOPHARYNGEAL SWAB";
            this.xrLabelSampleType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabelSampleType.WordWrap = false;
            // 
            // xrLabelDiscipline
            // 
            this.xrLabelDiscipline.AutoWidth = true;
            this.xrLabelDiscipline.CanGrow = false;
            this.xrLabelDiscipline.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Discipline")});
            this.xrLabelDiscipline.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelDiscipline.KeepTogether = true;
            this.xrLabelDiscipline.LocationFloat = new DevExpress.Utils.PointFloat(4.286892F, 87F);
            this.xrLabelDiscipline.Name = "xrLabelDiscipline";
            this.xrLabelDiscipline.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelDiscipline.SizeF = new System.Drawing.SizeF(175.3062F, 11F);
            this.xrLabelDiscipline.StylePriority.UseFont = false;
            this.xrLabelDiscipline.StylePriority.UsePadding = false;
            this.xrLabelDiscipline.StylePriority.UseTextAlignment = false;
            this.xrLabelDiscipline.Text = "xrLabelDiscipline";
            this.xrLabelDiscipline.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelDiscipline.WordWrap = false;
            // 
            // xrLabelSeq
            // 
            this.xrLabelSeq.BorderWidth = 0F;
            this.xrLabelSeq.CanGrow = false;
            this.xrLabelSeq.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Seq")});
            this.xrLabelSeq.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelSeq.KeepTogether = true;
            this.xrLabelSeq.LocationFloat = new DevExpress.Utils.PointFloat(149.0131F, 76F);
            this.xrLabelSeq.Multiline = true;
            this.xrLabelSeq.Name = "xrLabelSeq";
            this.xrLabelSeq.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelSeq.SizeF = new System.Drawing.SizeF(30.58F, 11F);
            this.xrLabelSeq.StylePriority.UseBorderWidth = false;
            this.xrLabelSeq.StylePriority.UseFont = false;
            this.xrLabelSeq.StylePriority.UsePadding = false;
            this.xrLabelSeq.StylePriority.UseTextAlignment = false;
            this.xrLabelSeq.Text = "xrLabelSeq";
            this.xrLabelSeq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelAccessionNumber
            // 
            this.xrLabelAccessionNumber.BorderWidth = 0F;
            this.xrLabelAccessionNumber.CanGrow = false;
            this.xrLabelAccessionNumber.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?AccessionNumber")});
            this.xrLabelAccessionNumber.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabelAccessionNumber.KeepTogether = true;
            this.xrLabelAccessionNumber.LocationFloat = new DevExpress.Utils.PointFloat(4.286941F, 65F);
            this.xrLabelAccessionNumber.Multiline = true;
            this.xrLabelAccessionNumber.Name = "xrLabelAccessionNumber";
            this.xrLabelAccessionNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelAccessionNumber.SizeF = new System.Drawing.SizeF(99.43815F, 11F);
            this.xrLabelAccessionNumber.StylePriority.UseBorderWidth = false;
            this.xrLabelAccessionNumber.StylePriority.UseFont = false;
            this.xrLabelAccessionNumber.StylePriority.UsePadding = false;
            this.xrLabelAccessionNumber.StylePriority.UseTextAlignment = false;
            this.xrLabelAccessionNumber.Text = "xrLabelAccessionNumber";
            this.xrLabelAccessionNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelAge
            // 
            this.xrLabelAge.BorderWidth = 0F;
            this.xrLabelAge.CanGrow = false;
            this.xrLabelAge.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Age")});
            this.xrLabelAge.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelAge.KeepTogether = true;
            this.xrLabelAge.LocationFloat = new DevExpress.Utils.PointFloat(103.7251F, 64.99998F);
            this.xrLabelAge.Multiline = true;
            this.xrLabelAge.Name = "xrLabelAge";
            this.xrLabelAge.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelAge.SizeF = new System.Drawing.SizeF(75.86819F, 11F);
            this.xrLabelAge.StylePriority.UseBorderWidth = false;
            this.xrLabelAge.StylePriority.UseFont = false;
            this.xrLabelAge.StylePriority.UseTextAlignment = false;
            this.xrLabelAge.Text = "xrLabelAge";
            this.xrLabelAge.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BorderWidth = 0F;
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabel5.KeepTogether = true;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.286943F, 76F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(18.51852F, 11F);
            this.xrLabel5.StylePriority.UseBorderWidth = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Col:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelCollectedDate
            // 
            this.xrLabelCollectedDate.BorderWidth = 0F;
            this.xrLabelCollectedDate.CanGrow = false;
            this.xrLabelCollectedDate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SampleCollectedDate")});
            this.xrLabelCollectedDate.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelCollectedDate.KeepTogether = true;
            this.xrLabelCollectedDate.LocationFloat = new DevExpress.Utils.PointFloat(22.80546F, 76F);
            this.xrLabelCollectedDate.Multiline = true;
            this.xrLabelCollectedDate.Name = "xrLabelCollectedDate";
            this.xrLabelCollectedDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelCollectedDate.SizeF = new System.Drawing.SizeF(80.91964F, 11F);
            this.xrLabelCollectedDate.StylePriority.UseBorderWidth = false;
            this.xrLabelCollectedDate.StylePriority.UseFont = false;
            this.xrLabelCollectedDate.StylePriority.UsePadding = false;
            this.xrLabelCollectedDate.StylePriority.UseTextAlignment = false;
            this.xrLabelCollectedDate.Text = "xrLabelCollectedDate";
            this.xrLabelCollectedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelCollectedDate.TextFormatString = "{0:dd-MM-yy HH:mm}";
            // 
            // xrBarCodeAccessionNumber
            // 
            this.xrBarCodeAccessionNumber.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?AccessionNumber")});
            this.xrBarCodeAccessionNumber.LocationFloat = new DevExpress.Utils.PointFloat(14.17583F, 22F);
            this.xrBarCodeAccessionNumber.Module = 0.7874016F;
            this.xrBarCodeAccessionNumber.Name = "xrBarCodeAccessionNumber";
            this.xrBarCodeAccessionNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCodeAccessionNumber.ShowText = false;
            this.xrBarCodeAccessionNumber.SizeF = new System.Drawing.SizeF(161.4173F, 42.99998F);
            this.xrBarCodeAccessionNumber.StylePriority.UseTextAlignment = false;
            code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarCodeAccessionNumber.Symbology = code128Generator1;
            this.xrBarCodeAccessionNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabelBirthdate
            // 
            this.xrLabelBirthdate.BorderWidth = 0F;
            this.xrLabelBirthdate.CanGrow = false;
            this.xrLabelBirthdate.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Birthdate")});
            this.xrLabelBirthdate.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelBirthdate.KeepTogether = true;
            this.xrLabelBirthdate.LocationFloat = new DevExpress.Utils.PointFloat(103.7251F, 11F);
            this.xrLabelBirthdate.Multiline = true;
            this.xrLabelBirthdate.Name = "xrLabelBirthdate";
            this.xrLabelBirthdate.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelBirthdate.SizeF = new System.Drawing.SizeF(75.86816F, 11F);
            this.xrLabelBirthdate.StylePriority.UseBorderWidth = false;
            this.xrLabelBirthdate.StylePriority.UseFont = false;
            this.xrLabelBirthdate.StylePriority.UsePadding = false;
            this.xrLabelBirthdate.StylePriority.UseTextAlignment = false;
            this.xrLabelBirthdate.Text = "xrLabelBirthdate";
            this.xrLabelBirthdate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelBirthdate.TextFormatString = "{0:dd-MM-yy}";
            // 
            // xrLabelNidpp
            // 
            this.xrLabelNidpp.BorderWidth = 0F;
            this.xrLabelNidpp.CanGrow = false;
            this.xrLabelNidpp.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?NidPp")});
            this.xrLabelNidpp.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelNidpp.KeepTogether = true;
            this.xrLabelNidpp.LocationFloat = new DevExpress.Utils.PointFloat(4.286941F, 11F);
            this.xrLabelNidpp.Multiline = true;
            this.xrLabelNidpp.Name = "xrLabelNidpp";
            this.xrLabelNidpp.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelNidpp.SizeF = new System.Drawing.SizeF(99.43815F, 11F);
            this.xrLabelNidpp.StylePriority.UseBorderWidth = false;
            this.xrLabelNidpp.StylePriority.UseFont = false;
            this.xrLabelNidpp.StylePriority.UsePadding = false;
            this.xrLabelNidpp.StylePriority.UseTextAlignment = false;
            this.xrLabelNidpp.Text = "xrLabelNidpp";
            this.xrLabelNidpp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabelFullName
            // 
            this.xrLabelFullName.BorderWidth = 0F;
            this.xrLabelFullName.CanGrow = false;
            this.xrLabelFullName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Fullname")});
            this.xrLabelFullName.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabelFullName.KeepTogether = true;
            this.xrLabelFullName.LocationFloat = new DevExpress.Utils.PointFloat(4.28694F, 0F);
            this.xrLabelFullName.Multiline = true;
            this.xrLabelFullName.Name = "xrLabelFullName";
            this.xrLabelFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabelFullName.SizeF = new System.Drawing.SizeF(175.3062F, 11F);
            this.xrLabelFullName.StylePriority.UseBorderWidth = false;
            this.xrLabelFullName.StylePriority.UseFont = false;
            this.xrLabelFullName.StylePriority.UsePadding = false;
            this.xrLabelFullName.StylePriority.UseTextAlignment = false;
            this.xrLabelFullName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrLabelFullName.WordWrap = false;
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
            // Seq
            // 
            this.Seq.Description = "The sequence number, this is the equivalent of the lab number";
            this.Seq.Name = "Seq";
            this.Seq.Type = typeof(int);
            this.Seq.ValueInfo = "0";
            // 
            // Discipline
            // 
            this.Discipline.Description = "The department to which the sample belongs to";
            this.Discipline.Name = "Discipline";
            // 
            // SampleType
            // 
            this.SampleType.Description = "The type of sample. eg: urine";
            this.SampleType.Name = "SampleType";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderWidth = 0F;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?EpisodeNumber")});
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Himalaya", 11F);
            this.xrLabel1.KeepTogether = true;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(103.7251F, 75.99999F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(45.28801F, 11F);
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabelSeq";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // EpisodeNumber
            // 
            this.EpisodeNumber.Description = "The is the equivalent to memo number";
            this.EpisodeNumber.Name = "EpisodeNumber";
            // 
            // SeventyFiveMillimeterTubeLabel
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageColor = System.Drawing.Color.Transparent;
            this.PageHeight = 98;
            this.PageWidth = 197;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Fullname,
            this.NidPp,
            this.Age,
            this.Birthdate,
            this.AccessionNumber,
            this.SampleCollectedDate,
            this.Seq,
            this.Discipline,
            this.SampleType,
            this.EpisodeNumber});
            this.SnapGridSize = 9.84252F;
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAge;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabelCollectedDate;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCodeAccessionNumber;
        private DevExpress.XtraReports.UI.XRLabel xrLabelBirthdate;
        private DevExpress.XtraReports.UI.XRLabel xrLabelNidpp;
        private DevExpress.XtraReports.UI.XRLabel xrLabelFullName;
        private DevExpress.XtraReports.Parameters.Parameter Fullname;
        private DevExpress.XtraReports.Parameters.Parameter NidPp;
        private DevExpress.XtraReports.Parameters.Parameter Age;
        private DevExpress.XtraReports.Parameters.Parameter Birthdate;
        private DevExpress.XtraReports.Parameters.Parameter AccessionNumber;
        private DevExpress.XtraReports.Parameters.Parameter SampleCollectedDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDiscipline;
        private DevExpress.XtraReports.UI.XRLabel xrLabelSeq;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAccessionNumber;
        private DevExpress.XtraReports.Parameters.Parameter Seq;
        private DevExpress.XtraReports.Parameters.Parameter Discipline;
        private DevExpress.XtraReports.UI.XRLabel xrLabelSampleType;
        private DevExpress.XtraReports.Parameters.Parameter SampleType;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.Parameters.Parameter EpisodeNumber;
    }
}
