
using System.Collections.Generic;

public class PcrResultsOnDownloadScript
{
    public List<dynamic> Kits { get; set; }

    public PcrResultsOnDownloadScript()
    {
        Kits = new List<dynamic>();
        Kits.Add(new { Id = 1, Kit = "Zeesan" });
        //Kits.Add(new { Id = 2, Kit = "LabGun" });
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

        foreach (var item in measurements)
        {
            if (item.TestCode == "ORF1ab")
            {
                ofr1ab = item.MeasurementValue;
            }
            if (item.TestCode == "N gene")
            {
                ngene = item.MeasurementValue;
            }
            if (item.TestCode == "SUC2")
            {
                suc2 = item.MeasurementValue;
            }
        }

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
        throw new System.NotImplementedException();
    }
    private string PerkinElmerResultInterPretation(dynamic measurements)
    {
        decimal orf1abDecimal;
        decimal ngeneDecimal;
        decimal cy5Decimal;

        string orf1ab = "";
        string ngene = "";
        string cy5 = "";

        foreach (var item in measurements)
        {
            if (item.TestCode == "ORF1ab")
            {
                orf1ab = item.MeasurementValue.ToString();
            }
            if (item.TestCode == "N-Gene")
            {
                ngene = item.MeasurementValue.ToString();
            }
            if (item.TestCode == "IC")
            {
                cy5 = item.MeasurementValue.ToString();
            }
        }
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
                return GetInterpretationTestCode() + "|Negative";
            }

            //does not fit any condition specified.
            return GetInterpretationTestCode() + "|";
        }
        else
        {
            if (!cy5IsDecimal)
            {
                return GetInterpretationTestCode() + "|Invalid";
            }
            else
            {
                return GetInterpretationTestCode() + "|Negative";
            }
        }

    }

}
