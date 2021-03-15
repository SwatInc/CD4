using CD4.ReportDispatch.SDK.Models;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.ReportDispatch.SDK.Services
{
    public class PapercutSmtpService : ISmtpService
    {
        public PapercutSmtpService()
        {
            SmtpSettings = new SmtpSettingsModel();
            SmtpSettings.HostUrl = "localhost";
            SmtpSettings.Port = 25;
            SmtpSettings.EnableSsl = false;
            SmtpSettings.FromAddress = "ibrahim.hucyn@gmail.com";
        }
        public SmtpSettingsModel SmtpSettings { get; set; }

        public SmtpSender GetSmtpSender()
        {
            return new SmtpSender(() => new System.Net.Mail.SmtpClient(SmtpSettings.HostUrl)
            {
                EnableSsl = SmtpSettings.EnableSsl,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Port = SmtpSettings.Port,
            });
        }
    }
}
