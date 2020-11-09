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
    public partial class AcceptSampleView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAcceptSampleViewModel _viewModel;

        public AcceptSampleView(IAcceptSampleViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            InitializeBinding();
        }

        private void InitializeBinding()
        {
            textEditAcceptBarcode.DataBindings.Add("Text", _viewModel, nameof(_viewModel.AcceptBarcode)
                , false, DataSourceUpdateMode.OnPropertyChanged);
            labelNoOfBarcodesRead.DataBindings.Add("Text", _viewModel, nameof(_viewModel.NoOfBarcodeReadDisplay));
            labelNotification.DataBindings.Add("Text", _viewModel, nameof(_viewModel.SuccessfullMessage));
            progressPanelAccept.DataBindings.Add("Visible", _viewModel, nameof(_viewModel.IsProcessing));
        }

        private async void AcceptSampleView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !_viewModel.IsProcessing)
            {
                try
                {
                    await _viewModel.AcceptBarcodeAsync();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occured while accepting the barcode: {_viewModel.AcceptBarcode}.\n{ex.Message}");
                }

            }
        }
    }
}