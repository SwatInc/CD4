CREATE TABLE [dbo].[TrackingHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TrackingType] INT NOT NULL,
	[Identifier] INT NOT NULL, -- requestId, sampleId or ResultId
	[StatusId] INT NOT NULL,
	[TimeStamp] DATETIMEOFFSET DEFAULT GETDATE()
)
