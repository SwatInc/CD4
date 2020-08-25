namespace CD4.DataLibrary.Models
{
    public class ResultReferenceRangeModel
    {
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
            
            //if specific reference range is not set return appropriate code... for now check normal limits...
            //return normal code if normal limits are not specified.
            if(this.NormalLowLimit ==-1 && this.NormalHighLimit ==-1) return ReferenceCode.NM.ToString();

            //do a crude comparision to get normal or attention code
            if (numericResult > this.NormalHighLimit || numericResult < this.NormalLowLimit)
            {
                return ReferenceCode.AT.ToString();
            }
            else
            {
                return ReferenceCode.NM.ToString();
            }

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
