CREATE TABLE [dbo].[AnalysisRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[PatientId] INT NOT NULL,
    [EpisodeNumber] varchar(15),
    [Age] varchar(20) NULL,

    CONSTRAINT [FK_AnalysisRequest_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient]([Id]) 
)