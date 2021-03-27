using CD4.ExcelInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CD4.ExcelInterface.Tests
{
    [TestClass]
    public class PcrResultsOnDownloadScriptTests
    {
        [TestMethod]
        public void ZeesanKitTests_NoCtAllTargets_Blank()
        {

            var tests = new List<MeasurementValues>();
            tests.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            tests.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            tests.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            var script = new PcrResultsOnDownloadScript();

            var result = script.GetInterpretation(1, tests);

            Assert.IsTrue(string.IsNullOrEmpty(result.ToLower().Split('|')[1]));
        }

        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplifiedAndAllTargetsAboveRange_Blank()
        {

            var tests = new List<MeasurementValues>();
            tests.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" });
            tests.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" });
            tests.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" });

            var script = new PcrResultsOnDownloadScript();

            var result = script.GetInterpretation(1, tests);

            Assert.IsTrue(string.IsNullOrEmpty(result.ToLower().Split('|')[1]));
        }


        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplifiedAndOneTargetAboveRange_PositiveAndBlankAndBlank()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();

            //positive
            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "36" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "34" });
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" }); // above range

            //blank
            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "37" });
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" }); // above range
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            //blank
            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" }); // above range
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "35" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);

            Assert.IsTrue(result1.ToLower().Contains("positive"));
            Assert.IsTrue(string.IsNullOrEmpty(result2.ToLower().Split('|')[1]));
            Assert.IsTrue(string.IsNullOrEmpty(result3.ToLower().Split('|')[1]));
        }

        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplifiedAndTwoTargetsAboveRange_Negative()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();


            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "36" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" }); // above range
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" }); // above range

            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" }); // above range
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" }); // above range
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" }); // above range
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "35" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" }); // above range

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);

            Assert.IsTrue(string.IsNullOrEmpty(result1.ToLower().Split('|')[1]));
            Assert.IsTrue(result2.ToLower().Contains("negative"));
            Assert.IsTrue(string.IsNullOrEmpty(result3.ToLower().Split('|')[1]));
        }

        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplified_Positive()
        {

            var tests = new List<MeasurementValues>();
            tests.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "37" });
            tests.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "35" });
            tests.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            var script = new PcrResultsOnDownloadScript();

            var result = script.GetInterpretation(1, tests);

            Assert.IsTrue(result.ToLower().Contains("positive"));
        }


        [TestMethod]
        public void ZeesanKitTests_TwoTargetsNoCt_Negative()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();

            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "25" });

            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "25" });
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "25" });
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);

            Assert.IsTrue(result1.ToLower().Contains("negative"));
            Assert.IsTrue(string.IsNullOrEmpty(result2.ToLower().Split('|')[1]));
            Assert.IsTrue(string.IsNullOrEmpty(result3.ToLower().Split('|')[1]));
        }

        [TestMethod]
        public void ZeesanKitTests_OneTargetsNoCt_Negative()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();
            var test4 = new List<MeasurementValues>();

            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" });
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "25" });

            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "30" });
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "25" });
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "25" });
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "25" });

            test4.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "52" });//only n gene AMP
            test4.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "25" });
            test4.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);
            var result4 = script.GetInterpretation(1, test4); // not defined

            Assert.IsTrue(result1.ToLower().Contains("negative"));
            Assert.IsTrue(result2.ToLower().Contains("positive"));
            Assert.IsTrue(string.IsNullOrEmpty(result3.ToLower().Split('|')[1]));
        }

        [DataTestMethod]
        [DataRow("12","13", "14","positive")]
        [DataRow("37","37", "37","positive")]
        [DataRow("37","37", "42","rerun")]
        [DataRow("37", "37", "38", "rerun")]
        [DataRow("37","38", "37", "negative")]
        [DataRow("38","37", "37", "negative")]
        [DataRow("37","38", "38", "negative")]
        [DataRow("38","37", "38", "negative")]
        [DataRow("-","-", "38", "negative")]
        [DataRow("-", "-", "42", "negative")]
        [DataRow("-","-", "20", "negative")]
        [DataRow("-","-", "-", "invalid")]
        [DataRow("20","-", "-", "invalid")]
        [DataRow("20", "20", "-", "invalid")]
        public void PerkinEmler_AllTargets_PositiveNegativeRerunInvalid(string orf1ab, string ngene, string cy5, string actualResult)
        {
            var test = new List<MeasurementValues>();
            test.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = orf1ab });
            test.Add(new MeasurementValues() { TestCode = "N-Gene", MeasurementValue = ngene });
            test.Add(new MeasurementValues() { TestCode = "IC", MeasurementValue = cy5 });

            var script = new PcrResultsOnDownloadScript();

            var interpretedResult = script.GetInterpretation(3, test);

            Assert.IsTrue(interpretedResult.ToLower().Contains(actualResult));

        }
    }
    

}
