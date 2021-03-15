using CD4.ReportDispatch.SDK.Models;
using FluentEmail.Smtp;

namespace CD4.ReportDispatch.SDK.Services
{
    public interface ISmtpService
    {
        SmtpSettingsModel SmtpSettings { get; set; }
        SmtpSender GetSmtpSender();
    }
}