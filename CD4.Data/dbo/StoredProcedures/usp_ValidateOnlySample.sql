CREATE PROCEDURE [dbo].[usp_ValidateOnlySample]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @AuditTypeId int;
	DECLARE @StatusDescription varchar(50);
	DECLARE @Username varchar(50);

	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = 5
	WHERE [SampleCin] = @Cin;

	-- TRACKING HISTORY
	INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId]) VALUES
	(2,@Cin,5,@UserId);

	--AUDIT TRAIL
	--prep for insert
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @AuditTypeId  = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
	SELECT @StatusDescription = [Status] FROM [dbo].[Status] WHERE [Id] = 5;
	--insert audit trail
	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditTypeId,@Cin,5,CONCAT('Sample ',@cin,', status changed to ',@StatusDescription,' by user ',@Username));

END