﻿CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequestClinicalDetailsSampleAndRequestedTests]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@Cin varchar(50),
	@SiteId int,
	@CollectionDate char(8),
	@ReceivedDate char(8),
	@CommaDelimitedClinicalDetailsIds varchar(100),
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

				--insert clincial details
				INSERT INTO [dbo].[AnalysisRequest_ClinicalDetail]([AnalysisRequestId],[ClinicalDetailsId])
				SELECT @AnalysisRequestId AS [AnalysisRequestId] ,CAST(value as int) AS [ClinicalDetailsId] 
				FROM STRING_SPLIT(@CommaDelimitedClinicalDetailsIds,',');

				--insert into dbo.Sample
				INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId], [CollectionDate], [ReceivedDate])
				VALUES (@Cin,@AnalysisRequestId , @SiteId, @CollectionDate, @ReceivedDate);

				--insert into dbo.Result
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
				SELECT [TD].[Sample_Cin], [TD].[TestId]
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