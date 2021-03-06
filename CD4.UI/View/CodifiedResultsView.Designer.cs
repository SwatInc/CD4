﻿namespace CD4.UI.View
{
    partial class CodifiedResultsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodifiedResultsView));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlCodifiedValues = new DevExpress.XtraGrid.GridControl();
            this.gridViewCodifiedResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.textEditCodfiedValue = new DevExpress.XtraEditors.TextEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCodfiedValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gridControlCodifiedValues);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.simpleButtonSave);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditId);
            this.splitContainerControl.Panel2.Controls.Add(this.textEditCodfiedValue);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(596, 268);
            this.splitContainerControl.SplitterPosition = 368;
            this.splitContainerControl.TabIndex = 0;
            // 
            // gridControlCodifiedValues
            // 
            this.gridControlCodifiedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCodifiedValues.Location = new System.Drawing.Point(0, 0);
            this.gridControlCodifiedValues.MainView = this.gridViewCodifiedResults;
            this.gridControlCodifiedValues.Name = "gridControlCodifiedValues";
            this.gridControlCodifiedValues.Size = new System.Drawing.Size(368, 268);
            this.gridControlCodifiedValues.TabIndex = 0;
            this.gridControlCodifiedValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCodifiedResults});
            // 
            // gridViewCodifiedResults
            // 
            this.gridViewCodifiedResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnCode});
            this.gridViewCodifiedResults.GridControl = this.gridControlCodifiedValues;
            this.gridViewCodifiedResults.Name = "gridViewCodifiedResults";
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 58;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Codified Value";
            this.gridColumnCode.FieldName = "CodifiedValue";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 1;
            this.gridColumnCode.Width = 321;
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSave.ImageOptions.SvgImage")));
            this.simpleButtonSave.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.simpleButtonSave.Location = new System.Drawing.Point(20, 215);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(173, 34);
            this.simpleButtonSave.TabIndex = 3;
            this.simpleButtonSave.ToolTip = "Save Record";
            // 
            // textEditId
            // 
            this.textEditId.Enabled = false;
            this.textEditId.Location = new System.Drawing.Point(20, 20);
            this.textEditId.Name = "textEditId";
            this.textEditId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.textEditId.Properties.NullText = "Id";
            this.textEditId.Properties.NullValuePrompt = "Id";
            this.textEditId.Size = new System.Drawing.Size(173, 20);
            this.textEditId.TabIndex = 1;
            // 
            // textEditCodfiedValue
            // 
            this.textEditCodfiedValue.Location = new System.Drawing.Point(20, 189);
            this.textEditCodfiedValue.Name = "textEditCodfiedValue";
            this.textEditCodfiedValue.Properties.NullText = "Please enter codified value";
            this.textEditCodfiedValue.Properties.NullValuePrompt = "Please enter codified value";
            this.textEditCodfiedValue.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditCodfiedValue.Properties.ValidateOnEnterKey = true;
            this.textEditCodfiedValue.Size = new System.Drawing.Size(173, 20);
            this.textEditCodfiedValue.TabIndex = 0;
            // 
            // CodifiedResultsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 268);
            this.Controls.Add(this.splitContainerControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodifiedResultsView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Codified Results";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCodifiedValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCodifiedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCodfiedValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraGrid.GridControl gridControlCodifiedValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCodifiedResults;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.TextEdit textEditCodfiedValue;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}