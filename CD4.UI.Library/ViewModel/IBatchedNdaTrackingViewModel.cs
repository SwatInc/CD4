using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IBatchedNdaTrackingViewModel
    {
        ScientistModel AnalysedUser { get; set; }
        ScientistModel CalQcValidatedUser { get; set; }
        DateTime? FromDate { get; set; }
        BindingList<NdaTrackingModel> NdaTrackingData { get; set; }
        List<ScientistModel> Scientists { get; set; }
        DateTime? SelectedReportDate { get; set; }
        StatusModel SelectedStatus { get; set; }
        List<StatusModel> Statuses { get; set; }
        DateTime? ToDate { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

        Task ExecuteSearchAsync();
        Task<List<CinAndFullnameModel>> SaveAnalysedUserAsync(List<NdaTrackingModel> selectedData);
        Task<List<CinAndFullnameModel>> SaveQcCalValidatedUserAsync(List<NdaTrackingModel> selectedData);
        Task<List<CinAndReportDateModel>> SaveReportDateAsync(List<NdaTrackingModel> selectedData);
        void UpdateUiQcCalValidatedUser(List<CinAndFullnameModel> updatedDate);
        void UpdateUiReportDate(List<CinAndReportDateModel> updatedData);
        void UpdateUiWithAnalysedUser(List<CinAndFullnameModel> updatedData);
    }
}