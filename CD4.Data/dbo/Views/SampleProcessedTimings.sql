CREATE VIEW [dbo].[SampleProcessedTimings]
	AS 
	SELECT
		[Sample_Cin],
		MAX([ResultProcessedDateTime]) AS [SampleProcessedDateTime]
FROM [dbo].[ResultProcessedTimings]
GROUP BY [Sample_Cin];

GO

