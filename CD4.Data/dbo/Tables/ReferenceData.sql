CREATE TABLE [dbo].[ReferenceData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ReferenceRangeId] INT NOT NULL,
	[ReferenceTypeId] INT NOT NULL,
	[HighLimitValue] DECIMAL(10, 8) NOT NULL,
	[LowLimitValue] DECIMAL(10, 8) NOT NULL, 
    CONSTRAINT [FK_ReferenceData_ReferenceType] FOREIGN KEY ([ReferenceTypeId]) REFERENCES [dbo].[ReferenceType]([Id]),
    CONSTRAINT [FK_ReferenceData_ReferenceRange] FOREIGN KEY ([ReferenceRangeId]) REFERENCES [dbo].[ReferenceRange]([Id])
)
