CREATE TABLE [dbo].[SampleTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SampleCin] VARCHAR(50) NOT NULL UNIQUE, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_SampleTracking_Sample] FOREIGN KEY ([SampleCin]) REFERENCES [dbo].[Sample]([Cin]),
    CONSTRAINT [FK_SampleTracking_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status]([Id]), 
    CONSTRAINT [FK_SampleTracking_Users] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users]([Id])
)
