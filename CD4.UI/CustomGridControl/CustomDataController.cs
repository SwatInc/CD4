using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI {
    public class CustomDataController : CurrencyDataController {
        protected override void BuildVisibleIndexes() {
            base.BuildVisibleIndexes();
            if(GroupedColumnCount == 0) return;
            int[] indexes = new int[VisibleIndexes.Count];
            VisibleIndexes.CopyTo(indexes, 0);
            VisibleIndexes.Clear();
            foreach(int rowHandle in indexes) {
                if(IsGroupRowHandle(rowHandle) && this.GetGroupRowValue(rowHandle)?.ToString() == string.Empty) {
                    ExpandRow(rowHandle);   //Auto expand  the empty group row
                    continue;
                }
                VisibleIndexes.Add(rowHandle);
            }
        }
    }
}
