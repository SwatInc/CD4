using System;

namespace CD4.ExcelInterface.QuantStudio5.ViewModels
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