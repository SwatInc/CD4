﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IClinicalDetailsDataAccess
    {
        Task<List<ClinicalDetailsDatabaseModel>> GetClinicalDetailsByRequestId(int requestId);
        Task<bool> SyncClinicalDetails(string csvClinicalDetails, int analysisRequestId);
    }
}