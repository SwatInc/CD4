﻿CREATE PROCEDURE [dbo].[usp_GetWorksheetBySpecifiedDateStatusIdAndDiscipline]
	@StartDate VARCHAR(8),
	@EndDate VARCHAR(8),
	@StatusId int,
    @DisciplineId int
AS
BEGIN
	WHILE ((@StartDate IS NOT NULL) AND (@StartDate <> '') AND (@EndDate IS NOT NULL) AND (@EndDate <> ''))
	BEGIN
		DECLARE @StartDateInUse DATETIME = CAST(CONCAT(@StartDate,' 00:00:00.000') AS DATETIME);
		DECLARE @EndDateInUse DATETIME = CAST(CONCAT(@EndDate,' 23:59:59.999') AS DATETIME);
        DECLARE @AcceptedStatusId int = 3;

        DECLARE @TempCins TABLE ([Cin] VARCHAR(20) PRIMARY KEY, [AnalysisRequestId] INT NOT NULL);
		DECLARE @TempClinicalDetails TABLE([AnalysisRequestId] INT PRIMARY KEY, [Detail] VARCHAR(100) NULL);
        

        SELECT @AcceptedStatusId = 1 WHERE @StatusId = 1;
		SELECT @AcceptedStatusId = 2 WHERE @StatusId = 2;
		SELECT @AcceptedStatusId = 7 WHERE @StatusId = 7;
		SELECT @AcceptedStatusId = 5 WHERE @StatusId = 5;

        -- get distinct Cins that have current status as specified in @StatusId and are Collected[Status: 2] on Specified date or later and the specified discipline
		INSERT INTO @TempCins
		SELECT DISTINCT([S].[Cin]),[S].[AnalysisRequestId] 
		FROM [dbo].[Sample] [S]
		INNER JOIN [dbo].[Result] [R] ON [R].[Sample_Cin] = [S].[Cin]
        INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
		INNER JOIN [dbo].[TrackingHistory] [TH] ON [TH].[SampleCin] = [S].[Cin]
		WHERE 
              ([TH].[TimeStamp]  BETWEEN @StartDateInUse AND @EndDateInUse)  AND 
              [TH].[TrackingType] = 2 AND 
              [TH].[StatusId] = @AcceptedStatusId AND
              [RT].[StatusId] = @StatusId AND --Tracking type [2] = sample | StatusId 2 = Collected
              [T].[DisciplineId] = @DisciplineId;		

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
               [RW].[SamplePriority],
               [RW].[EpisodeNumber],
               [RW].[Site],
               [RW].[SampleStatusId] AS [StatusIconId],
               ISNULL([C].[Detail],'') AS [ClinicalDetails]
		FROM [dbo].[RequestsWithTestsAndResults] [RW] 
        INNER JOIN @TempClinicalDetails [C] ON [RW].[AnalysisRequestId] = [C].[AnalysisRequestId]
		WHERE 
            --([RW].[RequestedDate]  BETWEEN @StartDateInUse AND @EndDateInUse) AND
            --[RW].[TestStatusId] = @StatusId AND 
            [Cin] IN (SELECT [Cin] FROM @TempCins)
			ORDER BY [Id];
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
               [IsDeltaOk],
               [SortOrder],
	           [PrimaryHeader],
	           [SecondaryHeader]
	           FROM [dbo].[WorkSheetResultData]
	           WHERE [DisciplineId] = @DisciplineId AND  [Cin] IN (SELECT [Cin] FROM @TempCins)
			   ORDER BY [Test];

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