CREATE TABLE [dbo].[Sample]
(
	[Id] INT NOT NULL IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL,
    [AnalysisRequestId] INT NOT NULL , 
    [SiteId] INT NOT NULL DEFAULT 0, -- 0 is UNKNOWN on SITES TABLE
    [CollectionDate] DATE NULL , 
    [ReceivedDate] DATE NOT NULL DEFAULT GETDATE(), 

    CONSTRAINT [AK_Sample_Cin] UNIQUE ([Cin]), 
    CONSTRAINT [FK_Sample_Sites] FOREIGN KEY ([SiteId]) REFERENCES [dbo].[Sites]([Id]), 
    CONSTRAINT [FK_Sample_ToTable] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [PK_Sample] PRIMARY KEY ([Id]))