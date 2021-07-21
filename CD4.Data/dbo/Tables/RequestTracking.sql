CREATE TABLE [dbo].[RequestTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AnalysisRequestId] INT NOT NULL UNIQUE, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(), 
    CONSTRAINT [FK_RequestTracking_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [FK_RequestTracking_Status] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status]([Id]), 
    CONSTRAINT [FK_RequestTracking_Users] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users]([Id])
)
GO
CREATE NONCLUSTERED INDEX [ResultTracking_StatusId_ResultId]
ON [dbo].[ResultTracking] ([StatusId])
INCLUDE ([ResultId])
GO
