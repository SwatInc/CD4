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

				--get current
				SELECT @CurrentStatus = [StatusId] FROM [dbo].[SampleTracking] WHERE [SampleCin] = @Cin;

				-- update sample site
				UPDATE [dbo].[Sample]
				SET [SiteId] = @SiteId
				WHERE [Cin] = @Cin;

				-- insert / update sample collected date
				UPDATE [dbo].[TrackingHistory]
				SET [TimeStamp] = @CollectionDate
				WHERE [SampleCin] = @Cin AND [StatusId] = 2
				-- insert / update sample received date
				UPDATE [dbo].[TrackingHistory]
				SET [TimeStamp] = @CollectionDate
				WHERE [SampleCin] = @Cin AND [StatusId] = 3

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
