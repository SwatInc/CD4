CREATE PROCEDURE [dbo].[usp_GetRequestAndSample]
	@Cin varchar(50)
AS
SET NOCOUNT ON;
BEGIN
	SELECT [AR].[Id] AS [RequestId]
	, [AR].[EpisodeNumber]
	, [AR].[Age]
	, [S].[Cin]
	, [S].[SiteId]
	, [SCT].[CollectedAt] AS [CollectionDate]
	, [SRT].[ReceivedAt] AS [ReceivedDate]
	FROM [dbo].[Sample] [S]
	INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
	INNER JOIN [dbo].[SampleCollectionTimings] [SCT] ON [S].[Cin] = [SCT].[Cin]
	INNER JOIN [dbo].[SampleReceivedTimings] [SRT] ON [S].[Cin] = [SRT].[Cin]
	WHERE [S].[Cin] = @Cin;
END