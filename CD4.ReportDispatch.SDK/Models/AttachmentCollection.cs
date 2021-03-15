using FluentEmail.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CD4.ReportDispatch.SDK.Models
{
    public class AttachmentCollection
    {
        public AttachmentCollection()
        {
            Attachments = new List<Attachment>();
        }
        public List<Attachment> Attachments { get; set; }
        public long AttachmentSize { get; set; }
    }
}
