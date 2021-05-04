CREATE PROCEDURE [dbo].[usp_GetWorksheetBySpecifiedDateAndDiscipline]
	@StartDate VARCHAR(8),
	@EndDate VARCHAR(8),
    @DisciplineId int
AS
BEGIN
	WHILE ((@StartDate IS NOT NULL) AND (@StartDate <> '') AND (@EndDate IS NOT NULL) AND (@EndDate <> ''))
	BEGIN
		DECLARE @StartDateInUse DATE = CAST(@StartDate AS DATE);
		DECLARE @EndDateInUse DATE = CAST(@EndDate AS DATE);

        DECLARE @TempCins TABLE ([Cin] VARCHAR(20) PRIMARY KEY, [AnalysisRequestId] INT NOT NULL);
		DECLARE @TempClinicalDetails TABLE([AnalysisRequestId] INT PRIMARY KEY, [Detail] VARCHAR(100) NULL);
        
        -- get distinct Cins that have current status as specified in @StatusId and are Collected[Status: 2] on Specified date or later
		INSERT INTO @TempCins
		SELECT DISTINCT([S].[Cin]),[S].[AnalysisRequestId] 
		FROM [dbo].[Sample] [S]
		INNER JOIN [dbo].[Result] [R] ON [R].[Sample_Cin] = [S].[Cin]
        INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
		INNER JOIN [dbo].[TrackingHistory] [TH] ON [TH].[SampleCin] = [S].[Cin]
		WHERE [TH].[TimeStamp] >= @StartDateInUse AND
              [TH].[TimeStamp] <= @EndDateInUse AND 
              [TH].[TrackingType] = 2 AND		--Tracking type [2] = sample | StatusId 2 = Collected
              [T].[DisciplineId]  = @DisciplineId;

        -- Get Clinical details
        INSERT INTO @TempClinicalDetails
        SELECT [TC].[AnalysisRequestId],STRING_AGG(ISNULL([CD].[Detail],''),',') 
        FROM @TempCins [TC]
        LEFT JOIN [dbo].[AnalysisRequest_ClinicalDetail] [ACD] ON [TC].[AnalysisRequestId] = [ACD].[AnalysisRequestId]
        LEFT JOIN [dbo].[ClinicalDetail] [CD] ON [ACD].[ClinicalDetailsId] = [CD].[Id]
        GROUP BY [TC].[AnalysisRequestId];

		-- fetch request data and join with clinical details :)
		SELECT DISTINCT([RW].[AnalysisRequestId]) AS [Id],
               [RW].[AnalysisRequestId],
               [RW].[Cin],
               [RW].[CollectionDate],
               [RW].[ReceivedDate],
               [RW].[FullName] AS [PatientName],
               [RW].[NidPp] AS [NationalId],
               [RW].[AgeSex],
               [RW].[Birthdate],
               [RW].[PhoneNumber],
               [RW].[Address],
               [RW].[AtollIslandCountry],
               [RW].[InstituteAssignedPatientId],
               [RW].[EpisodeNumber],
               [RW].[Site],
               [RW].[SampleStatusId] AS [StatusIconId],
               ISNULL([C].[Detail],'') AS [ClinicalDetails]
		FROM [dbo].[RequestsWithTestsAndResults] [RW] 
        INNER JOIN @TempClinicalDetails [C] ON [RW].[AnalysisRequestId] = [C].[AnalysisRequestId]
		WHERE 
            [RW].[RequestedDate] >= @StartDateInUse AND
            [RW].[RequestedDate] <= @EndDateInUse AND
            [RW].[Cin] IN (SELECT [Cin] FROM @TempCins);;
		--NOTE: Need to keep this date as requested date

		-- fetch results data
        SELECT [Id],
               [AnalysisRequestId],
               [Cin],
               [Description] AS [Test],
               [StatusId] AS [StatusIconId],
               [Result],
               [DataType],
               [Mask],
               [Unit],
               [ReferenceCode],
               [IsDeltaOk]
	           FROM [dbo].[WorkSheetResultData]
	           WHERE [DisciplineId] = @DisciplineId AND  [Cin] IN (SELECT [Cin] FROM @TempCins);

        --get reference ranges
        SELECT [ResultId],
               [NormalLowLimit],
               [NormalHighLimit],
               [AttentionLowLimit],
               [AttentionHighLimit],
               [PathologyLowLimit],
               [PathologyHighLimit]
        FROM [dbo].[ResultReferenceRanges]
        WHERE [ResultId] IN ( SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] IN (
                                        SELECT [Cin] FROM @TempCins ));
               
		BREAK;  
	END
END
