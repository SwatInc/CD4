using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.DataLibrary.Models
{
    public class TestsModel
    {
        public int Id { get; set; }
        public string Discipline { get; set; }
        public string Description { get; set; }
        public string SampleType { get; set; }

        public string ResultDataType { get; set; }
        /// <summary>
        /// The numeric zero ( 0 ) indcates a mandatory presence of zero if no digit is present a position
        /// The hash (#) means optional digit
        /// </summary>
        public string Mask { get; set; }
        public string Unit { get; set; }
        public string Code { get; set; }
        public bool IsReportable { get; set; }
        public bool DefaultCommented { get; set; }
        public int SortOrder { get; set; }
    }
}