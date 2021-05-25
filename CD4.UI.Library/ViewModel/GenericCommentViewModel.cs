using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Helpers;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.UI.Library.ViewModel
{
    public class GenericCommentViewModel : INotifyPropertyChanged, IGenericCommentViewModel
    {
        private Model.CommentsSelectionModel _selectedReason;
        private bool _isLoading;
        private bool _isOkEnabled;
        private int _reasonsCountDisplayed;
        private bool _isReasonsListEnabled;
        private IEnumerable<object> mappedResultComments;
        private bool isExistingSampleAndTestCommentsVisible;

        private int _selectedResultId { get; set; }
        private readonly ICommentsDataAccess _commentsDataAccess;
        private readonly IMapper _mapper;

        public event EventHandler<int> FetchReasons;
        public event EventHandler<CommentType> LoadExistingTestOrSamlpleOrPatientComments;
        public GenericCommentViewModel(ICommentsDataAccess commentsDataAccess, IMapper mapper)
        {
            _commentsDataAccess = commentsDataAccess;
            _mapper = mapper;
            Reasons = new BindingList<Model.CommentsSelectionModel>();
            ExistingResultComments = new BindingList<ResultCommentModel>();
            IsLoading = true;
            IsOkEnabled = false;
            FetchReasons += OnFetchReasons;
            LoadExistingTestOrSamlpleOrPatientComments += GenericCommentViewModel_LoadExistingTestOrSamlpleOrPatientComments;
        }

        private async void
            GenericCommentViewModel_LoadExistingTestOrSamlpleOrPatientComments
            (object sender, CommentType e)
        {
            //load result comment for the test/result
            if (e == CommentType.Result)
            {
                try
                {
                    var resultComments = await _commentsDataAccess.GetExistingResultComments(_selectedResultId);
                    var mappedResultComments = _mapper.Map<List<ResultCommentModel>>(resultComments);

                    DisplayExistingComments(mappedResultComments);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void DisplayExistingComments(List<ResultCommentModel> mappedResultComments)
        {
            ExistingResultComments.Clear();
            if (mappedResultComments is null) { return; }
            foreach (var item in mappedResultComments)
            {
                ExistingResultComments.Add(item);
            }
        }

        public void InitializeFetchReasonsAndComments(ICommentHelper commentHelper, int selectedResultId = -1)
        {
            _selectedResultId = selectedResultId;
            GenerateViewTitle(commentHelper);
            ShowSampleAndTestExistingComments(commentHelper);
            FetchReasons?.Invoke(this, (int)commentHelper.SelectedCommentType);
        }

        private void ShowSampleAndTestExistingComments(ICommentHelper commentHelper)
        {
            IsExistingSampleAndTestCommentsVisible = false;
            switch (commentHelper.SelectedCommentType)
            {
                case CommentType.Patient:
                    LoadExistingTestOrSamlpleOrPatientComments?.Invoke(this, CommentType.Patient);
                    break;
                case CommentType.Sample:
                    LoadExistingTestOrSamlpleOrPatientComments?.Invoke(this, CommentType.Sample);
                    break;
                case CommentType.Result:
                    IsExistingSampleAndTestCommentsVisible = true;
                    LoadExistingTestOrSamlpleOrPatientComments?.Invoke(this, CommentType.Result);
                    break;
                case CommentType.SampleRejection:
                    LoadExistingTestOrSamlpleOrPatientComments?.Invoke(this, CommentType.SampleRejection);
                    break;
                case CommentType.TestRejection:
                    LoadExistingTestOrSamlpleOrPatientComments?.Invoke(this, CommentType.TestRejection);
                    break;
                default:
                    break;
            }
        }

        private void GenerateViewTitle(ICommentHelper commentHelper)
        {
            ViewTitle = "";
            switch (commentHelper.SelectedCommentType)
            {
                case CommentType.Patient:
                    ViewTitle = "Select Patient Comment";
                    UserInstruction = "Please select the patient comment";
                    break;
                case CommentType.Sample:
                    ViewTitle = "Select Sample Comment";
                    UserInstruction = "Please select the sample comment";
                    break;
                case CommentType.Result:
                    ViewTitle = "Select Test / Result Comment";
                    UserInstruction = "Please select the test / result comment";
                    break;
                case CommentType.SampleRejection:
                    ViewTitle = "Select Sample Rejection Reason";
                    UserInstruction = "Please select a reason for sample rejection";
                    break;
                case CommentType.TestRejection:
                    ViewTitle = "Select Test Rejection Reason";
                    UserInstruction = "Please select a reason for test rejection";
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
        public BindingList<ResultCommentModel> ExistingResultComments { get; set; }
        public bool IsExistingSampleAndTestCommentsVisible
        {
            get => isExistingSampleAndTestCommentsVisible; set
            {
                isExistingSampleAndTestCommentsVisible = value;
                OnPropertyChanged();
            }
        }

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
        public string UserInstruction { get; set; }
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
