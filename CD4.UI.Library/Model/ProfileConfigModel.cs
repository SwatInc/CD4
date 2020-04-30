namespace CD4.UI.Library.Model
{
    public class ProfileConfigModel : ProfilesConfigurationBaseModel
    {
        private string profileDescription;

        public string ProfileDescription
        {
            get => profileDescription; set
            {
                if (profileDescription == value) return;
                profileDescription = value;
                OnPropertyChanged();
            }

        }

        public override string ToString()
        {
            return $"{profileDescription}";
        }
    }
}
