
using System.Collections.Generic;

public class QuantStudio5OnDownloadScript
{
    public List<dynamic> Kits { get; set; }

    public QuantStudio5OnDownloadScript()
    {
        Kits = new List<dynamic>();
        Kits.Add(new { Id = 1, Kit = "Zeesan" });
        Kits.Add(new { Id = 2, Kit = "LabGun" });
        Kits.Add(new { Id = 3, Kit = "PerkinElmer" });
    }
    public bool IsScriptLoaded()
    {
        return true;
    }

    public List<dynamic> GetKitNames()
    {

        return Kits;
    }
    public string GetInterpretation(int kit, dynamic measurements)
    {

        foreach (var item in Kits)
        {

            if (item.Id == kit)
            {
                if (item.Kit == "Zeesan")
                {
                    return ZeesanResultInterPretation(measurements);
                }
                if (item.Kit == "PerkinElmer")
                {
                    return PerkinElmerResultInterPretation(measurements);
                }
                if (item.Kit == "LabGun")
                {
                    return LabGunResultInterPretation(measurements);
                }
            }
        }

        return "";
    }

    public string GetInterpretationTestCode()
    {
        return "SARS-CoV-2";
    }

    private string ZeesanResultInterPretation(dynamic measurements)
    {
        decimal orf1abInt;
        decimal ngeneInt;
        decimal suc2Int;

        string ofr1ab = "";
        string ngene = "";
        string suc2 = "";

        var orf1abPresent = false;
        var ngenePresent = false;
        var sucPresent = false;

        #region Set genes values received from parameters

        foreach (var item in measurements)
        {
            if (item.TestCode == "ORF1ab")
            {
                ofr1ab = item.MeasurementValue;
                orf1abPresent = true;
            }
            if (item.TestCode == "N gene")
            {
                ngene = item.MeasurementValue;
                ngenePresent = true;
            }
            if (item.TestCode == "SUC2")
            {
                suc2 = item.MeasurementValue;
                sucPresent = true;
            }
        }

        #endregion

        //all genes are required for interpretation, if not return
        if (!(orf1abPresent && ngenePresent && sucPresent)) return GetInterpretationTestCode() + "|";

        //parse gene values
        #region TryParse Gene values to Numeric
        var ofr1abIsInt = decimal.TryParse(ofr1ab, out orf1abInt);
        var ngeneIsInt = decimal.TryParse(ngene, out ngeneInt);
        var suc2IsInt = decimal.TryParse(suc2, out suc2Int);
        #endregion

        #region Setting Gene Cutoffs
        var orf1abCutoff = 37M;
        var ngeneCutoff = 35M;
        var suc2Cutoff = 34M;
        var noAmpResult = "-";
        #endregion

        //set the non-numeric genes to an impossible value that would be evaluated as negative
        //The only non-negative value received here would be a dash(-) incase of gentier or null incase of QS5

        if (!ofr1abIsInt && ofr1ab == noAmpResult) { orf1abInt = 1000M; }
        if (!ngeneIsInt && ngene == noAmpResult) { ngeneInt = 1000M; }
        if (!suc2IsInt && suc2 == noAmpResult) { suc2Int = 1000M; }

        // Run interpretation rules
        #region All numeric Rules
        //All numeric  and N gene and ORF1ab is NEGATIVE. SUC is Positive. Result is Negative
        if (orf1abInt > orf1abCutoff && ngeneInt > ngeneCutoff && suc2Int <= suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|NEGATIVE";
        }

        //All numeric. orf1ab negative. N gene and SUC2 Positive. Result is BLANK
        if (orf1abInt > orf1abCutoff && ngeneInt <= ngeneCutoff && suc2Int <= suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|";
        }

        //All numeric. N gene negative. orf1ab and SUC2 positive. Result is BLANK
        if (orf1abInt <= orf1abCutoff && ngeneInt > ngeneCutoff && suc2Int <= suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|";
        }

        //All numeric. All negative. Result is NEGATIVE
        if (orf1abInt > orf1abCutoff && ngeneInt > ngeneCutoff && suc2Int > suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|";
        }

        //All numeric. orf1ab and n gene are positive. SUC is negative. Result is Positive
        if (orf1abInt <= orf1abCutoff && ngeneInt <= ngeneCutoff && suc2Int > suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|POSITIVE";
        }

        //All numeric and All genes positive. Result: Positive
        if (orf1abInt <= orf1abCutoff && ngeneInt <= ngeneCutoff && suc2Int <= suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|POSITIVE";
        }

        //Only or1ab Amplified. Result is BLANK
        if (orf1abInt <= orf1abCutoff && ngeneInt > ngeneCutoff && suc2Int > suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|";
        }
        //Only ngene Amplified. Result is BLANK
        if (orf1abInt > orf1abCutoff && ngeneInt <= ngeneCutoff && suc2Int > suc2Cutoff)
        {
            return GetInterpretationTestCode() + "|";
        }

        return "ERROR|No rules found for condition";
        #endregion


    }
    private string LabGunResultInterPretation(dynamic measurements)
    {
        decimal rdrpDecimal;
        decimal ngeneDecimal;
        decimal icDecimal;

        string rdrp = "";
        string ngene = "";
        string ic = "";

        var rdrpPresent = false;
        var ngenePresent = false;
        var icPresent = false;

        //capture the expected targerts in measurements to local string variables
        foreach (var item in measurements)
        {
            if (item.TestCode == "RdRp")
            {
                rdrp = item.MeasurementValue.ToString();
                rdrpPresent = true;
            }
            if (item.TestCode == "N gene")
            {
                ngene = item.MeasurementValue.ToString();
                ngenePresent = true;
            }
            if (item.TestCode == "IC")
            {
                ic = item.MeasurementValue.ToString();
                icPresent = true;
            }
        }

        //If any genes are missing... return
        if(!(rdrpPresent && ngenePresent && icPresent)) return GetInterpretationTestCode() + "|";

        //try parsing the string ct values to decimal for comparision
        var rdrpIsDecimal = decimal.TryParse(rdrp, out rdrpDecimal);
        var ngeneIsDecimal = decimal.TryParse(ngene, out ngeneDecimal);
        var icIsDecimal = decimal.TryParse(ic, out icDecimal);

        //if all values are numeric
        if (rdrpIsDecimal && ngeneIsDecimal && icIsDecimal)
        {
            if (rdrpDecimal <= 30 && ngeneDecimal <= 30 && icDecimal <= 30 )
            {
                return GetInterpretationTestCode() + "|POSITIVE";
            }
            
        }
        return GetInterpretationTestCode() + "|NEGATIVE";

    }
    private string PerkinElmerResultInterPretation(dynamic measurements)
    {
        decimal orf1abDecimal;
        decimal ngeneDecimal;
        decimal cy5Decimal;

        string orf1ab = "";
        string ngene = "";
        string cy5 = "";

        var orf1abPresent = false;
        var ngenePresent = false;
        var cy5Present = false;

        foreach (var item in measurements)
        {
            if (item.TestCode == "ORF1ab")
            {
                orf1ab = item.MeasurementValue.ToString();
                orf1abPresent = true;
            }
            if (item.TestCode == "N gene")
            {
                ngene = item.MeasurementValue.ToString();
                ngenePresent = true;
            }
            if (item.TestCode == "IC")
            {
                cy5 = item.MeasurementValue.ToString();
                cy5Present = true;
            }
        }

        //All genes must be present, return otherwise
        if(!(orf1abPresent && ngenePresent && cy5Present)) return GetInterpretationTestCode() + "|";

        //parse gene values
        var ofr1abIsDecimal = decimal.TryParse(orf1ab, out orf1abDecimal);
        var ngeneIsDecimal = decimal.TryParse(ngene, out ngeneDecimal);
        var cy5IsDecimal = decimal.TryParse(cy5, out cy5Decimal);

        //case 1: All amplifies
        if (ofr1abIsDecimal && ngeneIsDecimal && cy5IsDecimal)
        {
            //positive
            if (orf1abDecimal <= 37M && ngeneDecimal <=37M && cy5Decimal <= 37M)
            {
                return GetInterpretationTestCode() + "|POSITIVE";
            }
            //repeat from extraction
            if (orf1abDecimal <= 37M && ngeneDecimal <= 37M && (cy5Decimal > 37M && cy5Decimal <= 42M))
            {
                return GetInterpretationTestCode() + "|RERUN";
            }
            //negative
            if (orf1abDecimal > 37M || ngeneDecimal > 37M || cy5Decimal <= 37M)
            {
                return GetInterpretationTestCode() + "|NEGATIVE";
            }

            //does not fit any condition specified.
            return GetInterpretationTestCode() + "|";
        }
        else
        {
            //Case 2: Atleast one Ct is not numeric
            if (!cy5IsDecimal)
            {
                return GetInterpretationTestCode() + "|INVALID";
            }
            else
            {
                return GetInterpretationTestCode() + "|NEGATIVE";
            }
        }

    }

}
