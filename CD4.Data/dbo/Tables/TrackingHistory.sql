﻿CREATE TABLE [dbo].[TrackingHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TrackingType] INT NOT NULL,
	[AnalysisRequestId] INT,
	[SampleCin] varchar(50),
	[ResultId] int,
	[StatusId] INT NOT NULL,
	[UsersId] INT NOT NULL,
	[TimeStamp] DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL, 
    CONSTRAINT [FK_TrackingHistory_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]),
    CONSTRAINT [FK_TrackingHistory_Sample] FOREIGN KEY ([SampleCin]) REFERENCES [dbo].[Sample]([Cin]),
    CONSTRAINT [FK_TrackingHistory_Result] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[Result]([Id]), 
    CONSTRAINT [FK_TrackingHistory_Users] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users]([Id]), 
    CONSTRAINT [FK_TrackingHistory_AuditTypes] FOREIGN KEY ([TrackingType]) REFERENCES [dbo].[AuditTypes]([Id])
)
