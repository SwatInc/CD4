using System.Collections.Generic;
using System.ComponentModel;

namespace CD4.ExcelInterface.Models
{

    public class Config : INotifyPropertyChanged
    {
        private string mainFormTitle;

        public Config()
        {
            BatchId = new BatchId();
            DataRange = new DataRange();
            ExcludeRows = new List<int>();
            Measurements = new List<Measurement>();
        }
        public string MainFormTitle
        {
            get => mainFormTitle; set
            {
                mainFormTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MainFormTitle)));
            }
        }
        public string AnalyserName { get; set; }
        public string ExcelFileDirectory { get; set; }
        public string ExportPath { get; set; }
        public string DataExtension { get; set; }
        public string ControlFileExtension { get; set; }
        public string LisExportExtension { get; set; }
        public BatchId BatchId { get; set; }
        public DataRange DataRange { get; set; }
        public int SidColumn { get; set; }
        public int SamplePositionColumn { get; set; }
        public List<int> ExcludeRows { get; set; }
        public string PositiveControlSID { get; set; }
        public string NegativeControlSID { get; set; }
        public List<Measurement> Measurements { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
