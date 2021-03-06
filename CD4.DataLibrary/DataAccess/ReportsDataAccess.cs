﻿using CD4.DataLibrary.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ReportsDataAccess : DataAccessBase, IReportsDataAccess
    {
        public async Task<List<AnalysisRequestReportModel>> GetAnalysisReportByCinAsync(string cin, int loggedInUserId, string procedureName = "")
        {
            //stored procedure name to call
            var storedProcedure = "[dbo].[usp_GetAnalysisReportByCin]";
            if (!string.IsNullOrEmpty(procedureName)) { storedProcedure = procedureName; }

            //dynamic parameter with cin
            var parameters = new { Cin = cin, UserId = loggedInUserId };
            try
            {
                //Execute the stored procedure by calling LoadAnalysisReportAsync method
                var output = await LoadAnalysisReportAsync<dynamic>(storedProcedure, parameters);

                //If query yeilded no results, return new list
                if (output.Results.Count == 0)
                {
                    return new List<AnalysisRequestReportModel>();
                }

                //map the database model to output model and return
                return MapFromDatabaseModelToReturnModel(output);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<AnalysisRequestReportModel>> 
            GetAnalysisReportForEpisodeAsync(string episodeNumber, int loggedInUserId, string procedureName = "")
        {
            //stored procedure name to call
            var storedProcedure = "[dbo].[usp_GetAnalysisReportForEpisode]";
            if (!string.IsNullOrEmpty(procedureName)) { storedProcedure = procedureName; }

            var parameters = new { EpisodeNumber = episodeNumber, UserId = loggedInUserId };
            try
            {
                //Execute the stored procedure by calling LoadAnalysisReportAsync method
                var output = await LoadAnalysisReportAsync<dynamic>(storedProcedure, parameters);

                //If query yeilded no results, return new list
                if (output.Results.Count == 0)
                {
                    return new List<AnalysisRequestReportModel>();
                }

                //map the database model to output model and return
                return MapFromDatabaseModelToReturnModel(output);
            }
            catch (Exception)
            {

                throw;
            }

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
                    Nationality = databaseModel.Patient.Nationality,
                    AgeSex = databaseModel.Patient.AgeSex,
                    Birthdate = databaseModel.Patient.Birthdate,
                    Fullname = databaseModel.Patient.Fullname,
                    NidPp = databaseModel.Patient.NidPp,
                },
                EpisodeNumber = databaseModel.Patient.EpisodeNumber,
                QcCalValidatedBy = databaseModel.Patient.QcCalValidatedBy,
                ReportedAt = databaseModel.Patient.ReportedAt,
                ReceivedBy = databaseModel.Patient.ReceivedBy,
                AnalysedBy = databaseModel.Patient.AnalysedBy,
                InstituteAssignedPatientId = databaseModel.Patient.InstituteAssignedPatientId,
                SampleProcessedAt = databaseModel.Patient.SampleProcessedAt,
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
                     Discipline = assay.Discipline,
                     Cin  = assay.Cin,
                     Result = assay.Result,
                     Unit = assay.Unit,
                     DisplayNormalRange = assay.DisplayNormalRange,
                     Comment = assay.Comment,
                     SortOrder = assay.SortOrder,
                     PrimaryHeader = assay.PrimaryHeader,
                     SecondaryHeader = assay.SecondaryHeader
                });
            }

            //add the model to the output list and return
            output.Add(reportModel);
            return output;
        }

    }
}
