using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI {
    public class CustomGridView : DevExpress.XtraGrid.Views.Grid.GridView {
        public CustomGridView() : this(null) { }
        public CustomGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid) {

        }
        protected override string ViewName { get { return "CustomGridView"; } }
        protected override BaseGridController CreateDataController() { return new CustomDataController(); }
    }
}
