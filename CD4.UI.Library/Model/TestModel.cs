using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class TestModel : INotifyPropertyChanged
    {
        private int id;
        private string description;
        private string resultDataType;
        private string mask;
        private bool isReportable;
        private string discipline;
        private string sampleType;
        private string unit;
        private string code;
        private bool defaultCommented;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Discipline
        {
            get => discipline; set
            {
                discipline = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description; set
            {
                if (description == value) return;
                description = value;
                OnPropertyChanged();
            }
        }
        public string SampleType
        {
            get => sampleType; set
            {
                sampleType = value;
                OnPropertyChanged();
            }
        }
        public string ResultDataType
        {
            get => resultDataType; set
            {
                if (resultDataType == value) return;
                resultDataType = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// The numeric zero ( 0 ) indcates a mandatory presence of zero if no digit is present a position
        /// The hash (#) means optional digit
        /// </summary>
        public string Mask
        {
            get => mask; set
            {
                if (mask == value) return;
                mask = value;
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
        public string Code
        {
            get => code; set
            {
                code = value;
                OnPropertyChanged();
            }
        }
        public bool IsReportable
        {
            get => isReportable; set
            {
                if (isReportable == value) return;
                isReportable = value;
                OnPropertyChanged();
            }
        }
        public bool DefaultCommented
        {
            get => defaultCommented; set
            {
                defaultCommented = value;
                OnPropertyChanged();
            }
        }



        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        internal static bool HaveNulls(TestModel selectedTest)
        {
            if (selectedTest.Id == 0) return true;
            if (string.IsNullOrEmpty(selectedTest.Description)) return true;
            if (string.IsNullOrEmpty(selectedTest.Mask)) return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            var test = (TestModel)obj;
            if (test.Id != this.Id) return false;
            if (test.Description != this.Description) return false;
            if (test.mask != this.Mask) return false;
            if (test.isReportable != this.isReportable) return false;
            return true;
        }

    }
}