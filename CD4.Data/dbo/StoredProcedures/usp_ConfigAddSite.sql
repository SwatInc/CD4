CREATE PROCEDURE [dbo].[usp_ConfigAddSite]
	@SiteName varchar(100)
AS
BEGIN
	INSERT INTO [dbo].[Sites] ([Name])
	OUTPUT INSERTED.[Id], [INSERTED].[Name] AS [Site]
	VALUES (@SiteName)
END
