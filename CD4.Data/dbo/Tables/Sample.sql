CREATE TABLE [dbo].[Sample]
(
	[Id] INT NOT NULL IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL,
    [AnalysisRequestId] INT NOT NULL ,
    [SiteId] INT NOT NULL DEFAULT 1, -- 0 is UNKNOWN on SITES TABLE
    [IsStat] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [AK_Sample_Cin] UNIQUE ([Cin]), 
    CONSTRAINT [FK_Sample_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites]([Id]), 
    CONSTRAINT [FK_Sample_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [PK_Sample] PRIMARY KEY ([Id]))
    GO
    CREATE NONCLUSTERED INDEX [IX_Cin_ArId] ON [dbo].[Sample] ([Cin],[AnalysisRequestId])
    GO
