CREATE PROCEDURE [dbo].[usp_GetRequestAndSample]
	@Cin varchar(50)
AS
SET NOCOUNT ON;
BEGIN
SELECT [AR].[Id] AS [RequestId],[AR].[EpisodeNumber], [AR].[Age], [S].[Cin], [S].[SiteId], [S].[CollectionDate], [S].[ReceivedDate]
FROM [dbo].[Sample] [S]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
WHERE [S].[Cin] = @Cin;
END