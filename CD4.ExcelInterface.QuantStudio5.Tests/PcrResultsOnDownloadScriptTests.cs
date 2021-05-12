using CD4.ExcelInterface.QuantStudio5.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CD4.ExcelInterface.QuantStudio5.Tests
{
    [TestClass]
    public class PcrResultsOnDownloadScriptTests
    {
        [DataTestMethod]
        [DataRow("41", "41", "41","35", "negative")] //case 1
        [DataRow("41", "41", "40","35", "negative")] //case 2
        [DataRow("40", "40", "40", "35", "positive")] //case 3
        [DataRow("40", "40", "41", "35", "")] //case 4
        [DataRow("40", "41", "40", "35", "")] //case 5
        [DataRow("41", "40", "40", "35", "")] //case 6
        [DataRow("40", "41", "41", "35", "")] //case 7
        [DataRow("41", "40", "41", "35", "")] //case 8
        [DataRow("41", "41", "41", "40", "")] //case 9
        [DataRow("41", "41", "Undetermined", "35", "negative")] //case 1
        [DataRow("Undetermined", "Undetermined", "40", "35", "negative")] //case 2
        [DataRow("40", "40", "40", "35", "positive")] //case 3
        [DataRow("40", "40", "Undetermined", "35", "")] //case 4
        [DataRow("40", "Undetermined", "40", "35", "")] //case 5
        [DataRow("Undetermined", "40", "40", "35", "")] //case 6
        [DataRow("40", "Undetermined", "Undetermined", "35", "")] //case 7
        [DataRow("Undetermined", "40", "Undetermined", "35", "")] //case 8
        [DataRow("Undetermined", "Undetermined", "Undetermined", "40", "")] //case 9
        public void GENEdania_AllTargetsAllCases_PositiveNegativeBlank(string orf1ab, string ngene, string egene,string ic, string actualResult)
        {
            var test = new List<MeasurementValues>();
            test.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = orf1ab });
            test.Add(new MeasurementValues() { TestCode = "N Gene", MeasurementValue = ngene });
            test.Add(new MeasurementValues() { TestCode = "E Gene", MeasurementValue = egene });
            test.Add(new MeasurementValues() { TestCode = "IC", MeasurementValue = ic });

            var script = new QuantStudio5OnDownloadScript();

            var interpretedResult = script.GetInterpretation(4, test);

            Assert.IsTrue(interpretedResult.ToLower().Contains(actualResult));

        }
    }
}
