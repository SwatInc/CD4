using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Helpers;
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
    public class GenericCommentViewModel : INotifyPropertyChanged, IGenericCommentViewModel
    {
        private Model.CommentsSelectionModel _selectedReason;
        private bool _isLoading;
        private bool _isOkEnabled;
        private int _reasonsCountDisplayed;
        private bool _isReasonsListEnabled;
        private readonly ICommentsDataAccess _commentsDataAccess;
        private readonly IMapper _mapper;

        public event EventHandler<int> FetchReasons;
        public GenericCommentViewModel(ICommentsDataAccess commentsDataAccess, IMapper mapper)
        {
            _commentsDataAccess = commentsDataAccess;
            _mapper = mapper;
            Reasons = new BindingList<Model.CommentsSelectionModel>();
            IsLoading = true;
            IsOkEnabled = false;
            FetchReasons += OnFetchReasons;

        }

        public void InitializeFetchReasons(ICommentHelper commentHelper)
        {
            GenerateViewTitle(commentHelper);
            FetchReasons?.Invoke(this, (int)commentHelper.SelectedCommentType);
        }

        private void GenerateViewTitle(ICommentHelper commentHelper)
        {
            ViewTitle = "";
            switch (commentHelper.SelectedCommentType)
            {
                case CommentType.Patient:
                    ViewTitle = "Select Patient Comment";
                    break;
                case CommentType.Sample:
                    ViewTitle = "Select Sample Comment";
                    break;
                case CommentType.Result:
                    ViewTitle = "Select Test / Result Comment";
                    break;
                case CommentType.SampleRejection:
                    ViewTitle = "Select Sample Rejection Reason";
                    break;
                case CommentType.TestRejection:
                    ViewTitle = "Select Test Rejection Reason";
                    break;
                default:
                    ViewTitle = "Select Reason";
                    break;
            }
        }

        public async void OnFetchReasons(object sender, int e)
        {
            Reasons.Clear();
            var reasons = await _commentsDataAccess.GetAllCommentsByTypeId(e);
            var mappedReasons = _mapper.Map<List<Model.CommentsSelectionModel>>(reasons);

            foreach (var item in mappedReasons)
            {
                Reasons.Add(item);
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

        public BindingList<Model.CommentsSelectionModel> Reasons { get; set; }

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

        public string ViewTitle { get; set; }

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
