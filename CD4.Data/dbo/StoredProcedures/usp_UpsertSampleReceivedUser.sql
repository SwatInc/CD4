CREATE PROCEDURE [dbo].[usp_UpsertSampleReceivedUser]
	@SampleCin varchar(50),
	@SampleReceivedUserId int,
	@LoggedInUserId int
AS
BEGIN
	DECLARE @ActionUsername varchar(50);
	DECLARE @LoggedInUserName varchar(50);
	DECLARE @SampleAuditTypeId INT;
	DECLARE @SampleReceivedLookupId int;

	--get Received lookup Id
	SELECT @SampleReceivedLookupId = [Id] 
	FROM [dbo].[NdaLookup]
	WHERE [Description] = 'Received';

	--delete
	DELETE FROM [dbo].[NdaActionTracking]
	WHERE 
		[NdaLookupId] = @SampleReceivedLookupId AND
		[Cin] = @SampleCin;

	--insert
	INSERT INTO [dbo].[NdaActionTracking]([Cin],[NdaLookupId],[ActionUserId],[CreatedBy])
	VALUES
	(@SampleCin,@SampleReceivedLookupId,@SampleReceivedUserId,@LoggedInUserId);

	--audit
	-- get logged in username and action username
	SELECT @ActionUsername = [UserName] FROM [dbo].[Users] WHERE [Id] = @SampleReceivedUserId;
	SELECT @LoggedInUserName = [UserName] FROM [dbo].[Users] WHERE [Id] = @LoggedInUserId;

	SELECT @SampleAuditTypeId = [Id]
	FROM [dbo].[AuditTypes]
	WHERE [Description] = 'Sample';

	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
	SELECT @SampleAuditTypeId
		  ,[SampleCin] AS [Cin]
		  ,[StatusId]
		  ,CONCAT(@LoggedInUserName, ' marked sample ', @SampleCin,' as received by user: ', @ActionUsername)
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] = @SampleCin;	

END
