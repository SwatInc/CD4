CREATE PROCEDURE [dbo].[usp_ValidateSampleAndApplicableAssociatedTests]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @NotValidatedNotRejectedCount int = 0;
	DECLARE @ValidatedTestsBeforeCurrentValidation_ForAudit varchar(500);
	DECLARE @ValidatedTestsAfterCurrentValidation_ForAudit varchar(500);
	
	--AUDIT TRAIL BEFORE VALIDATION
	--read test status for all tests


	--validate the relavent tests that can be validated.
	--Note: StatusId 5 => Validated, StatusId 4 => ToValidate, StatusId 7 => Rejected
	UPDATE [dbo].[ResultTracking]
		SET [StatusId] = 5
	WHERE [StatusId] = 4 AND [ResultId] IN (
	SELECT [Id] FROM [dbo].[Result] --Sub query: gets ResultIds Cin-matching tests with result
	WHERE [Sample_Cin] = @Cin  AND ([Result] <> NULL OR [Result] <> ''));

	--do a count of not validated AND not rejected for the sample
	SELECT @NotValidatedNotRejectedCount =  COUNT([RT].[StatusId]) 
	FROM [dbo].[ResultTracking] [RT]
    WHERE ([RT].[StatusId] <> 5 AND [RT].[StatusId] <> 7) AND [ResultId] IN
		(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin);
	--If @NotValidatedNotRejectedCount = 0 then exec usp to validate the sample.
	IF @NotValidatedNotRejectedCount = 0
		BEGIN
			EXECUTE [dbo].[usp_ValidateOnlySample]
			@Cin = @Cin;
		END

	-- 1. select validated sample status and 2. test status for all tests in sample.
	SELECT [SampleCin] AS [Cin],[StatusId] FROM [dbo].[SampleTracking] WHERE [SampleCin] = @Cin;
	SELECT [R].[Id] AS [TestId], [RT].[StatusId] 
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
	WHERE [Sample_Cin] = @Cin;
END
