CREATE PROCEDURE [dbo].[usp_ValidateSampleAndApplicableAssociatedTests]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @NotValidatedNotRejectedCount int = 0;
	--validate the relavent tests that can be validated.
	--Note: StatusId 5 => Validated, StatusId 4 => ToValidate, StatusId 7 => Rejected
	UPDATE [dbo].[Result]
	SET [StatusId] = 5
	WHERE [Sample_Cin] = @Cin AND [StatusId] = 4 AND ([Result] <> NULL OR [Result] <> '');
	
	--do a count of not validated AND not rejected for the sample
    SELECT @NotValidatedNotRejectedCount =  COUNT([StatusId]) 
	FROM [dbo].[Result] [R]
    WHERE ([R].[StatusId] <> 5 AND [R].[StatusId] <> 7) AND [Sample_Cin] = @Cin;
	--If @NotValidatedNotRejectedCount = 0 then exec usp to validate the sample.
	IF @NotValidatedNotRejectedCount = 0
		BEGIN
			EXECUTE [dbo].[usp_ValidateOnlySample]
			@Cin = @Cin;
		END

	--select validated sample status and test status for all tests in sample.
	SELECT [Cin],[StatusId] FROM [dbo].[Sample] WHERE [Cin] = @Cin;
	SELECT [Id] AS [TestId], [StatusId] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;
END
