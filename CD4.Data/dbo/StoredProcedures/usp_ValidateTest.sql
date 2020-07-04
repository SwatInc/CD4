--validates the specified sample and return distinct testStatus of all the tests in the sample.
CREATE PROCEDURE [dbo].[usp_ValidateTest]
	@Cin varchar(50),
	@TestDescription varchar(50),
	@TestStatus int
AS	
BEGIN
SET NOCOUNT ON;
--variable for storing test Id
	DECLARE @TestId int;
--fetch the test Id from description
	SELECT @TestId = [Id] FROM [dbo].[Test] WHERE [Description] = @TestDescription;
--the query to update the specified test status to validated status.
	UPDATE [dbo].[Result]
	SET [StatusId] = @TestStatus
	WHERE [Sample_Cin] = @Cin AND [TestId] = @TestId;
--select the distinct status for all the tests in the sample.
	SELECT DISTINCT([StatusId]) FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;
END
