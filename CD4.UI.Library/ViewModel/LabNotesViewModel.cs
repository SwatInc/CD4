using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class LabNotesViewModel : INotifyPropertyChanged, ILabNotesViewModel
    {
        #region Private Properties

        private string _viewName;
        private string _newNote;
        private string _currentCin;
        private readonly AuthorizeDetailEventArgs _authorizeDetail;

        #endregion

        private event EventHandler<string> OnSampleSet;

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Default Constructor
        public LabNotesViewModel(AuthorizeDetailEventArgs authorizeDetail)
        {
            ViewName = "Sample Notes";
            _currentCin = null;
            _authorizeDetail = authorizeDetail;
            Notes = new BindingList<SampleNotesModel>();
            Notes.ListChanged += Notes_ListChanged;
            OnSampleSet += GetNotesForSample;
        }

        #endregion

        #region Public Properties
        public BindingList<SampleNotesModel> Notes { get; set; }
        public string ViewName
        {
            get => _viewName; set
            {
                if (_viewName == value) return;
                _viewName = $"Sample Notes for {value}";
                OnPropertyChanged();

                //load all notes for sample
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    OnSampleSet?.Invoke(this, value);
                }
            }
        }
        public string NewNote
        {
            get => _newNote; set
            {
                if (_newNote == value) return;
                _newNote = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region public Methods
        public void AddNewNote()
        {
            if (string.IsNullOrEmpty(_currentCin))
            {
                throw new Exception("Sample CIN needs to be set before adding a note");
            }
            if (string.IsNullOrEmpty(NewNote.Trim()))
            {
                Notes.Add(new SampleNotesModel()
                {
                    CIN = _currentCin,
                    Note = NewNote,
                    IsAttended = false,
                    Username = _authorizeDetail.Username,
                    UserId = _authorizeDetail.UserId,
                    TimeStamp = DateTimeOffset.Now
                });
            }
        }
        #endregion

        #region Private Methods
       
        /// <summary>
        /// Loads all notes for the cin.
        /// DO NOT call this method directly, use the event OnSampleSet instead
        /// </summary>
        private async void GetNotesForSample(object sender, string cin)
        {
            //Get the data from datalayer
            throw new NotImplementedException();
            //display the data on to the screen
            DisplayNotes(new List<SampleNotesModel>());
        }

        private void DisplayNotes(List<SampleNotesModel> notes)
        {
            if (notes is null) return;
            Notes.ListChanged -= Notes_ListChanged;
            //add data to display binding list
            Notes.ListChanged += Notes_ListChanged;
        }

        private async Task UpdateSampleNotesAsync(SampleNotesModel notesModel)
        {
            throw new NotImplementedException();
        }

        private async Task AddNewNoteAsync(SampleNotesModel notesModel)
        {
            throw new NotImplementedException();
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

        #endregion
    }
}
