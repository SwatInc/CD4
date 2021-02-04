
using System.Collections.Generic;

public class PcrResultsOnDownloadScript
{
    public List<dynamic> Kits { get; set; }

    public bool IsScriptLoaded()
    {
        return true;
    }

    public List<dynamic> GetKitNames()
    {
        Kits = new List<dynamic>();
        Kits.Add(new { Id = 1, Kit = "Zeesan" });
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
}
