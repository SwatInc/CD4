CREATE TABLE [dbo].[AnalysisRequest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL,
	PatientId INT NOT NULL, 
    [Age] INT NULL, 
    [CheckedBy] INT NOT NULL DEFAULT 0, -- Zero Will be NA on scientist table
    [ApprovedBy] INT NOT NULL DEFAULT 0 -- Zero will be NA on scientist table
, 
    CONSTRAINT [FK_AnalysisRequest_Patient] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patient]([Id]), 
    CONSTRAINT [FK_AnalysisRequest_ScientistChecked] FOREIGN KEY ([CheckedBy]) REFERENCES [dbo].[Scientist]([Id]),
    CONSTRAINT [FK_AnalysisRequest_ScientistApproved] FOREIGN KEY ([ApprovedBy]) REFERENCES [dbo].[Scientist]([Id]))
