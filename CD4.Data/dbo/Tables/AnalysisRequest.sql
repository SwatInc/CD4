CREATE TABLE [dbo].[AnalysisRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[PatientId] INT NOT NULL,
    [EpisodeNumber] varchar(15),
    [Age] varchar(20) NULL, 
    [CheckedBy] INT NOT NULL DEFAULT 0, -- Zero Will be NA on scientist table
    [ApprovedBy] INT NOT NULL DEFAULT 0, -- Zero will be NA on scientist table

    CONSTRAINT [FK_AnalysisRequest_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient]([Id]) 
)