using CD4.UI.Library.Helpers;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.Model
{
    public class RequestSampleModel : INotifyPropertyChanged
    {

        #region Private properties
        private int id;
        private int analysisRequestId;
        private string cin;
        private DateTimeOffset? collectionDate;
        private DateTimeOffset? receivedDate;
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
        private int statusIconId;
        private string birthDateString;
        private string _completeAddress;
        private long instituteAssignedPatientId;
        private bool samplePriority;

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
        public DateTimeOffset? CollectionDate
        {
            get => collectionDate; set
            {
                if (collectionDate == value) return;
                collectionDate = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset? ReceivedDate
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
        public string BirthDateString
        {
            get => birthDateString; private set
            {
                birthDateString = value;
                OnPropertyChanged();
            }
        }
        public DateTime Birthdate
        {
            get => birthdate; set
            {
                if (birthdate == value) return;
                birthdate = value;
                BirthDateString = value.ToString("dd-MMM-yyyy");
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
                CompleteAddress = $"{Address}, {AtollIslandCountry}";
                OnPropertyChanged();
            }
        }

        public string CompleteAddress
        {
            get => _completeAddress; set
            {
                _completeAddress = value;
                OnPropertyChanged();
            }
        }
        public long InstituteAssignedPatientId
        {
            get => instituteAssignedPatientId; set
            {
                instituteAssignedPatientId = value;
                OnPropertyChanged();
            }
        }

        public bool SamplePriority
        {
            get => samplePriority; set
            {
                samplePriority = value;

                //set priority icon
                if (samplePriority) { SamplePriorityIcon = StatusIconHelper.GetIcon(8); }
                if (!samplePriority) { SamplePriorityIcon = StatusIconHelper.GetIcon(9); }
                OnPropertyChanged(nameof(SamplePriorityIcon));
            }
        }
        public Image SamplePriorityIcon { get; set; }

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
        public Image StatusIcon { get; private set; }


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

        public int StatusIconId
        {
            get => statusIconId; set
            {
                if (statusIconId == value)
                {
                    return;
                }
                statusIconId = value;
                OnPropertyChanged();
                SetIcon(value);
            }
        }

        private void SetIcon(int value)
        {
            StatusIcon = StatusIconHelper.GetIcon(value);
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
