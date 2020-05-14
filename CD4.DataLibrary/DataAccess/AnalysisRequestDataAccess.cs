using CD4.DataLibrary.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequestDataAccess : DataAccessBase, IAnalysisRequestDataAccess
    {
        private readonly IPatientDataAccess patientData;

        public AnalysisRequestDataAccess(IPatientDataAccess patientData)
        {
            this.patientData = patientData;
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

            ClinicalDetailsDatabaseModel clinicalDetails;
            if(requestAndSample != null)
            {
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

            return true;
        }

        private async Task<RequestAndSampleDatabaseModel> GetSampleByIdAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetRequestAndSample]";
            var parameter = new SampleNumberParameterModel() { Cin = cin };

            var sampleAndRequest = await LoadDataWithParameterAsync<RequestAndSampleDatabaseModel, SampleNumberParameterModel>(storedProcedure, parameter);
            return sampleAndRequest.FirstOrDefault();
        }
    }
}
