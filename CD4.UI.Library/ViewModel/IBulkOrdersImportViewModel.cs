using CD4.UI.Library.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace CD4.UI.Library.ViewModel
{
    public interface IBulkOrdersImportViewModel
    {
        string ReceiptNumber { get; set; }
        string Address { get; set; }
        List<SitesModel> Sites { get; set; }
        int SelectedSiteId { get; set; }
        List<AtollModel> Atolls { get; set; }
        string SelectedAtoll { get; set; }
        string SelectedIsland { get; set; }
        BindingList<IslandModel> Islands { get; set; }
        List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        string TestToAdd { get; set; }
        BindingList<TestModel> AddedTests { get; set; }
        BindingList<BulkSchemaModel> BulkDataList { get; set; }
        string ExcelFilePath { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}