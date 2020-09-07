CREATE PROCEDURE [dbo].[usp_GetAllCodifiedValues]
AS
BEGIN
	SELECT [Id], [Code] AS [CodifiedValue]
	FROM [dbo].[CodifiedResult];
END