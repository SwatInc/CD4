using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using CD4.UI.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CD4.UI.Helpers
{
    public class BarcodeHelper : IBarcodeHelper
    {
        private readonly IPrintingHelper _printingHelper;
        private readonly INamesAbbreviator _namesAbbreviator;
        private readonly IGlobalSettingsHelper _globalSettingsHelper;
        private readonly int _fullnameCriticalLength = 25;
        public BarcodeHelper(IPrintingHelper printingHelper, INamesAbbreviator namesAbbreviator, IGlobalSettingsHelper globalSettingsHelper)
        {
            _printingHelper = printingHelper;
            _namesAbbreviator = namesAbbreviator;
            _globalSettingsHelper = globalSettingsHelper;
        }

        public bool PrintMultipleSampleBarcode(List<BarcodeDataModel> barcodeData)
        {
            if (barcodeData is null)
            {
                throw new Exception($"Cannot print barcodes, no data avaliable to generate labels.");
            }

            if (barcodeData.Count == 0)
            {
                throw new Exception($"Cannot print barcodes, no data avaliable to generate labels.");
            }

            try
            {
                var analysisRequestBarcode = GetAnalysisRequestBarcode(barcodeData);
                if(analysisRequestBarcode != null) { barcodeData.Add(analysisRequestBarcode); }
                GenerateLabelAndSendToPrinter(barcodeData);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private BarcodeDataModel GetAnalysisRequestBarcode(List<BarcodeDataModel> barcodeData)
        {
            if (!_globalSettingsHelper.Settings.IsAnalysisRequestBarcodeRequired) { return null; }
            if (barcodeData.Count == 0) { return null; }

            var requestBarcode = barcodeData.FirstOrDefault();
            barcodeData.Add(new BarcodeDataModel()
            {
                AccessionNumber = requestBarcode.AccessionNumber,
                Age = requestBarcode.Age,
                Birthdate = requestBarcode.Birthdate,
                CollectionDate = requestBarcode.CollectionDate,
                Discipline = "ANALYSIS REQUEST",
                FullName = requestBarcode.FullName,
                NidPp = requestBarcode.NidPp,
                Seq = requestBarcode.Seq,
                SamplePriority = requestBarcode.SamplePriority
            });

            return requestBarcode;
        }

        public bool PrintSingleSampleBarcode(List<BarcodeDataModel> barcodeData, string cin)
        {
            if (barcodeData is null)
            {
                throw new Exception($"The current sample: {cin} is not registered!\nPlease confirm the order first.");
            }

            if (barcodeData.Count == 0)
            {
                throw new Exception($"The current sample: {cin} is not registered!\nPlease confirm the order first.");
            }

            try
            {
                var requestBarcode = GetAnalysisRequestBarcode(barcodeData);
                if (requestBarcode != null) { barcodeData.Add(requestBarcode); }
                GenerateLabelAndSendToPrinter(barcodeData);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void GenerateLabelAndSendToPrinter(List<BarcodeDataModel> barcodeData)
        {
            foreach (var barcode in barcodeData)
            {
                if (barcode.SampleType is null) { barcode.SampleType = ""; }
                var barcodeLabel = new SeventyFiveMillimeterTubeLabel();
                barcodeLabel.Parameters["Fullname"].Value = GetAbbreviatedName(barcode.FullName);
                barcodeLabel.Parameters["NidPp"].Value = barcode.NidPp;
                barcodeLabel.Parameters["Birthdate"].Value = barcode.Birthdate;
                barcodeLabel.Parameters["Age"].Value = barcode.Age;
                barcodeLabel.Parameters["AccessionNumber"].Value = barcode.AccessionNumber;
                barcodeLabel.Parameters["SampleCollectedDate"].Value = barcode.CollectionDate.LocalDateTime;
                barcodeLabel.Parameters["Seq"].Value = barcode.Seq;
                barcodeLabel.Parameters["Discipline"].Value = barcode.Discipline;
                barcodeLabel.Parameters["SampleType"].Value = barcode.SampleType;
                barcodeLabel.Parameters["EpisodeNumber"].Value = barcode.EpisodeNumber;
                barcodeLabel.Parameters["SamplePriority"].Value = barcode.SamplePriority.ToString();
                barcodeLabel.DisplayName = $"{barcode.Discipline}_{barcode.SampleType}_{barcode.FullName}_{barcode.NidPp}.pdf";

                barcodeLabel.PrinterName = _printingHelper.BarcodePrinterName;
                barcodeLabel.RequestParameters = false;
                var autoprint = new ReportPrintTool(barcodeLabel);
                try
                {
#if !DEBUG
                    barcodeLabel.ShowPrintMarginsWarning = false;
                    autoprint.Print(barcodeLabel.PrinterName);
#endif

#if DEBUG
                    // barcodeLabel.ExportToPdf($"C:\\Logs\\{barcodeLabel.DisplayName}.pdf");
                    barcodeLabel.ExportToPdf($"C:\\Logs\\1.pdf");
#endif
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private string GetAbbreviatedName(string fullname)
        {
            if (_globalSettingsHelper.Settings.IsFullnameAbbreviated)
            {
                return _namesAbbreviator.Execute(fullname, _fullnameCriticalLength);
            }
            return fullname;
        }
    }
}

