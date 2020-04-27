using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class CodifiedResultsViewModel : ICodifiedResultsViewModel
    {
        public CodifiedResultsViewModel()
        {
            CodifiedValuesList = new BindingList<CodifiedValueModel>();
        }
        public BindingList<CodifiedValueModel> CodifiedValuesList { get; set; }
        public CodifiedValueModel SelectedRow { get; set; }
    }
}
