﻿using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using CD4.DataLibrary.Models.ReportModels;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        internal async Task<List<T>> LoadDataWithQueryAndParametersAsync<T,U>(string query, U parameters, string connectionName = "CD4Data" )
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString(connectionName)))
            {
                results = await connection.QueryAsync<T>(query,parameters);
            }

            return results.ToList();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        internal async Task<List<T>> LoadDataWithParameterAsync<T,U>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            (string storedProcedure, U parameter)
        {

            try
            {
                IEnumerable<T> results = new List<T>();
                using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
                {
                    return connection.QueryAsync<T>
                        (storedProcedure, parameter, commandType: CommandType.StoredProcedure).Result.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }


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

        /// <summary>
        /// Executes query and get multiple objects with model, list , stored procedure and paramters
        /// </summary>
        /// <typeparam name="T">The type of model instance to be returned</typeparam>
        /// <typeparam name="U">The type of list instance to be returned</typeparam>
        /// <typeparam name="V">parameter type</typeparam>
        /// <param name="storedProcedure">The stored procedure name</param>
        /// <param name="parameters">instance of parameters</param>
        /// <returns></returns>
        internal async Task<GenericModelAndListModel> QueryMultiple_GetModelAndListWithParameterAsync<T, U, V>
            (string storedProcedure, V parameters) where T: new()
        {
            var genericModelAndListList = new GenericModelAndListModel();
            var returnData = genericModelAndListList.GetNewModel<T, U>();

            T InstanceT = default(T);
            List<U> ListU = null;

            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure,parameters,commandType: CommandType.StoredProcedure))
                {
                    InstanceT = lists.Read<T>().FirstOrDefault();
                    ListU = lists.Read<U>().ToList();
                }
            }

            returnData.T1 = InstanceT;
            returnData.U1 = ListU;
            return returnData;
        }

        internal async Task<dynamic> QueryMultiple_WithProvidedReturnTypes_NoParameters(string storedProcedure, TypesModel listTypes, dynamic simpleTypes)
        {
            List<dynamic> dynamicResults = new List<dynamic>();

            foreach (var item in listTypes.GenericModelsList)
            {
                dynamicResults.Add(Activator.CreateInstance(item));
            }

            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, commandType: CommandType.StoredProcedure))
                {
                    int counter = 0;
                    foreach (var item in simpleTypes)
                    {
                        var t = item.GetType();
                        dynamicResults[counter] = lists.Read(t);
                        counter += 1;
                    }
                }
            }

            return dynamicResults;

        }

        internal async Task<T> SelectInsertOrUpdateAsync<T,U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                try
                {
                    var s =  await connection.QueryFirstOrDefaultAsync<T>
                        (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                    return s;
                }
                catch (Exception)
                {

                    throw;
                }

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

        internal async Task<StatusUpdatedSampleAndTestStatusModel> ValidateSampleAndGetUpdatedSampleAndTestStatus<T>(string storedProcedure, T parameters)
        {
            var SampleStatus = new StatusUpdatedSampleModel();
            var TestStatus = new List<StatusUpdatedTestModel>();
            try
            {
                using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
                {
                    using (var reader = await connection.QueryMultipleAsync
                        (storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        SampleStatus = reader.Read<StatusUpdatedSampleModel>().FirstOrDefault();
                        TestStatus = reader.Read<StatusUpdatedTestModel>().ToList();
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }

            //no need to check for nulls from the returned list. It will always be populated.
            return new StatusUpdatedSampleAndTestStatusModel()
            {
                SampleStatus = SampleStatus,
                TestStatusList = TestStatus
            };
        }

        /// <summary>
        /// Gets data needed to generate an analysis report by using the provided Cin(Parameter) and stored procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">An instance with the required parameter, Cin</param>
        /// <returns>A Task of AnalysisReportDatabaseModel</returns>
        internal async Task<AnalysisReportDatabaseModel> LoadAnalysisReportAsync<T>(string storedProcedure, T parameters)
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

        public SqlMapper.ICustomQueryParameter GetCinTable(List<string> sampleCins)
        {
            var returnTable = new DataTable();
            returnTable.Columns.Add("Cin");

            try
            {

                //Add rows to the Datatable declared, and return
                foreach (var cin in sampleCins)
                {
                    returnTable.Rows.Add(cin);
                }
                return returnTable.AsTableValuedParameter("SampleCinsUDT");
            }
            catch (Exception)
            {
                //throw the exception right out! It will be handled down the line.
                throw;
            }
        }
    }
}
