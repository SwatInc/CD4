CREATE TABLE [dbo].[ResultTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResultId] INT NOT NULL UNIQUE, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_ResultTracking_Result] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[Result]([Id]),
    CONSTRAINT [FK_ResultTracking_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status]([Id]),
    CONSTRAINT [FK_ResultTracking_Users] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users]([Id])
)
