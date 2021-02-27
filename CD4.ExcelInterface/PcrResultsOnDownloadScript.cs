﻿
using System.Collections.Generic;

public class PcrResultsOnDownloadScript
{
    public List<dynamic> Kits { get; set; }

    public PcrResultsOnDownloadScript()
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

        //all genes are required for interpretation, if not return
        if(!(orf1abPresent && ngenePresent && sucPresent)) return GetInterpretationTestCode() + "|";

        //parse gene values
        var ofr1abIsInt = decimal.TryParse(ofr1ab, out orf1abInt);
        var ngeneIsInt = decimal.TryParse(ngene, out ngeneInt);
        var suc2IsInt = decimal.TryParse(suc2, out suc2Int);

        if (ofr1abIsInt && ngeneIsInt && suc2IsInt)
        {
            if (orf1abInt <= 37M && ngeneInt <= 35M && suc2Int <= 34M)
            {
                return GetInterpretationTestCode() + "|Positive";
            }
            else
            {
                return GetInterpretationTestCode() + "|Negative";
            }
        }
        else
        {
            return GetInterpretationTestCode() + "|Negative";
        }
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
            if (item.TestCode == "N-Gene")
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
                return GetInterpretationTestCode() + "|Positive";
            }
            
        }
        return GetInterpretationTestCode() + "|Negative";

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
            if (item.TestCode == "N-Gene")
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
                return GetInterpretationTestCode() + "|Positive";
            }
            //repeat from extraction
            if (orf1abDecimal <= 37M && ngeneDecimal <= 37M && (cy5Decimal > 37M && cy5Decimal <= 42M))
            {
                return GetInterpretationTestCode() + "|Rerun";
            }
            //negative
            if (orf1abDecimal > 37M || ngeneDecimal > 37M || cy5Decimal <= 37M)
            {
                return GetInterpretationTestCode() + "|1Negative";
            }

            //does not fit any condition specified.
            return GetInterpretationTestCode() + "|";
        }
        else
        {
            //Case 2: Atleast one Ct is not numeric
            if (!cy5IsDecimal)
            {
                return GetInterpretationTestCode() + "|IInvalid";
            }
            else
            {
                return GetInterpretationTestCode() + "|2Negative";
            }
        }

    }

}
