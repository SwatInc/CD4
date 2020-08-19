-- validates the specified tests and return distinct testStatus of all the tests in the sample.
CREATE PROCEDURE [dbo].[usp_ValidateTest]
	@Cin varchar(50),
	@TestDescription varchar(50),
	@TestStatus int
AS	
BEGIN
SET NOCOUNT ON;
-- variable for storing test Id and ResultId
	DECLARE @TestId int;
	DECLARE @ResultId int;
	DECLARE @AuditTypeIdTest int;
	DECLARE @StatusText varchar(50);
	DECLARE @TestResult_Audit varchar(50);

-- fetch the test Id from description
	SELECT @TestId = [Id] FROM [dbo].[Test] WHERE [Description] = @TestDescription;

-- fetch resultId with Cin
	SELECT @ResultId = [R].[Id] 
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
	WHERE [Sample_Cin] = @Cin AND [T].[Description] = @TestDescription;

-- the query to update the specified test status to validated status.
	UPDATE [dbo].[ResultTracking]
	SET [StatusId] = @TestStatus
	WHERE [ResultId] = @ResultId;

-- select the distinct status for all the tests in the sample.
	SELECT DISTINCT([StatusId]) 
	FROM [dbo].[ResultTracking] [RT]
	WHERE [RT].[ResultId] IN --sub query gets all ResultIds corresponding to the Cin
		(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin);

-- tracking history
	INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId]) VALUES
	(3,@ResultId,@TestStatus,1);

-- audit trail
	--select audit type and status text(eg: validated instead of Id) 
	SELECT @AuditTypeIdTest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
	SELECT @StatusText = [Status] FROM [dbo].[Status] WHERE [Id] = @TestStatus;
	--select test result
	SELECT @TestResult_Audit = [Result] FROM [dbo].[Result] WHERE [Id]  = @ResultId;
	--insert audit trail
	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details])
	VALUES (@AuditTypeIdTest,@Cin,@TestStatus,
	'Test status of '+@TestDescription+ ' changed to '+ @StatusText +' with result ' + @TestResult_Audit);
END
