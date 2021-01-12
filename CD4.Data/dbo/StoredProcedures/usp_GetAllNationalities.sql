CREATE PROCEDURE [dbo].[usp_GetAllNationalities]
AS
BEGIN
SET NOCOUNT ON;
	SELECT 
	 [Id]
	,[Country]
	FROM [dbo].[Country];
END
