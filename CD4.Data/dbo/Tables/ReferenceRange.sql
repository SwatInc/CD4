CREATE TABLE [dbo].[ReferenceRange]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestId] INT NOT NULL,
	[GenderId] INT NOT NULL,
	[FromAgeDays] INT NOT NULL,
	[ToAgeDays] INT NOT NULL,
	[DeltaValidityIntervalDays] INT NOT NULL,
	[BiasFactor] INT NOT NULL DEFAULT 0, 
    [DisplayNormalRange] VARCHAR(100) NULL, 
    CONSTRAINT [FK_ReferenceRange_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_ReferenceRange_Gender] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Gender]([Id])
)
