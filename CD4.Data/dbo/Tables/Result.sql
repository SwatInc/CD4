CREATE TABLE [dbo].[Result]
(
	[Id] INT NOT NULL IDENTITY, 
    [Sample_Cin] VARCHAR(50) NOT NULL,
    [TestId] INT NOT NULL, 
    [Result] NVARCHAR(50) NULL, 
    [ReferenceCode] CHAR(2) NOT NULL DEFAULT 'NM', -- default set as normal(NM) because inital result on table will be null.
    [IsDeltaOk] BIT NOT NULL DEFAULT 1, -- default is NotFailed(1) because initial result is null delta failure cannot be determined unless a result is entered.
    [IsStat] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Result_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_Result_Sample] FOREIGN KEY ([Sample_Cin]) REFERENCES [dbo].[Sample]([Cin]), 
    CONSTRAINT [AK_Result_CinAndTestId] UNIQUE ([Sample_Cin],[TestId]), 
    CONSTRAINT [PK_Result_Id] PRIMARY KEY ([Id]))
GO
CREATE INDEX [IX_Result_Result] ON [dbo].[Result] ([Result]) INCLUDE ([Sample_Cin]);
GO
CREATE NONCLUSTERED INDEX [IX_Result_Result_TestId]
ON [dbo].[Result] ([Result])
INCLUDE ([TestId]);
GO
CREATE NONCLUSTERED INDEX [IX_SampleCin_Result]
ON [dbo].[Result] ([Sample_Cin],[Result])
GO
CREATE NONCLUSTERED INDEX [IX_TestId_Composite_Result]
ON [dbo].[Result] ([TestId],[Result])
GO

