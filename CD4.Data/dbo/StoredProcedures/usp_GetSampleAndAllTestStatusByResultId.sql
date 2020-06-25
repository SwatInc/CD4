CREATE PROCEDURE [dbo].[usp_GetSampleAndAllTestStatusByResultId]
	@ResultId int
AS
BEGIN
SET NOCOUNT ON;
	--declare a variable to hold cin.
	DECLARE @Cin varchar(50);
	--variable for sample status
	DECLARE @SampleStatus int;

	--get cin from resultId
	SELECT @Cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;
	--get sampleStatus...
	SELECT @SampleStatus = [StatusId] FROM [dbo].[Sample] WHERE [Cin] = @Cin;
	--and concat sample status with a CSV tests status
	SELECT CONCAT(@SampleStatus,',', STRING_AGG([StatusId],',')) FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;
END
