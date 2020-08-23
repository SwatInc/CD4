CREATE TABLE [dbo].[ReferenceRange]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestId] INT NOT NULL,
	[GenderId] INT NOT NULL,
	[FromAgeDays] INT NOT NULL,
	[ToAgeDays] INT NOT NULL,
	[DeltaValidityIntervalDays] INT NOT NULL,
	[BiasFactor] INT NOT NULL,
	[RaceId] INT NOT NULL,
	[ClinicalDetailsId] INT NOT NULL
)
