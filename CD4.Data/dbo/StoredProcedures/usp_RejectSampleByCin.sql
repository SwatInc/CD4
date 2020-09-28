CREATE PROCEDURE [dbo].[usp_RejectSampleByCin] 
    @Cin varchar(50),
    @CommentListId int,
    @UserId int
AS
BEGIN
  SET NOCOUNT ON;
  SET XACT_ABORT ON;
  BEGIN TRANSACTION;
    BEGIN TRY

      DECLARE @Comment VARCHAR(2000);
      DECLARE @NumTestsNotRejected int;
      DECLARE @SampleTrackingTypeId int;
      DECLARE @TestTrackingTypeId int;
      DECLARE @ResultIds TABLE (
        Id int
      );
      --get the comment string
      SELECT @Comment =  [Description] 
      FROM [dbo].[CommentList]
      WHERE [Id] = @CommentListId;

      -- set result status to rejected for all tests of the sample except for
      -- validated or registered tests
      UPDATE [dbo].[ResultTracking]
      SET [StatusId] = 7	-- 7 is rejected
      OUTPUT INSERTED.[ResultId] INTO @ResultIds
      WHERE [StatusId] <> 5 OR [StatusId] <> 1
      AND [ResultId] IN (SELECT
        [Id] AS [ResultId]
      FROM [dbo].[Result]
      WHERE [Sample_Cin] = @Cin);

      -- remove the results of rejected tests
      UPDATE [dbo].[Result]
      SET [Result] = NULL
      WHERE [Id] IN (SELECT
        [Id]
      FROM @ResultIds);

      -- Get the number of tests not rejected for the sample
      SELECT @NumTestsNotRejected = COUNT([Id]) 
      FROM [dbo].[ResultTracking] 
      WHERE [StatusId] <> 7;
      -- if all tests for the sample is rejected and sample status is not validated or registered,
      -- mark the sample as rejected.
      UPDATE [dbo].[SampleTracking]
      SET [StatusId] = 7 -- 7 is rejected
      WHERE [SampleCin] = @Cin AND 
            [StatusId] <> 1 AND 
            [StatusId] <> 5 AND 
            @NumTestsNotRejected = 0;

    -- insert sample comment
    INSERT INTO [dbo].[Comment]([CommentListId],[CommentTypeId],[Identifier],[UserId],[CreatedAt],[UpdatedAt])
    VALUES
        (@CommentListId,2,@Cin,1,GETDATE(),GETDATE());
    -- insert test comments for rejected sample
    INSERT INTO [dbo].[Comment]([CommentListId],[CommentTypeId],[Identifier],[UserId],[CreatedAt],[UpdatedAt])
    SELECT @CommentListId,3,[Id] AS [Identifier] ,@UserId,GETDATE(),GETDATE()
    FROM @ResultIds;

    -- Insert sample tracking history: WARNING!!! this should execute only if sample was rejected.
    SELECT @SampleTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
    SELECT @TestTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';

    INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId])
    VALUES
        (@SampleTrackingTypeId,@Cin,7,@UserId);
    -- insert test tracking history
    INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId])
    SELECT @TestTrackingTypeId,[Id],7,@UserId
    FROM @ResultIds;
    -- Write audit logs - sample
    INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
    VALUES
        (@SampleTrackingTypeId,@Cin,7,CONCAT('Sample Rejected: ',@Cin));
    -- Write audit logs - Tests
    INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
    SELECT @TestTrackingTypeId,@Cin,7,CONCAT('Sample ',@Cin,', rejection caused test rejections: ',[T].[TestNamesRejected])
    FROM
    (
        SELECT STRING_AGG(CONVERT(VARCHAR(1000),[Description]), ' | ') AS [TestNamesRejected]
        FROM [dbo].[Test]
        WHERE [Id] IN 
                    (
                        SELECT [TestId] AS [Id] 
                        FROM [dbo].[Result] 
                        WHERE [Id] IN (SELECT [Id] FROM @ResultIds)
                    )
    ) AS T;

    COMMIT TRANSACTION;
    -- return datac - sample status
    SELECT [SampleCin] AS [Cin]
          ,[StatusId] 
    FROM [dbo].[SampleTracking] 
    WHERE [SampleCin] = @Cin;
    -- return datac - result status, result and reference code
    SELECT [RT].[ResultId]
          ,[R].[Sample_Cin] AS [Cin]
          ,[R].[Result]
          ,[R].[ReferenceCode]
          ,[RT].[StatusId]
    FROM [dbo].[ResultTracking] [RT]
    INNER JOIN [dbo].[Result] [R] ON [RT].[ResultId] = [R].[Id]
    WHERE [RT].[ResultId] IN  (SELECT [Id] AS [ResultId] FROM @ResultIds);

  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
  END CATCH;
END;