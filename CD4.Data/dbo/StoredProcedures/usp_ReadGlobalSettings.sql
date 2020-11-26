CREATE PROCEDURE [dbo].[usp_ReadGlobalSettings]
AS
BEGIN
	SELECT [Id]
		  ,[VerifyNidPpOnOrder] 
	FROM [dbo].[GlobalSettings];
END
