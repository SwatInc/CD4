﻿namespace CD4.DataLibrary.Models
{
    public class WorkListResultsModel
    {
        public int Id { get; set; }
        public int AnalysisRequestId { get; set; }
        public string Cin { get; set; }
        public string Test { get; set; }
        public string Result { get; set; }
        public string DataType { get; set; }
        public string Mask { get; set; }


    }
}