using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class PatientModel : INotifyPropertyChanged
    {
        #region Private Properties
        private int id;
        private string fullname;
        private string nidPp;
        private DateTime birthdate;
        private string gender;
        private string atoll;
        private string island;
        private string country;
        private string address;
        private string phoneNumber;
        private long instituteAssignedPatientId;

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
        public DateTime Birthdate
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
        public long InstituteAssignedPatientId
        {
            get => instituteAssignedPatientId; set
            {
                if (instituteAssignedPatientId == value) { return; }
                instituteAssignedPatientId = value;
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

    }
}
