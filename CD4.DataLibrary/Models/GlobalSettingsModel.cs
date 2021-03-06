﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class GlobalSettingsModel
    {
        public bool VerifyNidPpOnOrder { get; set; }
        public bool IsAnalysisRequestBarcodeRequired { get; set; }
        public string ReportExportBasePath { get; set; }
        public bool IsFullnameAbbreviated { get; set; }
        public string HmsLinkQuery { get; set; }
        public bool IsReportByEpisode { get; set; }
    }
}
