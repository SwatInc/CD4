CREATE PROCEDURE [dbo].[usp_GetCinsByEpisodeNumber]
	@EpisodeNumber varchar(15)
AS
BEGIN
	SELECT [Cin]
	FROM [dbo].[Sample] [s]
	INNER JOIN [dbo].[AnalysisRequest] [ar] ON [s].[AnalysisRequestId] = [ar].[Id]
	WHERE [ar].[EpisodeNumber] = @EpisodeNumber;
END
