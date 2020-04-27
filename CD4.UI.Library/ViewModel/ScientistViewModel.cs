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
    public class ScientistViewModel : INotifyPropertyChanged, IScientistViewModel
    {
        public event EventHandler<String> PushingLogs;
        public event EventHandler<string> PushingMessages;

        public ScientistViewModel()
        {
            this.ScientistList = new BindingList<ScientistModel>();
            this.SelectedRow = new ScientistModel();

            InitializeDemoData();

        }

        private void InitializeDemoData()
        {
            var scientist1 = new ScientistModel() { Id = 1, Scientist = "Jabir Ibn Hayyam" };
            var scientist2 = new ScientistModel() { Id = 2, Scientist = "Ibn Sina" };

            this.ScientistList.Add(scientist1);
            this.ScientistList.Add(scientist2);
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<ScientistModel> ScientistList { get; set; }
        public ScientistModel SelectedRow { get; set; }

        public void DisplaySelectedData(int selectedId)
        {
            var selectedRow = this.ScientistList.SingleOrDefault(c => c.Id == selectedId);
            this.SelectedRow.Id = selectedRow.Id;
            this.SelectedRow.Scientist = selectedRow.Scientist;
        }

        public void SaveScientist(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedRow.Scientist))
            {
                PushingMessages?.Invoke(this, "Cannot save a blank!");
                return;
            }
            if (IsDublicatedSubmitted(SelectedRow.Scientist))
            {
                PushingMessages?.Invoke(this, $"{SelectedRow.Scientist} is already in the system");
                return;
            }

            //Save from here.
            PushingMessages?.Invoke(this, $"{SelectedRow.Scientist} is saved.");

        }

        private bool IsDublicatedSubmitted(string scientist)
        {
            var Search = ScientistList.SingleOrDefault(p => p.Scientist == scientist);
            if (Search is null) return false;
            return true;

        }
    }
}
