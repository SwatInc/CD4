﻿using System;
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
using DevExpress.Utils.DirectXPaint;
using CD4.UI.Library.Model;

namespace CD4.UI.View
{
    public partial class RejectionCommentView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRejectionCommentViewModel _viewModel;
        [Browsable(false)] public new int? DialogResult { get; set; }
        public RejectionCommentView(IRejectionCommentViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            InitializeBinding();

            simpleButtonOk.Click += SimpleButtonOk_Click;
            listBoxControlRejectionReasons.Paint += VerifyDisplayedItemsCount;
        }

        private void VerifyDisplayedItemsCount(object sender, EventArgs e)
        {
            _viewModel.ReasonsCountDisplayed = listBoxControlRejectionReasons.ItemCount;
            _viewModel.SelectedReason = (CommentsSelectionModel)listBoxControlRejectionReasons.SelectedItem;
        }

        private void SimpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = _viewModel.SelectedReason.Id;
            Close();
        }

        private void InitializeBinding()
        {
            listBoxControlRejectionReasons.DataSource = _viewModel.RejectionReasons;
            listBoxControlRejectionReasons.DisplayMember = nameof(CommentsSelectionModel.Comment);
            listBoxControlRejectionReasons.ValueMember = nameof(CommentsSelectionModel.Id);
            listBoxControlRejectionReasons.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.IsReasonsListEnabled)
                ,false, DataSourceUpdateMode.OnPropertyChanged));

            progressPanelLoadingReasons.DataBindings.Add(new Binding("Visible", _viewModel
                , nameof(_viewModel.IsLoading)));

            simpleButtonOk.DataBindings.Add(new Binding("Enabled", _viewModel, nameof(_viewModel.IsOkEnabled),
                false, DataSourceUpdateMode.OnPropertyChanged));


        }
    }
}