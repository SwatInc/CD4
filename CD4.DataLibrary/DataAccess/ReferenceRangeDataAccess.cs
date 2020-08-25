using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class ReferenceRangeDataAccess : IReferenceRangeDataAccess
    {
        public async Task<ResultReferenceRangeModel> GetDemoReferenceRangeByResultIdAsync(int resultId)
        {
            //delete this method and implement this later.
            return await Task.Run(() =>
            {
                return new ResultReferenceRangeModel()
                {
                    ResultId = resultId,
                    NormalHighLimit = 1.000f,
                    NormalLowLimit = 0.900f
                };
            });
        }

        public async Task<ResultReferenceRangeModel> GetReferenceRangeByResultIdAsync(int resultId)
        {
            throw new NotImplementedException();
        }
    }
}
