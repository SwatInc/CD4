--Marks the sample and associated tests as collected and set sample collected date to current SQL server datetime
CREATE PROCEDURE [dbo].[usp_MarkSampleCollected]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	--Set sample status as collected  and set collected date.
	UPDATE [dbo].[Sample]
	SET [StatusId] = 2,
		[CollectionDate] = GETDATE()
	WHERE [Cin] = @Cin AND [StatusId] = 1;
	--Set associated test statuses as collected
	UPDATE [dbo].[Result]
	SET [StatusId] = 2
	WHERE [Sample_Cin] = @Cin AND [StatusId] =1;
END
