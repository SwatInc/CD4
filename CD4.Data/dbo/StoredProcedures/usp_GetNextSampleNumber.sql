CREATE PROCEDURE [dbo].[usp_GetNextSampleNumber]
AS
BEGIN
	INSERT INTO [dbo].[AutoSampleNumberHelper]([Seed])
	OUTPUT INSERTED.[Id]
	VALUES (1);
END
