CREATE PROCEDURE [dbo].[usp_GetAllUnits]
AS
BEGIN
	SELECT [Id],[Unit]
	FROM [dbo].[Unit];
END
