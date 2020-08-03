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
		 , [a].[Cin]
		 , [a].[CreatedAt] AS [ReceivedAt]
	FROM [dbo].[AuditTrail] [a]
	WHERE [a].[StatusId] = 3 AND [a].[Cin] <> 'NA' --StatusId 3 on dbo.Status must be Received
)
GO
CREATE UNIQUE CLUSTERED INDEX IX_SampleReceivedTimings_Id
ON [dbo].[SampleReceivedTimings]([Id]);
GO