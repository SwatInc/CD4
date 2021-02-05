using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.ResultsInterface.Models
{
    public class InterfaceResultsModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Lookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        public InterfaceResultsModel()
        {
            Measurements = new List<MeasurementValues>();
            InstrumentId = new InstrumentIdentification();
        }
        public string SampleId { get; set; }
        public string Dilution { get; set; }
        public string ReagentLot { get; set; }
        public string ReagentSerialNumber { get; set; }
        public string ControlLotNumber { get; set; }
        public string ResultType { get; set; }
        public string BatchId { get; set; }
        public List<MeasurementValues> Measurements { get; set; }
        public string Unit { get; set; }
        public string ReferenceRange { get; set; }
        public string AbnormalFlags { get; set; }
        public string NatureOfAbnormality { get; set; }
        public ResultStatus ResultStatus { get; set; }
        public string OperatorIdentification { get; set; }
        public string StartDateTime { get; set; }
        public string CompletedDateTime { get; set; }
        public InstrumentIdentification InstrumentId { get; set; }

    }
}
