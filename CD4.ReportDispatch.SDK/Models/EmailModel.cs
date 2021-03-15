using System;
using System.Collections.Generic;

namespace CD4.ReportDispatch.SDK.Models
{
    public class EmailModel
    {
        public EmailModel()
        {
            //get this at another place... later
            TemplateModel = new { Name = "Bob" };
        }
        public string ToAddress { get; set; }
        public string ToDisplayName { get; set; }
        public string Subject { get; set; }
        public string Template { get; set; }
        public dynamic TemplateModel { get; set; }
    }
}
