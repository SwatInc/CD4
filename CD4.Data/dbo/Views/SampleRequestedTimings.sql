CREATE VIEW [dbo].[SampleRequestedTimings]
(
	[Id],
	[AnalysisRequestId],
	[RequestedAt]
)
WITH SCHEMABINDING
AS
(
	SELECT [a].[Id]
		 , [a].[AnalysisRequestId]
		 , [a].[TimeStamp] AS [RequestedAt]
	FROM [dbo].[TrackingHistory] [a]
	WHERE [a].[StatusId] = 1 AND [a].[TrackingType] = 1
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleRequestedTimings_Id
ON [dbo].[SampleRequestedTimings]([Id]);