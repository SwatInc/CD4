﻿CREATE TABLE [dbo].[ResultReferenceRanges]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ResultId] INT NOT NULL, 
    [NormalHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1, 
    [NormalLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [AttentionHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1, 
    [AttentionLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [PathologyHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1, 
    [PathologyLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [HighPathologyHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1, 
    [HighPathologyLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [AbsoluteDeltaLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [AbsoluteDeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [RelativeDeltaLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [RelativeDeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityAbsoluteLow_DeltaLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityAbsoluteLow_DeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityAbsoluteHigh_DeltaLowLimt] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityAbsoluteHigh_DeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityRelativeLow_DeltaLowLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityRelativeLow_DeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityRelativeHigh_DeltaLowlimit] DECIMAL(10, 3) NOT NULL DEFAULT -1,
    [OutOfNormalityRelativeHigh_DeltaHighLimit] DECIMAL(10, 3) NOT NULL DEFAULT -1, 
    [DeltaValidityDays] INT NOT NULL DEFAULT 0, 
    [BiasFactor] INT NOT NULL DEFAULT 0,
    [DisplayNormalRange] varchar(100) DEFAULT NULL
    CONSTRAINT [FK_ResultReferenceRanges_ResultId] FOREIGN KEY ([ResultId]) REFERENCES [dbo].[Result]([Id]), 

    )
