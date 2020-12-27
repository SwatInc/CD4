using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class SampleNotesModel : INotifyPropertyChanged
    {
        private bool isAttended;

        public int Id { get; set; }
        public string CIN { get; set; }
        public string Note { get; set; }
        public bool IsAttended
        {
            get => isAttended; set
            {
                isAttended = value;
                OnPropertyChanged();
            }
        }
        public string Username { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
