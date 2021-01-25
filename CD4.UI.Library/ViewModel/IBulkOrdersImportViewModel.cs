using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public interface IBulkOrdersImportViewModel
    {
        string ReceiptNumber { get; set; }
        List<SitesModel> Sites { get; set; }
        List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        string TestToAdd { get; set; }
        BindingList<TestModel> AddedTests { get; set; }
        BindingList<BulkSchemaModel> BulkDataList { get; set; }
        string ExcelFilePath { get; set; }
        bool LoadingAnimationVisible { get; set; }
        string ButtonErrorsCountlabel { get; }
        bool ButtonErrorsCountEnabled { get; }
        List<string> ErrorMessages { get; set; }
        bool ErrorsPanelVisible { get; set; }
        bool MainPanelVisible { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void ClearErrorMessages();
        Task ConformUploadSelected(List<BulkSchemaModel> selectedRecordsToImport);
        Task ManageAddTestToRequestAsync();
    }
}