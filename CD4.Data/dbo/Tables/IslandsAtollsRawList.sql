CREATE TABLE [dbo].[IslandsAtollsRawList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AtollOrIsland] nvarchar(100) NOT NULL UNIQUE,
	[IsAtoll] bit NOT NULL
)
