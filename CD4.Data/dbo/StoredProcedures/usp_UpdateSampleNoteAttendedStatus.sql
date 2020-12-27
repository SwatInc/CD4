CREATE PROCEDURE [dbo].[usp_UpdateSampleNoteAttendedStatus]
	@NoteId int,
	@IsAttended bit
AS
BEGIN
	UPDATE [dbo].[SampleNotes]
	SET [IsAttended] = @IsAttended
	WHERE [Id] = @NoteId;
END
