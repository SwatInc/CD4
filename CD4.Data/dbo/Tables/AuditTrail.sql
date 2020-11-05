CREATE TABLE [dbo].[AuditTrail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AuditTypeId] INT NOT NULL,
    [Cin] varchar(50) not null DEFAULT 'NA',
    [StatusId] INT NOT NULL, 
    [Details] VARCHAR(2000) NULL, 
    [CreatedAt] DATETIMEOFFSET NULL DEFAULT SYSDATETIMEOFFSET()
)
