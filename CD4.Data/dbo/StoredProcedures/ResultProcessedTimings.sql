CREATE VIEW [dbo].[ResultProcessedTimings]
WITH SCHEMABINDING
	AS 
	SELECT
		[th].[Id],
		[r].[Id] AS [ResultId],
		[r].[Sample_Cin],
		[th].[TimeStamp] AS [SampleProcessedDateTime]
FROM [dbo].[Result] [r]
INNER JOIN [dbo].[TrackingHistory] [th] ON [th].[ResultId] = [r].[Id]
WHERE [th].[StatusId] = 4 and [th].[TrackingType] = 3;  -- Status ID = 4 is ToValidate
GO

CREATE UNIQUE CLUSTERED INDEX 
    [ucidx_Id]
ON [dbo].[ResultProcessedTimings]([Id]);
GO
