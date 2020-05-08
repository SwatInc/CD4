CREATE PROCEDURE [dbo].[usp_GetAllAtollAndIslands]
AS
BEGIN
SET NOCOUNT ON;
SELECT [a].[Id],[a].[Atoll],[a].[Island] FROM [dbo].[Atoll][a];
END
