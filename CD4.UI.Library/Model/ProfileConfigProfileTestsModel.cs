namespace CD4.UI.Library.Model
{
    public class ProfileConfigProfileTestsModel : ProfilesConfigurationBaseModel
    {
        private string testDescription;
        private string profileDescription;

        public string TestDescription
        {
            get => testDescription; set
            {
                if (testDescription == value) return;
                testDescription = value;
                OnPropertyChanged();
            }
        }
        public string ProfileDescription
        {
            get => profileDescription; set
            {
                if (profileDescription == value) return;
                profileDescription = value;
                OnPropertyChanged();
            }
        }
    }
}
