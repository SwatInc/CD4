CREATE VIEW [dbo].[SampleValidatedTimings]
(
	[Id],
	[Cin],
	[ValidatedAt]
)
WITH SCHEMABINDING
AS
(
	SELECT [a].[Id]
		 , [a].[SampleCin] AS [Cin]
		 , [a].[TimeStamp] AS [ValidatedAt]
	FROM [dbo].[TrackingHistory] [a]
	WHERE [a].[StatusId] = 5 AND [a].[TrackingType] = 2 --status: 5 is validated
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleValidatedTimings_Id
ON [dbo].[SampleValidatedTimings]([Id]);
GO
