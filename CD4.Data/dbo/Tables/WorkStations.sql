CREATE TABLE [dbo].[WorkStations]
(
	[Id] INT NOT NULL IDENTITY,
	[Description] varchar(100) NOT NULL, 
    CONSTRAINT [PK_WorkStations] PRIMARY KEY ([Id]),
)
