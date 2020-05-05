using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class RequestSampleModel : INotifyPropertyChanged
    {
        #region Private properties
        private int id;
        private int analysisRequestId;
        private string cin;
        private DateTime collectionDate;
        private DateTime receivedDate;
        private string patientName;
        private string nationalId;
        private string ageSex;
        private DateTime birthdate;
        private string phoneNumber;
        private string address;
        private string atollIslandCountry;
        private string episodeNumber;
        private string site;
        private string clinicalDetails;

        #endregion

        #region Public Properties
        //Sample
        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public int AnalysisRequestId
        {
            get => analysisRequestId; set
            {
                if (analysisRequestId == value) return;
                analysisRequestId = value;
                OnPropertyChanged();
            }
        }
        public string Cin
        {
            get => cin; set
            {
                if (cin == value) return;
                cin = value;
                OnPropertyChanged();
            }
        }
        public DateTime CollectionDate
        {
            get => collectionDate; set
            {
                if (collectionDate == value) return;
                collectionDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime ReceivedDate
        {
            get => receivedDate; set
            {
                if (receivedDate == value) return;
                receivedDate = value;
                OnPropertyChanged();
            }
        }

        //Patient
        public string PatientName
        {
            get => patientName; set
            {
                if (patientName == value) return;
                patientName = value;
                OnPropertyChanged();
            }
        }
        public string NationalId
        {
            get => nationalId; set
            {
                if (nationalId == value) return;
                nationalId = value;
                OnPropertyChanged();
            }
        }
        public string AgeSex
        {
            get => ageSex; set
            {
                if (ageSex == value) return;
                ageSex = value;
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
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                if (phoneNumber == value) return;
                phoneNumber = value;
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
        public string AtollIslandCountry
        {
            get => atollIslandCountry; set
            {
                if (atollIslandCountry == value) return;
                atollIslandCountry = value;
                OnPropertyChanged();
            }
        }
        public string EpisodeNumber
        {
            get => episodeNumber; set
            {
                if (episodeNumber == value) return;
                episodeNumber = value;
                OnPropertyChanged();
            }
        }
        public string Site
        {
            get => site; set
            {
                if (site == value) return;
                site = value;
                OnPropertyChanged();
            }
        }

        //ClinicalDetails
        public string ClinicalDetails
        {
            get => clinicalDetails; set
            {
                if (clinicalDetails == value) return;
                clinicalDetails = value;
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
