CREATE PROCEDURE [dbo].[usp_GetAllCountries]
AS
BEGIN
SET NOCOUNT ON;
SELECT [c].[Id], [c].[Country] FROM [dbo].[Country] [c];
END