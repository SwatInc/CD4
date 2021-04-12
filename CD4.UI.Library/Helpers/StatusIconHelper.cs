using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Helpers
{
    public static class StatusIconHelper
    {
        public static Image GetIcon(int statusIconId)
        {
            switch (statusIconId)
            {
                case 1:
                    return Properties.Resources.Requested;
                case 2:
                    return Properties.Resources.Sampled;
                case 3:
                    return Properties.Resources.Received;
                case 4:
                    return Properties.Resources.ToValidate;
                case 5:
                    return Properties.Resources.Validated;
                case 6:
                    return Properties.Resources.Processing;
                case 7:
                    return Properties.Resources.Rejected;
                default:
                    return Properties.Resources.Undefined;
            }
        }
    }
}
