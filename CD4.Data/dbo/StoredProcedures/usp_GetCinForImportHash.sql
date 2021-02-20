CREATE PROCEDURE [dbo].[usp_GetCinForImportHash]
	@Hash INT
AS
BEGIN
	SELECT [Cin] 
	FROM [dbo].[BulkImportedHash] 
	WHERE [Hash] = @Hash;
END
