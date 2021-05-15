using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CD4.DataLibrary.Models
{
    public class TestsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ResultDataType { get; set; }
        /// <summary>
        /// The numeric zero ( 0 ) indcates a mandatory presence of zero if no digit is present a position
        /// The hash (#) means optional digit
        /// </summary>
        public string Mask { get; set; }
        public bool IsReportable { get; set; }

    }
}