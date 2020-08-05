CREATE PROCEDURE [dbo].[usp_ValidateSampleAndApplicableAssociatedTests]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @NotValidatedNotRejectedCount int = 0;
	DECLARE @ValidatedTestsWithResults varchar(500);
	DECLARE @ResultDataToValidate TABLE([ResultId] int not null PRIMARY KEY, [TestDesc] varchar(50),[Result] varchar(50));
	DECLARE @AuditTypeIdTest int;
	DECLARE @StatusText varchar(50);

	--APPLICABLE TEST RESULTS VALIDATION
	--Note: StatusId 5 => Validated, StatusId 4 => ToValidate, StatusId 7 => Rejected
	--get tests that can be validated into a table variable
	INSERT INTO @ResultDataToValidate([ResultId],[TestDesc],[Result])
	SELECT [R].[Id],[T].[Description],[R].[Result] 
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
	WHERE [Sample_Cin] = @Cin  AND ([Result] <> NULL OR [Result] <> '');

	--mark tests as validated
	UPDATE [dbo].[ResultTracking]
		SET [StatusId] = 5
	WHERE [StatusId] = 4 AND [ResultId] IN (SELECT [ResultId] FROM @ResultDataToValidate);

	--SAMPLE VALIDATION IF REQUIRED
	--do a count of not validated AND not rejected for the sample
	SELECT @NotValidatedNotRejectedCount =  COUNT([RT].[StatusId]) 
	FROM [dbo].[ResultTracking] [RT]
    WHERE ([RT].[StatusId] <> 5 AND [RT].[StatusId] <> 7) AND [ResultId] IN
		(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin);
	--If @NotValidatedNotRejectedCount = 0 then exec usp to validate the sample.
	IF @NotValidatedNotRejectedCount = 0
		BEGIN
			EXECUTE [dbo].[usp_ValidateOnlySample]
			@Cin = @Cin,
			@UserId = @UserId;
			-- Audit for sample trail done in the [dbo].[usp_ValidateOnlySample]
		END

	--SELECTING RETURN DATA
	-- 1. select validated sample status and 2. test status for all tests in sample.
	SELECT [SampleCin] AS [Cin],[StatusId] FROM [dbo].[SampleTracking] WHERE [SampleCin] = @Cin;
	SELECT [R].[Id] AS [TestId], [RT].[StatusId] 
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
	WHERE [Sample_Cin] = @Cin;

	--AUDIT TRAIL... (NOTE: Audit for sample trail done in the [dbo].[usp_ValidateOnlySample])
	/*
-- audit trail
	--select audit type and status text(eg: validated instead of Id) 
	SELECT @AuditTypeIdTest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
	SELECT @StatusText = [Status] FROM [dbo].[Status] WHERE [Id] = @TestStatus;

	--insert audit trail
	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details])
	VALUES (@AuditTypeIdTest,@Cin,@TestStatus,
			'Test status of '+@TestDescription+ ' changed to '+ @StatusText);

	*/
	SELECT @AuditTypeIdTest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
	SELECT @StatusText = [Status] FROM [dbo].[Status] WHERE [Id] = 5;

	SELECT @ValidatedTestsWithResults = STRING_AGG([TestDesc]+': '+[Result],'|') FROM @ResultDataToValidate

	--insert audit trail
	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details])
	VALUES (@AuditTypeIdTest,@Cin,5,'Validated: ' + @ValidatedTestsWithResults);

END
