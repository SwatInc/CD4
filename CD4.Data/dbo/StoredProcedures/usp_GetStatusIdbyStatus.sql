CREATE PROCEDURE [dbo].[usp_GetStatusIdbyStatus]
	@Status varchar(10)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [S].[Id]
	FROM [dbo].[Status] [S]
	WHERE [S].[Status] = @Status;
END
