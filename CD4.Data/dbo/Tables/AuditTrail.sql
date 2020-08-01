CREATE TABLE [dbo].[AuditTrail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuditTypeId] INT NOT NULL, 
    [StatusId] INT NOT NULL, 
    [Details] VARCHAR(2000) NULL, 
    [CreatedAt] DATETIME2 NULL DEFAULT GETDATE()
)
