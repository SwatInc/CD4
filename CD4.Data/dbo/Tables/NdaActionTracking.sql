CREATE TABLE [dbo].[NdaActionTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Cin] varchar(50) NOT NULL, 
    [NdaLookupId] INT NOT NULL, 
    [ActionUserId] INT NOT NULL, 
    [CreatedBy] INT NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    CONSTRAINT [FK_NdaActionTracking_Sample] FOREIGN KEY ([Cin]) REFERENCES [dbo].[Sample]([Cin]), 
    CONSTRAINT [FK_NdaActionTracking_NdaLookup] FOREIGN KEY ([NdaLookupId]) REFERENCES [dbo].[NdaLookup]([Id]), 
    CONSTRAINT [FK_NdaActionTracking_UsersActionUser] FOREIGN KEY ([ActionUserId]) REFERENCES [dbo].[Users]([Id]),
    CONSTRAINT [FK_NdaActionTracking_UsersCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users]([Id])
)
