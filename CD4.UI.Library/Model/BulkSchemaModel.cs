﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class BulkSchemaModel : INotifyPropertyChanged
    {
        private string fullname;
        private string nidPp;
        private string gender;
        private string nationality;
        private bool isValidData;
        private string cin;

        public BulkSchemaModel()
        {
            IsValidData = true;
        }
        public string Cin
        {
            get => cin; set
            {
                cin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cin)));
            }
        }
        public string NidPp
        {
            get => nidPp; set
            {
                nidPp = value.Trim();
            }
        }
        public string Fullname
        {
            get => fullname; set
            {
                fullname = value.Trim().ToUpper();
            }
        }
        public string Gender
        {
            get => gender; set
            {
                gender = value.Trim().ToUpper();
            }
        }
        public DateTime Birthdate { get; set; }
        public int PhoneNumber { get; set; }
        public string Nationality
        {
            get => nationality; set
            {
                nationality = value.Trim().ToUpper();
            }
        }
        public string Address { get; set; }
        public string Atoll { get; set; }
        public string Island { get; set; }
        public bool BreathingDifficulty { get; set; }
        public bool Cough { get; set; }
        public bool Fever { get; set; }
        public bool RunnyNose { get; set; }
        public bool TravelHistory { get; set; }
        public string SampleSite { get; set; }
        public DateTime SampleCollectedDateTime { get; set; }
        public int Hash { get; set; }
        public bool IsDublicate { get; private set; }
        public bool IsValidData
        {
            get => isValidData; set
            {
                isValidData = value;
                if (value)
                {
                    IsValidIcon = Properties.Resources.valid;
                }
                else
                {
                    IsValidIcon = Properties.Resources.invalid;
                }
            }
        }
        public Image IsValidIcon { get; private set; }

        #region underlying IDs
        public int GenderId { get; set; }
        public int NationalityId { get; set; }
        public int AtollIslandId { get; set; }
        public int SiteId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void SetDublicateStatus(bool isDublicate)
        {
            this.IsDublicate = isDublicate;
        }
    }
}
