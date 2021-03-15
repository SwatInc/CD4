using CD4.ReportDispatch.SDK.Models;
using FluentEmail.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CD4.ReportDispatch.SDK.Services
{
    public class AttachmentService
    {
        #region Default Constructor
        public AttachmentService()
        {
            ServiceModel = new AttachmentModel();
            Initialize();
        }

        #endregion

        #region Public Properties
        public AttachmentModel ServiceModel { get; set; }
        #endregion

        #region Public Methods
        public async Task<AttachmentCollection> GetAttachmentsAsync()
        {
            var directoryInfor = new DirectoryInfo(ServiceModel.Directory);
            var fileInfos = await Task.Run(() => directoryInfor.GetFiles(ServiceModel.Extension)); //Getting files

            List<Attachment> attachments = new List<Attachment>();

            var attachmentSize = 0L;
            foreach (var file in fileInfos)
            {
                attachmentSize += file.Length;
                attachments.Add(new Attachment()
                {
                    ContentId = Guid.NewGuid().ToString(),
                    ContentType = ServiceModel.ContentType,
                    Filename = file.Name,
                    IsInline = false,
                    Data = new FileStream(file.FullName, FileMode.Open)
                });
            }

            return new AttachmentCollection() { Attachments = attachments, AttachmentSize = attachmentSize };
        }

        #endregion

        #region Private Methods
        private void Initialize()
        {
            //get the information from somewhere
            ServiceModel.Directory = @"C:\Export";
            ServiceModel.Extension = "*.pdf";
            ServiceModel.ContentType = "application/pdf";
        }
        #endregion

    }
}
