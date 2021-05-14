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
using System.Diagnostics;

namespace CD4.UI.View
{
    public partial class TestsView : XtraForm
    {
        private readonly ITestViewModel _viewModel;
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        public TestsView(ITestViewModel viewModel)
        {
            InitializeComponent();
            this._viewModel = viewModel;
            InitializeBinding();

            _viewModel.PushingMessages += _viewModel_PushingMessages;
            barButtonItemSave.ItemClick += _viewModel.SaveTest;
            barButtonItemNewTest.ItemClick += _viewModel.NewTest;
            gridViewTests.FocusedRowChanged += GridViewTests_FocusedRowChanged;
        }

        private void InitializeBinding()
        {
            _log.Info($"Initialize data binding in {nameof(CodifiedResultsView)}");
            gridControlCodifiedValues.DataSource = _viewModel.TestList;

            //Id
            this.textEditId.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Id)));

            //Discipline datasource 
            this.lookUpEditDiscipline.Properties.DataSource = _viewModel.DisciplineList;
            this.lookUpEditDiscipline.Properties.ValueMember = nameof(DisciplineModel.Id);
            this.lookUpEditDiscipline.Properties.DisplayMember = nameof(DisciplineModel.Discipline);
            //selected discipline
            this.lookUpEditDiscipline.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedDiscipline)));


            //description
            this.textEditDescription.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Description)));

            //selected sample type
            this.lookUpEditSampleType.Properties.DataSource = _viewModel.SampleTypesList;
            this.lookUpEditSampleType.Properties.ValueMember = nameof(SampleTypeModel.Id);
            this.lookUpEditSampleType.Properties.DisplayMember = nameof(SampleTypeModel.Description);
            //sample type datasource
            lookUpEditSampleType.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedSampleType)));

            //LookUpEdit TestDataType Datasource
            this.lookUpEditTestDataType.Properties.DataSource = _viewModel.ResultDataTypes;
            this.lookUpEditTestDataType.Properties.ValueMember = nameof(ResultDataTypeModel.Id);
            this.lookUpEditTestDataType.Properties.DisplayMember = nameof(ResultDataTypeModel.DataType);

            //LookUpEdit Selected Item
            this.lookUpEditTestDataType.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedDataType)));

            //Result Mask
            this.textEditResultMask.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Mask)));

            //unit
            this.lookUpEditUnit.Properties.DataSource = _viewModel.UnitList;
            this.lookUpEditUnit.Properties.ValueMember = nameof(UnitModel.Id);
            this.lookUpEditUnit.Properties.DisplayMember = nameof(UnitModel.Unit);
            //selected unit
            this.lookUpEditUnit.DataBindings.Add
                (new Binding("EditValue", _viewModel, nameof(_viewModel.SelectedUnit)));

            //code
            this.textEditCode.DataBindings.Add
                (new Binding("EditValue", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.Code)));

            //Is Reportable?
            this.checkEditIsReportable.DataBindings.Add
                (new Binding("Checked", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.IsReportable)));

            //Default Commented?
            this.checkEdit1.DataBindings.Add
                (new Binding("Checked", _viewModel.SelectedTest, nameof(_viewModel.SelectedTest.DefaultCommented)));

        }

        private void GridViewTests_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if row handle is -1, no row is focused.
            if (e.FocusedRowHandle == -1) return;

            _log.Info($"{nameof(gridViewTests)} row clicked.");
            var SelectedId = (int)gridViewTests.GetRowCellValue(e.FocusedRowHandle, "Id");

            _log.Info($"Selected codified Id: {SelectedId}");
            _viewModel.DisplaySelectedTest(SelectedId);

        }

        private void _viewModel_PushingMessages(object sender, string e)
        {
            XtraMessageBox.Show(e);
        }
    }
}