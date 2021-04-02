CREATE PROCEDURE [dbo].[usp_GetAllScientistsForNda]
AS
BEGIN
	SELECT [Id],[Fullname] AS [Scientist] FROM [dbo].[Users];
END
