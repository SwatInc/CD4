CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [ResultType] INT NOT NULL, 
    [Mask] VARCHAR(50) NOT NULL, 
    [Reportable] BIT NOT NULL
)
