CREATE VIEW [dbo].[NdaRequestsReportedDetails]
	AS
	SELECT 
		  [NTT].[Cin]
		 ,[NTT].[TrackedTime] AS [ReportedAt]
	FROM [dbo].[NdaTimeTracking] [NTT]
	INNER JOIN [dbo].[NdaLookup] [NL] ON [NL].[Id] = [NTT].[NdaLookupId] 
	WHERE [NL].[Description] = 'Reported';