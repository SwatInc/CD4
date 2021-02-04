CREATE PROCEDURE [dbo].[usp_LoadScriptByName]
	@Name varchar(50)
AS
BEGIN
	SELECT [Script] FROM [dbo].[CSScript] WHERE [Name] = @Name;
END
