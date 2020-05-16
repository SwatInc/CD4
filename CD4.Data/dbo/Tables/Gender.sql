CREATE TABLE [dbo].[Gender]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Gender] VARCHAR(13) NOT NULL, 
    CONSTRAINT [AK_Gender_Gender] UNIQUE ([Gender])

)
