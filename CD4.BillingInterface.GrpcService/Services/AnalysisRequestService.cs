using CD4.BillingInterface.GrpcService.Protos;
using CD4.DataLibrary.DataAccess;
using CD4.DataLibrary.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CD4.BillingInterface.GrpcService.Protos.AnalysisRequest;

namespace CD4.BillingInterface.GrpcService.Services
{
    public class AnalysisRequestService : AnalysisRequestBase
    {
        private readonly ILogger<AnalysisRequestService> _logger;
        private readonly IAnalysisRequestDataAccess _analysisRequestDataAccess;
        private readonly IBillingCD4TestMapService _billingCD4TestMapService;
        private readonly IStatusDataAccess _statusDataAccess;

        public AnalysisRequestService(ILogger<AnalysisRequestService> logger,
            IAnalysisRequestDataAccess analysisRequestDataAccess,
            IBillingCD4TestMapService billingCD4TestMapService,
            IStatusDataAccess statusDataAccess)
        {
            _logger = logger;
            _analysisRequestDataAccess = analysisRequestDataAccess;
            _billingCD4TestMapService = billingCD4TestMapService;
            _statusDataAccess = statusDataAccess;

        }

        public override async Task<Response> Save(AnalysisRequestModel request, ServerCallContext context)
        {

            _logger.LogDebug($"Analysis Request received from Billing.\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");

            _logger.LogDebug("Building Analysis Request");
            var insertAR = new AnalysisRequestDataModel()
            {
                EpisodeNumber = request.Request.MemoNumber,
                Cin = request.Request.SampleId,
                SiteId = request.Request.SiteId,
                SampleCollectionDate = GetDatetimeFromTicks(request.Request.SampleCollectedDateTime),
                SampleReceivedDate = GetDatetimeFromTicks(request.Request.SampleReceivedDateTime),
                NationalIdPassport = request.Patient.NidPp,
                Fullname = request.Patient.Fullname,
                Birthdate = GetDatetimeFromTicks(request.Patient.Birthdate),
                Age = request.Patient.Age,
                AtollId = request.Patient.AtollId,
                Address = request.Patient.Address,
                GenderId = request.Patient.GenderId,
                PhoneNumber = request.Patient.PhoneNumber,
                CountryId = request.Patient.Nationality,
                Tests = new List<TestsModel>(),
                ClinicalDetails = new List<ClinicalDetailsSelectionModel>()
            };

            var UnmappedTestCodesExist = false;
            _logger.LogDebug("Mapping analyses");
            foreach (var item in request.Tests.AnalysisId)
            {
                var cd4Tests = GetTestIdFromBillingCode(item);
                if (cd4Tests is null) { _logger.LogWarning($"Billing TestCode: {item} not mapped to any CD4 TestCodes"); UnmappedTestCodesExist = true; continue; }
                if (cd4Tests.Count == 0) { _logger.LogWarning($"Billing TestCode: {item} not mapped to any CD4 TestCodes"); UnmappedTestCodesExist = true; continue; }

                insertAR.Tests.AddRange(cd4Tests);
                _logger.LogDebug($"Billing TestCode: {item} mapped to test(s): {JsonConvert.SerializeObject(cd4Tests)}");
            }
            _logger.LogDebug("Mapping analyses completed");


            if (request.Tests.AnalysisId.Count > 0 && insertAR.Tests.Count == 0)
            {
                _logger.LogInformation("Response code 500 with message None of the test codes are mapped. Analysis request not inserted to CD4");
                return new Response() { Status = 500, Message = "None of the test codes are mapped. Analysis request not inserted to CD4" };
            }



            try
            {
                _logger.LogDebug("Calling datalayer for inserting/updating analysis request");
                await _analysisRequestDataAccess.ConfirmRequestAsync(insertAR, 1);

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
            var TestMap = _billingCD4TestMapService.GetTestMap();
            var matches = TestMap.FindAll((x) => x.BillingTestId == testCode);
            if (matches.Count == 0) { return new List<TestsModel>(); }

            var tests = new List<TestsModel>();
            foreach (var item in matches)
            {
                tests.Add(new TestsModel() { Id = item.TestId });
            }

            return tests;
        }

        private DateTime GetDatetimeFromTicks(Timestamp datetime)
        {
            return new DateTime(datetime.Seconds * 10000000);
        }
    }
}
