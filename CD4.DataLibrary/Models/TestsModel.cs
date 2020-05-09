using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.DataLibrary.Models
{
    public class TestsModel : INotifyPropertyChanged
    {
        private int id;
        private string description;
        private string resultDataType;
        private string mask;
        private bool isReportable;

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
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
        public bool IsReportable
        {
            get => isReportable; set
            {
                if (isReportable == value) return;
                isReportable = value;
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

        internal static bool HaveNulls(TestsModel selectedTest)
        {
            if (selectedTest.Id == 0) return true;
            if (string.IsNullOrEmpty(selectedTest.Description)) return true;
            if (string.IsNullOrEmpty(selectedTest.Mask)) return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            var test = (TestsModel)obj;
            if (test.Id != Id) return false;
            if (test.Description != Description) return false;
            if (test.mask != Mask) return false;
            if (test.isReportable != isReportable) return false;
            return true;
        }

    }
}