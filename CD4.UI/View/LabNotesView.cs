using CD4.UI.Library.Model;
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
            FormClosing += LabNotesView_FormClosing;
            gridViewSampleNotes.CellValueChanged += GridViewSampleNotes_CellValueChanged;
        }

        private void GridViewSampleNotes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewSampleNotes.PostEditor();
            gridViewSampleNotes.UpdateCurrentRow();
        }

        private void LabNotesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _viewModel.Reset();
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
            //Binding the grid
            gridControlSampleNotes.DataSource = _viewModel.Notes;
        }

        public void SetSampleNumber(string cin)
        {
            _viewModel.ViewName = cin;
        }
    }
}