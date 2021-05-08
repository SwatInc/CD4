using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.Entensibility.ReportingFramework
{
    public interface ILoadMultipleExtensions
    {
        List<IFetchReportTemplate> ReportTemplates { get; set; }
    }
}
