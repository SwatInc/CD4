CREATE PROCEDURE [dbo].[usp_GetUserRoleAndClaims]
	@Username varchar(256)
AS
BEGIN
	--role, username, fullname, 
	SELECT [R].[Name] AS [UserRole], [U].[UserName], [U].[Fullname]
	FROM [dbo].[Users] [U]
	INNER JOIN [dbo].[UserRoles] [UR] ON [U].[Id] = [UR].[UserId]
	INNER JOIN [dbo].[Roles] [R] ON [R].[Id] = [UR].[RoleId]
	WHERE [U].[Username] = @Username;

	--claims for all roles
	SELECT [RC].[ClaimValue] AS [Claims]
	FROM [dbo].[Users] [U]
	INNER JOIN [dbo].[UserRoles] [UR] ON [U].[Id] = [UR].[UserId]
	INNER JOIN [dbo].[RoleClaims] [RC] ON [RC].[RoleId] = [UR].[RoleId]
	WHERE [U].[Username] = @Username;;
END
