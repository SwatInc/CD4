CREATE PROCEDURE [dbo].[usp_CollectLateRegisteredTests]
	@Cin varchar(50),
	@UserId int
AS
BEGIN

	DECLARE @IsSampleStatusChangeRequired int = 0;
	DECLARE @ResultIds TABLE(ResultId int);
	DECLARE @UpdatedTests varchar(200);
	DECLARE @UpdatedTestsCount int;
	DECLARE @SampleAuditTypeId int;
	DECLARE @UserName varchar(50);

	SELECT @SampleAuditTypeId = [Id]
    FROM [dbo].[AuditTypes]
    WHERE [Description] = 'Sample';

	Update [dbo].[ResultTracking]
	SET [StatusId] = 2,
		[UsersId] = @UserId
	OUTPUT INSERTED.[ResultId] INTO @ResultIds
	WHERE [Id] IN 
			( 
				SELECT [rt].[Id] FROM [dbo].[ResultTracking] [rt]
				INNER JOIN [dbo].[Result] [r] on [rt].[ResultId] = [r].[Id]
				WHERE [r].[Sample_Cin] = @Cin AND [StatusId] = 1
			);

	SELECT @UpdatedTestsCount = COUNT(*) FROM @ResultIds;

	SELECT @IsSampleStatusChangeRequired  = COUNT(Id) 
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] = @Cin AND [StatusId] = 5;

	UPDATE [dbo].[SampleTracking] 
	SET [StatusId] = 2 
	WHERE [SampleCin] = @Cin AND @IsSampleStatusChangeRequired > 0;

	--Audit
	IF(@IsSampleStatusChangeRequired > 0)
	BEGIN
	--extract this out to a stored procedure.
		INSERT INTO [dbo].[AuditTrail]
        (
            [AuditTypeId],
            [Cin],
            [StatusId],
            [Details]
        )
        VALUES
        (@SampleAuditTypeId, @Cin, 7, CONCAT('Sample ',@Cin, ' status changed from validated to collected on new tests collection'));
	END

	SELECT @UpdatedTests =  STRING_AGG([T].[Description], ' | ')
	FROM [dbo].[Test] [T]
	INNER JOIN [dbo].[Result] [R] ON [T].[Id] = [R].[TestId]
	WHERE [R].[Id] IN (SELECT [ResultId] FROM @ResultIds);

	SELECT @UserName = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;

	INSERT INTO [dbo].[AuditTrail]
    (
        [AuditTypeId],
        [Cin],
        [StatusId],
        [Details]
    )
    VALUES
    (@SampleAuditTypeId, @Cin, 7, CONCAT('New Tests collected by user: ',@UserName,'. Collected tests: ', @UpdatedTests));

END