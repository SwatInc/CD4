CREATE TABLE [dbo].[NdaActionTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Sid] INT NOT NULL, 
    [NdaLookUpId] INT NOT NULL, 
    [ActionUserId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL, 
    [CreatedBy] INT NOT NULL,

)
