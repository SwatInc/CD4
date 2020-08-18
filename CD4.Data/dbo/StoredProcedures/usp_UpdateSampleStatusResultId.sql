CREATE PROCEDURE [dbo].[usp_UpdateSampleStatusResultId]
	@ResultId int,
	@SampleStatus int,
	@UserId int
AS
BEGIN
	--variables
	DECLARE @cin varchar(50);
	DECLARE @AuditTypeId int;
	DECLARE @StatusDescription varchar(50);
	DECLARE @Username varchar(50);

	--get cin
	SELECT @cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;
	--update sample status
	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = @SampleStatus
	WHERE [SampleCin] = @cin;

	-- TRACKING HISTORY
	INSERT INTO [dbo].[TrackingHistory]([TrackingType],[SampleCin],[StatusId],[UsersId]) VALUES
	(2,@Cin,@SampleStatus,@UserId);

	--AUDIT TRAIL
	--prep for insert
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @AuditTypeId  = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
	SELECT @StatusDescription = [Status] FROM [dbo].[Status] WHERE [Id] = @SampleStatus;
	--insert audit trail
	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditTypeId,@cin,@SampleStatus,'Sample ' +@cin+ ', status changed to '+ @StatusDescription+' by user '+@Username)
	
END