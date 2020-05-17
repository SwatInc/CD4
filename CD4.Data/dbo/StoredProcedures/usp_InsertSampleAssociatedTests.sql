CREATE PROCEDURE [dbo].[usp_InsertSampleAssociatedTests]
	@AnalysisRequestId int,
	@Sample_Cin varchar(50),
	@TestId int
	--Result and result date is null
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[Result] ([AnalysisRequestId], [Sample_Cin], [TestId])
	OUTPUT INSERTED.Id
	VALUES (@AnalysisRequestId, @Sample_Cin ,@TestId);
END