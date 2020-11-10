CREATE PROCEDURE [dbo].[usp_UpdateSampleWithCin]
	@Cin varchar(50),
	@SiteId int,
	@CollectionDate datetimeoffset,
	@ReceivedDate datetimeoffset
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				
				DECLARE @AuditTypeIdSample int;
				DECLARE @CurrentStatus int;
				DECLARE @IsSampleCollected int;
				DECLARE @IsSampleAccepted int;
				DECLARE @SampleAuditType int  = 2;
				DECLARE @CollectedStatusId int = 2;
				DECLARE @AcceptedStatusId int = 2;

				-- check whether sample is accepted / collected
				SELECT @IsSampleCollected = COUNT([Id]) FROM [dbo].[TrackingHistory] WHERE [SampleCin] = @Cin AND [StatusId] = 2;
				SELECT @IsSampleAccepted = COUNT([Id]) FROM [dbo].[TrackingHistory] WHERE [SampleCin] = @Cin AND [StatusId] = 3;

				--get current
				SELECT @CurrentStatus = [StatusId] FROM [dbo].[SampleTracking] WHERE [SampleCin] = @Cin;

				-- update sample site
				UPDATE [dbo].[Sample]
				SET [SiteId] = @SiteId
				WHERE [Cin] = @Cin;

				-- insert / update sample collected date
				INSERT INTO [dbo].[TrackingHistory]([TrackingType],[SampleCin],[StatusId],[UsersId])
				SELECT @SampleAuditType,@Cin,@CollectedStatusId,1
				WHERE @IsSampleCollected = 0;

				UPDATE [dbo].[TrackingHistory]
				SET [TimeStamp] = @CollectionDate
				WHERE [SampleCin] = @Cin AND [StatusId] = 2;

				-- insert / update sample received date
				INSERT INTO [dbo].[TrackingHistory]([TrackingType],[SampleCin],[StatusId],[UsersId])
				SELECT @SampleAuditType,@Cin,@AcceptedStatusId,1
				WHERE @AcceptedStatusId = 0;

				UPDATE [dbo].[TrackingHistory]
				SET [TimeStamp] = @ReceivedDate
				WHERE [SampleCin] = @Cin AND [StatusId] = 3;



				-- AUDIT
				SELECT @AuditTypeIdSample = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				VALUES(@AuditTypeIdSample, @Cin,@CurrentStatus, 'Sample Update.... site, collected and received dates.');

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;
