using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CD4.UI.Library.ViewModel;
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class PatientSearchResultsView : XtraForm
    {
        private readonly IPatientSearchResultsViewModel _viewModel;

        public PatientSearchResultsView(IPatientSearchResultsViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeDataBinding();

            _viewModel.PatientSelected += OnPatientSelected;
            gridViewPatientSearchResults.DoubleClick += gridViewPatientSearchResults_DoubleClick;


            InitializeSearchAsync().ConfigureAwait(true);

        }

        private void OnPatientSelected(object sender, PatientModel e)
        {
            Close();
        }

        private void gridViewPatientSearchResults_DoubleClick(object sender, EventArgs e)
        {
            var selectedRowHandles = gridViewPatientSearchResults.GetSelectedRows();
            if (selectedRowHandles.Length == 0) return;

            var row = (PatientModel)gridViewPatientSearchResults.GetRow(selectedRowHandles[0]);
           _viewModel.UserSelectedPatient(row);
        }

        private async Task InitializeSearchAsync()
        {
            if (_viewModel.SearchTerm is null) this.Close();
            await _viewModel.SearchByPatientNameAsync();
        }

        private void InitializeDataBinding()
        {
            gridControlPatientSearchResults
                .DataSource = _viewModel.SearchResults;
        }
    }
}