using CD4.DataLibrary.DataAccess;
using CD4.Entensibility.ReportingFramework;
using CD4.Entensibility.ReportingFramework.Models;
using CD4.UI.UiSpecificModels;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class ReportView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IReportsDataAccess _reportsData;
        private readonly CinAndReportIdModel _cinAndReportId;
        private readonly int _loggedInUserId;
        private readonly ILoadMultipleExtensions _reportExtensions;

        public event EventHandler OnSearchByCin;
        public ReportView(IReportsDataAccess reportsData, CinAndReportIdModel cinAndReportId, int loggedInUserId, ILoadMultipleExtensions reportExtensions)
        {
            InitializeComponent();

            //assign report data access library as a private field
            _reportsData = reportsData;
            _cinAndReportId = cinAndReportId;
            _loggedInUserId = loggedInUserId;
            _reportExtensions = reportExtensions;

            //Write cin to form Tag
            Tag = cinAndReportId.Cin;
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
                var report = await _reportsData.GetAnalysisReportByCinAsync((string)Tag, _loggedInUserId).ConfigureAwait(true);
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
            var report = new AnalysisRequestReportModel()
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
                Address = reportModel.Patient.Address,
                Nationality = reportModel.Patient.Nationality
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
            report.PrintedDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

            //add report to a list of reports to make it compatible as datasource
            var reports = new List<AnalysisRequestReportModel>();
            report.SetPdf417String();
            reports.Add(report);

            //ReportTemplates[0] The ZERO need to be handled dynamically to be truly extensible
            var xtraReport = _reportExtensions.ReportTemplates[0].Execute((ReportTemplate)_cinAndReportId.ReportIndex);
            xtraReport.DataSource = reports;
            xtraReport.RequestParameters = false;

            xtraReport.DisplayName = $"{Tag}_{report.Patient.Fullname} ({report.Patient.NidPp.Replace('/', '-')})";

            if (_cinAndReportId.Action == ReportActionModel.Export)
            {
                var settings = new Properties.Settings();
                string exportDirectoryStructure = $"{DateTime.Today:yyyy}\\{DateTime.Today:MMMM}\\{DateTime.Today:dd}\\{reportModel.SampleSite.Trim()}";
                var exportDirPath = $"{settings.ReportExportBasePath}\\{exportDirectoryStructure}";

                try
                {
                    ExportReport(xtraReport, exportDirPath);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error exporting report. Please fing the details below.\n{ex.Message}\n{ex.StackTrace}\nExport path: {exportDirPath}");
                    
                    //prompt for user to select a temp export path
                    var folderBrowserDialog = new XtraFolderBrowserDialog();
                    // Show the FolderBrowserDialog.
                    DialogResult result = folderBrowserDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        exportDirPath = $"{folderBrowserDialog.SelectedPath}\\{exportDirectoryStructure}";
                        ExportReport(xtraReport, exportDirPath);
                    }
                }

            }
            if (_cinAndReportId.Action == ReportActionModel.Print)
            {
                xtraReport.PrinterName = "DocumentPrinter";
                xtraReport.CreateDocument();
                xtraReport.Print();
            }

            //Close this form
            DisposeMe();


        }

        private void ExportReport(XtraReport xtraReport, string exportDirPath)
        {
            // If directory does not exist, create it
            if (!Directory.Exists(exportDirPath))
            {
                Directory.CreateDirectory(exportDirPath);
            }
            xtraReport.ExportToPdf($"{exportDirPath}\\{xtraReport.DisplayName}.pdf");
        }

        private void DisposeMe()
        {
            Close();
            Dispose();
        }

        private void InitializeReport(string cin)
        {

            var report = new AnalysisRequestReportModel()
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

            var reports = new List<AnalysisRequestReportModel>();
            reports.Add(report);



            var xreport = _reportExtensions.ReportTemplates[0].Execute(ReportTemplate.AnalysisReportDefault);
            xreport.DataSource = reports;
            ReportPrintTool tool = new ReportPrintTool(xreport);
            tool.ShowPreview();
        }
    }

}
