namespace CD4.UI.Library.Model
{
    public class ProfileConfigModel : ProfilesConfigurationBaseModel
    {
        private string profile;

        public string Profile
        {
            get => profile; set
            {
                if (profile == value) return;
                profile = value;
                OnPropertyChanged();
            }

        }

        public override string ToString()
        {
            return $"{profile}";
        }
    }
}
