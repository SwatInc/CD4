CREATE PROCEDURE [dbo].[usp_InsertSampleAssociatedTests]
	@Sample_Cin varchar(50),
	@TestId int
	--Result and result date is null
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
	OUTPUT INSERTED.Id
	VALUES ( @Sample_Cin ,@TestId);
END