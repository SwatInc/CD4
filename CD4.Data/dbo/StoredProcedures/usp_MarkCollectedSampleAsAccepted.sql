CREATE PROCEDURE [dbo].[usp_MarkCollectedSampleAsAccepted]
	@Cin varchar(50),
	@UserId int
AS
	-- get the current status of the sample
	-- If current status is collected, mark the sample as collected [in sample tracking]
	-- if current status is collected, mark the tests as collected [in result tracking]
	-- add tracking history
	-- add audit trail

	-- return standard current sample and test status data -- this will be used if the call is done from ResultEntry

BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @LoggedInUser varchar(256);
        DECLARE @ReceivedStatus int  = 3;
        DECLARE @RegisteredStatus int  = 1;
        DECLARE @CollectedStatus int  = 2;
        DECLARE @SampleTrackingType int = 2; 
        DECLARE @ResultTrackingType int = 3; 
		DECLARE @IsSampleAlreadyAccepted int;
		DECLARE @IsRegisteredSample int;
        DECLARE @AcceptedCins TABLE ([SampleCin] varchar(50));
        DECLARE @AcceptedResultIds TABLE ([ResultId] int);

		-- indicate whether sample is already accepted when this procedure is called
        SELECT @IsSampleAlreadyAccepted = COUNT([SampleCin]) 
		FROM [dbo].[TrackingHistory] 
		WHERE [SampleCin] = @Cin AND [TrackingType] = @SampleTrackingType AND [StatusId] = @ReceivedStatus;
		-- check whether the current sample is a registered sample
		SELECT @IsRegisteredSample = COUNT(Id) FROM [dbo].[SampleTracking] WHERE [StatusId] = @RegisteredStatus AND [SampleCin] = @Cin;

        -- If the sample status is collected, change the status to accepted.
        UPDATE [dbo].[SampleTracking]
        SET [StatusId] = @ReceivedStatus,
            [CreatedAt] = SYSDATETIMEOFFSET()
            OUTPUT INSERTED.[SampleCin] INTO @AcceptedCins
        WHERE [SampleCin] = @Cin AND [StatusId] = @CollectedStatus;

        -- Set the assocated tests status to accepted if the test status is collected.
        UPDATE [dbo].[ResultTracking]
        SET [StatusId] = @ReceivedStatus,
            [CreatedAt] = SYSDATETIMEOFFSET()
            OUTPUT INSERTED.[ResultId] INTO @AcceptedCins
        WHERE [StatusId] = @CollectedStatus AND [ResultId] IN (
                                    SELECT [Id] AS [ResultId] 
                                    FROM [dbo].[Result] 
                                    WHERE [Sample_Cin] = @Cin);
        --Tracking history
        -- get the logged in username
        SELECT @LoggedInUser = [UserName] FROM [dbo].[Users] WHERE [Id]= @UserId;
        -- SAMPLE tracking history
		INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId],[TimeStamp])
        SELECT @SampleTrackingType,@Cin,@ReceivedStatus,@UserId,SYSDATETIMEOFFSET() 
		WHERE (@IsSampleAlreadyAccepted = 0 AND @IsRegisteredSample = 0);

        -- Test/result tracking history
        INSERT INTO [dbo].[TrackingHistory]([TrackingType],[ResultId],[StatusId],[UsersId],[TimeStamp])
        SELECT @ResultTrackingType,[ResultId],@ReceivedStatus,@UserId,SYSDATETIMEOFFSET()
        FROM @AcceptedResultIds
		WHERE (@IsSampleAlreadyAccepted = 0 AND @IsRegisteredSample = 0);

		DECLARE @AuditDetails varchar(100) = CONCAT('Sample ',@Cin,' accepted by user ',@LoggedInUser);
		DECLARE @InsertedId int;
        -- insert audit trail - sample
		IF (@IsSampleAlreadyAccepted = 0 AND @IsRegisteredSample = 0)
		BEGIN
			--PRINT 'Got here';
			--PRINT CONCAT(@IsSampleAlreadyAccepted,'|', @IsRegisteredSample);
			PRINT @InsertedId;
			EXECUTE @InsertedId = [dbo].[usp_InsertSampleAuditTrail]
			@Cin = @Cin,
			@StatusId = @ReceivedStatus,
			@Details = @AuditDetails,
			@InsertedId = @InsertedId OUTPUT;
		END

    COMMIT TRANSACTION;
        -- return data - sample status
        SELECT [SampleCin] AS [Cin],
               [StatusId]
        FROM [dbo].[SampleTracking]
        WHERE [SampleCin] = @Cin;
        -- return datac - result status, result and reference code
        SELECT [RT].[ResultId],
               [R].[Sample_Cin] AS [Cin],
               [R].[Result],
               [R].[ReferenceCode],
               [RT].[StatusId]
        FROM [dbo].[ResultTracking] [RT]
            INNER JOIN [dbo].[Result] [R]
                ON [RT].[ResultId] = [R].[Id]
        WHERE [RT].[ResultId] IN (
                                     SELECT [ResultId] FROM @AcceptedResultIds
                                 );

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;

END