using CD4.ReportDispatch.SDK.Models;
using FluentEmail.Smtp;

namespace CD4.ReportDispatch.SDK.Services
{
    public class OutlookSmptService : ISmtpService
    {
        public OutlookSmptService()
        {
            SmtpSettings = new SmtpSettingsModel();

            SmtpSettings.FromAddress = "ibrahim.hucyn@live.com";
            SmtpSettings.HostUrl = "smtp.office365.com";
            SmtpSettings.Port = 587;
            SmtpSettings.EnableSsl = true;
            SmtpSettings.ApiKeyOrPassword = "";
        }
        public SmtpSettingsModel SmtpSettings { get; set; }

        public SmtpSender GetSmtpSender()
        {
            return new SmtpSender(() => new System.Net.Mail.SmtpClient(SmtpSettings.HostUrl)
            {
                EnableSsl = SmtpSettings.EnableSsl,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(SmtpSettings.FromAddress, SmtpSettings.ApiKeyOrPassword),
                Port = SmtpSettings.Port,
            });
        }
    }
}
