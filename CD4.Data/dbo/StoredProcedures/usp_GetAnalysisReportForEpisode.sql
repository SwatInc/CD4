CREATE PROCEDURE [dbo].[usp_GetAnalysisReportForEpisode]
	@EpisodeNumber VARCHAR(15),
	@UserId int
AS
	BEGIN
	SET NOCOUNT ON;
		DECLARE @SampleAuditTypeId int = 2;
		DECLARE @LoggedInUser varchar(256);
		DECLARE @ResultDataPrinted varchar(1000);
		DECLARE @Cins TABLE([Cin] varchar(50) NOT NULL);
		DECLARE @ReportResult TABLE
		(
			[Cin] VARCHAR(50) NOT NULL,
			[Discipline] VARCHAR(50) NOT NULL,
			[Assay] NVARCHAR(100) NOT NULL,
			[Result] NVARCHAR(50)NULL,
			[Unit] varchar(10) null,
			[DisplayNormalRange] varchar(100),
			[Comment] varchar(1000)
		);

		--get all cins for the report
		INSERT INTO @Cins([Cin])
		SELECT [Cin] 
		FROM [dbo].[Sample] [s]
		INNER JOIN [dbo].[AnalysisRequest] [ar] ON [s].[AnalysisRequestId] = [ar].[Id]
		WHERE [ar].[EpisodeNumber] = @EpisodeNumber

		INSERT INTO @ReportResult
		SELECT
			 [W].[Cin]
			,[W].[Discipline]
			,[W].[Description] AS [Assay]
			,[W].[Result] 
			,[W].[Unit]
			,[RR].[DisplayNormalRange]
			,[W].[Comment]
			FROM [dbo].[WorkSheetResultData] [W]
			INNER JOIN [dbo].[ResultTracking] [RT] ON [W].[Id] = [RT].[ResultId]
			INNER JOIN [dbo].[ResultReferenceRanges] [RR] ON [W].[Id] = [RR].[ResultId]
			WHERE 
				  [W].[Cin] IN (SELECT [Cin] FROM @Cins) AND
				  [W].[Reportable] = 1 AND
				  ([W].[Result] IS NOT NULL OR [W].[Result] <> '') AND
				  [RT].[StatusId] = 5;

		SELECT [Cin],[Discipline],[Assay],[Result],[Unit],[DisplayNormalRange],[Comment] FROM @ReportResult;
	
		SELECT 
		DISTINCT([R].[NidPp])
		,[R].[FullName]
		,[R].[AgeSex]
		,[R].[Birthdate]
		,CONCAT([R].[Address],' ',[R].[AtollIslandCountry]) AS [Address]
		,[R].[Nationality]
		,[R].[Site] AS [SampleSite]
		,[R].[CollectionDate] AS [CollectedDate]
		,[R].[ReceivedDate]
		,[R].[Cin]
		,[R].[EpisodeNumber]
		,[R].[QcCalValidatedBy]
		,[R].[ReportedAt]
		,[R].[ReceivedBy]
		,[R].[AnalysedBy]
		,[R].[InstituteAssignedPatientId]
		,[SPT].[SampleProcessedDateTime] AS [SampleProcessedAt]
		FROM [dbo].[RequestsWithTestsWithResults] [R]
		LEFT JOIN [dbo].[SampleProcessedTimings] [SPT] ON [R].[Cin] = [SPT].[Sample_Cin]
		WHERE [R].[Cin] IN
				(SELECT [Cin] FROM @Cins);

		--get logged in user
		SELECT @LoggedInUser = [UserName] FROM [dbo].[Users] WHERE [Id] =@UserId;
		-- audit trail entry for now. Do not mark sample as printed, beofore that, Need a workflow to retract a dispatched report.

		SELECT @ResultDataPrinted = STRING_AGG(CONCAT([Assay],':',[Result]),'|') FROM @ReportResult;

		INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
		SELECT @SampleAuditTypeId,[Cin],5,CONCAT('Report printed by user: ',@LoggedInUser,' printed results: ',@ResultDataPrinted)
		FROM @Cins;
END
