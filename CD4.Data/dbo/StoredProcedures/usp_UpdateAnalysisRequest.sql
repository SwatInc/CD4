CREATE PROCEDURE [dbo].[usp_UpdateAnalysisRequest]
	@Id int,
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20)
AS
BEGIN
SET NOCOUNT ON;
	UPDATE [dbo].[AnalysisRequest]
	SET [PatientId] = @PatientId,
		[EpisodeNumber] = @EpisodeNumber,
		[Age] = @Age
	WHERE [Id] = @Id;
END
