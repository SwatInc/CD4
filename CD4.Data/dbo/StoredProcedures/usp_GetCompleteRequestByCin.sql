CREATE PROCEDURE [dbo].[usp_GetCompleteRequestByCin]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @RequestId int;

	--Get request data from view
	SELECT [Cin],
	[EpisodeNumber],
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
	[CountryId],
	[InstituteAssignedPatientId]
	FROM [dbo].[RequestSearchData] 
	WHERE [Cin] = @Cin;

	--Get analysis request Id required to fetch clinical details
	SET @RequestId = (SELECT [S].[AnalysisRequestId] 
	FROM [dbo].[Sample] [S] 
	WHERE [S].[Cin] = @Cin);

	--Get clinical details ids for the request
	SELECT [AC].[ClinicalDetailsId] 
	FROM [dbo].[AnalysisRequest_ClinicalDetail] [AC] 
	WHERE [AC].[AnalysisRequestId] = @RequestId;

	--Get the test data
	SELECT [R].[Id], [R].[Sample_Cin], [R].[TestId], [R].[Result], [RT].[CreatedAt] AS [ResultDate] 
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
	WHERE [R].[Sample_Cin] = @Cin;
END;
