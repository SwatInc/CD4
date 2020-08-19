CREATE TABLE [dbo].[AuditTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL -- 1. Request, 2. Sample and 3. Test
)
