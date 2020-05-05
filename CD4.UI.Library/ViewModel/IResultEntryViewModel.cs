using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IResultEntryViewModel
    {
        List<RequestSampleModel> RequestData { get; set; }
        BindingList<ResultModel> SelectedResultData { get; set; }
        RequestSampleModel SelectedRequestData { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}