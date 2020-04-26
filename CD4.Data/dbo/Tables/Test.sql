CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [ResultDataTypeId] INT NOT NULL, 
    [Mask] VARCHAR(50) NOT NULL, 
    [Reportable] BIT NOT NULL, 
    CONSTRAINT [FK_Test_ResultDataType] FOREIGN KEY ([ResultDataTypeId]) REFERENCES [dbo].[ResultDataType]([Id])
)
