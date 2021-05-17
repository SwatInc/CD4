CREATE PROCEDURE [dbo].[usp_GetAllDisciplines]
AS
BEGIN
	SELECT [Id], [Description] AS [Discipline], [Code]
	FROM [dbo].[Discipline];
END
