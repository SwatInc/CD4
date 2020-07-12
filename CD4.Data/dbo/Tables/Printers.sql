CREATE TABLE [dbo].[Printers]
(
	[Id] INT NOT NULL IDENTITY,
	[Description] varchar(100) NOT NULL,
    CONSTRAINT [PK_Printers] PRIMARY KEY ([Id]), 
)
