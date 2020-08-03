CREATE VIEW [dbo].[SampleCollectionTimings]
(
	[Id],
	[Cin],
	[CollectedAt]
)
WITH SCHEMABINDING
AS
(
	SELECT [a].[Id]
		 , [a].[Cin]
		 , [a].[CreatedAt] AS [CollectedAt]
	FROM [dbo].[AuditTrail] [a]
	WHERE [a].[StatusId] = 2 AND [a].[Cin] <> 'NA' --StatusId 2 on dbo.Status must be Collected
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleCollectionTimings_Id
ON [dbo].[SampleCollectionTimings]([Id]);
GO