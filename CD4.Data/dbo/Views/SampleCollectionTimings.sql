CREATE VIEW [dbo].[SampleCollectionTimings]
(
	[Id],
	[Cin],
	[CollectedAt]
)
WITH SCHEMABINDING
AS
(
	SELECT [th].[Id]
		 , [th].[SampleCin] AS [Cin]
		 , [th].[TimeStamp] AS [CollectedAt]
	FROM [dbo].[TrackingHistory] [th]
	WHERE [th].[StatusId] = 2 AND [th].[SampleCin] IS NOT NULL --StatusId 2 on dbo.Status must be Collected
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleCollectionTimings_Id
ON [dbo].[SampleCollectionTimings]([Id]);
GO