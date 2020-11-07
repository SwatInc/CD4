CREATE PROCEDURE [dbo].[usp_GetWorkStationSpecificPrinters]
	@WorkStationName varchar(100)
AS
BEGIN
	SELECT [P].[Description] AS [PrinterName], [PT].[Id] AS [PrinterType]
	FROM [dbo].[Printers] [P]
	INNER JOIN [dbo].[WorkStationPrinters] [WSP] ON [P].[Id] = [WSP].[PrinterId]
	INNER JOIN [dbo].[WorkStations] [WS] ON [WSP].[WorkStationId] = [WS].[Id]
	INNER JOIN [dbo].[PrinterTypes] [PT] ON [WSP].[PrinterTypeId] = [PT].[Id]
	WHERE [WS].[Description] = @WorkStationName;
END
