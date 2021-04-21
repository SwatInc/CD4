
using System;

public class RxEvidenceInvestigatorOnDownloadScript
{
    public RxEvidenceInvestigatorOnDownloadScript()
    {
    }
    public bool IsScriptLoaded()
    {
        return true;
    }

    public string GetInterpretation(dynamic measurement)
    {
        var Cutoff500 = 500M;
        var Cutoff300 = 300M;
        var Cutoff100 = 100M;
        var Cutoff50 = 50M;

        var uploadCode = (UploadCodes)Enum.Parse(typeof(UploadCodes), measurement.TestCode);
        var isMeasurementNumeric = decimal.TryParse(measurement.MeasurementValue, out decimal decimalResult);

        //return empty result if not numeric
        if (!isMeasurementNumeric) { return GetEmptyReturnResult(); }

        if (UploadCodes.AMPH == uploadCode)
        {
            if (decimalResult >= Cutoff500) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }

        if (UploadCodes.BENZ1 == uploadCode)
        {
            if (decimalResult >= Cutoff300) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }

        if (UploadCodes.BENZ2 == uploadCode)
        {
            if (decimalResult >= Cutoff300) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }

        if (UploadCodes.THC == uploadCode)
        {
            if (decimalResult >= Cutoff50) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }

        if (UploadCodes.BZG == uploadCode)
        {
            if (decimalResult >= Cutoff300) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }

        if (UploadCodes.ETHANOL == uploadCode)
        {
            if (decimalResult >= Cutoff100) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }
        if (UploadCodes.MDONE == uploadCode)
        {
            if (decimalResult >= Cutoff300) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }
        if (UploadCodes.OPIAT == uploadCode)
        {
            if (decimalResult >= Cutoff300) { return $"{uploadCode}_I|ދައްކާ POSITIVE| "; }
            return $"{uploadCode}_I|ނުދައްކާ NEGATIVE| ";
        }


        return GetEmptyReturnResult();
    }

    public string GetEmptyReturnResult()
    {
        return "||";
    }

    public enum UploadCodes
    {
        AMPH,
        BENZ1,
        BENZ2,
        THC,
        BZG,
        ETHANOL,
        MDONE,
        OPIAT
    }
}
