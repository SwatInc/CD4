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
using DevExpress.XtraGrid.Views.Base;
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        private readonly IResultEntryViewModel _viewModel;

        public ResultEntryView(IResultEntryViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            SizeChanged += OnSizeChangedAdjustSplitContainers;
            gridViewSamples.FocusedRowChanged += SelectedSampleChanged;
        }

        private void SelectedSampleChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var selectedSample = (RequestSampleModel)gridViewSamples.GetRow(e.FocusedRowHandle);
        }

        private void InitializeBinding()
        {
            #region Samples
            gridControlSamples.DataSource = _viewModel.RequestData;
            #endregion

            #region Tests / Result data
            gridControlTests.DataSource = _viewModel.SelectedResultData;
            #endregion

            #region Selected Samples data
            
            #endregion
        }

        private void OnSizeChangedAdjustSplitContainers(object sender, EventArgs e)
        {
            //set splitter for adjusting Top (patient) panel
            splitContainerControlPatient.SplitterPosition = 90;

            //set splitter for adjusting functions panel
            var height = this.splitContainerControlFunctions.Size.Height;
            splitContainerControlFunctions.SplitterPosition = (int)((decimal)height - 90m);
        }

    }
}