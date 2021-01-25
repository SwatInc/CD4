CREATE PROCEDURE [dbo].[usp_InsertImportRecordHash]
	@Cin varchar(50),
	@Hash int
AS
BEGIN
	INSERT INTO [dbo].[BulkImportedHash]([Cin],[Hash]) 
	VALUES
	(@Cin, @Hash)
END
