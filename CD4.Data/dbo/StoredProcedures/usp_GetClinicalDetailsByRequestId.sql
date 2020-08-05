CREATE PROCEDURE [dbo].[usp_GetClinicalDetailsByRequestId]
	@AnalysisRequestId int
AS
BEGIN
SET NOCOUNT ON;
	SELECT [C].[Id],[C].[AnalysisRequestId],[C].[ClinicalDetailsId]
	FROM [dbo].[AnalysisRequest_ClinicalDetail] [C]
	WHERE [C].[AnalysisRequestId] = @AnalysisRequestId;
END
