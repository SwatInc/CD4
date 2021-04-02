﻿using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface INdaTrackingDataAccess
    {
        Task<List<NdaTrackingModel>> LoadSearchResults(DateTime fromDate, DateTime toDate, int sampleStatus);
    }
}