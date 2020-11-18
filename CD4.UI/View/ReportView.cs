using CD4.DataLibrary.DataAccess;
using CD4.UI.Report;
using DevExpress.DataProcessing;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ReportView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IReportsDataAccess reportsData;
        private readonly int _loggedInUserId;

        public event EventHandler OnSearchByCin;
        public ReportView(IReportsDataAccess reportsData, string cin, int loggedInUserId)
        {
            InitializeComponent();

            //assign report data access library as a private field
            this.reportsData = reportsData;
            _loggedInUserId = loggedInUserId;
            //Write cin to form Tag
            this.Tag = cin;
            StartReportGenerationSequence();

        }

        /// <summary>
        /// raises an event to initiate report genration
        /// </summary>
        private void StartReportGenerationSequence()
        {
            //If form Tag is null, return
            if (this.Tag is null) { return; }

            //fire the event initialize query to get report for Cin
            this.OnSearchByCin += ReportView_OnSearchByCin;
            this.OnSearchByCin?.Invoke(this, EventArgs.Empty);
            this.OnSearchByCin -= ReportView_OnSearchByCin;

        }

        /// <summary>
        /// Requests report data for Cin from data layer
        /// </summary>
        private async void ReportView_OnSearchByCin(object sender, EventArgs e)
        {
            //throw a null exception if Tag is null
            if (this.Tag is null)
            {
                throw new ArgumentNullException((string)this.Tag);
            }

            try
            {
                var report = await reportsData.GetAnalysisReportByCinAsync((string)this.Tag, _loggedInUserId).ConfigureAwait(true);
                MapDataToReport(report.FirstOrDefault());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void MapDataToReport(DataLibrary.Models.ReportModels.AnalysisRequestReportModel reportModel)
        {
            //Show a message if no results are validated for the analysis request.
            if (reportModel is null)
            {
                XtraMessageBox.Show("No results validated for the selected analysis request.\nCannot generate report.");
                DisposeMe();

                return;
            }
            
            //map AnalysisRequestReport
            var report = new AnalysisRequestReport()
            {
                SampleSite = reportModel.SampleSite,
                CollectedDate = reportModel.CollectedDate,
                ReceivedDate = reportModel.ReceivedDate
            };
            //Map patient
            var patient = new Patient()
            {
                NidPp = reportModel.Patient.NidPp.ToUpper().Trim(),
                Fullname = reportModel.Patient.Fullname.ToUpper().Trim(),
                AgeSex = reportModel.Patient.AgeSex,
                Birthdate = reportModel.Patient.Birthdate,
                Address = reportModel.Patient.Address
            };
            //map Assays
            var assays = new BindingList<Assays>();
            foreach (var assay in reportModel.Assays)
            {
                assays.Add(new Assays()
                {
                    Cin = assay.Cin,
                    Discipline = assay.Discipline,
                    Assay = assay.Assay,
                    Result = assay.Result,
                    Unit = assay.Unit,
                    DisplayNormalRange = assay.DisplayNormalRange
                });
            }

            //add patient and assays to report
            report.Assays = assays;
            report.Patient = patient;

            //add report to a list of reports to make it compatible as datasource
            var reports = new List<AnalysisRequestReport>();
            reports.Add(report);

            var xtraReport = new AnalysisReport() { DataSource = reports };
            ReportPrintTool tool = new ReportPrintTool(xtraReport);

            //hide unnecessary buttons
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Customize,CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Background,CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.EditPageHF, CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.HighlightEditingFields, CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Open, CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None);
            tool.PreviewForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Save, CommandVisibility.None);
            
            //Set Main view as mdi parent.
            tool.PreviewForm.MdiParent = this.MdiParent;
            //Show the report
            tool.ShowPreview();
            //Close this form
            DisposeMe();


        }

        private void DisposeMe()
        {            
            this.Close();
            this.Dispose();
        }

        private void InitializeReport(string cin)
        {

            var report = new AnalysisRequestReport()
            {
                SampleSite = "Flu Clinic",
                CollectedDate = DateTime.Today,
                ReceivedDate = DateTime.Today

            };
            var patient = new Patient()
            {
                NidPp = "A253455",
                Fullname = "Ahmed Bin Hambal",
                AgeSex = "23Y / MALE",
                Birthdate = DateTime.Today,
                Address = "The most complete address ever in the history of mankind!"
            };

            var Assays = new BindingList<Assays>()
            {
                new Assays()
                {
                    Cin = "BS1234567",
                    Assay = "CRP",
                    Result = "0.5"
                },
                new Assays()
                {
                    Cin = "BS1234567",
                    Assay = "CK",
                    Result = "9"
                },
                new Assays()
                {
                    Cin = "BS1234567",
                    Assay = "CK-MB",
                    Result = "50"
                }
            };

            report.Patient = patient;
            report.Assays = Assays;

            var reports = new List<AnalysisRequestReport>();
            reports.Add(report);

            

            var xreport = new AnalysisReport() { DataSource = reports };

            ReportPrintTool tool = new ReportPrintTool(xreport);
            tool.ShowPreview();
        }
    }

    public class AnalysisRequestReport
    {
        public string SampleSite { get; set; }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public Patient Patient { get; set; }
        public BindingList<Assays> Assays { get; set; }

    }

    public class Assays
    {
        public string Cin { get; set; }
        public string Discipline { get; set; }
        public string Assay { get; set; }
        public string Result { get; set; }
        public string Unit { get; set; }
        public string DisplayNormalRange { get; set; }
    }

    public class Patient
    {
        public string NidPp { get; set; }
        public string Fullname { get; set; }
        public string AgeSex { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
    }
}
