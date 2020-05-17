using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequestDataAccess : DataAccessBase, IAnalysisRequestDataAccess
    {
        private readonly IPatientDataAccess patientData;
        private readonly IClinicalDetailsDataAccess clinicalDetailsData;

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
            int InsertedPatientId = 0;
            int InsertedRequestId = 0;

            List<TestsModel> TestsToInsert = new List<TestsModel>();
            List<TestsModel> TestsToRemove = new List<TestsModel>();
            List<ClinicalDetailsDatabaseModel> clinicalDetails = new List<ClinicalDetailsDatabaseModel>();
            List<ResultsDatabaseModel> databaseTestsForRequest = new List<ResultsDatabaseModel>();


            #region Request Rejection Criteria

            if (string.IsNullOrEmpty(request.Cin))
            {
                throw new ArgumentNullException("CIN", "COVID Identification number cannot be null! Analysis request not saved!");
            }
            if (request.Tests.Count == 0)
            {
                throw new ArgumentException("A minimum of one test is mandatory to confirm the request!");
            }

            #endregion

            #region Fetch Present data

            var requestAndSample = await GetSampleByIdAsync(request.Cin);
            var patient = (await patientData.GetPatientByNidPp(request.NationalIdPassport)).FirstOrDefault();

            if (requestAndSample != null)
            {
                clinicalDetails = await clinicalDetailsData.GetClinicalDetailsByRequestId(requestAndSample.RequestId);
                databaseTestsForRequest = await GetRequestedTestsByRequestId(requestAndSample.RequestId);
            }

            #endregion

            #region Determine request, sample and , clinical details status | Test to insert / delete

            requestSampleStatus = AssesRequestAndSampleStatus(requestAndSample, request);
            patientStatus = AssesPatientStatus(patient, request);

            if (requestAndSample != null)
            {
                clinicalDetailsStatus = AssesClinicalDetailStatus(request, clinicalDetails);
                TestsToInsert = GetTestsToInsert(request.Tests, databaseTestsForRequest);
                TestsToRemove = GetTestsToRemove(request.Tests, databaseTestsForRequest);

            }

            #endregion

            #region Insert / Update / Delete from database

            #region Database IO

            #region insert / update patient

            if (patientStatus == RequestDataStatus.Dirty)
            {
                var patientToUpdate = new PatientUpdateDatabaseModel()
                {
                    Id = patient.Id,
                    Fullname = request.Fullname,
                    NidPp = request.NationalIdPassport,
                    Birthdate = request.Birthdate.ToString("yyyyMMdd"),
                    GenderId = request.GenderId,
                    AtollId = request.AtollId,
                    CountryId = request.CountryId,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber
                };
                var isPatientUpdated = await patientData.UpdatePatient(patientToUpdate);
                if (!isPatientUpdated) { throw new Exception("Cannot update patient data!"); }
            }
            if (patientStatus == RequestDataStatus.New)
            {
                //insert patient
                var patientToInsert = new PatientInsertDatabaseModel()
                {
                    Fullname = request.Fullname,
                    NidPp = request.NationalIdPassport,
                    Birthdate = request.Birthdate.ToString("yyyyMMdd"),
                    GenderId = request.GenderId,
                    AtollId = request.AtollId,
                    CountryId = request.CountryId,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber
                };
                InsertedPatientId = await patientData.InsertPatient(patientToInsert);

                if (InsertedPatientId == 0)
                {
                    throw new Exception("An error occured. Cannot insert the patient!");
                }

            }

            #endregion

            #region Insert / Update request and sample
            if (requestSampleStatus == RequestDataStatus.Dirty)
            {
                var requestToUpdate = new AnalysisRequestUpdateDatabaseModel()
                {
                    Id = requestAndSample.RequestId,
                    PatientId = patient.Id,
                    EpisodeNumber = request.EpisodeNumber,
                    Age = request.Age
                };
                var isRequestUpdated = await UpdateRequest(requestToUpdate);
                if (!isRequestUpdated)
                {
                    throw new Exception("Cannot update request data! [ either episode number, age or patient associated with request was not updated ]");
                }
            }
            if (requestSampleStatus == RequestDataStatus.New)
            {
                var requestToInsert = new AnalysisRequestInsertDatabaseModel()
                {
                    PatientId = GetPatientId(patient, InsertedPatientId),
                    EpisodeNumber = request.EpisodeNumber,
                    Age = request.Age
                };
                InsertedRequestId = await InsertRequest(requestToInsert);
                if (InsertedRequestId == 0)
                {
                    throw new Exception("An error occured. Cannot insert the request data! [Age and Episode number | cannot associate patient with request.]");
                }
            }

            #endregion

            #region results table IO for tests in request.

            if (TestsToRemove.Count > 0)
            {
                //delete tests
            }

            if (TestsToInsert.Count > 0)
            {
                //insert tests
            }

            #endregion

            #endregion




            #endregion
            return true;
        }

        /// <summary>
        /// Determined which of the variable holds the patient Id, either will have the Id but not both.
        /// </summary>
        /// <param name="patient"> The patient record fetched from database. </param>
        /// <param name="insertedPatientId"> Inserted patient Id</param>
        /// <returns> return the patient Id associated with the patient of current request</returns>
        private int GetPatientId(PatientModel patient, int insertedPatientId)
        {
            if(patient is null)
            {
                return insertedPatientId;
            }
            return patient.Id;
        }

        private RequestDataStatus AssesClinicalDetailStatus
            (AnalysisRequestDataModel request, List<ClinicalDetailsDatabaseModel> clinicalDetails)
        {
            var status = RequestDataStatus.New;
            if (!ClinicalDetailsDatabaseModel.AreEqual(request.ClinicalDetails, clinicalDetails))
            {
                status = RequestDataStatus.Dirty;
            }
            else
            {
                status = RequestDataStatus.Clean;
            }

            return status;

        }

        private RequestDataStatus AssesPatientStatus
            (PatientModel patient, AnalysisRequestDataModel request)
        {
            var status = RequestDataStatus.New;
            if (patient != null)
            {
                if (!patient.AreEqual(request))
                {
                    status = RequestDataStatus.Dirty;
                }
                else
                {
                    status = RequestDataStatus.Clean;
                }
            }
            return status;
        }

        /// <summary>
        /// Asses the status of request and sample data supplied by 
        /// UI compared with that on database
        /// </summary>
        /// <param name="requestAndSample"></param>
        /// <param name="request"></param>
        /// <returns>An enum indicating new, dirty or clean status of supplied data
        /// in comparision with database.
        /// </returns>
        private RequestDataStatus AssesRequestAndSampleStatus
            (RequestAndSampleDatabaseModel requestAndSample, AnalysisRequestDataModel request)
        {
            var status = RequestDataStatus.New;
            if (requestAndSample != null)
            {
                //checks Age, Cin, Site, Collection Date and received date
                if (!requestAndSample.AreEqual(request))
                {
                    status = RequestDataStatus.Dirty;
                    //This will require an update. updates will be done in a later step.
                }
                else
                {
                    status = RequestDataStatus.Clean;
                }
            }

            return status;
        }

        private async Task<RequestAndSampleDatabaseModel> GetSampleByIdAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetRequestAndSample]";
            var parameter = new CinParameterModel() { Cin = cin };

            var sampleAndRequest = await LoadDataWithParameterAsync<RequestAndSampleDatabaseModel, CinParameterModel>(storedProcedure, parameter);
            return sampleAndRequest.FirstOrDefault();
        }

        public async Task<List<ResultsDatabaseModel>> GetRequestedTestsByRequestId(int requestId)
        {
            var storedProcedure = "[dbo].[usp_GetTestWithResultsByRequestId]";
            var parameter = new RequestIdParameterModel() { AnalysisRequestId = requestId };
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

        public async Task<int> InsertRequest(AnalysisRequestInsertDatabaseModel request)
        {
            var storedProcedure = "[dbo].[usp_InsertAnalysisRequest]";
            return await InsertOrUpdate<int, AnalysisRequestInsertDatabaseModel>
                (storedProcedure, request);
        }

        public async Task<bool> UpdateRequest(AnalysisRequestUpdateDatabaseModel request)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdateAnalysisRequest]";
                _ = await InsertOrUpdate<bool, AnalysisRequestUpdateDatabaseModel>
                    (storedProcedure, request);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
