﻿CREATE TABLE [dbo].[Result]
(
	[Id] INT NOT NULL IDENTITY, 
    [Sample_Cin] VARCHAR(50) NOT NULL,
    [TestId] INT NOT NULL, 
    [Result] VARCHAR(50) NULL, 
    [ResultDate] DATE NULL, --if result not null, get system date GETDATE()   
    CONSTRAINT [FK_Result_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_Result_Sample] FOREIGN KEY ([Sample_Cin]) REFERENCES [dbo].[Sample]([Cin]), 
    CONSTRAINT [PK_Id_Cin] PRIMARY KEY ([Id],[Sample_Cin]))
GO
CREATE INDEX [IX_Result_Result] ON [dbo].[Result] ([Result]);
GO
CREATE NONCLUSTERED INDEX [IX_Result_Result_TestId]
ON [dbo].[Result] ([Result])
INCLUDE ([TestId]);
GO
