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
        
        -- get distinct Cins
        INSERT INTO @TempCins
        SELECT DISTINCT([S].[Cin]),[S].[AnalysisRequestId] 
        FROM [dbo].[Sample] [S] 
        INNER JOIN dbo.Result [r] ON [r].[Sample_Cin] = [S].[Cin]
        WHERE [s].[ReceivedDate] >= @StartDateInUse AND [r].[StatusId] = @StatusId;

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
               [RW].[StatusId],
               ISNULL([C].[Detail],'') AS [ClinicalDetails]
		FROM [dbo].[RequestsWithTestsAndResults] [RW] WITH (NOEXPAND)
        INNER JOIN @TempClinicalDetails [C] ON [RW].[AnalysisRequestId] = [C].[AnalysisRequestId]
		WHERE [RW].[ReceivedDate] >= @StartDateInUse AND [RW].[StatusId] = @StatusId;

		-- fetch results data which is not complete(has no results).
        SELECT [Id],
               [AnalysisRequestId],
               [Cin],
               [Description] AS [Test],
               [StatusId] AS [StatusIconId],
               [Result],
               [DataType],
               [Mask] 
	           FROM [dbo].[WorkSheetResultData]
	           WHERE [Cin] IN (SELECT [Cin] FROM @TempCins);

		BREAK;  
	END
END