CREATE PROCEDURE [dbo].[usp_GetBarcodeDetails]
	@Cin varchar(50)
AS
BEGIN
		SELECT 
			 DISTINCT([S].[Id]) AS [Seq]
			,[S].[Cin] AS [AccessionNumber]
			,[P].[NidPp]
			,[P].[FullName]
			,[P].[Birthdate]
			,[AR].[Age]
			,[ST].[Description] AS [SampleType]
			,[D].[Description] AS [Discipline]
			,[TH].[TimeStamp] AS [CollectionDate]
			,[AR].[EpisodeNumber]
			,[S].[IsStat] AS [SamplePriority]
		FROM dbo.[Sample] [S]
		INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
		INNER JOIN [dbo].[Patient] [P] ON [P].[Id] = [AR].[PatientId]
		INNER JOIN [dbo].[Result] [R] ON [R].[Sample_Cin] = [S].[Cin]
		INNER JOIN [dbo].[Test] [T] ON [T].[Id] = [R].[TestId]
		INNER JOIN [dbo].[SampleType] [ST] ON [T].[SampleTypeId] = [ST].[Id]
		INNER JOIN [dbo].[Discipline] [D] ON [D].[Id] = [T].[DisciplineId]
		INNER JOIN [dbo].[TrackingHistory] [TH] ON [TH].[SampleCin] = [S].[Cin]
		WHERE [TH].[StatusId] = 2 AND [TH].[TrackingType] = 2 AND [S].[Cin] = @Cin;

		--Status Id 2 is Collected. Need collected date for barcode
		--Tracking Type 2 is "Sample" in dbo.AuditType
END
