CREATE VIEW [dbo].[SampleProcessedTimings]
	WITH SCHEMABINDING
	AS SELECT 
		DISTINCT([r].[Sample_Cin]),
		MAX([rt].[TimeStamp]) AS [SampleProcessedDateTime]
FROM [dbo].[Result] [r]
INNER JOIN [dbo].[TrackingHistory] [rt] ON [rt].[ResultId] = [r].[Id]
AND [rt].[Statusid] = 4
GROUP BY [r].[Sample_Cin];

GO

CREATE UNIQUE CLUSTERED INDEX 
    ucidx_sample_cin
ON [dbo].[SampleProcessedTimings]([Sample_Cin]);

GO