CREATE TABLE [dbo].[Sample]
(
	[Id] INT NOT NULL IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL,
    [StatusId] INT NOT NULL,
    [AnalysisRequestId] INT NOT NULL , 
    [SiteId] INT NOT NULL DEFAULT 1, -- 0 is UNKNOWN on SITES TABLE
    [CollectionDate] DATE NULL , 
    [ReceivedDate] DATE NOT NULL DEFAULT GETDATE(), 

    CONSTRAINT [AK_Sample_Cin] UNIQUE ([Cin]), 
    CONSTRAINT [FK_Sample_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites]([Id]), 
    CONSTRAINT [FK_Sample_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [PK_Sample] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Sample_Status] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id]))
    GO
    CREATE NONCLUSTERED INDEX [IX_Cin_ArId] ON [dbo].[Sample] ([Cin],[AnalysisRequestId])
    GO
