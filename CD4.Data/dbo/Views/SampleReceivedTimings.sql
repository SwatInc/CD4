CREATE VIEW [dbo].[SampleReceivedTimings]
(
	[Id],
	[Cin],
	[ReceivedAt]
)
WITH SCHEMABINDING
AS
(
	SELECT [a].[Id]
		 , [a].[SampleCin] AS [Cin]
		 , [a].[TimeStamp] AS [ReceivedAt]
	FROM [dbo].[TrackingHistory] [a]
	WHERE [a].[StatusId] = 3 AND [a].[TrackingType] = 2
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleReceivedTimings_Id
ON [dbo].[SampleReceivedTimings]([Id]);
GO