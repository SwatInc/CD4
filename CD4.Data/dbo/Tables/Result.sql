CREATE TABLE [dbo].[Result]
(
	[Id] INT NOT NULL IDENTITY, 
    [Sample_Cin] VARCHAR(50) NOT NULL,
    [TestId] INT NOT NULL, 
    [Result] VARCHAR(50) NULL, 
    [IsNormal] BIT NULL DEFAULT 1, -- default set as normal(1) because inital result on table will be null.
    [IsDeltaFailed] BIT NULL DEFAULT 0, -- default is NotFailed(0) because initial result is null delta failure cannot be determined unless a result is entered.
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

