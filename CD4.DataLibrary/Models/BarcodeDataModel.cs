﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.Models
{
    public class BarcodeDataModel
    {
        public int Seq { get; set; }
        public string AccessionNumber { get; set; }
        public string NidPp { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Age { get; set; }
        public string Discipline { get; set; }
        public DateTimeOffset CollectionDate { get; set; }
    }
}
