using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class CodifiedResultsModel : INotifyPropertyChanged
    {
        private int? id;
        private string codifiedValue;

        public int? Id
        {
            get
            {
                return id;
            }

            set
            {
                if (id == value) return;
                id = value;
                OnPropertyChanged();
            }
        }
        public string CodifiedValue
        {
            get => codifiedValue; set
            {
                if (codifiedValue == value) return;
                codifiedValue = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override bool Equals(object obj)
        {
            var model = (CodifiedResultsModel)obj;

            if (model.id != this.id) return false;
            if (model.CodifiedValue != this.CodifiedValue) return false;

            return true;

        }
    }
}
