using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class ProfilesConfigurationBaseModel : INotifyPropertyChanged
    {
        private State state;
        private int id;
        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public int Id
        {
            get => id; set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }

        public State State
        {
            get => state; set
            {
                if (state == value) return;
                state = value;
                OnPropertyChanged();
            }
        }

    }
}
