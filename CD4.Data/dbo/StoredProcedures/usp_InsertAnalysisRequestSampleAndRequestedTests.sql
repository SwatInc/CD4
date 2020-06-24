--THIS PROCEDURE IS CALLED IF THE INSERTED REQUEST DOES NOT HAVE ANY CLINICAL DETAILS
CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequestSampleAndRequestedTests]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@Cin varchar(50),
	@SampleStatusId int,
	@SiteId int,
	@CollectionDate char(8),
	@ReceivedDate char(8),
	@RequestedTestData [dbo].[ResultTableInsertDataUDT] READONLY
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				
				DECLARE @AnalysisRequestId int;

				--used to catch all inserted ids
				DECLARE @InsertedId TABLE ([Id] int);

				--insert into dbo.AnalysisRequest
				INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
				OUTPUT INSERTED.Id INTO @InsertedId
				VALUES (@PatientId, @EpisodeNumber, @Age);

				--set inserted analysis requestId
				SELECT @AnalysisRequestId =  [Id] FROM @InsertedId;

				--insert into dbo.Sample
				INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId], [CollectionDate], [ReceivedDate], [StatusId])
				VALUES (@Cin,@AnalysisRequestId , @SiteId, @CollectionDate, @ReceivedDate, @SampleStatusId);

				--insert into dbo.Result
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId], [StatusId])
				SELECT [TD].[Sample_Cin], [TD].[TestId], [TD].[TestStatusId]
				FROM @RequestedTestData [TD];

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
				IF (XACT_STATE()) = -1  
				BEGIN  
					ROLLBACK TRANSACTION; 
				END;
				THROW;
		END CATCH;
SELECT @ReturnValue;
END;