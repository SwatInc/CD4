CREATE TABLE [dbo].[BulkImportedHash]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Cin] VARCHAR(50) NOT NULL,
	[Hash] INT NOT NULL,
    CONSTRAINT [AK_BulkImportedHash_Hash] UNIQUE ([Hash])
)
