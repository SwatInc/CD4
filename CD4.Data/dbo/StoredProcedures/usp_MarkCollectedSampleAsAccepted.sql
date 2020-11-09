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
        DECLARE @CollectedStatus int  = 2;
        DECLARE @SampleTrackingType int = 2; 
        DECLARE @ResultTrackingType int = 3; 
        DECLARE @AcceptedCins TABLE ([SampleCin] varchar(50));
        DECLARE @AcceptedResultIds TABLE ([ResultId] int);


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
        SELECT @SampleTrackingType,@Cin,@ReceivedStatus,@UserId,SYSDATETIMEOFFSET();

        -- Test/result tracking history
        INSERT INTO [dbo].[TrackingHistory]([TrackingType],[ResultId],[StatusId],[UsersId],[TimeStamp])
        SELECT @ResultTrackingType,[ResultId],@ReceivedStatus,@UserId,SYSDATETIMEOFFSET()
        FROM @AcceptedResultIds;

        -- insert audit trail - sample
        INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details],[CreatedAt])
        VALUES (@ResultTrackingType, @Cin, @ReceivedStatus,CONCAT('Sample ',@Cin,' accepted by user ',@LoggedInUser),SYSDATETIMEOFFSET());

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
