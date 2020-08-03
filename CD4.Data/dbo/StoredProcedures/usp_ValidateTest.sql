-- validates the specified sample and return distinct testStatus of all the tests in the sample.
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

END
