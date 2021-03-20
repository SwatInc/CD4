using CD4.Entensibility.ReportingFramework.Models;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace CD4.Entensibility.ReportingFramework
{
    public interface IFetchReportTemplate
    {
        XtraReport Execute(ReportTemplate reportTemplate);
        List<InfoModel> GetExtensionInformation();
    }
}
