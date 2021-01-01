CREATE PROCEDURE [dbo].[usp_GetSampleNotesByCin]
	@Cin varchar(50)
AS
BEGIN
	SELECT [s].[Id]
		 , [s].[Cin]
		 , [s].[Note]
		 , [s].[IsAttended]
		 , [u].[UserName]
		 , [s].[UserId]
		 , [s].[TimeStamp]
	FROM [dbo].[SampleNotes] [s]
	INNER JOIN [dbo].[Users] [u] ON [s].[UserId] = [u].[Id]
	WHERE [s].[Cin] = @Cin
END
