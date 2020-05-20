using CD4.DataLibrary.Helpers;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class PatientModel : INotifyPropertyChanged
    {
        #region Private Properties
        private int id;
        private string fullname;
        private string nidPp;
        private DateTime? birthdate;
        private string gender;
        private string atoll;
        private string island;
        private string country;
        private string address;
        private string phoneNumber;

        #endregion

        #region Public Properties
        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string Fullname
        {
            get => fullname; set
            {
                if (fullname == value) return;
                fullname = value;
                OnPropertyChanged();
            }
        }
        public string NidPp
        {
            get => nidPp; set
            {
                if (nidPp == value) return;
                nidPp = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birthdate
        {
            get => birthdate; set
            {
                if (birthdate == value) return;
                birthdate = value;
                OnPropertyChanged();
            }
        }
        public string Gender
        {
            get => gender; set
            {
                if (gender == value) return;
                gender = value;
                OnPropertyChanged();
            }
        }
        public string Atoll
        {
            get => atoll; set
            {
                if (atoll == value) return;
                atoll = value;
                OnPropertyChanged();
            }
        }
        public string Island
        {
            get => island; set
            {
                if (island == value) return;
                island = value;
                OnPropertyChanged();
            }
        }
        public string Country
        {
            get => country; set
            {
                if (country == value) return;
                country = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address; set
            {
                if (address == value) return;
                address = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                if (phoneNumber == value) return;
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public bool AreEqual(AnalysisRequestDataModel dataToCompare)
        {
            if (dataToCompare.Fullname != this.fullname) return false;
            if (dataToCompare.NationalIdPassport != this.NidPp) return false;
            if (DateHelper.GetCD4FormatDate(dataToCompare.Birthdate) != DateHelper.GetCD4FormatDate(this.Birthdate)) return false;
            if (dataToCompare.Gender != this.Gender) return false;
            if (dataToCompare.Atoll != this.Atoll) return false;
            if (dataToCompare.Island != this.Island) return false;
            if (dataToCompare.Country != this.Country) return false;
            if (dataToCompare.Address != this.Address) return false;
            if (dataToCompare.PhoneNumber != this.phoneNumber) return false;

            return true;
        }
    }
}
