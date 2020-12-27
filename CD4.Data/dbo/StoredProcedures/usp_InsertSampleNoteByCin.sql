CREATE PROCEDURE [dbo].[usp_InsertSampleNoteByCin]
	@Cin varchar(50),
	@Note varchar(200),
	@UserId int
AS
BEGIN
	INSERT INTO [dbo].[SampleNotes] ([Cin],[Note],[UserId])
	OUTPUT INSERTED.[Id]
	     , INSERTED.[Cin]
		 , INSERTED.[Note]
		 , INSERTED.[IsAttended]
		 , INSERTED.[UserId]
		 , INSERTED.[TimeStamp]
	VALUES
	(@Cin,@Note,@UserId);
END
