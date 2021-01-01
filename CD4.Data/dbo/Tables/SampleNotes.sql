CREATE TABLE [dbo].[SampleNotes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL, 
    [Note] VARCHAR(200) NOT NULL, 
    [IsAttended] BIT NOT NULL DEFAULT 0, 
    [UserId] INT NOT NULL, 
    [TimeStamp] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET( ) , 
    CONSTRAINT [FK_SampleNotes_Sample] FOREIGN KEY ([Cin]) REFERENCES [dbo].[Sample]([Cin]), 
    CONSTRAINT [FK_SampleNotes_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id])
)
