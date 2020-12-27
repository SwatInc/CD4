using AutoMapper;
using CD4.DataLibrary.DataAccess;
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
        private readonly ISampleDataAccess _sampleDataAccess;
        private readonly IMapper _mapper;

        #endregion

        #region Events

        private event EventHandler<string> OnSampleSet;

        #endregion

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Default Constructor
        public LabNotesViewModel(AuthorizeDetailEventArgs authorizeDetail, ISampleDataAccess sampleDataAccess, IMapper mapper)
        {
            ViewName = "Sample Notes";
            _currentCin = null;
            _authorizeDetail = authorizeDetail;
            _sampleDataAccess = sampleDataAccess;
            _mapper = mapper;
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
                if (!string.IsNullOrEmpty(value?.Trim()))
                {
                    _currentCin = value.Trim();
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
                return;
            }
            if (!string.IsNullOrEmpty(NewNote.Trim()))
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
                NewNote = null;
            }
        }
            
        public void Reset()
        {
            Notes.ListChanged -= Notes_ListChanged;

            ViewName = "Sample Notes";
            _currentCin = null;
            Notes.Clear();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Loads all notes for the cin.
        /// DO NOT call this method directly, use the event OnSampleSet instead
        /// </summary>
        private async void GetNotesForSample(object sender, string cin)
        {
            try
            {
                var notes = await _sampleDataAccess.GetSampleNotesByCin(cin);
                var mappedNotes = _mapper.Map<List<SampleNotesModel>>(notes);
                DisplayNotes(mappedNotes);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void DisplayNotes(List<SampleNotesModel> notes)
        {
            if (notes is null) return;

            Notes.ListChanged -= Notes_ListChanged;
            Notes.Clear();
            foreach (var item in notes)
            {
                Notes.Add(item);
            }

            Notes.ListChanged += Notes_ListChanged;
        }

        private async Task UpdateSampleNotesAsync(SampleNotesModel notesModel)
        {
            try
            {
                await _sampleDataAccess.UpdateSampleNoteAttendedStatus(notesModel.Id, notesModel.IsAttended);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task AddNewNoteAsync(SampleNotesModel notesModel)
        {
            try
            {
                var mappedNotes = _mapper.Map<DataLibrary.Models.SampleNotesModel>(notesModel);
                var inserted = await _sampleDataAccess.InsertSampleNote(mappedNotes);

                OnSampleSet?.Invoke(this, _currentCin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void Notes_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.PropertyDescriptor?.Name == "IsAttended" && e.ListChangedType == ListChangedType.ItemChanged)
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
                try
                {
                    await AddNewNoteAsync(Notes[e.NewIndex]);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        #endregion
    }
}
