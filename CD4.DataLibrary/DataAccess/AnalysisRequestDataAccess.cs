using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequestDataAccess : DataAccessBase, IAnalysisRequestDataAccess
    {
        private readonly IPatientDataAccess patientData;
        private readonly IClinicalDetailsDataAccess clinicalDetailsData;
        private List<TestsModel> TestsToInsert  = new List<TestsModel>();
        private List<TestsModel> TestsToRemove = new List<TestsModel>();

        public AnalysisRequestDataAccess(IPatientDataAccess patientData, IClinicalDetailsDataAccess clinicalDetailsData)
        {
            this.patientData = patientData;
            this.clinicalDetailsData = clinicalDetailsData;
        }
        public async Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request)
        {
            RequestDataStatus requestSampleStatus = RequestDataStatus.New;
            RequestDataStatus patientStatus = RequestDataStatus.New;
            RequestDataStatus clinicalDetailsStatus = RequestDataStatus.New;

            #region Request Rejection Criteria

            if (string.IsNullOrEmpty(request.Cin))
            {
                throw new ArgumentNullException("CIN", "COVID Identification number cannot be null! Analysis request not saved!"); 
            }

            #endregion

            #region Fetch Present data

            var requestAndSample = await GetSampleByIdAsync(request.Cin);
            var patient = (await patientData.GetPatientByNidPp(request.NationalIdPassport)).FirstOrDefault();

            List<ClinicalDetailsDatabaseModel> clinicalDetails = new List<ClinicalDetailsDatabaseModel>();
            List<ResultsDatabaseModel> databaseTestsForRequest = new List<ResultsDatabaseModel>();
            if(requestAndSample != null)
            {
                clinicalDetails = await clinicalDetailsData.GetClinicalDetailsByRequestId(requestAndSample.RequestId);
                databaseTestsForRequest = await GetRequestedTestsByRequestId(requestAndSample.RequestId);
            }

            #endregion

            #region Set Status for Data [GETTING READY MANIPULATE DATABASE]

            #region Determine request and sample status

            if (requestAndSample != null)
            {
                //checks Age, Cin, Site, Collection Date and received date
                if (!requestAndSample.AreEqual(request))
                {
                    requestSampleStatus = RequestDataStatus.Dirty;
                    //This will require an update. updates will be done in a later step.
                }
                else
                {
                    requestSampleStatus = RequestDataStatus.Clean;
                }
            }

            #endregion

            #region DeterminePatientStatus

            if(patient != null)
            {
                if(!patient.AreEqual(request))
                {
                    patientStatus = RequestDataStatus.Dirty;
                }
                else
                {
                    patientStatus = RequestDataStatus.Clean;
                }
            }

            #endregion

            #region Determine Clinical Details Status
            if (requestAndSample != null)
            {
                if (!ClinicalDetailsDatabaseModel.AreEqual(request.ClinicalDetails, clinicalDetails))
                {
                    clinicalDetailsStatus = RequestDataStatus.Dirty;
                }
                else
                {
                    clinicalDetailsStatus = RequestDataStatus.Clean;
                }

            }
            #endregion

            #region Setup tests to insert and remove from database

            TestsToInsert = GetTestsToInsert(request.Tests, databaseTestsForRequest);
            TestsToRemove = GetTestsToRemove(request.Tests, databaseTestsForRequest);

            #endregion

            #endregion


            return true;
        }

        private async Task<RequestAndSampleDatabaseModel> GetSampleByIdAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetRequestAndSample]";
            var parameter = new SampleNumberParameterModel() { Cin = cin };

            var sampleAndRequest = await LoadDataWithParameterAsync<RequestAndSampleDatabaseModel, SampleNumberParameterModel>(storedProcedure, parameter);
            return sampleAndRequest.FirstOrDefault();
        }

        public async Task<List<ResultsDatabaseModel>> GetRequestedTestsByRequestId(int requestId)
        {
            var storedProcedure = "[dbo].[usp_GetTestWithResultsByRequestId]";
            var parameter = new RequestIdParameterModel() { AnalysisRequestId = requestId};
            return await LoadDataWithParameterAsync<ResultsDatabaseModel, RequestIdParameterModel>(storedProcedure, parameter);
        
        }

        private List<TestsModel> GetTestsToInsert(List<TestsModel> userInputList, List<ResultsDatabaseModel> requestedTestsOnDatabase)
        {
            if (userInputList is null) return new List<TestsModel>();
            if (requestedTestsOnDatabase is null) return userInputList;

            if (userInputList.Count == 0 || requestedTestsOnDatabase.Count == 0) return userInputList;

            var testInsertList = new List<TestsModel>();
            foreach (var test in userInputList)
            {
                var testOnDatabase = requestedTestsOnDatabase.Where((t) => t.TestId == test.Id).FirstOrDefault();
                if (testOnDatabase is null) testInsertList.Add(test);
            }

            return testInsertList;
        }

        /// <summary>
        /// Get List of Tests models with only the test Id field populated.
        /// WARNING: referencing any field other than Id from the returned model with throw a null reference exception
        /// </summary>
        /// <param name="userInputList"></param>
        /// <param name="requestedTestsOnDatabase"></param>
        /// <returns>List of TestsModel</returns>
        private List<TestsModel> GetTestsToRemove(List<TestsModel> userInputList, List<ResultsDatabaseModel> requestedTestsOnDatabase)
        {
            var errorMessageOnZeroUserInput = "A minimum of one test need to be selected per request!";
            if (requestedTestsOnDatabase is null) return new List<TestsModel>();
            if (userInputList is null) throw new ArgumentNullException(errorMessageOnZeroUserInput);

            if (requestedTestsOnDatabase.Count == 0) return new List<TestsModel>();
            if (userInputList.Count == 0) throw new ArgumentNullException(errorMessageOnZeroUserInput);

            var listOfTestsToRemove = new List<TestsModel>();
            foreach (var test in requestedTestsOnDatabase)
            {
                var userSelectedTest = userInputList.Where((t) => t.Id == test.TestId).FirstOrDefault();
                if (userSelectedTest is null && string.IsNullOrEmpty(test.Result))
                {
                    listOfTestsToRemove.Add(new TestsModel()
                    {
                        Id = test.Id,
                    });
                }
            }
            return listOfTestsToRemove;

        }
    }
}
