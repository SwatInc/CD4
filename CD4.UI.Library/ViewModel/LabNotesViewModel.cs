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

            OnSampleSet += GetNotesForSample;
            Notes.ListChanged += Notes_ListChanged;

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
        public async Task AddNewNoteAsync()
        {
            if (string.IsNullOrEmpty(_currentCin))
            {
                return;
            }
            if (!string.IsNullOrEmpty(NewNote?.Trim()))
            {
                var note = new SampleNotesModel()
                {
                    CIN = _currentCin,
                    Note = NewNote,
                    IsAttended = false,
                    Username = _authorizeDetail.Username,
                    UserId = _authorizeDetail.UserId,
                    TimeStamp = DateTimeOffset.Now
                };
                NewNote = null;

                try
                {
                    await AddNewNoteAsync(note);
                }
                catch (Exception ex)
                {

                    if (ex.Message.Contains("FOREIGN KEY"))
                    {
                        XtraMessageBox.Show($"An error occured while adding the note to sample. Please make sure that the order is confirmed.\n{ex.Message}");
                    }
                    else
                    {
                        XtraMessageBox.Show($"An error occured while adding the note to sample.\n{ex.Message}");
                    }
                }
            }
        }

        public void Reset()
        {
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
                progressPanelVisible = true;
                var notes = await _sampleDataAccess.GetSampleNotesByCin(cin);
                var mappedNotes = _mapper.Map<List<SampleNotesModel>>(notes);
                DisplayNotes(mappedNotes);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            finally
            {
                progressPanelVisible = false;
            }
        }

        private void DisplayNotes(List<SampleNotesModel> notes)
        {
            if (notes is null) return;

            Notes.Clear();
            foreach (var item in notes)
            {
                Notes.Add(item);
            }
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
                progressPanelVisible = true;
                var mappedNotes = _mapper.Map<DataLibrary.Models.SampleNotesModel>(notesModel);
                var inserted = await _sampleDataAccess.InsertSampleNote(mappedNotes);

                notesModel.Id = inserted.Id;
                notesModel.TimeStamp = inserted.TimeStamp;

                Notes.Add(notesModel);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Cannot load sample notes for {notesModel.CIN}.\n{ex.Message}");
            }
            finally
            {
                progressPanelVisible = false;
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
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occured while setting attended status\n{ex.Message}");
                }
            }

        }

        #endregion
    }
}
