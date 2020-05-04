using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class ResultEntryViewModel: INotifyPropertyChanged
    {

        #region Default Constructor
        public ResultEntryViewModel()
        {

        }

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public List<RequestSampleModel> RequestData { get; set; }
        public BindingList<ResultModel> ResultData { get; set; }
        public RequestSampleModel SelectedRequestData { get; set; }

    }
}
