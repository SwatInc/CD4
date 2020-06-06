using CD4.DataLibrary.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ReportsDataAccess : DataAccessBase, IReportsDataAccess
    {
        public async Task<List<AnalysisRequestReportModel>> GetAnalysisReportByCinAsync(string cin)
        {
            //stored procedure name to call
            var storedProcedure = "[dbo].[usp_GetAnalysisReportByCin]";
            //dynamic parameter with cin
            var parameters = new { Cin = cin };

            //Execute the stored procedure by calling LoadAnalysisReportByCinAsync method
            var output = await this.LoadAnalysisReportByCinAsync<dynamic>(storedProcedure, parameters);

            //If query yeilded no results, return new list
            if (output.Results.Count == 0)
            {
                return new List<AnalysisRequestReportModel>();
            }

            //map the database model to output model and return
            return MapFromDatabaseModelToReturnModel(output);
        }

        /// <summary>
        /// Convert from AnalysisReportDatabaseModel to list of AnalysisRequestReportModel
        /// </summary>
        /// <param name="databaseModel">The AnalysisReportDatabaseModel returned by query</param>
        /// <returns>A list of AnalysisRequestReportModel</returns>
        private List<AnalysisRequestReportModel> MapFromDatabaseModelToReturnModel
            (AnalysisReportDatabaseModel databaseModel)
        {
            //Initialize a list inatance to return
            var output = new List<AnalysisRequestReportModel>();
            //Initialize model to add to list.
            var reportModel = new AnalysisRequestReportModel()
            {
                //Initialize patient data
                Patient = new PatientModel()
                {
                    Address = databaseModel.Patient.Address,
                    AgeSex = databaseModel.Patient.AgeSex,
                    Birthdate = databaseModel.Patient.Birthdate,
                    Fullname = databaseModel.Patient.Fullname,
                    NidPp = databaseModel.Patient.NidPp
                },
                //Initialize sample collected date, received date and sample site.
                CollectedDate = databaseModel.Patient.CollectedDate,
                ReceivedDate = databaseModel.Patient.ReceivedDate,
                SampleSite = databaseModel.Patient.SampleSite
            };

            //Add assays to the model
            foreach (var assay in databaseModel.Results)
            {
                reportModel.Assays.Add(new AssaysModel
                {
                     Assay = assay.Assay,
                     Cin  = assay.Cin,
                     Result = assay.Result
                });
            }

            //add the model to the output list and return
            output.Add(reportModel);
            return output;
        }

    }
}
