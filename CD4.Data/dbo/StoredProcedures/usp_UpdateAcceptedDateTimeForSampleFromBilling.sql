CREATE PROCEDURE [dbo].[usp_UpdateAcceptedDateTimeForSampleFromBilling]
	@Cin varchar(50),
	@AcceptedAt char(19) -- format 'yyyy-MM-dd HH:mm:ss'
AS
BEGIN

/*========= IMPORTANT: DO NOT CALL THIS DIRECTLY. USE [dbo].[DecideAndExecInsertOrUpdateSampleAcceptedDatetime] ===============*/

		DECLARE @AcceptedStatusId int;
		DECLARE @AuditTypeId int;

		DECLARE @AcceptedDate DATETIMEOFFSET(7) = CAST(@AcceptedAt AS DATETIME) AT TIME ZONE 'Pakistan Standard Time';
			
		-- get the status Id for received to insert the Accepted date for received status
		SELECT @AcceptedStatusId = [Id] 
		FROM [dbo].[Status] 
		WHERE [Status] = 'Received';

		SELECT @AuditTypeId  = [Id]
		FROM [dbo].[AuditTypes]
		WHERE [Description] = 'Sample';

		UPDATE [dbo].[TrackingHistory] 
		SET [TimeStamp] = @AcceptedDate
		WHERE 
			[StatusId] = @AcceptedStatusId AND
			[SampleCin] = @Cin;

		-- tracking history
		INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details]) 
		VALUES (@AuditTypeId,@Cin,@AcceptedStatusId,CONCAT('Sample accepted datetime' ,@AcceptedDate,' updated as received from billing.'));

END
