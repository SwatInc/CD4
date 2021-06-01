using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.UiSpecificModels
{
    public class CinEpisodeAndReportIdModel
    {
        public string Cin { get; set; }
        public string EpisodeNumber { get; set; }
        public int ReportIndex { get; set; }
        public ReportActionModel Action { get; set; }
    }
}
