CREATE TABLE [dbo].[Scientist]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Scientist_Name] UNIQUE ([Name])
)
