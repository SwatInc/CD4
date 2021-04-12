CREATE VIEW [dbo].[RequestSearchData]
	AS
SELECT 
	[S].[Cin],[S].[SiteId], [SCT].[CollectedAt] AS [CollectionDate],[SRT].[ReceivedAt] AS [ReceivedDate],
	[P].[NidPp],[P].[FullName],[P].[GenderId],[P].[PhoneNumber],[P].[Birthdate],[P].[Address],[P].[InstituteAssignedPatientId],
	[A].[Atoll],[A].[Island], [P].[CountryId],
	[AR].[EpisodeNumber]
FROM [dbo].[Sample] [S]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
INNER JOIN [dbo].[Atoll] [A] ON [P].[AtollId] = [A].[Id]
LEFT JOIN [dbo].[SampleCollectionTimings] [SCT] ON [S].[Cin] = [SCT].[Cin]
LEFT JOIN [dbo].[SampleReceivedTimings] [SRT] ON [S].[Cin] = [SRT].[Cin]

GO