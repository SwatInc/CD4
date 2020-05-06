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
            InitializeSearchAsync().ConfigureAwait(true);
        }

        private async Task InitializeSearchAsync()
        {
            if (_viewModel.PatientNameForSearch is null) this.Close();
            await _viewModel.SearchByPatientNameAsync();
        }

        private void InitializeDataBinding()
        {
            gridControlPatientSearchResults
                .DataSource = _viewModel.SearchResults;
        }
    }
}