CREATE TABLE [dbo].[BillingTestCodeMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestId] INT NOT NULL,
	[BillingTestId] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_BillingTestCodeMap_Tests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id])
)
