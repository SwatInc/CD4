CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DisciplineId] INT NOT NULL,
    [Description] VARCHAR(50) NOT NULL,
    [SampleTypeId] INT NOT NULL,
    [ResultDataTypeId] INT NOT NULL, 
    [Mask] VARCHAR(50) NOT NULL,
    [UnitId] INT NOT NULL,
    [Reportable] BIT NOT NULL, 
    [DeafultCommented] BIT NOT NULL,
    CONSTRAINT [FK_Test_ResultDataType] FOREIGN KEY ([ResultDataTypeId]) REFERENCES [dbo].[ResultDataType]([Id]), 
    CONSTRAINT [AK_Test_Description] UNIQUE ([Description]), 
    CONSTRAINT [FK_Test_SampleType] FOREIGN KEY ([SampleTypeId]) REFERENCES [SampleType]([Id]), 
    CONSTRAINT [FK_Test_Discipline] FOREIGN KEY ([DisciplineId]) REFERENCES [Discipline]([Id]), 
    CONSTRAINT [FK_Test_Unit] FOREIGN KEY ([UnitId]) REFERENCES [Unit]([Id])
)
