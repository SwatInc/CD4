using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequestDataAccess : DataAccessBase, IAnalysisRequestDataAccess
    {
        #region Private Fields
        private readonly IPatientDataAccess patientData;
        private readonly IClinicalDetailsDataAccess clinicalDetailsData;
        private readonly ISampleDataAccess sampleDataAccess;
        private readonly IResultDataAccess resultDataAccess;
        private readonly IStatusDataAccess statusDataAccess;

        #endregion

        public AnalysisRequestDataAccess(IPatientDataAccess patientData,
            IClinicalDetailsDataAccess clinicalDetailsData,
            ISampleDataAccess sampleDataAccess,
            IResultDataAccess resultDataAccess,
            IStatusDataAccess statusDataAccess)
        {
            this.patientData = patientData;
            this.clinicalDetailsData = clinicalDetailsData;
            this.sampleDataAccess = sampleDataAccess;
            this.resultDataAccess = resultDataAccess;
            this.statusDataAccess = statusDataAccess;
        }

        public async Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request, int loggedInUserId)
        {
            RequestDataStatus requestSampleStatus = RequestDataStatus.New;
            RequestDataStatus patientStatus = RequestDataStatus.New;
            RequestDataStatus clinicalDetailsStatus = RequestDataStatus.New;
            int InsertedPatientId = 0;

            List<TestsModel> TestsToInsert = new List<TestsModel>();
            List<TestsModel> TestsToRemove = new List<TestsModel>();
            List<ClinicalDetailsDatabaseModel> clinicalDetails = new List<ClinicalDetailsDatabaseModel>();
            List<ResultsDatabaseModel> databaseTestsForRequest = new List<ResultsDatabaseModel>();


            #region Request Rejection Criteria - Primary
            //Requests with no Cin are invalid
            if (string.IsNullOrEmpty(request.Cin))
            {
                throw new ArgumentNullException("CIN", "COVID Identification number cannot be null! Analysis request not saved!");
            }
            //Requests with not tests are not valid.
            if (request.Tests.Count == 0)
            {
                throw new ArgumentException("A minimum of one test is mandatory to confirm the request!");
            }
            //Checking whether the current request exists on the database. If it does, any edits for the request should not change the patient to a new patient.
            var PatientDataValidityForAnalysisRequest = await IsPatientDifferentForAnalysisRequest(request);
            //if the data update criteria for existing request fails, throw an exception saying so...
            if (PatientDataValidityForAnalysisRequest.IsAnalysisRequestsPatientChanged)
            {
                throw new Exception("Cannot confirm request. Cannot change patient for a previously confirmed request!\n" +
                    $"Previous details: {request.Cin}: {PatientDataValidityForAnalysisRequest.DatabasePatient.NidPp} ( {PatientDataValidityForAnalysisRequest.DatabasePatient.Fullname} )\n" +
                    $"Current details: {request.Cin}: {request.NationalIdPassport} ( {request.Fullname} )");
            }

            #endregion

            #region Fetch Present data
            //load the sample from database, if exists
            var requestAndSample = await GetSampleByIdAsync(request.Cin);
            //fetch patient data specific to the now handlng request
            PatientModel patient = (await patientData.GetPatientByNidPp(request.NationalIdPassport)).FirstOrDefault();

            //if the request and sample exist on the database...
            if (requestAndSample != null)
            {
                //Get clinical details saved on the database for request
                clinicalDetails = await clinicalDetailsData.GetClinicalDetailsByRequestId(requestAndSample.RequestId);
                //Get requested tests saved on the database
                databaseTestsForRequest = await GetRequestedTestsByRequestIdAsync(requestAndSample.RequestId);
            }

            #endregion

            #region Determine request, sample and , clinical details status | Determine Tests to insert / delete
            //Checking whether the current handling request is new, clean, or dirty.
            requestSampleStatus = AssesRequestAndSampleStatus(requestAndSample, request);
            //checking whether the patient for the current request is new, clean or dirty.
            patientStatus = AssesPatientStatus(patient, request);

            //if the request and sample was previously saved on database....
            if (requestAndSample != null)
            {
                //determine the status of clinical details... New, Clean or dirty.
                clinicalDetailsStatus = AssesClinicalDetailStatus(request, clinicalDetails);
                //Generate a list of tests to insert for the request
                TestsToInsert = GetTestsToInsert(request.Tests, databaseTestsForRequest);
                //Make a list of tests for the request that exists on the database but does not exist on the request.
                //NOTE: If no results exists for these tests, they will be removed.
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
                    Birthdate = DateHelper.GetCD4FormatDate(request.Birthdate),
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
                    Birthdate = DateHelper.GetCD4FormatDate(request.Birthdate),
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

            #region Case New Request, Everything below the tree is new, Insert all

            if (requestSampleStatus == RequestDataStatus.New)
            {
                //IF REQUEST IS NEW:: CLINICAL DETAILS, SAMPLE AND REQUESTED TESTS
                //WILL BE NEW FOR SURE. SO HANDLE THEM ALL AT THE SAME TIME
                return await InsertNewCompleteRequest(GetPatientId(patient, InsertedPatientId), request, loggedInUserId);

            }

            #endregion

            #region Update request

            if (requestSampleStatus == RequestDataStatus.Dirty)
            {
                var requestToUpdate = new AnalysisRequestUpdateDatabaseModel()
                {
                    Id = requestAndSample.RequestId,
                    PatientId = patient.Id,
                    EpisodeNumber = request.EpisodeNumber,
                    Age = request.Age
                };
                var isRequestUpdated = await UpdateRequestAsync(requestToUpdate, loggedInUserId);
                if (!isRequestUpdated)
                {
                    throw new Exception("Cannot update request data! [ either episode number, age or patient associated with request was not updated ]");
                }
            }


            #endregion

            #region Update Sample

            if (requestSampleStatus == RequestDataStatus.Dirty)
            {
                var sampleToUpdate = new SampleUpdateDatabaseModel()
                {
                    Cin = request.Cin,
                    SiteId = request.SiteId,
                    CollectionDate = request.SampleCollectionDate,
                    ReceivedDate = request.SampleReceivedDate

                };

                var output = await sampleDataAccess.UpdateSample(sampleToUpdate,loggedInUserId);
                if (!output)
                {
                    throw new Exception("Cannot sample details. [May include: Site, collected date or received date]. Please verify!");
                }

            }

            #endregion

            #region Update Results Table [Test data | NOT ACTUAL SAMPLE RESULTS]

            if (TestsToInsert.Count > 0 || TestsToRemove.Count > 0)
            {
                var output = await resultDataAccess.ManageRequestedTestsDataAsync(TestsToInsert, TestsToRemove, request.Cin,loggedInUserId);
                if (!output)
                {
                    throw new Exception("Error adding or removing requested tests!");
                }
            }

            #endregion

            #region Sync Clinical details data
            if (clinicalDetailsStatus == RequestDataStatus.Dirty)
            {
                //Sync
                string csvClinicalDetails =
                    ClinicalDetailsDataAccess.GetCsvClinicalDetails(request.ClinicalDetails);
                var output = await clinicalDetailsData.SyncClinicalDetails
                    (csvClinicalDetails, requestAndSample.RequestId);
                if (!output)
                {
                    throw new Exception("Cannot update clinical details for the request.");
                }

            }
            #endregion


            #endregion


            #endregion

            return true;
        }

        /// <summary>
        /// Determines whether the patient or an existing analysis request is changed to another patient 
        /// with current submitted request confirmation. Changing patient to a whole another patient is not allowed, but
        /// updating patient details is allowed except for NationalId / PP
        /// </summary>
        /// <param name="request">user submitted request data via UI</param>
        /// <returns>Returns true if the Nid/Pp does not match with the request of the same CIN on the database</returns>
        private async Task<ExistingRequestsPatientComparisionArgs> IsPatientDifferentForAnalysisRequest
            (AnalysisRequestDataModel request)
        {
            //get database patient details for the CIN
            var patient  = await patientData.GetPatientBySamplCin(request.Cin);

            //If no records found on the database for the CIN, return false.
            if (patient is null)
            {
                return new ExistingRequestsPatientComparisionArgs() { IsAnalysisRequestsPatientChanged = false };
            }

            //If NidPp matches with the user input, return false.
            if (patient.IsMatch(request))
            {
                return new ExistingRequestsPatientComparisionArgs() { IsAnalysisRequestsPatientChanged = false };
            }

            // if none of the above matches, It means that the patient changed to another patient for an existing request.
            //  So return true with database patient data.
            return new ExistingRequestsPatientComparisionArgs() 
            {
                 IsAnalysisRequestsPatientChanged = true,
                 DatabasePatient = new PatientNidPpAndNameModel()
                 {
                     Fullname = patient.Fullname,
                     NidPp  = patient.NidPp
                 }
            };
        }

        private async Task<bool> InsertNewCompleteRequest
            (int patientId, AnalysisRequestDataModel request, int loggedInUserId)
        {
            var insertData = new RequestSampleAndClinicalDetailsInsertDatabaseModel(patientId, request, statusDataAccess, loggedInUserId);
            bool success;

            if (string.IsNullOrEmpty(insertData.CommaDelimitedClinicalDetailsIds))
            {
                // when clinical details are not available.
                success =  await SelectInsertOrUpdateAsync<bool, dynamic>
                    ("[dbo].[usp_InsertAnalysisRequestSampleAndRequestedTests]", insertData.GetWithoutClinicalDetails());
                await InsertSampleCollectedDate(request, loggedInUserId);
                return success;
            }
            //with clinical details
            success = await SelectInsertOrUpdateAsync<bool, RequestSampleAndClinicalDetailsInsertDatabaseModel>
                ("[dbo].[usp_InsertAnalysisRequestClinicalDetailsSampleAndRequestedTests]", insertData);
            await InsertSampleCollectedDate(request, loggedInUserId);
            return success;

        }

        /// <summary>
        /// Determined which of the variable holds the patient Id, either will have the Id but not both.
        /// </summary>
        /// <param name="patient"> The patient record fetched from database. </param>
        /// <param name="insertedPatientId"> Inserted patient Id</param>
        /// <returns> return the patient Id associated with the patient of current request</returns>
        private int GetPatientId(PatientModel patient, int insertedPatientId)
        {
            if (patient is null)
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
            //Setting an initial status of new
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

        public async Task<List<ResultsDatabaseModel>> GetRequestedTestsByRequestIdAsync
            (int requestId)
        {
            var storedProcedure = "[dbo].[usp_GetTestWithResultsByRequestId]";
            var parameter = new RequestIdParameterModel() { AnalysisRequestId = requestId };
            return await LoadDataWithParameterAsync<ResultsDatabaseModel, RequestIdParameterModel>(storedProcedure, parameter);

        }

        /// <summary>
        /// Tests to insert: Make a list of tests that does not exist on the database as requested, but exists on current request. 
        /// </summary>
        /// <param name="userInputList">The test list from current processing request provided by user. This might have been edited by user</param>
        /// <param name="requestedTestsOnDatabase">The list of tests that exists on the database for the request</param>
        /// <returns></returns>
        private List<TestsModel> GetTestsToInsert(List<TestsModel> userInputList, List<ResultsDatabaseModel> requestedTestsOnDatabase)
        {
            //if current processing list does not have any tests, there is nothing to insert.
            if (userInputList is null) return new List<TestsModel>();
            //if no tests exist on the database for the request, insert the whole test list from current processing request.
            if (requestedTestsOnDatabase is null) return userInputList;

            //doing the almost the same as above.
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
        private List<TestsModel> GetTestsToRemove
            (List<TestsModel> userInputList, List<ResultsDatabaseModel> requestedTestsOnDatabase)
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
                    //make sure that a dulicate test is not added to remove test list under any circumstance, 
                    //That would crash the stored procedure, UDT has PK on testID column
                    var isTestToRemoveDublicate = listOfTestsToRemove.Where((t) => t.Id == test.TestId).FirstOrDefault();
                    if (isTestToRemoveDublicate != null) continue;
                    listOfTestsToRemove.Add(new TestsModel()
                    {
                        Id = test.TestId,
                    });
                }
            }
            return listOfTestsToRemove;

        }

        public async Task<int> InsertRequestAsync(AnalysisRequestInsertDatabaseModel request)
        {
            var storedProcedure = "[dbo].[usp_InsertAnalysisRequest]";
            return await SelectInsertOrUpdateAsync<int, AnalysisRequestInsertDatabaseModel>
                (storedProcedure, request);
        }

        public async Task<bool> UpdateRequestAsync(AnalysisRequestUpdateDatabaseModel request, int loggedInUserId)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_UpdateAnalysisRequest]";
                var parameters = new
                {
                    Id = request.Id,
                    PatientId = request.PatientId,
                    EpisodeNumber = request.EpisodeNumber,
                    Age = request.Age,
                    UserId = loggedInUserId
                };
                _ = await SelectInsertOrUpdateAsync<bool, dynamic>
                    (storedProcedure, parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CompleteRequestSearchResultsModel>SearchRequestByCinAsync
            (string cin)
        {
            var storedProcedure = "[dbo].[usp_GetCompleteRequestByCin]";
            var parameter = new CinParameterModel() { Cin = cin };

            return await SelectMultipleRequestDataSets(storedProcedure, parameter);
        }

        /// <summary>
        /// Get the fields required for barcode
        /// </summary>
        /// <param name="cin">Accession number</param>
        /// <returns></returns>
        public async Task<List<BarcodeDataModel>> GetBarcodeDataAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetBarcodeDetails]";
            var parameter = new { Cin = cin };
            try
            {
                return await LoadDataWithParameterAsync<BarcodeDataModel,dynamic>(storedProcedure,parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertSampleCollectedDate(AnalysisRequestDataModel request, int loggedInUserId)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleWithCin]";
            var parameters = new
            {
                Cin = request.Cin,
                SiteId = request.SiteId,
                CollectionDate = request.SampleCollectionDate,
                ReceivedDate = request.SampleReceivedDate,
                UserId = loggedInUserId
            };

            try
            {
                _ = await SelectInsertOrUpdateAsync<dynamic, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetNextCinSeed()
        {
            var storedProcedure = "[dbo].[usp_GetNextSampleNumber]";
            try
            {
                var data = await LoadDataAsync<int>(storedProcedure);
                return FormatCinSeed(data.FirstOrDefault());
            }
            catch (Exception)
            {

                throw;
            }

        }

        private string FormatCinSeed(int nextCinSeed)
        {
            var totalLength = 7;
            var padCharacter = '0';
            var prefix = "ML";

            var paddedNextSeed = nextCinSeed.ToString().PadLeft(totalLength, padCharacter);
            return $"{prefix}{paddedNextSeed}";
        }
    }
}
