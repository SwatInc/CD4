CREATE PROCEDURE [dbo].[usp_GetNotesCountForSample]
	@Cin varchar(50)
AS
BEGIN
	SELECT COUNT([Id]) AS [NotesCount]
	FROM [dbo].[SampleNotes]
	WHERE [Cin]  = @Cin;
END
