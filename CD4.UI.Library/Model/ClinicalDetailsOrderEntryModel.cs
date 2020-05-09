using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class ClinicalDetailsOrderEntryModel : ClinicalDetailsModel
    {
        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected; set
            {
                if (isSelected == value) return;
                isSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
