CREATE TABLE [dbo].[Country]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Country] VARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Country_Country] UNIQUE ([Country])
)
