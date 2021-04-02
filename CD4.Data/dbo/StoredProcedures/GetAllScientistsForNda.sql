CREATE PROCEDURE [dbo].[usp_GetAllScientistsForNda]
AS
BEGIN
	SELECT [Id],[FullName] AS [Scientist] FROM [dbo].[Users];
END
