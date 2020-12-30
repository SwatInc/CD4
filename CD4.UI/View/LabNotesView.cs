using CD4.UI.Library.Model;
using CD4.UI.Library.ViewModel;
using System.ComponentModel;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class LabNotesView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILabNotesViewModel _viewModel;
        [Browsable(false)] public new int DialogResult { get; set; } // number of notes
        public LabNotesView(ILabNotesViewModel viewModel)
        {
            InitializeComponent();
            DialogResult = 0;
            _viewModel = viewModel;
            InitializeBinding();

            KeyUp += LabNotesView_KeyUp;
            FormClosing += LabNotesView_FormClosing;
            gridViewSampleNotes.CellValueChanged += GridViewSampleNotes_CellValueChanged;
            simpleButtonSave.Click += Save_Click;
        }

        /// <summary>
        /// This does not actually save anything. Just fullfils the purpose of making the grid view loose focus which then triggers
        /// a save on the current record. aditionally, this closes the view
        /// </summary>
        private void Save_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void GridViewSampleNotes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gridViewSampleNotes.PostEditor();
            gridViewSampleNotes.UpdateCurrentRow();
        }

        private void LabNotesView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = _viewModel.Notes.Count;
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
            if (e.KeyCode == Keys.F6)
            {
                //focuses the Save button so that selected grid row validates
                simpleButtonSave.Focus();
                Close(); // Close the dialog view
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

            progressPanelNotes.DataBindings.Add
                (new Binding("Visible", _viewModel, nameof(_viewModel.ProgressPanelVisible), false, DataSourceUpdateMode.OnPropertyChanged));
        }

        public void SetSampleNumber(string cin)
        {
            _viewModel.ViewName = cin;
        }
    }
}