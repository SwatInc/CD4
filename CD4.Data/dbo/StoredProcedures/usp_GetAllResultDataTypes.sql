CREATE PROCEDURE [dbo].[usp_GetAllResultDataTypes]
AS
BEGIN
	SELECT [Id],[Name] AS [DataType]
	FROM [dbo].[ResultDataType];
END