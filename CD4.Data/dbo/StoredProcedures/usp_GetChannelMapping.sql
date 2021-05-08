CREATE PROCEDURE [dbo].[usp_GetChannelMapping]
AS
BEGIN
	SELECT 
	  [s].[TestId]
	, [s].[Download]
	, [s].[Upload]
	, [s].[Unit]
	, [a].[Description] AS [AnalyserName]
	, [t].[Mask]
	, [rdt].[Name] AS [DataType]
	FROM [dbo].[ChannelMap] [s]
	INNER JOIN [dbo].[Analyser] [a] ON [s].[AnalyserId] = [a].[Id]
	INNER JOIN [dbo].[Test] [t] ON [t].[Id] = [s].[TestId]
	INNER JOIN [dbo].[ResultDataType] [rdt] ON [rdt].[Id] = [t].[ResultDataTypeId]
END
