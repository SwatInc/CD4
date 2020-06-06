--CREATE PROCEDURE [dbo].[GetReportDataByCin]
--	@Cin VARCHAR(50)
--AS
--BEGIN
	
--	--DECLARE @ReportResult TABLE([Cin] VARCHAR(50),[Assay] VARCHAR(50),[Result] VARCHAR(50));

--	--INSERT INTO @ReportResult
--	--SELECT
--	-- [W].[Cin]
--	--,[W].[Description] AS [Assay]
--	--,[W].[Result] 
--	--FROM [dbo].[WorkSheetResultData] [W]
--	--WHERE [W].[Cin] = @Cin AND ([W].[Result] IS NOT NULL OR [W].[Result] <> '');

--	--SELECT 
--	-- [R].[NidPp]
--	--,[R].[Fullname]
--	--,[R].[AgeSex]
--	--,[R].[Birthdate]
--	--,CONCAT([R].[Address],' ',[R].[AtollIslandCountry]) AS [Address]
--	--,[R].[Site] AS [SampleSite]
--	--,[R].[CollectionDate] AS [CollectedDate]
--	--,[R].[ReceivedDate]
--	--,[R].[Cin]
--	--FROM [dbo].[RequestDataForReport] [R]
--	--INNER JOIN @ReportResult [TEMP] ON [R].[Cin] = [TEMP].[Cin]
--	--WHERE [R].[Cin] = @Cin;

--END
