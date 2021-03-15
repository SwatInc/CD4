using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.ReportDispatch.SDK.Models
{
    public class SmtpSettingsModel
    {
        public bool EnableSsl { get; set; }
        public string HostUrl { get; set; }
        public int Port { get; set; }
        public string FromAddress { get; set; }
        public string ApiKeyOrPassword { get; set; }
    }
}
