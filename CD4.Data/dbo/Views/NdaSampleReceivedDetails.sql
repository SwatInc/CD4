CREATE VIEW [dbo].[NdaSampleReceivedDetails]
	AS
	SELECT 
		 [NAT].[Cin]
		,CONCAT([U].[FullNameLocal], CHAR(13),[U].[Fullname]) AS [ReceivedBy]
	FROM [dbo].[NdaActionTracking] [NAT]
	INNER JOIN [dbo].[Users] [U] ON [NAT].[ActionUserId] = [U].[Id]
	INNER JOIN [dbo].[NdaLookup] [NL] ON [NL].[Id] = [NAT].[NdaLookupId] 
	WHERE [NL].[Description] = 'Received';
GO
		
