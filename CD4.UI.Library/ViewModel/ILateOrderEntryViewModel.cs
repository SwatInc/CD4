using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface ILateOrderEntryViewModel
    {
        List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        BindingList<TestModel> AddedTests { get; set; }
        Task<bool> ConfirmAnalysisRequest();
        Task ManageAddTestToRequestAsync();

        string TestToAdd { get; set; }
        bool LoadingStaticDataStatus { get; set; }
    }
}