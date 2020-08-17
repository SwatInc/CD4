CREATE TABLE [dbo].[TrackingHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TrackingType] INT NOT NULL,
	[AnslysisRequestId] INT,
	[SampleCin] varchar(50),
	[ResultId] int,
	[StatusId] INT NOT NULL,
	[TimeStamp] DATETIMEOFFSET DEFAULT GETDATE(), 
    CONSTRAINT [FK_TrackingHistory_AnalysisRequest] FOREIGN KEY ([AnslysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]),
    CONSTRAINT [FK_TrackingHistory_Sample] FOREIGN KEY ([SampleCin]) REFERENCES [dbo].[Sample]([Cin]),
    CONSTRAINT [FK_TrackingHistory_Result] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[Result]([Id])
)
