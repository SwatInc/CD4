CREATE PROCEDURE [dbo].[usp_GetTestWithResultsByRequestId]
	@AnalysisRequestId int
AS
BEGIN
SET NOCOUNT ON;
SELECT [R].[Id], [R].[AnalysisRequestId], [R].[Sample_Cin], [R].[TestId], [R].[Result], [R].[ResultDate]
FROM [dbo].[Result] [R]
WHERE [R].[AnalysisRequestId] = @AnalysisRequestId;
END