using CD4.UI.Library.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Model
{
    public class NdaTrackingModel : INotifyPropertyChanged
    {
        private DateTimeOffset? reportedDate;
        private string calQcValidatedBy;
        private string analysedBy;
        private int statusIconId;

        public long InstituteAssignedPatientId { get; set; }
        public string Cin { get; set; }
        public int StatusIconId
        {
            get => statusIconId; set
            {
                statusIconId = value;
                SetIcon(value);
            }
        }

        private void SetIcon(int value)
        {
            Status = StatusIconHelper.GetIcon(value);
        }

        public Image Status { get; set; }
        public string AnalysedBy
        {
            get => analysedBy; set
            {
                analysedBy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnalysedBy)));
            }
        }
        public string CalQcValidatedBy
        {
            get => calQcValidatedBy; set
            {
                calQcValidatedBy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalQcValidatedBy)));

            }
        }
        public DateTimeOffset? CollectedDate { get; set; }
        public DateTimeOffset? ReceivedDate { get; set; }
        public DateTimeOffset? ValidatedDateTime { get; set; }
        public DateTimeOffset? ReportedDate
        {
            get => reportedDate; set
            {
                reportedDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReportedDate)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
