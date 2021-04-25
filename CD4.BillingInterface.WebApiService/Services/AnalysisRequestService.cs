using CD4.BillingInterface.WebApiService.Models;
using CD4.DataLibrary.DataAccess;
using CD4.DataLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.BillingInterface.WebApiService.Services
{
    public class AnalysisRequestService : IAnalysisRequestService
    {
        private readonly ILogger<AnalysisRequestService> _logger;
        private readonly IAnalysisRequestDataAccess _analysisRequestDataAccess;
        private readonly IBillingCD4AnalysesMapService _billingCD4AnalysesMapService;
        private readonly IStatusDataAccess _statusDataAccess;
        private readonly INdaTrackingDataAccess _ndaTrackingDataAccess;

        public AnalysisRequestService(ILogger<AnalysisRequestService> logger,
            IAnalysisRequestDataAccess analysisRequestDataAccess,
            IBillingCD4AnalysesMapService billingCD4AnalysesMapService,
            IStatusDataAccess statusDataAccess,
            INdaTrackingDataAccess ndaTrackingDataAccess)
        {
            _logger = logger;
            _analysisRequestDataAccess = analysisRequestDataAccess;
            _billingCD4AnalysesMapService = billingCD4AnalysesMapService;
            _statusDataAccess = statusDataAccess;
            _ndaTrackingDataAccess = ndaTrackingDataAccess;
        }

        public async Task<Response> Save(AnalysisRequestModel request)
        {

            _logger.LogDebug($"Analysis Request received from Billing.\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");

            //check for the presence of VALID userid of the user who accepted the sample
            if (request.Request.SampleReceivedBy == 0 || request.Request.SampleReceivedBy == 1 || request.Request.SampleReceivedBy == 2 || request.Request.SampleReceivedBy == 3)
            {
                return new Response() { Status = 304, Message = "Required parameter not provided or invalid. [SampleReceivedBy:int]" };
            }


            _logger.LogDebug("Building Analysis Request");
            var insertAR = new AnalysisRequestDataModel()
            {
                EpisodeNumber = request.Request.MemoNumber,
                Cin = DeriveSampleNo(request.Patient),
                SiteId = request.Request.SiteId,
                SampleCollectionDate = GetDatetimeFromTicks(request.Request.SampleCollectedAt),
                SampleReceivedDate = GetDatetimeFromTicks(request.Request.SampleReceivedAt),
                NationalIdPassport = request.Patient.NidPp,
                Fullname = request.Patient.Fullname,
                Birthdate = GetDatetimeFromTicks(request.Patient.Birthdate),
                Age = request.Patient.Age,
                AtollId = request.Patient.AtollId,
                Address = request.Patient.Address,
                GenderId = request.Patient.GenderId,
                PhoneNumber = request.Patient.PhoneNumber,
                CountryId = request.Patient.NationalityId,
                Tests = new List<TestsModel>(),
                ClinicalDetails = new List<ClinicalDetailsSelectionModel>()
            };

            //try parsing patient Id
            var isPatientIdLong = long.TryParse(request.Patient.PatientId, out var longPatientId);
            if (isPatientIdLong) 
            { 
                insertAR.InstituteAssignedPatientId = longPatientId;
                _logger.LogInformation($"Patient Id successfully parsed as long. Patient Id: {longPatientId}");
            }
            if (!isPatientIdLong) { _logger.LogError($"Invalid patient Id. Expected to be numeric long. Actual: {request.Patient.PatientId}"); }

            var UnmappedTestCodesExist = false;
            _logger.LogDebug("Mapping analyses");
            foreach (var item in request.Analyses.RequestedTests)
            {
                var cd4Tests = GetTestIdFromBillingCode(item);
                if (cd4Tests is null) { _logger.LogWarning($"Billing TestCode: {item} not mapped to any CD4 TestCodes"); UnmappedTestCodesExist = true; continue; }
                if (cd4Tests.Count == 0) { _logger.LogWarning($"Billing TestCode: {item} not mapped to any CD4 TestCodes"); UnmappedTestCodesExist = true; continue; }

                insertAR.Tests.AddRange(cd4Tests);
                _logger.LogDebug($"Billing TestCode: {item} mapped to test(s): {JsonConvert.SerializeObject(cd4Tests)}");
            }
            _logger.LogDebug("Mapping analyses completed");


            if (request.Analyses.RequestedTests.Count > 0 && insertAR.Tests.Count == 0)
            {
                _logger.LogInformation("Response code 500 with message None of the test codes are mapped. Analysis request not inserted to CD4");
                return new Response() { Status = 500, Message = "None of the test codes are mapped. Analysis request not inserted to CD4" };
            }



            try
            {
                _logger.LogDebug("Calling datalayer for inserting/updating analysis request");
                await _analysisRequestDataAccess.ConfirmRequestAsync(insertAR, 2);

                //ToDo: insert the person who received / accepted the sample
                await _ndaTrackingDataAccess.UpsertSampleReceivedUserIdAsync(insertAR.Cin, request.Request.SampleReceivedBy, 2);

                //insert the sample accepted date and time if required.
                if (DecideToMarkSampleAsAccepted(insertAR))
                {
                    _logger.LogInformation("Inserting sample accepted date and time");
                    await _statusDataAccess.SetSampleAcceptedTimeReceivedFromBilling
                        (insertAR.Cin, insertAR.SampleReceivedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                if (UnmappedTestCodesExist)
                {
                    _logger.LogDebug("Response code 201 with message Some unmapped tests / profiles not inserted to CD4.");
                    return new Response() { Status = 201, Message = "Some unmapped tests / profiles not inserted to CD4." };
                }

                _logger.LogDebug("Response code 200 with message success.");
                return new Response() { Status = 200, Message = "Success" };

            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Response code 500 with message {ex.Message}.");
                return new Response() { Status = 500, Message = ex.Message };
            }
        }

        private string DeriveSampleNo(Models.PatientModel patient)
        {
            var tempSampleId = patient.Fullname;
            var yy = DateTime.Today.Year.ToString("yy");
            var yyyy = DateTime.Today.Year.ToString("yyyy");

            return tempSampleId
                .Replace($"US/{20}","")
                .Replace($"us/{20}","")
                .Replace($"Us/{20}","")
                .Replace($"uS/{20}","")
                .Replace(" ", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace("_", "")
                .Replace("\\", "")
                .Trim();
        }

        /// <summary>
        /// This method decides to insert sample accepted date time for the sample.
        /// </summary>
        /// <param name="insertAR">Analysis request parameters</param>
        /// <returns>true or false indicating whether the sample needs to be collected</returns>
        private bool DecideToMarkSampleAsAccepted(AnalysisRequestDataModel insertAR)
        {
            if (insertAR.SampleReceivedDate.HasValue)
            {
                return true;
            }
            return false;
        }


        private List<TestsModel> GetTestIdFromBillingCode(string testCode)
        {
            var TestMap = _billingCD4AnalysesMapService.GetTestMap();
            var matches = TestMap.FindAll((x) => x.BillingTestId == testCode);
            if (matches.Count == 0) { return new List<TestsModel>(); }

            var tests = new List<TestsModel>();
            foreach (var item in matches)
            {
                tests.Add(new TestsModel() { Id = item.TestId });
            }

            return tests;
        }

        /// <summary>
        /// converts ticks to datetime
        /// </summary>
        /// <param name="ticks">the number of ticks of a datetime</param>
        /// <returns>DateTime corresponding to number of ticks passed in</returns>
        private DateTime GetDatetimeFromTicks(long ticks)
        {
            return new DateTime(ticks);
        }
    }

}
