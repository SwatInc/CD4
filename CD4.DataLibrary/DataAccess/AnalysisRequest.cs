using System.Data;
using System.Data.SqlClient;

namespace CD4.DataLibrary.DataAccess
{
    public class AnalysisRequest : DataAccessBase, IAnalysisRequest
    {
        public void ConfirmRequest()
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
        }
    }
}
