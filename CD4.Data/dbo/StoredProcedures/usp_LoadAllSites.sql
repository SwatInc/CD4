CREATE PROCEDURE [dbo].[usp_LoadAllSites]
AS
BEGIN
	SELECT [Id],[Name] AS [Site] FROM [dbo].[Sites];
END
