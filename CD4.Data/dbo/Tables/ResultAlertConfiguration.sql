CREATE TABLE [dbo].[ResultAlertConfiguration]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestId] INT NOT NULL,
	[Result] VARCHAR(100) NOT NULL,
	[AlertMessage] VARCHAR(100) NOT NULL,
	[Operator] VARCHAR(2) NOT NULL, 
    [IsEnabled] BIT NOT NULL, 
    CONSTRAINT [FK_ResultAlertConfiguration_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id])
)
