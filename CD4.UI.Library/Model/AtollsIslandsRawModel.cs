using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class AtollsIslandsRawModel : INotifyPropertyChanged
    {
        #region Private properties

        private int id;
        private string atollOrIslandName;
        private bool isAtoll;

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
        public string AtollOrIslandName
        {
            get => atollOrIslandName; set
            {
                if (atollOrIslandName == value) return;
                atollOrIslandName = value;
                OnPropertyChanged();
            }
        }
        public bool IsAtoll
        {
            get => isAtoll; set
            {
                if (isAtoll == value) return;
                isAtoll = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
