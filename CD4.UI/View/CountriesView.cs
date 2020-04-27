using CD4.UI.Library.ViewModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class CountriesView : DevExpress.XtraEditors.XtraForm
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();
        private ICountryViewModel _viewModel { get; }

        public CountriesView(ICountryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            InitializeBinding();

            this.gridViewCodifiedResults.FocusedRowChanged += this.gridViewCodifiedResults_FocusedRowChanged;
            _viewModel.PushingMessages += _viewModel_PushingMessages;
            simpleButtonSave.Click += _viewModel.SaveCountry;
        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");

            gridControlCodifiedValues.DataSource = _viewModel.CountryList;

            this.textEditId.DataBindings.Add(new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Id)));
            this.textEditSelectedCountry.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedRow, nameof(_viewModel.SelectedRow.Country)));

        }

        private void gridViewCodifiedResults_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _log.Info($"{nameof(gridViewCodifiedResults)} row clicked.");
            var SelectedId = (int)gridViewCodifiedResults.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedCountryData(SelectedId);
        }
    }
}