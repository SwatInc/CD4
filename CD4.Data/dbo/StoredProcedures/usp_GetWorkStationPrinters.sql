CREATE PROCEDURE [dbo].[usp_GetPrintersByWorkStation]
	@WorkStation varchar(100)
AS
BEGIN
SET NOCOUNT ON;
	SELECT [p].[Description] AS [Printer],[pt].[Description] AS [PrinterType]
	FROM [dbo].[Printers] [p]
	INNER JOIN [dbo].[WorkStationPrinters] [wsp] ON [wsp].[PrinterId] = [p].[Id]
	INNER JOIN [dbo].[PrinterTypes] [pt] ON [pt].[Id] = [wsp].[PrinterType]
	INNER JOIN [dbo].[WorkStations] [ws] ON [ws].[Id] = [wsp].[WorkStationId]
	WHERE [ws].[Description] = @WorkStation;
END
