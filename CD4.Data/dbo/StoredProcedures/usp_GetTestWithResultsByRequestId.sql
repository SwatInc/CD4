CREATE PROCEDURE [dbo].[usp_GetTestWithResultsByRequestId]
	@AnalysisRequestId int
AS
BEGIN
SET NOCOUNT ON;
SELECT [R].[Id], [S].[AnalysisRequestId], [R].[Sample_Cin], [R].[TestId], [R].[Result], [R].[ResultDate]
FROM [dbo].[Result] [R]
INNER JOIN [dbo].[Sample] [S] ON [S].[Cin] = [R].[Sample_Cin]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [AR].[Id] = [S].[AnalysisRequestId]
WHERE [S].[AnalysisRequestId] = @AnalysisRequestId;
END