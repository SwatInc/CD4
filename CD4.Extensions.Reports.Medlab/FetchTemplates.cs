using CD4.Entensibility.ReportingFramework;
using CD4.Entensibility.ReportingFramework.Models;
using CD4.UI.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;

namespace CD4.Extensions.Reports.Medlab
{
    public class FetchTemplates : IFetchReportTemplate
    {

        public XtraReport Execute(ReportTemplate reportTemplate)
        {
            switch (reportTemplate)
            {
                case ReportTemplate.AnalysisReportDefault:
                    return new AnalysisReport();
                case ReportTemplate.AnalysisReportForPrinting:
                    return new AnalysisReportForPrinting();
                case ReportTemplate.TubeLabel75mm:
                    return new SeventyFiveMillimeterTubeLabel();
                default:
                    throw new ArgumentOutOfRangeException("Cannot find the specified report enum value.");
            }
        }

        public List<InfoModel> GetExtensionInformation()
        {
            return new List<InfoModel>()
            {
                new InfoModel(){Index=0, TemplateName="Analysis Report [Default]", ReportType = ReportType.AnalysisRequest},
                new InfoModel(){Index=1, TemplateName="Analysis Report [Without Seal]", ReportType = ReportType.AnalysisRequest },
                new InfoModel(){ Index=2, TemplateName = "Tube Label 75mm", ReportType = ReportType.Barcode}
            };

        }
    }
}
