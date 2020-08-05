--Marks the sample and associated tests as collected and set sample collected date to current SQL server datetime
CREATE PROCEDURE [dbo].[usp_MarkSampleCollected]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @AuditType int;
	DECLARE @Username varchar(50);

	--Set sample status as collected  and set collected date.
	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = 2,
		[CreatedAt] = GETDATE()
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;
	--Set associated test statuses as collected
	UPDATE [dbo].[ResultTracking]
	SET [StatusId] = 2
	WHERE  [StatusId] =1 AND [ResultId] IN
			(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin);
	--audit trail
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @AuditType = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details]) 
	VALUES (@AuditType,@Cin,2,'Sample '+@Cin+ ' is marked as collected by user, '+@Username);

END
