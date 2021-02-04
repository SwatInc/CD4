CREATE TABLE [dbo].[Analyser]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] varchar(50),
	[Serial] varchar(50),
	[DisciplineId] int, 
    CONSTRAINT [FK_Analyser_Discipline] FOREIGN KEY ([DisciplineId]) REFERENCES [dbo].[Discipline]([Id])
)
