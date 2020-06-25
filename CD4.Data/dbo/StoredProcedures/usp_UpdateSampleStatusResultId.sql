CREATE PROCEDURE [dbo].[usp_UpdateSampleStatusResultId]
	@ResultId int,
	@SampleStatus int
AS
BEGIN
	--variable for cin
	DECLARE @cin varchar(50);
	--get cin
	SELECT @cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;
	--update sample status
	UPDATE [dbo].[Sample]
	SET [StatusId] = @SampleStatus
	WHERE [Cin] = @Cin;
END