﻿using CD4.DataLibrary.Models;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IAnalysisRequestDataAccess
    {
        Task<bool> ConfirmRequestAsync(AnalysisRequestDataModel request);
    }
}