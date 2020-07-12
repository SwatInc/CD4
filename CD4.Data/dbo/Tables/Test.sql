CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Discipline] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(50) NOT NULL,
    [SampleTypeId] INT NOT NULL,
    [ResultDataTypeId] INT NOT NULL, 
    [Mask] VARCHAR(50) NOT NULL,
    [Unit] VARCHAR(10) NULL,
    [Reportable] BIT NOT NULL, 
    CONSTRAINT [FK_Test_ResultDataType] FOREIGN KEY ([ResultDataTypeId]) REFERENCES [dbo].[ResultDataType]([Id]), 
    CONSTRAINT [AK_Test_Description] UNIQUE ([Description]), 
    CONSTRAINT [FK_Test_SampleType] FOREIGN KEY ([SampleTypeId]) REFERENCES [SampleType]([Id])
)
