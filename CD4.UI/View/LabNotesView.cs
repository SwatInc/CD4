using CD4.UI.Library.ViewModel;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class LabNotesView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILabNotesViewModel _viewModel;

        public LabNotesView(ILabNotesViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();
            KeyUp += LabNotesView_KeyUp;
        }

        private void LabNotesView_KeyUp(object sender, KeyEventArgs e)
        {
            //if enter is pressed...
            if (e.KeyCode == Keys.Enter)
            {
                //Call view model to add new note..., will model will validate the input.
                _viewModel.AddNewNote();
            }
        }

        private void InitializeBinding()
        {
            //binding view name / title
            DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.ViewName),
                false, DataSourceUpdateMode.OnPropertyChanged));
            //bind TextEditSampleNote
            textEditSampleNote.DataBindings.Add(new Binding("Text", _viewModel, nameof(_viewModel.NewNote),
                false, DataSourceUpdateMode.OnPropertyChanged));
        }

        public void SetSampleNumber(string cin)
        {
            _viewModel.ViewName = cin;
        }
    }
}