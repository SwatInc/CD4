CREATE PROCEDURE [dbo].[usp_InsertAcceptedDateTimeForSampleFromBilling]
	@Cin varchar(50),
	@AcceptedAt char(19) -- format 'yyyy-MM-dd HH:mm:ss'
AS
BEGIN
	
	DECLARE @StatusId int;
	DECLARE @AuditTypeId int;

	-- get the status Id for received to insert the Accepted date for received status
	SELECT @StatusId = [Id] 
	FROM [dbo].[Status] 
	WHERE [Status] = 'Received';

	SELECT @AuditTypeId  = [Id]
	FROM [dbo].[AuditTypes]
	WHERE [Description] = 'Sample';
	
	INSERT INTO [dbo].[TrackingHistory]([TrackingType],[SampleCin],[StatusId],[UsersId],[TimeStamp])
	VALUES (@AuditTypeId,@Cin,@StatusId,1,@AcceptedAt);

	-- tracking history
	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditTypeId,@Cin,@StatusId,CONCAT('Sample accepted datetime' ,@AcceptedAt,' inserted as received from billing.'));

END
