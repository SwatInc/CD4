using System;
using System.Security.Cryptography;

namespace CD4.DataLibrary.Models
{
    public class ResultReferenceRangeModel
    {
        private bool[] _referenceInterpretationCode = new bool[5];

        public int Id { get; set; }
        public int ResultId { get; set; }
        public float NormalHighLimit { get; set; } = -1;
        public float NormalLowLimit { get; set; } = -1;
        public float AttentionHighLimit { get; set; } = -1;
        public float AttentionLowLimit { get; set; } = -1;
        public float PathologyHighLimit { get; set; } = -1;
        public float PathologyLowLimit { get; set; } = -1;
        public float HighPathologyHighLimit { get; set; } = -1;
        public float HighPathologyLowLimit { get; set; } = -1;
        public float AbsoluteDeltaLowLimit { get; set; } = -1;
        public float AbsoluteDeltaHighLimit { get; set; } = -1;
        public float RelativeDeltaLowLimit { get; set; } = -1;
        public float RelativeDeltaHighLimit { get; set; } = -1;
        public float OutOfNormalityAbsoluteLow_DeltaLowLimit { get; set; } = -1;
        public float OutOfNormalityAbsoluteLow_DeltaHighLimit { get; set; } = -1;
        public float OutOfNormalityAbsoluteHigh_DeltaLowLimt { get; set; } = -1;
        public float OutOfNormalityAbsoluteHigh_DeltaHighLimit { get; set; } = -1;
        public float OutOfNormalityRelativeLow_DeltaLowLimit { get; set; } = -1;
        public float OutOfNormalityRelativeLow_DeltaHighLimit { get; set; } = -1;
        public float OutOfNormalityRelativeHigh_DeltaLowlimit { get; set; } = -1;
        public float OutOfNormalityRelativeHigh_DeltaHighLimit { get; set; } = -1;
        public int DeltaValidityDays { get; set; }
        public int BiasFactor { get; set; }

        /// <summary>
        /// Returns the reference code for the result passed in.
        /// Condition: The result Id must match the current models result Id
        /// </summary>
        /// <param name="result">The result for which reference code is to be evaluated</param>
        /// <param name="resultId">The result Id which corresponds to the result passed-in</param>
        /// <returns>Reference code as string</returns>
        public string GetResultReferenceCode(string result, int resultId)
        {
            //NOTE: todo: This method will be properly implemented a bit later.
            //if null, return normal code
            if (string.IsNullOrEmpty(result)) return ReferenceCode.NM.ToString();

            //try parsing to int...
            var IsNumeric = float.TryParse(result, out var numericResult);
            //if fails... return normal code for now... needs improvement for codified results
            if (!IsNumeric) return ReferenceCode.NM.ToString();
            
            //condition for normal result
            _referenceInterpretationCode[0] = (IsExceedsNormal(numericResult));
            _referenceInterpretationCode[1] = (IsExceedsAttention(numericResult));
            _referenceInterpretationCode[2] = (IsExceedsPathology(numericResult));
            _referenceInterpretationCode[3] = (IsExceedsPanic(numericResult));
            _referenceInterpretationCode[4] = (IsExceedsAcceptability(numericResult));

            return DetermineReferenceCode(_referenceInterpretationCode);
        }

        private string DetermineReferenceCode(bool[] referenceInterpretationCode)
        {
            if (referenceInterpretationCode[4]) return ReferenceCode.NA.ToString();
            if (referenceInterpretationCode[3]) return ReferenceCode.HP.ToString();
            if (referenceInterpretationCode[2]) return ReferenceCode.PA.ToString();
            if (referenceInterpretationCode[1]) return ReferenceCode.AT.ToString();
            if (referenceInterpretationCode[0]) return ReferenceCode.AT.ToString(); //outside normal but not attention, as AT for now

            return ReferenceCode.NM.ToString();
        }

        private bool IsExceedsAcceptability(float numericResult)
        {
            return false;
        }

        private bool IsExceedsPanic(float numericResult)
        {
            return HighPathologyHighLimit != -1
                   && numericResult > HighPathologyHighLimit
                   || HighPathologyLowLimit != -1
                   && numericResult < HighPathologyLowLimit;
        }

        private bool IsExceedsPathology(float numericResult)
        {
            return PathologyHighLimit != -1
                   && numericResult > PathologyHighLimit
                   || PathologyLowLimit != -1
                   && numericResult < PathologyLowLimit;
        }

        private bool IsExceedsAttention(float numericResult)
        {
            return AttentionHighLimit != -1
                   && numericResult > AttentionHighLimit
                   || AttentionLowLimit != -1
                   && numericResult < AttentionLowLimit;
        }

        /// <summary>
        /// checks whether result exceeds a specified normal limit. If no limit is specified it is assumed
        /// that the result exceeding normal is not applicable.
        /// </summary>
        /// <returns>True is result exceeds specified limits. If not specified, then false</returns>
        private bool IsExceedsNormal(float numericResult)
        {
            return NormalHighLimit != -1
                && numericResult > NormalHighLimit
                || NormalLowLimit != -1
                && numericResult < NormalLowLimit;
        }

        private enum ReferenceCode
        {
            NM, //Normal
            AT, //Attention
            PA, //Pathology
            HP, //High Pathology (Panic)
            NA  //Not Acceptable (exceeds defined acceptability values)
        }
    }
}
