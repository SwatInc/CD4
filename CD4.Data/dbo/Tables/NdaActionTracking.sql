CREATE TABLE [dbo].[NdaActionTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Cin] varchar(50) NOT NULL, 
    [NdaLookupId] INT NOT NULL, 
    [ActionUserId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [CreatedBy] INT NOT NULL,

)
