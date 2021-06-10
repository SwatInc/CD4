using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.UiSpecificModels
{
    public class GridColumnModel
    {
        public string Caption { get; set; }
        public string FieldName { get; set; }
        public bool AllowEdit { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }
        public int VisibleIndex { get; set; }
        public int Width { get; set; }
        public bool IsSorted { get; set; }
        public bool IsAscending { get; set; }
    }
}
