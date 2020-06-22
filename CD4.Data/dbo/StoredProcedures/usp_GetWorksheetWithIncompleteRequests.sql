/*
returns two lists of data
	One with request, patient, clinical details data
	Other with results data.

CONDITION: 
Data returned will be filtered form date. i.e. >= to the date specified.C:\Users\ibrah\source\repos\CD4\CD4.Data\dbo\StoredProcedures\GetWorksheetWithIncompleteRequests.sql
If no date is specified, the procedure not return anything.
*/
CREATE PROCEDURE [dbo].[usp_GetWorksheetWithIncompleteRequests]
	@StartDate VARCHAR(8)
	--pass in todays date if no date is specified.
	-- Format: yyyyMMdd
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
        INNER JOIN dbo.Result r ON r.Sample_Cin = S.Cin
        WHERE s.ReceivedDate > @StartDateInUse AND (r.Result IS NULL OR r.Result = '');

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
               [RW].[Site]
               ,ISNULL([C].[Detail],'') AS [ClinicalDetails]
		FROM [dbo].[RequestsWithTestsWithoutResults] [RW] WITH (NOEXPAND)
        INNER JOIN @TempClinicalDetails [C] ON [RW].[AnalysisRequestId] = [C].[AnalysisRequestId]
		WHERE [RW].[ReceivedDate] > @StartDateInUse;

		-- fetch results data which is not complete(has no results).
        SELECT [Id],
               [AnalysisRequestId],
               [Cin],
               [Description] AS [Test],
               [Result],
               [DataType],
               [Mask] 
	           FROM [dbo].[WorkSheetResultData]
	           WHERE [Cin] IN (SELECT [Cin] FROM @TempCins);

		BREAK;  
	END
END