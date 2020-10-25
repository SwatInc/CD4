using CD4.UI.Library.Model;
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
        Task ValidateSample(RequestSampleModel requestSampleModel);

        BindingList<CodifiedResultsModel> CodifiedPhrasesForSelectedTest { get; set; }
        BindingList<string> SelectedClinicalDetails { get; set; }
        DateTime LoadWorksheetFromDate { get; set; }
        List<StatusModel> AllStatus { get; set; }
        StatusModel SelectedStatus { get; set; }
        bool IsloadWorkSheetButtonEnabled { get; set; }
        bool IsLoadingAnimationEnabled { get; set; }
        ResultEntryViewModel.GridControlTestActiveDatasource GridTestActiveDatasource { get; set; }
        List<AuditTrailModel> SampleAuditTrail { get; set; }
        ResultEntryViewModel.GridControlSampleActiveDatasource GridSampleActiveDatasource { get; set; }
        dynamic TestHistoryData { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        event EventHandler RequestDataRefreshed;
        event EventHandler<string> PushingMessages;
        event EventHandler<string> PushingLogs;

        Task GetSampleAuditTrailByCinAsync(string cin);
        Task RejectSampleAsync(string cin, int commentListId);
        bool CanRejectSample(RequestSampleModel sampleToReject);
        Task CancelSampleRejection(string cin);
        Task RejectTestAsync(ResultModel testToReject, int commentListId);
        bool CanRejectTest(ResultModel sampleToReject);
        Task CancelTestRejection(ResultModel testData);
        bool CanCancelSampleRejection(RequestSampleModel sample);
        bool CanCancelTestRejection(ResultModel resultToEvaluateForRejection);
        Task<dynamic> GetResultHistoryAsync(ResultModel testRecord);
    }
}