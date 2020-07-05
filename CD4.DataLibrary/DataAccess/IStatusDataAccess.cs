﻿using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IStatusDataAccess
    {
        Task<int> DetermineSampleStatus(int resultId);
        Task<List<StatusModel>> GetAllStatus();
        int GetRegisteredStatusId();
        int GetToValidateStatusId();
        Task<StatusUpdatedSampleAndTestStatusModel> ValidateSample(string cin);
        Task<bool> ValidateTest(string cin, string testDescription, int testStatus, string result);
    }
}