CREATE TABLE [dbo].[IslandsAtollsRawList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AtollOrIsland] varchar(100) NOT NULL UNIQUE
)
