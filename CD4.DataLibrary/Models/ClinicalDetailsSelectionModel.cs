using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class ClinicalDetailsSelectionModel : ClinicalDetailsModel
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
