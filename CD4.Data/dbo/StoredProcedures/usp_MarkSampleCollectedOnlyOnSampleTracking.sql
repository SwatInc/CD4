-- marks sample tracking as collected. But does not change Tracking History [Already collected sample received].
CREATE PROCEDURE [dbo].[usp_MarkSampleCollectedOnlyOnSampleTracking]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @AuditType int;
	DECLARE @Username varchar(50);
	DECLARE @EffectedResultIds TABLE ([Id] INT NOT NULL UNIQUE)
	DECLARE @SampleCollectedTimeStamp DATETIMEOFFSET;

	--Set sample status as collected  and set collected date.
	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = 2,
		[CreatedAt] = SYSDATETIMEOFFSET()
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;
	--Set associated test statuses as collected
	INSERT INTO @EffectedResultIds ([Id])
	SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;

	UPDATE [dbo].[ResultTracking]
	SET [StatusId] = 2
	WHERE  [StatusId] = 1 AND [ResultId] IN
			(SELECT [Id] FROM @EffectedResultIds);

	-- TRACKING HISTORY
	-- Sample tracking history has already been entered earlier if this usp is used
	--INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId]) VALUES
	--(2,@Cin,2,@UserId);
	-- result

	--get sample collected timestamp on tracking history
	SELECT @SampleCollectedTimeStamp = [TimeStamp] FROM [dbo].[TrackingHistory] WHERE
	[SampleCin] = @Cin AND [TrackingType] = 2 AND [StatusId] = 2;

	INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId],[TimeStamp])
	SELECT 2, [Id],2,@UserId,@SampleCollectedTimeStamp FROM @EffectedResultIds;

	--audit trail
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @AuditType = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditType,@Cin,2,'Sample '+@Cin+ ' is marked as collected by user, '+@Username);

END
