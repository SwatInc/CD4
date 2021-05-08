using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;

namespace CD4.UI.Report
{
    /// <summary>
    /// The is the barcode label that will be printed for 75mm standard tubes
    /// </summary>
    public partial class SeventyFiveMillimeterTubeLabel : XtraReport
    {
        public SeventyFiveMillimeterTubeLabel()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            if (SamplePriority.Value == "True")
            {
                xrLabelSampleType.StyleName = "xrControlStyleUrgent";
            }

            if (SamplePriority.Value == "False")
            {
                xrLabelSampleType.StyleName = "xrControlStyleRoutine";
            }
        }
    }
}
