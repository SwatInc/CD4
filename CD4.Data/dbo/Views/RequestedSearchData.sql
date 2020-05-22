CREATE VIEW [dbo].[RequestSearchData]
	AS
SELECT 
	[S].[Cin],[S].[SiteId], [S].[CollectionDate],[S].[ReceivedDate],
	[P].[NidPp],[P].[FullName],[P].[GenderId],[P].[PhoneNumber],[P].[Birthdate],[P].[Address],
	[A].[Atoll],[A].[Island], [P].[CountryId]
FROM [dbo].[Sample] [S]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
INNER JOIN [dbo].[Atoll] [A] ON [P].[AtollId] = [A].[Id];
GO