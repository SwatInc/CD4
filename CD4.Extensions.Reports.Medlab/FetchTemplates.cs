using CD4.Entensibility.ReportingFramework;
using CD4.Entensibility.ReportingFramework.Models;
using CD4.Extensions.Reports.Medlab.Report;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;

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
                case ReportTemplate.DoA:
                    return new AnalysisReportDoA();
                default:
                    throw new ArgumentOutOfRangeException("Cannot find the specified report enum value.");
            }
        }

        public XtraReport Execute(ReportTemplate reportTemplate, List<AnalysisRequestReportModel> arReportDatasource)
        {
            switch (reportTemplate)
            {
                case ReportTemplate.AnalysisReportDefault:
                    return new AnalysisReport() { DataSource = arReportDatasource };
                case ReportTemplate.AnalysisReportForPrinting:
                    return new AnalysisReportForPrinting() { DataSource = arReportDatasource };
                case ReportTemplate.TubeLabel75mm:
                    return new SeventyFiveMillimeterTubeLabel();
                case ReportTemplate.DoA:
                    return new AnalysisReportDoA() { DataSource = GetDoADatasource(arReportDatasource) };
                default:
                    throw new ArgumentOutOfRangeException("Cannot find the specified report enum value.");
            }
        }

        private List<DoAAnalysisRequestReportModel> GetDoADatasource(List<AnalysisRequestReportModel> arReportDatasource)
        {
            var data = arReportDatasource.FirstOrDefault();
            var analysis = data.Assays;
            var doADatasource = new DoAAnalysisRequestReportModel()
            {
                CollectedDate = data.CollectedDate,
                Patient = data.Patient,
                PrintedDate = data.PrintedDate,
                ReceivedDate = data.ReceivedDate,
                SampleSite = data.SampleSite,

            };
            doADatasource.AcetylMorphine = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("morphine"))?.Result;
            doADatasource.Amphetamine = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("amphetamine"))?.Result;
            doADatasource.Benzodiazepine1 = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("benzodiazepine-1"))?.Result;
            doADatasource.Benzodiazepine2 = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("benzodiazepine-2"))?.Result;
            doADatasource.Cannabinoids = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("cannabinoids"))?.Result;
            doADatasource.Cocaine = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("cocaine"))?.Result;
            doADatasource.EthylGlucuronide = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("glucuronide"))?.Result;
            doADatasource.Opiates = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("opiates"))?.Result;

            return new List<DoAAnalysisRequestReportModel>() { doADatasource };
        }

        public List<InfoModel> GetExtensionInformation()
        {
            return new List<InfoModel>()
            {
                new InfoModel(){Index=0, TemplateName="Analysis Report [ Default ]", ReportType = ReportType.AnalysisRequest},
                new InfoModel(){Index=1, TemplateName="Analysis Report [ Without Seal ]", ReportType = ReportType.AnalysisRequest },
                new InfoModel(){ Index=2, TemplateName = "Tube Label 75mm", ReportType = ReportType.Barcode},
                new InfoModel(){Index=3, TemplateName="Analysis Report [ DoA ]", ReportType = ReportType.AnalysisRequest}
            };

        }
    }
}
