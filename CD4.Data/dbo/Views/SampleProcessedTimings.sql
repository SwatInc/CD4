CREATE VIEW [dbo].[SampleProcessedTimings]
	AS 
	SELECT 
		[r].[Sample_Cin],
		MAX([rt].[TimeStamp]) AS [SampleProcessedDateTime]
FROM [dbo].[Result] [r]
INNER JOIN [dbo].[TrackingHistory] [rt] ON [rt].[ResultId] = [r].[Id]
WHERE [rt].[Statusid] = 4
GROUP BY [r].[Sample_Cin];