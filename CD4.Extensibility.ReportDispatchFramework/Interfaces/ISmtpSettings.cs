using CD4.Extensibility.ReportDispatchFramework.Models;
using FluentEmail.Smtp;

namespace CD4.Extensibility.ReportDispatchFramework.Services
{
    public interface ISmtpService
    {
        SmtpSettingsModel SmtpSettings { get; set; }
        SmtpSender GetSmtpSender();
    }
}