using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    /// <summary>
    /// Test name from base class, "TestModel" is used as
    /// profile name if IsProfile is true
    /// </summary>
    public class ProfilesAndTestModelOeModel : TestsModel
    {
        private bool isProfile;
        public ProfilesAndTestModelOeModel()
        {
            TestsInProfile = new List<TestsModel>();
        }
        public bool IsProfile
        {
            get => isProfile; set
            {
                if (isProfile == value) return;
                isProfile = value;
                OnPropertyChanged();
            }
        }
        public List<TestsModel> TestsInProfile { get; set; }

        public override bool Equals(object obj)
        {
            try
            {
                var test = (ProfilesAndTestModelOeModel)obj;
                if (test.Id != Id) return false;
                if (test.Description != Description) return false;

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
