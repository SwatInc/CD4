CREATE PROCEDURE [dbo].[usp_GetClinicalDetailsByRequestId]
	@AnalysisRequestId int
AS
BEGIN
SET NOCOUNT ON;
SELECT * 
FROM [dbo].[AnalysisRequest_ClinicalDetail] [C]
WHERE [C].[AnalysisRequestId] = @AnalysisRequestId;
END
