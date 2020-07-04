﻿using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IResultEntryViewModel
    {
        List<RequestSampleModel> RequestData { get; set; }
        BindingList<ResultModel> SelectedResultData { get; set; }
        RequestSampleModel SelectedRequestData { get; set; }
        Task SetSelectedSampleAsync(RequestSampleModel requestSampleData);
        Task SetTestCodifiedPhrasesAsync(ResultModel selectedTest);
        Task GetWorkSheet();
        Task ValidateTest(ResultModel resultModel);

        BindingList<CodifiedResultsModel> CodifiedPhrasesForSelectedTest { get; set; }
        BindingList<string> SelectedClinicalDetails { get; set; }
        DateTime LoadWorksheetFromDate { get; set; }
        List<StatusModel> AllStatus { get; set; }
        StatusModel SelectedStatus { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler RequestDataRefreshed;
        event EventHandler<string> PushingMessages;
        event EventHandler<string> PushingLogs;
    }
}