using CD4.ExcelInterface.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CD4.ExcelInterface.Tests
{
    [TestClass]
    public class PcrResultsOnDownloadScriptTests
    {
        [TestMethod]
        public void ZeesanKitTests_NoCtAllTargets_Negative()
        {

            var tests = new List<MeasurementValues>();
            tests.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            tests.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            tests.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            var script = new PcrResultsOnDownloadScript();

            var result = script.GetInterpretation(1, tests);

            Assert.IsTrue(result.ToLower().Contains("negative"));
        }

        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplifiedAndAllTargetsAboveRange_Negative()
        {

            var tests = new List<MeasurementValues>();
            tests.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" });
            tests.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" });
            tests.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" });

            var script = new PcrResultsOnDownloadScript();

            var result = script.GetInterpretation(1, tests);

            Assert.IsTrue(result.ToLower().Contains("negative"));
        }


        [TestMethod]
        public void ZeesanKitTests_AllTargetsAmplifiedAndOneTargetAboveRange_Negative()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();

            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "36" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "34" });
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "35" }); // above range

            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "37" });
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" }); // above range
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "38" }); // above range
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "35" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "34" });

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);

            Assert.IsTrue(result1.ToLower().Contains("negative"));
            Assert.IsTrue(result2.ToLower().Contains("negative"));
            Assert.IsTrue(result3.ToLower().Contains("negative"));
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

            Assert.IsTrue(result1.ToLower().Contains("negative"));
            Assert.IsTrue(result2.ToLower().Contains("negative"));
            Assert.IsTrue(result3.ToLower().Contains("negative"));
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
            Assert.IsTrue(result2.ToLower().Contains("negative"));
            Assert.IsTrue(result3.ToLower().Contains("negative"));
        }

        [TestMethod]
        public void ZeesanKitTests_OneTargetsNoCt_Negative()
        {

            var test1 = new List<MeasurementValues>();
            var test2 = new List<MeasurementValues>();
            var test3 = new List<MeasurementValues>();

            test1.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "-" });
            test1.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "36" });
            test1.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "25" });

            test2.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "52" });
            test2.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "25" });
            test2.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "-" });

            test3.Add(new MeasurementValues() { TestCode = "ORF1ab", MeasurementValue = "25" });
            test3.Add(new MeasurementValues() { TestCode = "N gene", MeasurementValue = "-" });
            test3.Add(new MeasurementValues() { TestCode = "SUC2", MeasurementValue = "25" });

            var script = new PcrResultsOnDownloadScript();

            var result1 = script.GetInterpretation(1, test1);
            var result2 = script.GetInterpretation(1, test2);
            var result3 = script.GetInterpretation(1, test3);

            Assert.IsTrue(result1.ToLower().Contains("negative"));
            Assert.IsTrue(result2.ToLower().Contains("negative"));
            Assert.IsTrue(result3.ToLower().Contains("negative"));
        }
    }
    

}
