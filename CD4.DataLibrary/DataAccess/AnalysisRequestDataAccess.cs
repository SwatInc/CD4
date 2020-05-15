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
            List<ResultsDatabaseModel> requestedTests = new List<ResultsDatabaseModel>();
            if(requestAndSample != null)
            {
                clinicalDetails = await clinicalDetailsData.GetClinicalDetailsByRequestId(requestAndSample.RequestId);
                requestedTests = await GetRequestedTestsByRequestId(requestAndSample.RequestId);
            }

            #endregion

            #region Determine request and sample status

            if (requestAndSample != null)
            {
                if (!requestAndSample.AreEqual(request))
                {
                    requestSampleStatus = RequestDataStatus.Dirty;
                    //This will require an update.
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

            #region SelectedTestsStatus

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
    }
}
