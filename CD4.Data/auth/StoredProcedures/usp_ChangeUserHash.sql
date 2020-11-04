CREATE PROCEDURE [dbo].[usp_ChangeUserHash]
	@PasswordHash varchar(1000),
	@UserName varchar(256)
AS
BEGIN
	UPDATE [dbo].[Users]
	SET [PasswordHash] = @PasswordHash
	WHERE [Username] = @UserName;
END
