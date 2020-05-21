CREATE PROCEDURE [dbo].[usp_GetCompleteRequestByCin]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @RequestId int;

	--Get request data from view
	SELECT [Cin],
	[SiteId],
	[CollectionDate],
	[ReceivedDate],
	[NidPp],
	[FullName],
	[GenderId],
	[PhoneNumber],
	[Birthdate],
	[Address],
	[Atoll],
	[Island],
	[CountryId] 
	FROM [dbo].[RequestSearchData] 
	WHERE [Cin] = @Cin;

	--Get analysis request Id required to fetch clinical details
	SET @RequestId = (SELECT [S].[AnalysisRequestId] 
	FROM [dbo].[Sample] [S] 
	WHERE [S].[Cin] = @Cin);

	--Get CSV of clinical details for the request
	SELECT STRING_AGG([AC].[ClinicalDetailsId], ',') AS [CsvClinicalDetails] 
	FROM [dbo].[AnalysisRequest_ClinicalDetail] [AC] 
	WHERE [AC].[AnalysisRequestId] = @RequestId;

	--Get the test data
	SELECT [R].[Id], [R].[Sample_Cin], [R].[TestId], [R].[Result], [R].[ResultDate] 
	FROM [dbo].[Result] [R] 
	WHERE [R].[Sample_Cin] = @Cin;
END;
