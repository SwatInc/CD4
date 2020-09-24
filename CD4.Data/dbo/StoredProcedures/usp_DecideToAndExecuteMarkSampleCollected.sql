CREATE PROCEDURE [dbo].[usp_DecideToAndExecuteMarkSampleCollected]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
	DECLARE @DecidingFactor int;
	
	--get the number of records for the sample number which is marked collected.
	SELECT @DecidingFactor = COUNT([Id]) 
	FROM [dbo].[TrackingHistory]
	WHERE [SampleCin] = @Cin AND [StatusId] = 2;

	-- If none is marked collected
	IF @DecidingFactor = 0
	BEGIN -- mark them as collected by calling the usp
		EXEC [dbo].[usp_MarkSampleCollected] @Cin = @Cin, @UserId = @UserId;
	END
END
