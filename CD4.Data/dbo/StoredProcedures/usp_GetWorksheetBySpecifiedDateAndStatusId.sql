/*
returns two lists of data
	One with request, patient, clinical details data
	Other with results data.

CONDITION: 
Data returned will be filtered form date and Test Status
*/
CREATE PROCEDURE [dbo].[usp_GetWorksheetBySpecifiedDateAndStatusId]
	@StartDate VARCHAR(8),
	--pass in todays date if no date is specified.
	-- Format: yyyyMMdd
    @StatusId int -- Look for tests with this status Id
AS
BEGIN
	WHILE (@StartDate IS NOT NULL) AND (@StartDate <> '')
	BEGIN
		DECLARE @StartDateInUse DATE = CAST(@StartDate AS DATE);

        DECLARE @TempCins TABLE ([Cin] VARCHAR(20) PRIMARY KEY, [AnalysisRequestId] INT NOT NULL);
		DECLARE @TempClinicalDetails TABLE([AnalysisRequestId] INT PRIMARY KEY, [Detail] VARCHAR(100) NULL);
        
        -- get distinct Cins which is more than specified date and matches the status
        INSERT INTO @TempCins
        SELECT DISTINCT([S].[Cin]),[S].[AnalysisRequestId] 
        FROM [dbo].[Sample] [S] 
        INNER JOIN [dbo].[AuditTrail] [AT] ON [S].[Cin] = [AT].[Cin]
        WHERE [AT].[CreatedAt] >= @StartDateInUse AND [AT].[StatusId] = @StatusId;

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
               [RW].[EpisodeNumber],
               [RW].[Site],
               [RW].[SampleStatusId] AS [StatusIconId],
               ISNULL([C].[Detail],'') AS [ClinicalDetails]
		FROM [dbo].[RequestsWithTestsAndResults] [RW] 
        INNER JOIN @TempClinicalDetails [C] ON [RW].[AnalysisRequestId] = [C].[AnalysisRequestId]
		WHERE [RW].[RequestedDate] >= @StartDateInUse AND [RW].[TestStatusId] = @StatusId;

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
               [IsNormal],
               [IsDeltaOk]
	           FROM [dbo].[WorkSheetResultData]
	           WHERE [Cin] IN (SELECT [Cin] FROM @TempCins);

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