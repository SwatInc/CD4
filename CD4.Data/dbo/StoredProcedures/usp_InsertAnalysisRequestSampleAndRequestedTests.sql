CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequestSampleAndRequestedTests]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@Cin varchar(50),
	@AnalysisRequestId int,
	@SiteId int,
	@CollectionDate char(8),
	@ReceivedDate char(8),
	@requestedTestData [dbo].[ResultTableInsertDataUDT] READONLY
AS
BEGIN
SET NOCOUNT ON;

	--used to catch all inserted ids
	DECLARE @InsertedId TABLE ([Id] int);

	--insert into dbo.AnalysisRequest
	INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
	OUTPUT INSERTED.Id INTO @InsertedId
	VALUES (@PatientId, @EpisodeNumber, @Age);

	--set inserted analysis requestId
	SELECT @AnalysisRequestId =  [Id] FROM @InsertedId;

	--insert into dbo.Sample
	INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId], [CollectionDate], [ReceivedDate])
	VALUES (@Cin,@AnalysisRequestId , @SiteId, @CollectionDate, @ReceivedDate);

	--insert into dbo.Result
	INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
	SELECT [TD].[Sample_Cin], [TD].[TestId]
	FROM @requestedTestData [TD];

END