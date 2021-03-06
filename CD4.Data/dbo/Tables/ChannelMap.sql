﻿CREATE TABLE [dbo].[ChannelMap]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TestId] INT NOT NULL, 
    [Download] VARCHAR(50) NOT NULL, 
    [Upload] VARCHAR(50) NOT NULL, 
    [Unit] VARCHAR(50) NOT NULL, 
    [AnalyserId] INT NOT NULL, 
    [Enabled] BIT NOT NULL DEFAULT 1, -- only checked while downloading orders in download or query mode. result interface from analyser should not be effected.
    CONSTRAINT [FK_ChannelMap_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_ChannelMap_Analyser] FOREIGN KEY ([AnalyserId]) REFERENCES [dbo].[Analyser]([Id])
)
