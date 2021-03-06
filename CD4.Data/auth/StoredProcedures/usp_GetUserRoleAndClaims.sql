﻿CREATE PROCEDURE [dbo].[usp_GetUserRoleAndClaims]
	@Username varchar(256)
AS
BEGIN

	DECLARE @Claims varchar(1000);

		--claims for all roles
	SELECT @Claims  = STRING_AGG([RC].[ClaimValue],',')
	FROM [dbo].[Users] [U]
	INNER JOIN [dbo].[UserRoles] [UR] ON [U].[Id] = [UR].[UserId]
	INNER JOIN [dbo].[RoleClaims] [RC] ON [RC].[RoleId] = [UR].[RoleId]
	WHERE [U].[UserName] = @Username;

	--role, username, fullname, 
	SELECT [R].[Name] AS [UserRole]
	, [U].[UserName]
	, [U].[Fullname]
	, @Claims AS [ClaimsCsv]
	, [U].[Id] AS [UserId]
	FROM [dbo].[Users] [U]
	INNER JOIN [dbo].[UserRoles] [UR] ON [U].[Id] = [UR].[UserId]
	INNER JOIN [dbo].[Roles] [R] ON [R].[Id] = [UR].[RoleId]
	WHERE [U].[UserName] = @Username;

END
