CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequest]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
	OUTPUT INSERTED.Id
	VALUES (@PatientId, @EpisodeNumber, @Age);
END