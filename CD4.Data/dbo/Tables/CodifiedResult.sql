CREATE TABLE [dbo].[CodifiedResult]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_CodifiedResult_Code] UNIQUE ([Code])
)
