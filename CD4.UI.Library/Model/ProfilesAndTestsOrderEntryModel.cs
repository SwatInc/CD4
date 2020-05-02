using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    /// <summary>
    /// Test name from base class, "TestModel" is used as
    /// profile name if IsProfile is true
    /// </summary>
    public class ProfilesAndTestsDatasourceOeModel : TestModel
    {
        private bool isProfile;
        public ProfilesAndTestsDatasourceOeModel()
        {
            this.TestsInProfile = new List<TestModel>();
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
        public List<TestModel> TestsInProfile { get; set; }

    }
}
