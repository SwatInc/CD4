using CD4.ReportDispatch.SDK.Models;
using FluentEmail.Smtp;

namespace CD4.ReportDispatch.SDK.Services
{
    public class GmailSmptService : ISmtpService
    {
        public GmailSmptService()
        {
            SmtpSettings = new SmtpSettingsModel();

            SmtpSettings.HostUrl = "smtp.gmail.com";
            SmtpSettings.Port = 587;
            SmtpSettings.EnableSsl = true;
            SmtpSettings.ApiKeyOrPassword = "";
            SmtpSettings.FromAddress = "ibrahim.hucyn@gmail.com";
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
