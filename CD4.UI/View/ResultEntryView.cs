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

namespace CD4.UI.View
{
    public partial class ResultEntryView : XtraForm
    {
        public ResultEntryView()
        {
            InitializeComponent();
            this.SizeChanged += OnSizeChangedAdjustSplitContainers;

            DemoData();
        }

        private void DemoData()
        {
            var clinicaldetails = new List<string>()
            {
                "asjdkjashd",
                "jhgsdahags",
                "jhgsdahags",
                "jhgsdahags",
                "jhgsdahags","jhgsdahags","jhgsdahags","jhgsdahags","jhgsdahags"
            };

            listBoxControl1.DataSource = clinicaldetails;
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