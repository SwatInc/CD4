CREATE PROCEDURE [dbo].[usp_ReadGlobalSettings]
AS
BEGIN
	SELECT [JsonSettings] 
	FROM [dbo].[GlobalSettings];
END
