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
                case ReportTemplate.AnalyserGeneratedReport:
                    return new AnalyserGeneratedReport();
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
                case ReportTemplate.AnalyserGeneratedReport:
                    return new AnalyserGeneratedReport() { DataSource = GetDoADatasourceForAnalyserGeneratedReport(arReportDatasource) };
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
                QcCalValidatedBy = data.QcCalValidatedBy,
                ReportedAt = data.ReportedAt,
                ReceivedBy = data.ReceivedBy,
                AnalysedBy = data.AnalysedBy,
                InstituteAssignedPatientId = data.InstituteAssignedPatientId,
            };
            doADatasource.Methadone = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("methadone") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Amphetamine = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("amphetamine") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Benzodiazepine1 = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("benzodiazepine-1") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Benzodiazepine2 = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("benzodiazepine-2") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Cannabinoids = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("cannabinoids") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Cocaine = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("cocaine") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Ethanol = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("ethanol") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.Opiates = analysis.FirstOrDefault((x) => x.Assay.ToLower().Contains("opiates") && x.Assay.EndsWith("_I"))?.Result;
            doADatasource.EpisodeNumber = data.EpisodeNumber;
            return new List<DoAAnalysisRequestReportModel>() { doADatasource };
        }

        private List<AnalysisRequestReportModel> GetDoADatasourceForAnalyserGeneratedReport
            (List<AnalysisRequestReportModel> arReportDatasource)
        {
            List<Assays> resultsToRemove = new List<Assays>();
            foreach (var report in arReportDatasource)
            {
                foreach (var item in report.Assays)
                {
                    //if interpretation test
                    if (item.Assay.Contains("_I"))
                    {
                        //remove localisation
                        item.Result = item.Result.Replace("ދައްކާ", "");
                        item.Result = item.Result.Replace("ނު", "").Trim();

                        //look for the corresponding concentration result...
                        var concAssay = report.Assays.FirstOrDefault((x) => x.Assay + "_I" == item.Assay);
                        if (concAssay is null) { continue; }

                        // and update the result to look like "Interpretation (conc.)"
                        concAssay.Result = $"{item.Result} ({concAssay.Result})";
                    }

                }

                //remove interpretation assays
                resultsToRemove.AddRange(report.Assays.Where((y) => y.Assay.Contains("_I")).ToList());
            }


            foreach (var item in resultsToRemove)
            {
                arReportDatasource[0].Assays.Remove(item);
            }

            return arReportDatasource;
        }

        public List<InfoModel> GetExtensionInformation()
        {
            return new List<InfoModel>()
            {
                new InfoModel(){Index=0, TemplateName="Analysis Report [ Clinical ]", ReportType = ReportType.AnalysisRequest},
                new InfoModel(){Index=1, TemplateName="Analysis Report [ Without Seal ]", ReportType = ReportType.AnalysisRequest },
                new InfoModel(){ Index=2, TemplateName = "Tube Label 75mm", ReportType = ReportType.Barcode},
                new InfoModel(){Index=3, TemplateName="Analysis Report [ Default DoA ]", ReportType = ReportType.AnalysisRequest},
                new InfoModel(){Index=4, TemplateName="Machine Generated Report [ DoA ]", ReportType = ReportType.AnalysisRequest}

                //new InfoModel(){Index=0, TemplateName="Analysis Report [ Default ]", ReportType = ReportType.AnalysisRequest},
                //new InfoModel(){Index=1, TemplateName="Analysis Report [ Without Seal ]", ReportType = ReportType.AnalysisRequest },
                //new InfoModel(){ Index=2, TemplateName = "Tube Label 75mm", ReportType = ReportType.Barcode}
            };

        }
    }
}
