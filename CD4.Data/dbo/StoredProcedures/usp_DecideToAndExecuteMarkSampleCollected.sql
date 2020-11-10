CREATE PROCEDURE [dbo].[usp_DecideToAndExecuteMarkSampleCollected]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
	DECLARE @DecidingFactor int;
	DECLARE @DecidingFactor2 int;
	
	--get the number of records for the sample number which is marked collected.
	SELECT @DecidingFactor = COUNT([Id]) 
	FROM [dbo].[TrackingHistory]
	WHERE [SampleCin] = @Cin AND [StatusId] = 2;

	-- if the trackingHistory shows sample as collected, but sampleTracking shows as registered.
	SELECT @DecidingFactor2 = COUNT([Id]) 
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;

	-- If none is marked collected
	IF @DecidingFactor = 0
	BEGIN -- mark them as collected by calling the usp
		EXEC [dbo].[usp_MarkSampleCollected] @Cin = @Cin, @UserId = @UserId;
	END

	-- If marked as collected on tracking History, Registered on SampleTracking
	IF @DecidingFactor > 0 AND @DecidingFactor2 = 1
	BEGIN -- mark them as collected by calling the usp
		EXEC [dbo].[usp_MarkSampleCollectedOnlyOnSampleTracking] @Cin = @Cin, @UserId = @UserId;
	END
END
