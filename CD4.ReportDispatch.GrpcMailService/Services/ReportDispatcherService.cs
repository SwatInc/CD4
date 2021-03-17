using CD4.ReportDispatch.SDK.Models;
using CD4.ReportDispatch.SDK.Services;
using FluentEmail.Core;
using FluentEmail.Razor;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CD4.ReportDispatch.GrpcMailService.Services
{
    public class ReportDispatcherService : ReportDispatcher.ReportDispatcherBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly ISmtpService _smtpService;

        public ReportDispatcherService(ILogger<ReportDispatcherService> logger,
            IConfiguration configuration,
            ISmtpService smtpService)
        {
            _logger = logger;
            _configuration = configuration;
            _smtpService = smtpService;
        }
        public override async Task<Response> Dispatch
            (DispatchRequestModel request, ServerCallContext context)
        {
            var a  = _configuration.GetValue<string>("Logging:LogLevel:Default");
            _logger.LogInformation("Get reports for all sample numbers,");
            _logger.LogWarning(a);

            var sids = "";
            foreach (var sid in request.SampleIds)
            {
                sids += $"\n{sid}";
            }
            _logger.LogInformation(sids);
            _logger.LogInformation($"\nEmail Template: {request.TemplateName} \nTo Email: {request.ToEmail}");


            var mailModel = new EmailModel()
            {
                Subject = $"CD4 LIMS: COVID-19 PCR Test Results {DateTime.Today:dd.MM.yyyy}",
                ToAddress = "ibrahim.hucyn@gmail.com",
                ToDisplayName = "Ibrahim",
                Template = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "medlab_reportdispatch_template.html"))
            };
            try
            {
                await ExecuteAsync(_smtpService, await (new AttachmentService()).GetAttachmentsAsync(), mailModel);
                return new Response() { Status = 200, Message = "All OK" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Response() { Status = 500, Message = ex.Message };
            }
            //await ExecuteAsync(new OutlookSmptService(), await (new AttachmentService()).GetAttachmentsAsync(), mailModel);

            //uncomment to send via gmail. have to have the API key in GmailSmptService class
            //await ExecuteAsync(new GmailSmptService(), await (new AttachmentService()).GetAttachmentsAsync(), mailModel);

            
        }

        public async Task ExecuteAsync(ISmtpService smtpService, AttachmentCollection attachments, EmailModel emailModel)
        {
            Email.DefaultSender = smtpService.GetSmtpSender();
            Email.DefaultRenderer = new RazorRenderer();

            var maxMailSize = 25;

            if ((attachments.AttachmentSize / (1024 * 1024)) < maxMailSize)
            {
                try
                {
                    await Task.Delay(3000);
                    var email = await Email
                        .From(smtpService.SmtpSettings.FromAddress, "swatincadmin")
                        .To(emailModel.ToAddress, emailModel.ToDisplayName)
                        .Subject(emailModel.Subject)
                        .Attach(attachments.Attachments)
                        .UsingTemplate(emailModel.Template, emailModel.TemplateModel, true)
                        .SendAsync();

                    //close all filestreams
                    foreach (var item in attachments.Attachments)
                    {
                        item.Data.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                throw new Exception($"Cannot mail since the mail size exceeds maximum allowed {maxMailSize} MB");
            }

        }
    }
}
