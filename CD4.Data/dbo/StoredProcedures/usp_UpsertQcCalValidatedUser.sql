CREATE PROCEDURE [dbo].[usp_UpsertQcCalValidatedUser]
	@SampleCins  [dbo].[SampleCinsUDT] READONLY,
	@UserId int,
	@LoggedInUserId int
AS
BEGIN

	DECLARE @ActionUsername varchar(50);
	DECLARE @LoggedInUserName varchar(50);
	DECLARE @SampleAuditTypeId INT;
	DECLARE @QcCalValidateLookupId int;

	--get QcCalValidated lookup Id
	SELECT @QcCalValidateLookupId = [Id] 
	FROM [dbo].[NdaLookup]
	WHERE [Description] = 'QcAndCalValidated';
	
	--delete 
	DELETE FROM [dbo].[NdaActionTracking]
	WHERE 
		[NdaLookupId] = @QcCalValidateLookupId AND
		[Cin] IN (SELECT [Cin] FROM @SampleCins);

	--insert
	INSERT INTO [dbo].[NdaActionTracking]([Cin],[NdaLookupId],[ActionUserId],[CreatedBy])
	SELECT [Cin],@QcCalValidateLookupId,@UserId,@LoggedInUserId
	FROM @SampleCins;

	--audit
	-- get logged in username and action username
	SELECT @ActionUsername = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @LoggedInUserName = [UserName] FROM [dbo].[Users] WHERE [Id] = @LoggedInUserId;

	SELECT @SampleAuditTypeId = [Id]
	FROM [dbo].[AuditTypes]
	WHERE [Description] = 'Sample';

	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
	SELECT @SampleAuditTypeId
		  ,[SampleCin] AS [Cin]
		  ,[StatusId]
		  ,CONCAT(@ActionUsername, ' set as QC and Cal validated user by user: ',@LoggedInUserName)
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] IN (SELECT [Cin] AS [SampleCin] FROM @SampleCins);	

		--report back the cin and QC and cal validated user for UI updates
	SELECT [A].[Cin],[U].[Fullname]
	FROM [dbo].[NdaActionTracking] [A]
	INNER JOIN [dbo].[Users] [U] ON [U].[Id] = [A].[ActionUserId]
	WHERE [NdaLookupId] = @QcCalValidateLookupId AND 
			[Cin] IN (SELECT DISTINCT([Cin]) FROM @SampleCins)

END
