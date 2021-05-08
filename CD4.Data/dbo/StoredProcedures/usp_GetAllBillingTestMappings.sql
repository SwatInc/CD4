CREATE PROCEDURE [dbo].[usp_GetAllBillingTestMappings]
AS
BEGIN
	SELECT 
		[Id],
		[TestId],
		[BillingTestId]
	FROM [dbo].[BillingTestCodeMap]
END

