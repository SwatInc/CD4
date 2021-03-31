CREATE TABLE [dbo].[NdaTimeTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Cin] varchar(50) NOT NULL, 
    [TrackedTime] DATETIMEOFFSET NOT NULL,
    [NdaLookupId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL,
    [CreatedBy] INT NOT NULL
)
