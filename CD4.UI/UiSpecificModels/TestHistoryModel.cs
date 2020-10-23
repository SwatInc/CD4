using System;

namespace CD4.UI.UiSpecificModels
{
    public class TestHistoryModel
    {
        public string TestName { get; set; }
        public int Number { get; set; }
        public double Result { get; set; }
        public DateTimeOffset ResultDate { get; set; }
    }
}
