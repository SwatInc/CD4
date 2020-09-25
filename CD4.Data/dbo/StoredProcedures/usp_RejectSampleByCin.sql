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
      OUTPUT INSERTED.[Id] INTO @ResultIds
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
    INSERT INTO [dbo].[Comment]([CommentListId],[CommentTypeId],[Identifier],[UserId])
    VALUES
        (@CommentListId,2,@Cin,1);
    -- insert test comments for rejected sample
    INSERT INTO [dbo].[Comment]([CommentListId],[CommentTypeId],[Identifier],[UserId])
    SELECT @CommentListId,3,[Id] AS [Identifier] ,@UserId
    FROM @ResultIds;

    -- Insert sample tracking history: WARNING!!! this should execute only if sample was rejected.
    SELECT @SampleTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample'
    INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId])
    VALUES
        (@SampleTrackingTypeId,@Cin,7,@UserId);
    -- insert test tracking history

    -- Write audit logs

    COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW;
  END CATCH;
END;