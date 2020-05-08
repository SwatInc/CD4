CREATE PROCEDURE [dbo].[usp_GetAllGenders]
AS
BEGIN
SET NOCOUNT ON;
SELECT [g].[Id], [g].[Gender] FROM [dbo].[Gender] [g];
END