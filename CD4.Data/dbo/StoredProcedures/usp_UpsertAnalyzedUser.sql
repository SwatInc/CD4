CREATE PROCEDURE [dbo].[usp_UpsertAnalyzedUser]
	@SampleCins  [dbo].[SampleCinsUDT] READONLY,
	@UserId int,
	@LoggedInUserId int
AS
BEGIN
	DECLARE @ActionUsername varchar(50);
	DECLARE @LoggedInUserName varchar(50);
	DECLARE @SampleAuditTypeId INT;
	DECLARE @TestedLookupId int;

	--get Tested lookup Id
	SELECT @TestedLookupId = [Id] 
	FROM [dbo].[NdaLookup]
	WHERE [Description] = 'Tested';

	--delete 
	DELETE FROM [dbo].[NdaActionTracking]
	WHERE 
		[NdaLookupId] = @TestedLookupId AND
		[Cin] IN (SELECT [Cin] FROM @SampleCins);

	--insert
	INSERT INTO [dbo].[NdaActionTracking]([Cin],[NdaLookupId],[ActionUserId],[CreatedBy])
	SELECT [Cin],@TestedLookupId,@UserId,@LoggedInUserId
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
		  ,CONCAT(@ActionUsername,' has set ', @LoggedInUserName, ' as the user who processed NDA batch')
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] IN (SELECT [Cin] AS [SampleCin] FROM @SampleCins);	

		--report back the cin and QC and cal validated user for UI updates
	SELECT [A].[Cin],[U].[Fullname]
	FROM [dbo].[NdaActionTracking] [A]
	INNER JOIN [dbo].[Users] [U] ON [U].[Id] = [A].[ActionUserId]
	WHERE [NdaLookupId] = @TestedLookupId AND 
			[Cin] IN (SELECT DISTINCT([Cin]) FROM @SampleCins)
END