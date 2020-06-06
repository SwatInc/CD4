using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using CD4.DataLibrary.Models.ReportModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class DataAccessBase
    {
        internal readonly SqlDataAccessHelper helper;

        public DataAccessBase()
        {
            this.helper = new SqlDataAccessHelper();
        }

        internal async Task<List<T>> LoadDataAsync<T>(string storedProcedure)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = await connection.QueryAsync<T>(storedProcedure, CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        internal async Task<List<T>> LoadDataWithParameterAsync<T,U>
            (string storedProcedure, U parameter)
        {

            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = await connection.QueryAsync<T>
                    (storedProcedure, parameter, commandType: CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        /// <summary>
        /// NOTE: T should be the first type of data set returned by the query / procedure
        /// NOTE: U should be the second type of data set returned by the query / procedure
        /// MEANS that the generic classes should be passed in the order that is expected to be returned by the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <returns>returns a class with List<T> AND List<U> as public properties</returns>
        internal async Task<GenericTwoListModel> LoadStaticDataTwoSetsAsync<T, U>
            (string storedProcedure)
        {
            var genericTwoList = new GenericTwoListModel();
            var returnData = genericTwoList.GetLists<T, U>();

            List<T> ListT = null;
            List<U> ListU = null;

            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, CommandType.StoredProcedure))
                {
                    ListT = lists.Read<T>().ToList();
                    ListU = lists.Read<U>().ToList();
                }
            }

            returnData.T1 = ListT;
            returnData.U1 = ListU;
            return returnData;
        }

        internal async Task<T> SelectInsertOrUpdate<T,U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                return await connection.QueryFirstOrDefaultAsync<T>
                    (storedProcedure,parameters,commandType: CommandType.StoredProcedure);
            }

        }

        internal async Task<CompleteRequestSearchResultsModel> SelectMultipleRequestDataSets<T>(string storedProcedure, T parameters)
        {
            var requestPatientSampleData = new RequestSearchDataModel();
            var clinicalDetailIds  = new List<ClinicalDetailIdsModel>();
            var requestedTestsData = new List<ResultsDatabaseModel>();

            try
            {
                using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
                {
                    using (var reader = await connection.QueryMultipleAsync
                        (storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        requestPatientSampleData = reader.Read<RequestSearchDataModel>().FirstOrDefault();
                        clinicalDetailIds = reader.Read<ClinicalDetailIdsModel>().ToList();
                        requestedTestsData = reader.Read<ResultsDatabaseModel>().ToList();
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


            if (requestPatientSampleData is null) { return new CompleteRequestSearchResultsModel(); }
            return new CompleteRequestSearchResultsModel()
            {
                RequestPatientSampleData = requestPatientSampleData,
                ClinicalDetailIds = clinicalDetailIds,
                RequestedTestsData = requestedTestsData
            };
        }

        internal async Task<WorklistModel> SelectWorksheetDatasets<T>(string storedProcedure, T parameters)
        {
            var patientData = new List<WorklistPatientDataModel>();
            var resultData = new List<WorkListResultsModel>();
            try
            {
                using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
                {
                    using (var reader = await connection.QueryMultipleAsync
                        (storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        patientData = reader.Read<WorklistPatientDataModel>().ToList();
                        resultData = reader.Read<WorkListResultsModel>().ToList();
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


            if (patientData.Count == 0) { return new WorklistModel(); }
            return new WorklistModel()
            {
                 PatientData = patientData,
                 TestResultsData = resultData
            };
        }

        /// <summary>
        /// Gets data needed to generate an analysis report by using the provided Cin(Parameter) and stored procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">An instance with the required parameter, Cin</param>
        /// <returns>A Task of AnalysisReportDatabaseModel</returns>
        internal async Task<AnalysisReportDatabaseModel> LoadAnalysisReportByCinAsync<T>(string storedProcedure, T parameters)
        {
            //initialize patient and results models
            var patient = new PatientForAnalysisReportDatabaseModel();
            var results = new List<ResultsForAnalysisReportDatabaseModel>();

            //open try catch block
            try
            {
                //Initialize connection
                using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
                {
                    //execute query to get multiple datasets, for patient and results
                    using (var reader = await connection.QueryMultipleAsync
                        (storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        //read results list
                        results = reader.Read<ResultsForAnalysisReportDatabaseModel>().ToList();
                        //read patient data
                        patient = reader.Read<PatientForAnalysisReportDatabaseModel>().FirstOrDefault();

                    }

                }
            }
            catch (Exception)
            {
                //throw any exceptions without handling them.
                //will be caught and handled in UI layer.
                throw;
            }

            //if query yielded no results, return an empty report model
            if (results.Count == 0)
            {
                return new AnalysisReportDatabaseModel();
            }

            //assign the patient and results models to a new instance of report model and return
            return new AnalysisReportDatabaseModel()
            {
                Patient = patient,
                Results = results
            };

        }

    }
}
