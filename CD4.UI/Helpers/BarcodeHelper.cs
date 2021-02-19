﻿using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using CD4.UI.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Helpers
{
    public class BarcodeHelper : IBarcodeHelper
    {
        private readonly IPrintingHelper _printingHelper;
        private readonly INamesAbbreviator _namesAbbreviator;
        private readonly int _fullnameCriticalLength = 25;
        public BarcodeHelper(IPrintingHelper printingHelper, INamesAbbreviator namesAbbreviator)
        {
            _printingHelper = printingHelper;
            _namesAbbreviator = namesAbbreviator;
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


            foreach (var barcode in barcodeData)
            {
                var barcodeLabel = new SeventyFiveMillimeterTubeLabel();
                barcodeLabel.Parameters["Fullname"].Value = GetAbbreviatedName(barcode.FullName);
                barcodeLabel.Parameters["NidPp"].Value = barcode.NidPp;
                barcodeLabel.Parameters["Birthdate"].Value = barcode.Birthdate;
                barcodeLabel.Parameters["Age"].Value = barcode.Age;
                barcodeLabel.Parameters["AccessionNumber"].Value = barcode.AccessionNumber;
                barcodeLabel.Parameters["SampleCollectedDate"].Value = barcode.CollectionDate.LocalDateTime;
                barcodeLabel.Parameters["Seq"].Value = barcode.Seq;
                barcodeLabel.Parameters["Discipline"].Value = barcode.Discipline;

                barcodeLabel.PrinterName = _printingHelper.BarcodePrinterName;
                barcodeLabel.RequestParameters = false;
                var autoprint = new ReportPrintTool(barcodeLabel);
                try
                {
                    barcodeLabel.ShowPrintMarginsWarning = false;
                    autoprint.Print(barcodeLabel.PrinterName);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        private string GetAbbreviatedName(string fullname)
        {
            return _namesAbbreviator.Execute(fullname, _fullnameCriticalLength);
        }
    }
}
