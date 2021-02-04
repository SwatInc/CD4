using System;

namespace CD4.ExcelInterface.ViewModels
{
    public class LogModel
    {
        public LogModel()
        {
            Date = DateTimeOffset.Now;
        }
        public DateTimeOffset Date{ get; set; }
        public string Log { get; set; }
    }
}