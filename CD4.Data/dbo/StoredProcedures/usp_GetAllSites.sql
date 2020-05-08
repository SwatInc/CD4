CREATE PROCEDURE [dbo].[usp_GetAllSites]

AS
BEGIN
SET NOCOUNT ON;
SELECT [s].[Id], [s].[Name] AS [Site] FROM [dbo].[Sites][s];
END
