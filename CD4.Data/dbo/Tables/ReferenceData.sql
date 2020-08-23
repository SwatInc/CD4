CREATE TABLE [dbo].[ReferenceData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ReferenceTypeId] INT NOT NULL,
	[HighLimitValue] DECIMAL(10, 8) NOT NULL,
	[LowLimitvalue] DECIMAL(10, 8) NOT NULL
)
