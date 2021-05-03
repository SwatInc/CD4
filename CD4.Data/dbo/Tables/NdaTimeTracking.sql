CREATE TABLE [dbo].[NdaTimeTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Cin] varchar(50) NOT NULL, 
    [TrackedTime] DATETIMEOFFSET NOT NULL,
    [NdaLookupId] INT NOT NULL, 
    [CreatedBy] INT NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
    CONSTRAINT [FK_NdaTimeTracking_Sample] FOREIGN KEY ([Cin]) REFERENCES [dbo].[Sample]([Cin]),
    CONSTRAINT [FK_NdaTimeTracking_NdaLookup] FOREIGN KEY ([NdaLookupId]) REFERENCES [dbo].[NdaLookup]([Id]), 
    CONSTRAINT [FK_NdaTimeTracking_UsersCreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Users]([Id])

)
