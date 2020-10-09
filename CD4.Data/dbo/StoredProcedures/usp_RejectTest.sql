CREATE PROCEDURE [dbo].[usp_RejectTest]
    @ResultId int,
    @Cin varchar(50),
    @CommentListId int,
    @UserId int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    BEGIN TRY

        DECLARE @Comment varchar(2000);
        DECLARE @TestTrackingTypeId int;
        DECLARE @LoggedInUser varchar(256);
        DECLARE @NumTestsNotRejected int;
        DECLARE @InsertedSampleAuditTrailId int;
        DECLARE @RejectedTestName varchar(50);
        DECLARE @AutoSampleRejectionReason varchar(100);

        --get the comment string
        SELECT @Comment = [Description]
        FROM [dbo].[CommentList]
        WHERE [Id] = @CommentListId;
        DECLARE @ResultIds TABLE (Id int);

        -- Mark the test as rejected if the test status is 
        -- not validated and not registered.
        UPDATE [dbo].[ResultTracking]
        SET [StatusId] = 7 -- 7 is rejected
        OUTPUT INSERTED.[ResultId]
        INTO @ResultIds
        WHERE [StatusId] <> 5
              AND [StatusId] <> 1
              AND [ResultId] = @ResultId;

        -- set the result of the test to null
        UPDATE [dbo].[Result]
        SET [Result] = NULL
        WHERE [Id] = @ResultId;

        -- insert test comments for rejected test
        INSERT INTO [dbo].[Comment]
        (
            [CommentListId],
            [CommentTypeId],
            [Identifier],
            [UserId],
            [CreatedAt],
            [UpdatedAt]
        )
        SELECT @CommentListId,
               5,
               [Id] AS [Identifier],
               @UserId,
               GETDATE(),
               GETDATE()
        FROM @ResultIds; -- 5 comment type: Test Rejection

        -- Insert test tracking history: WARNING!!! this should execute only if sample was rejected.
        SELECT @TestTrackingTypeId = [Id]
        FROM [dbo].[AuditTypes]
        WHERE [Description] = 'Test';
        -- get username
        SELECT @LoggedInUser = [UserName] FROM [dbo].[Users];

        -- Get the number of tests not rejected for the sample
        SELECT @NumTestsNotRejected = COUNT([RT].[Id])
        FROM [dbo].[ResultTracking] [RT]
            INNER JOIN [dbo].[Result] [R]
                ON [R].[Id] = [RT].[ResultId]
        WHERE [RT].[StatusId] <> 7
              AND [R].[Sample_Cin] = @Cin;

        -- if all tests for the sample is rejected and sample status is not validated or registered,
        -- mark the sample as rejected.
        UPDATE [dbo].[SampleTracking]
        SET [StatusId] = 7 -- 7 is rejected
        WHERE [SampleCin] = @Cin
              AND [StatusId] <> 1
              AND [StatusId] <> 5
              AND @NumTestsNotRejected = 0;

        -- Get rejected test name
        SELECT @RejectedTestName = [T].[Description] 
        FROM [dbo].[Test] [T]
        INNER JOIN [dbo].[Result] [R] ON [T].[Id] = [R].[TestId]
        WHERE [R].[Id] = @ResultId;

        -- Insert test audit trail
        INSERT INTO [dbo].[AuditTrail]
        (
            [AuditTypeId],
            [Cin],
            [StatusId],
            [Details]
        )
        VALUES
        (
              @TestTrackingTypeId
            , @Cin
            , 7
            ,CONCAT(@RejectedTestName,' on ',@Cin, ' rejected by user ',@LoggedInUser)
        );

        -- Generate auto sample rejection comment
        SELECT @AutoSampleRejectionReason = CONCAT('Sample ',@Cin, ' rejected by CD4. Reason: All associated tests got rejected.');
        
        -- insert sample audit trail as sample rejected, if all tests of the sample is rejected
        IF @NumTestsNotRejected = 0
        BEGIN
            EXEC  [dbo].[usp_InsertSampleAuditTrail]
              @Cin = @Cin
            , @StatusId = 7
            , @Details = @AutoSampleRejectionReason
            ,@InsertedId = @InsertedSampleAuditTrailId output;
        END;
        COMMIT TRANSACTION;

        -- return data - sample status
        SELECT [SampleCin] AS [Cin],
               [StatusId]
        FROM [dbo].[SampleTracking]
        WHERE [SampleCin] = @Cin;
        -- return data - result status, result and reference code
        SELECT [RT].[ResultId],
               [R].[Sample_Cin] AS [Cin],
               [R].[Result],
               [R].[ReferenceCode],
               [RT].[StatusId]
        FROM [dbo].[ResultTracking] [RT]
            INNER JOIN [dbo].[Result] [R]
                ON [RT].[ResultId] = [R].[Id]
        WHERE [RT].[ResultId] IN (
                                     SELECT [Id] AS [ResultId] FROM @ResultIds
                                 );
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DELETE FROM [dbo].[AuditTrail] WHERE [Id] = @InsertedSampleAuditTrailId;
        THROW;
    END CATCH;
END