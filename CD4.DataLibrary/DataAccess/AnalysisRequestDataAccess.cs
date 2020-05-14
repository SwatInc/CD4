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
            /*STEPS
             * Does the request exist on database?
             * YES: 
             *      0. Request details changed? Update.
             *      1. check whether any extra tests exists, Add them
             *      2. if patient details require updating, update
             *      3. if clinical details require updating, update
             * NO: 
             *      PREPARE FOR ADDING REQUEST
             *          1. Look for the patient on data, insert / update as required.
             *          2. Insert request record to dbo.AnalysisRequest.
             *          3. Insert clinical details records to dbo.AnalysisRequest_ClinicalDetail
             *          4. Insert sample record to dbo.Sample
             *          5. Insert test data to dbo.Result with null result
             */

            //sanity check
            if (string.IsNullOrEmpty(request.Cin)) throw new ArgumentNullException("CIN", "COVID Identification number cannot be null! Analysis request not saved!");

            var sample = await GetSampleByIdAsync(request.Cin);

            var time = new Stopwatch();

            if(sample is null)
            {

                var patient = (await patientData.GetPatientByNidPp(request.NationalIdPassport)).FirstOrDefault();

                //var IsPatientDemographicsChanged = patient.ArePatientDetailsAMatch(AnalysisRequestDataModel);
                //Insert Request.
            }
            else
            {
                //Check for equality, update if necessary
            }

            throw new NotImplementedException();
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
