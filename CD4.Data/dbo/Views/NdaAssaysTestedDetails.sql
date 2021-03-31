CREATE VIEW [dbo].[NdaAssaysTestedDetails]
	AS
	SELECT 
		 [NAT].[Cin]
		,CONCAT([U].[FullName], CHAR(13),[U].[FullNameLocal]) AS [ReportedBy]
	FROM [dbo].[NdaActionTracking] [NAT]
	INNER JOIN [dbo].[Users] [U] ON [NAT].[ActionUserId] = [U].[Id]
	INNER JOIN [dbo].[NdaLookup] [NL] ON [NL].[Id] = [NAT].[NdaLookupId] 
	WHERE [NL].[Description] = 'Tested';
GO
