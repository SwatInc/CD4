CREATE PROCEDURE [dbo].[usp_GetAnalysisReportByCin]
	@Cin VARCHAR(50)
AS
	BEGIN
	SET NOCOUNT ON;
		DECLARE @ReportResult TABLE
		(
			[Cin] VARCHAR(50) NOT NULL,
			[Discipline] VARCHAR(50) NOT NULL,
			[Assay] VARCHAR(50) NOT NULL,
			[Result] VARCHAR(50)NULL,
			[Unit] varchar(10) null
		);

		INSERT INTO @ReportResult
		SELECT
			 [W].[Cin]
			,[W].[Discipline]
			,[W].[Description] AS [Assay]
			,[W].[Result] 
			,[W].[Unit]
			,[RR].[DisplayNormalRange]
			FROM [dbo].[WorkSheetResultData] [W]
			INNER JOIN [dbo].[ResultTracking] [RT] ON [W].[Id] = [RT].[ResultId]
			INNER JOIN [dbo].[ResultReferenceRanges] [RR] ON [W].[Id] = [RR].[ResultId]
			WHERE [W].[Cin] = @Cin AND 
				 ([W].[Result] IS NOT NULL OR [W].[Result] <> '') AND
				  [RT].[StatusId] = 5;

		SELECT [Cin],[Discipline],[Assay],[Result],[Unit] FROM @ReportResult;
	
		SELECT 
		DISTINCT([R].[NidPp])
		,[R].[FullName]
		,[R].[AgeSex]
		,[R].[Birthdate]
		,CONCAT([R].[Address],' ',[R].[AtollIslandCountry]) AS [Address]
		,[R].[Site] AS [SampleSite]
		,[R].[CollectionDate] AS [CollectedDate]
		,[R].[ReceivedDate]
		,[R].[Cin]
		FROM [dbo].[RequestsWithTestsWithResults] [R]
		WHERE [R].[Cin] = @Cin;
END
