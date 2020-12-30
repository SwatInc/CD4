CREATE PROCEDURE [dbo].[usp_DecideToAndExecuteMarkSampleCollected]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
	DECLARE @CollectedSampleCount int;
	DECLARE @RegisteredSampleCount int;
	DECLARE @ResgisteredTestsCount int;
	
	--get the number of records for the sample number which is marked collected.
	SELECT @CollectedSampleCount = COUNT([Id]) 
	FROM [dbo].[TrackingHistory]
	WHERE [SampleCin] = @Cin AND [StatusId] = 2;

	-- if the trackingHistory shows sample as collected, but sampleTracking shows as registered.
	SELECT @RegisteredSampleCount = COUNT([Id]) 
	FROM [dbo].[SampleTracking]
	WHERE [SampleCin] = @Cin AND [StatusId] = 1;

	SELECT @ResgisteredTestsCount = COUNT([Id])
	FROM [dbo].[ResultTracking]
	WHERE [StatusId] = 1 AND [ResultId] IN 
		(
			SELECT [Id] AS [ResultId]
			FROM [dbo].[Result]
			WHERE [Sample_Cin] = @Cin
		);

	-- If none is marked collected
	IF @CollectedSampleCount = 0
	BEGIN -- mark them as collected by calling the usp
		EXEC [dbo].[usp_MarkSampleCollected] @Cin = @Cin, @UserId = @UserId;
	END

	-- If marked as collected on tracking History, Registered on SampleTracking
	IF @CollectedSampleCount > 0 AND @RegisteredSampleCount = 1
	BEGIN -- mark them as collected by calling the usp
		EXEC [dbo].[usp_MarkSampleCollectedOnlyOnSampleTracking] @Cin = @Cin, @UserId = @UserId;
	END

	IF(@RegisteredSampleCount = 0 AND @ResgisteredTestsCount > 0)
	BEGIN
		EXEC [dbo].[usp_CollectLateRegisteredTests] @Cin = @Cin, @UserId = @UserId;
	END
END
