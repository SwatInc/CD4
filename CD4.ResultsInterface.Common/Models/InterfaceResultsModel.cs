using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CD4.ResultsInterface.Common.Models
{
    public class InterfaceResultsModel
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
        public int Count { get; internal set; }
    }

    public class InstrumentIdentification
    {
        public string InstrumentCode { get; set; }
        public string InstrumentSerialNumber { get; set; }
        public string RackBarcode { get; set; }
        public string TubePositionInRack { get; set; }
        public string RackLocation { get; set; }
    }

    public class MeasurementValues : INotifyPropertyChanged
    {
        private string testCode;
        private string measurementValue;
        private string unit;

        public string TestCode
        {
            get { return testCode; }
            set
            {
                testCode = value;
                OnPropertyChanged();
            }
        }
        public string MeasurementValue
        {
            get => measurementValue; set
            {
                measurementValue = value;
                OnPropertyChanged();
            }
        }
        public string Unit
        {
            get => unit; set
            {
                unit = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Lookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public enum ResultStatus
    {
        FinalResult,
        RerunResult,
        PreliminaryResult
    }
}
