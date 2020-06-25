CREATE PROCEDURE [dbo].[usp_GetAllStatus]
AS
BEGIN
SET NOCOUNT ON;
	--get all status
	SELECT [Id], [Status] FROM [dbo].[Status];
END