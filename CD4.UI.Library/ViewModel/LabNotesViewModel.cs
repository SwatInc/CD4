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
    public class LabNotesViewModel : INotifyPropertyChanged, ILabNotesViewModel
    {

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        public LabNotesViewModel()
        {
            Notes = new BindingList<SampleNotesModel>();
            Notes.ListChanged += Notes_ListChanged;
        }

        private async void Notes_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor.Name == "IsAttended" && e.ListChangedType == ListChangedType.ItemChanged)
            {
                var changedNote = Notes[e.NewIndex];
                try
                {
                    await UpdateSampleNotesAsync(changedNote);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                await AddNewNoteAsync(Notes[e.NewIndex]);
            }
        }
        #region Public Properties
        public BindingList<SampleNotesModel> Notes { get; set; }
        #endregion

        #region public Methods
        public async Task GetNotesForSample(string cin)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private async Task UpdateSampleNotesAsync(SampleNotesModel notesModel)
        {
            throw new NotImplementedException();
        }

        private async Task AddNewNoteAsync(SampleNotesModel notesModel)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
