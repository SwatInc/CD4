CREATE PROCEDURE [dbo].[usp_GetAnalysisReportByCin]
	@Cin VARCHAR(50),
	@UserId int
AS
	BEGIN
	SET NOCOUNT ON;
		DECLARE @SampleAuditTypeId int = 2;
		DECLARE @LoggedInUser varchar(256);
		DECLARE @ResultDataPrinted varchar(1000);
		DECLARE @ReportResult TABLE
		(
			[Cin] VARCHAR(50) NOT NULL,
			[Discipline] VARCHAR(50) NOT NULL,
			[Assay] NVARCHAR(100) NOT NULL,
			[Result] NVARCHAR(50)NULL,
			[Unit] varchar(10) null,
			[DisplayNormalRange] varchar(100)
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
			WHERE [W].[Cin] = @Cin AND [W].[Reportable] = 1 AND
				 ([W].[Result] IS NOT NULL OR [W].[Result] <> '') AND
				  [RT].[StatusId] = 5;

		SELECT [Cin],[Discipline],[Assay],[Result],[Unit],[DisplayNormalRange] FROM @ReportResult;
	
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
		FROM [dbo].[RequestsWithTestsWithResults] [R]
		WHERE [R].[Cin] = @Cin;

		--get logged in user
		SELECT @LoggedInUser = [UserName] FROM [dbo].[Users] WHERE [Id] =@UserId;
		-- audit trail entry for now. Do not mark sample as printed, beofore that, Need a workflow to retract a dispatched report.

		SELECT @ResultDataPrinted = STRING_AGG(CONCAT([Assay],':',[Result]),'|') FROM @ReportResult;

		INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
		VALUES
		(@SampleAuditTypeId,@Cin,5,CONCAT('Report printed by user: ',@LoggedInUser,' printed results: ',@ResultDataPrinted));
END
