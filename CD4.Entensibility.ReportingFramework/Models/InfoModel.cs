using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.Entensibility.ReportingFramework.Models
{
    public class InfoModel
    {
        public int Index { get; set; }
        public string TemplateName { get; set; }
        public ReportType ReportType { get; set; }
        public string ProcedureName { get; set; }
    }
}
