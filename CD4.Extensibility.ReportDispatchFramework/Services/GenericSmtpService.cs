using CD4.Extensibility.ReportDispatchFramework.Models;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.Extensibility.ReportDispatchFramework.Services
{
    /// <summary>
    /// This class allows the user to change SMTP variable values to send with different mail providers
    /// </summary>
    public class GenericSmtpService : ISmtpService
    {
        public GenericSmtpService()
        {
            Initialize();
        }

        private void Initialize()
        {
            SmtpSettings = new SmtpSettingsModel();
            //host url
            //port
            //ssl enabled
            //api key / password
            //from address

        }

        public SmtpSettingsModel SmtpSettings { get; set; }

        /// <summary>
        /// Constructs an SMTP sender
        /// </summary>
        /// <returns>return FluentEmail.Smtp.SmtpSender</returns>
        public SmtpSender GetSmtpSender()
        {
            var smtpClient = new System.Net.Mail.SmtpClient(SmtpSettings.HostUrl)
            {
                EnableSsl = SmtpSettings.EnableSsl,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Port = SmtpSettings.Port,
            };

            if (!string.IsNullOrEmpty(SmtpSettings.ApiKeyOrPassword))
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpSettings.FromAddress, SmtpSettings.ApiKeyOrPassword);
            }

            return new SmtpSender(smtpClient);
        }
    }
}
