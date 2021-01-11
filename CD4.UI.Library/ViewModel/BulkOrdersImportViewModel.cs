using CD4.UI.Library.Model;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CD4.UI.Library.ViewModel
{
    public class BulkOrdersImportViewModel : INotifyPropertyChanged, IBulkOrdersImportViewModel
    {
        #region Private Properties

        private string testToAdd;
        private string receiptNumber;
        private string address;
        private string selectedAtoll;
        private string selectedIsland;
        private int selectedSiteId;
        private string excelFilePath;

        #endregion

        #region Default Constructor
        public BulkOrdersImportViewModel()
        {
            Islands = new BindingList<IslandModel>();
            Sites = new List<SitesModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();
            Nationalities = new List<CountryModel>();
            AllTestsData = new List<ProfilesAndTestsDatasourceOeModel>();
            BulkDataList = new BindingList<BulkSchemaModel>();
        }
        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public Properties

        public string ReceiptNumber
        {
            get => receiptNumber; set
            {
                if (receiptNumber == value) { return; }
                receiptNumber = value;
                OnPropertyChanged();
            }
        }
        public string TestToAdd
        {
            get => testToAdd; set
            {
                if (testToAdd == value) { return; }
                testToAdd = value;
                OnPropertyChanged();
            }
        }
        public string ExcelFilePath
        {
            get => excelFilePath; set
            {
                if(excelFilePath == value) { return; }
                excelFilePath = value;
                LoadExcelFile();
                ValidateData();
                OnPropertyChanged();
            }
        }

        private List<AtollIslandModel> AllAtollsWithCorrespondingIsland { get; set; }
        public BindingList<IslandModel> Islands { get; set; }
        public List<SitesModel> Sites { get; set; }
        public List<CountryModel> Nationalities { get; set; }
        public BindingList<TestModel> AddedTests { get; set; }
        public List<ProfilesAndTestsDatasourceOeModel> AllTestsData { get; set; }
        public BindingList<BulkSchemaModel> BulkDataList { get; set; }
        public List<GenderModel> GenderList { get; set; }
        public BindingList<ClinicalDetailsOrderEntryModel> ClinicalDetails { get; set; }

        #endregion

        #region Private Methods
        private void ValidateData()
        {
        }

        private void LoadExcelFile()
        {
            var excelData = new ExcelMapper(ExcelFilePath).Fetch<BulkSchemaModel>();
            BulkDataList.Clear();

            if (excelData != null)
            {
                if(excelData.ToList().Count < 1) { return; }
                foreach (var item in excelData)
                {
                    BulkDataList.Add(item);
                }
            }
        }
        #endregion
    }
}
