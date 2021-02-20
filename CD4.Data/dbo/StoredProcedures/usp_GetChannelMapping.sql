CREATE PROCEDURE [dbo].[usp_GetChannelMapping]
AS
BEGIN
	SELECT 
	  [s].[TestId]
	, [s].[Download]
	, [s].[Upload]
	, [s].[Unit]
	, [a].[Description] AS [AnalyserName]
	FROM [dbo].[ChannelMap] [s]
	INNER JOIN [dbo].[Analyser] [a] ON [s].[AnalyserId] = [a].[Id]
END
