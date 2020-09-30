using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class RejectionCommentViewModel : INotifyPropertyChanged, IRejectionCommentViewModel
    {
        private CommentsSelectionModel _selectedReason;
        private bool _isLoading;
        private bool _isOkEnabled;
        private int _reasonsCountDisplayed;
        private bool _isReasonsListEnabled;
        private readonly ICommentsDataAccess _commentsDataAccess;
        private readonly IMapper _mapper;

        public event EventHandler FetchReasons;
        public RejectionCommentViewModel(ICommentsDataAccess commentsDataAccess, IMapper mapper)
        {
            _commentsDataAccess = commentsDataAccess;
            _mapper = mapper;
            RejectionReasons = new BindingList<CommentsSelectionModel>();
            IsLoading = true;
            IsOkEnabled = false;
            FetchReasons += OnFetchReasons;
            InitializeFetchReasons();

        }

        private void InitializeFetchReasons()
        {
            FetchReasons?.Invoke(this, EventArgs.Empty);
        }

        private async void OnFetchReasons(object sender, EventArgs e)
        {
            //sample rejection CommentTypeId is 4
            var reasons = await _commentsDataAccess.GetAllCommentsByTypeId(4);
            var mappedResons = _mapper.Map<List<CommentsSelectionModel>>(reasons);

            RejectionReasons.Clear();
            foreach (var reason in mappedResons)
            {
                RejectionReasons.Add(reason);
            }

            IsLoading = false;
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<CommentsSelectionModel> RejectionReasons { get; set; }
        public CommentsSelectionModel SelectedReason
        {
            get => _selectedReason; set
            {
                if (_selectedReason == value) return;
                _selectedReason = value;
                HandleIsOkEnabled();
                OnPropertyChanged();

            }
        }

        /// <summary>
        /// handle Is OK button enabled flag
        /// </summary>
        private void HandleIsOkEnabled()
        {
            IsOkEnabled = SelectedReason != null ? SelectedReason.Id > 0 : false;
        }

        public bool IsLoading
        {
            get => _isLoading; set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
        public bool IsOkEnabled
        {
            get => _isOkEnabled; set
            {
                _isOkEnabled = value;
                OnPropertyChanged();
            }
        }

        public int ReasonsCountDisplayed
        {
            get => _reasonsCountDisplayed; set
            {
                if (_reasonsCountDisplayed == value) return;
                _reasonsCountDisplayed = value;
                IsReasonsListEnabled = _reasonsCountDisplayed > 0;
                OnPropertyChanged();
            }
        }

        public bool IsReasonsListEnabled
        {
            get => _isReasonsListEnabled; set
            {
                if (_isReasonsListEnabled == value) return;
                _isReasonsListEnabled = value;
                OnPropertyChanged();
            }
        }


    }
}
