CREATE TABLE [dbo].[ResultType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_ResultType_Name] UNIQUE ([Name])
)
