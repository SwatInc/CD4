--Marks the sample and associated tests as collected and set sample collected date to current SQL server datetime
CREATE PROCEDURE [dbo].[usp_MarkSampleCollected]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @AuditType int;
	DECLARE @Username varchar(50);
	DECLARE @EffectedResultIds TABLE ([Id] INT NOT NULL UNIQUE)

	--Set sample status as collected  and set collected date.
	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = 2,
		[CreatedAt] = GETDATE()
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;
	--Set associated test statuses as collected
	INSERT INTO @EffectedResultIds ([Id])
	SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;

	UPDATE [dbo].[ResultTracking]
	SET [StatusId] = 2
	WHERE  [StatusId] = 1 AND [ResultId] IN
			(SELECT [Id] FROM @EffectedResultIds);

	-- TRACKING HISTORY
	-- sample
	INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId]) VALUES
	(2,@Cin,2,@UserId);
	-- result
	INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId])
	SELECT 2, [Id],2,@Userid FROM @EffectedResultIds;

	--audit trail
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @AuditType = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditType,@Cin,2,'Sample '+@Cin+ ' is marked as collected by user, '+@Username);

END
