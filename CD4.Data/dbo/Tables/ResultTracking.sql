CREATE TABLE [dbo].[ResultTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResultId] INT NOT NULL, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL
)
