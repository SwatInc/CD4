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
    public partial class OrderEntryView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IOrderEntryViewModel _viewModel;

        public OrderEntryView(IOrderEntryViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            #region Request Data
            //Cin
            textEditCin.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.Cin ),false,
                DataSourceUpdateMode.OnPropertyChanged));

            //Site and Selected Site
            lookUpEditSite.Properties.DataSource = _viewModel.Sites;
            lookUpEditSite.Properties.DisplayMember = nameof(SitesModel.Site);
            lookUpEditSite.Properties.ValueMember =nameof(SitesModel.Id);
            lookUpEditSite.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedSiteId)));

            //Collection Date
            dateEditCollectedDate.DataBindings.Add
                ("EditValue", _viewModel, nameof(_viewModel.SampleCollectionDate), true,
                DataSourceUpdateMode.OnPropertyChanged);

            //Request Date
            dateEditSampleReceived.DataBindings.Add
                ("EditValue", _viewModel, nameof(_viewModel.SampleReceivedDate),true,
                DataSourceUpdateMode.OnPropertyChanged);
            #endregion


        }
    }
}