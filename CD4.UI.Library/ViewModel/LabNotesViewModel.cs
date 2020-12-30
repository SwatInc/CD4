using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
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
        private bool progressPanelVisible;
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
        public bool ProgressPanelVisible
        {
            get => progressPanelVisible; set
            {
                progressPanelVisible = value;
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
            if (!string.IsNullOrEmpty(NewNote?.Trim()))
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

            Notes.ListChanged += Notes_ListChanged;
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
                ProgressPanelVisible = true;
                var notes = await _sampleDataAccess.GetSampleNotesByCin(cin);
                var mappedNotes = _mapper.Map<List<SampleNotesModel>>(notes);
                DisplayNotes(mappedNotes);
            }
            catch (Exception ex)
            {
                ProgressPanelVisible = false;
                XtraMessageBox.Show(ex.Message);
            }

            ProgressPanelVisible = false;

        }

        private void DisplayNotes(List<SampleNotesModel> notes)
        {
            if (notes is null) return;
            try
            {
                Notes.ListChanged -= Notes_ListChanged;
                Notes.Clear();
                foreach (var item in notes)
                {
                    Notes.Add(item);
                }
            }
            finally
            {
                Notes.ListChanged += Notes_ListChanged;
            }


        }

        private async Task UpdateSampleNotesAsync(SampleNotesModel notesModel)
        {
            try
            {
                ProgressPanelVisible = true;
                await _sampleDataAccess.UpdateSampleNoteAttendedStatus(notesModel.Id, notesModel.IsAttended);
            }
            catch (Exception)
            {
                ProgressPanelVisible = false;

                throw;
            }
            ProgressPanelVisible = false;

        }

        private async Task AddNewNoteAsync(SampleNotesModel notesModel)
        {
            try
            {
                ProgressPanelVisible = true;

                var mappedNotes = _mapper.Map<DataLibrary.Models.SampleNotesModel>(notesModel);
                var inserted = await _sampleDataAccess.InsertSampleNote(mappedNotes);

                OnSampleSet?.Invoke(this, _currentCin);
            }
            catch (Exception)
            {
                ProgressPanelVisible = false;

                throw;
            }
            ProgressPanelVisible = false;

        }

        private async void Notes_ListChanged(object sender, ListChangedEventArgs e)
        {
            ProgressPanelVisible = true;

            if (e.PropertyDescriptor?.Name == "IsAttended" && e.ListChangedType == ListChangedType.ItemChanged)
            {
                var changedNote = Notes[e.NewIndex];
                try
                {
                    await UpdateSampleNotesAsync(changedNote);
                }
                catch (Exception ex)
                {
                    ProgressPanelVisible = false;

                    XtraMessageBox.Show($"An error occured while setting attended status\n{ex.Message}");
                }
            }

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                try
                {
                    await AddNewNoteAsync(Notes[e.NewIndex]);
                }
                catch (Exception ex)
                {
                    ProgressPanelVisible = true;

                    if (ex.Message.Contains("FOREIGN KEY"))
                    {
                        XtraMessageBox.Show($"An error occured while adding the note to sample. Please make sure that the order is confirmed.\n{ex.Message}");
                    }
                    else
                    {
                        XtraMessageBox.Show($"An error occured while adding the note to sample.\n{ex.Message}");
                    }
                    if(Notes.Count > 0) { Notes.RemoveAt(e.NewIndex); }
                }
            }
            ProgressPanelVisible = false;

        }

        #endregion
    }
}
