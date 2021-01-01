using AutoMapper;
using CD4.DataLibrary.DataAccess;
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
    public class RejectionCommentViewModel : INotifyPropertyChanged, IRejectionCommentViewModel
    {
        private Model.CommentsSelectionModel _selectedReason;
        private bool _isLoading;
        private bool _isOkEnabled;
        private int _reasonsCountDisplayed;
        private bool _isReasonsListEnabled;
        private RejectionReasonType _reasonType;
        private readonly ICommentsDataAccess _commentsDataAccess;
        private readonly IMapper _mapper;

        public event EventHandler FetchReasons;
        public RejectionCommentViewModel(ICommentsDataAccess commentsDataAccess, IMapper mapper)
        {
            _commentsDataAccess = commentsDataAccess;
            _mapper = mapper;
            RejectionReasons = new BindingList<Model.CommentsSelectionModel>();
            SampleRejectionCommentsList = new List<CommentsSelectionModel>();
            TestRejectionCommentsList = new List<CommentsSelectionModel>();
            IsLoading = true;
            IsOkEnabled = false;
            FetchReasons += OnFetchReasons;
            InitializeFetchReasons();

        }

        private void InitializeFetchReasons()
        {
            FetchReasons?.Invoke(this, EventArgs.Empty);
        }

        public async void OnFetchReasons(object sender, EventArgs e)
        {
            //sample rejection CommentTypeId is 4
            var reasons = await _commentsDataAccess.GetAllCommentsByTypeId(4);
            SampleRejectionCommentsList = _mapper.Map<List<Model.CommentsSelectionModel>>(reasons);

            //test rejection CommentTypeId is 5
            reasons = await _commentsDataAccess.GetAllCommentsByTypeId(5);
            TestRejectionCommentsList = _mapper.Map<List<Model.CommentsSelectionModel>>(reasons);

            IsLoading = false;
        }

        /// <summary>
        /// Assign display comments
        /// </summary>
        /// <param name="rejectionCommentType"></param>
        private void AssignComments(RejectionReasonType rejectionCommentType)
        {
            RejectionReasons.Clear();

            switch (rejectionCommentType)
            {
                case RejectionReasonType.Sample:

                    foreach (var reason in SampleRejectionCommentsList)
                    {
                        RejectionReasons.Add(reason);
                    }

                    break;
                case RejectionReasonType.Test:

                    foreach (var reason in TestRejectionCommentsList)
                    {
                        RejectionReasons.Add(reason);
                    }
                    break;

                default:
                    break;
            }
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public BindingList<Model.CommentsSelectionModel> RejectionReasons { get; set; }
        public List<Model.CommentsSelectionModel> SampleRejectionCommentsList { get; set; }
        public List<Model.CommentsSelectionModel> TestRejectionCommentsList { get; set; }

        public Model.CommentsSelectionModel SelectedReason
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

        public RejectionReasonType ReasonType
        {
            get => _reasonType; set
            {
                if (_reasonType == value) return;
                _reasonType = value;
                //when reason type changes assign appropriate comments
                AssignComments(_reasonType);
            }
        }
    }
}
