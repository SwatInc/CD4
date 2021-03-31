CREATE TABLE [dbo].[NdaTimeTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sid] INT NOT NULL, 
    [NdaLookupId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL
)
