CREATE PROCEDURE [dbo].[usp_GetHashForUsername]
	@username varchar(256)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [U].[UserName], [U].[PasswordHash]
	FROM [dbo].[Users] [U]
	WHERE [U].[UserName] = @username;
END
