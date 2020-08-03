--Marks the sample and associated tests as collected and set sample collected date to current SQL server datetime
CREATE PROCEDURE [dbo].[usp_MarkSampleCollected]
	@Cin varchar(50)
AS
BEGIN
SET NOCOUNT ON;
	--Set sample status as collected  and set collected date.
	UPDATE [dbo].[SampleTracking]
	SET [StatusId] = 2,
		[CreatedAt] = GETDATE()
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;
	--Set associated test statuses as collected
	UPDATE [dbo].[ResultTracking]
	SET [StatusId] = 2
	WHERE  [StatusId] =1 AND [ResultId] IN
			(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin);
END
