CREATE VIEW [dbo].[RequestsWithTestsAndResults]
(
       [Id],
       [TestStatusId],
       [SampleStatusId],
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
AS
( 
SELECT [R].[Id],
       [RT].[StatusId] AS [TestStatusId],
       [ST].[StatusId] AS [SampleStatusId],
       [S].[AnalysisRequestId],
       [S].[Cin],
       [SCT].[CollectedAt] AS [CollectionDate],
       [SRT].[ReceivedAt] AS [ReceivedDate],
       [P].[FullName],
       [P].[NidPp],
	   ISNULL(CONCAT([AR].[Age],' / ',[G].[Gender]) ,'')AS [AgeSex],
       [P].[Birthdate],
       [P].[PhoneNumber],
       [P].[Address],
	   ISNULL(CONCAT([A].[Atoll],'. ',[A].[Island],', ',[C].[Country]),'')AS [AtollIslandCountry],
	   [AR].[EpisodeNumber],
	   [SI].[Name] AS [Site]
FROM [dbo].[Result] [R] 
INNER JOIN [dbo].[Sample] [S] ON [R].[Sample_Cin] = [S].[Cin]
INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
INNER JOIN [dbo].[Gender] [G] ON [P].[GenderId] = [G].[Id]
INNER JOIN [dbo].[Atoll] [A] ON [P].[AtollId] = [A].[Id]
INNER JOIN [dbo].[Country] [C] ON [P].[CountryId]  = [C].[Id] 
INNER JOIN [dbo].[Sites] [SI] ON [S].[SiteId] = [SI].[Id]
LEFT JOIN [dbo].[SampleTracking] [ST] ON  [s].[Cin] = [ST].[SampleCin]     -- for current sample status tracking
LEFT JOIN [dbo].[ResultTracking] [RT] ON [RT].[ResultId] = [R].[Id]        -- for current result status tracking
LEFT JOIN [dbo].[SampleCollectionTimings] [SCT] ON [S].[Cin] = [SCT].[Cin]
LEFT JOIN [dbo].[SampleReceivedTimings] [SRT] ON [S].[Cin] = [SRT].[Cin]

)
GO
