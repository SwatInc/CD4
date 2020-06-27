﻿CREATE TABLE [dbo].[WorkStationPrinters]
(
	[Id] INT NOT NULL,
	[WorkStationId] int NOT NULL,
	[PrinterId] int NOT NULL, 
	[PrinterType] int NOT NULL, 
    CONSTRAINT [PK_WorkStationPrinters] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_WorkStationPrinters_WorkStations] FOREIGN KEY ([WorkStationId]) REFERENCES [WorkStations]([Id]),
    CONSTRAINT [FK_WorkStationPrinters_Printers] FOREIGN KEY ([PrinterId]) REFERENCES [Printers]([Id]),
	CONSTRAINT [FK_WorkStationPrinters_PrinterTypes] FOREIGN KEY ([PrinterType]) REFERENCES [PrinterTypes]([Id]),

)