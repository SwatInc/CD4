﻿CREATE VIEW [dbo].[RequestDataForWorksheet]
(
       [Id],
       [AnalysisRequestId],
       [Cin],
       [CollectionDate],
       [ReceivedDate],
       [FullName],
       [NidPp],
	   [AgeSex],
       [Birthdate],
       [PhoneNumber],
       [Address],
	   [AtollIslandCountry],
	   [EpisodeNumber],
	   [Site]
)
WITH SCHEMABINDING
AS
( 
SELECT [R].[Id],
       [S].[AnalysisRequestId],
       [S].[Cin],
       [S].[CollectionDate],
       [S].[ReceivedDate],
       [P].[FullName],
       [P].[NidPp],
	   CONCAT([AR].[AGE],' / ',[G].[Gender]) AS [AgeSex],
       [P].[Birthdate],
       [P].[PhoneNumber],
       [P].[Address],
	   CONCAT([A].[Atoll],'. ',[A].[Island],', ',[C].[Country]) AS [AtollIslandCountry],
	   [AR].[EpisodeNumber],
	   [SI].[NAME] AS [Site]
FROM [dbo].[Result] [R] 
INNER JOIN [dbo].[Sample] [S] ON [R].[Sample_Cin] = [S].[Cin]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
INNER JOIN [dbo].[Gender] [G] ON [P].[GenderId] = [G].[Id]
INNER JOIN [dbo].[Atoll] [A] ON [P].[AtollId] = [A].[Id]
INNER JOIN [dbo].[Country] [C] ON [P].[CountryId]  = [C].[Id] 
INNER JOIN [dbo].[Sites] [SI] ON [S].[SiteId] = [SI].[Id]
WHERE [R].[Result] IS NULL
)