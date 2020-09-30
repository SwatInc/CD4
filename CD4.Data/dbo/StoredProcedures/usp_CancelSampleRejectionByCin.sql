CREATE PROCEDURE [dbo].[usp_CancelSampleRejectionByCin]
	@Cin varchar(50),
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
		BEGIN TRANSACTION;
			BEGIN TRY
				
				DECLARE @LoggedInUser varchar(256);
				DECLARE @SampleTrackingTypeId int;
				DECLARE @TestTrackingTypeId int;				
				DECLARE @ResultIds TABLE (
					Id int
				);

				-- change all the rejected tests for the sample to collected
				-- and mark them collected.
				UPDATE [dbo].[ResultTracking]
				SET [StatusId] = 2	-- 2 is collected
				OUTPUT INSERTED.[ResultId] INTO @ResultIds -- this line required?
				WHERE [StatusId] = 7 -- 7 is rejected
					  AND [ResultId] IN (SELECT [Id] AS [ResultId]
								   FROM [dbo].[Result]
								   WHERE [Sample_Cin] = @Cin);

				-- mark the sample as collected if rejected.
				UPDATE [dbo].[SampleTracking]
				SET [StatusId] = 2 -- 2 is collected
				WHERE [SampleCin] = @Cin AND [StatusId] = 7;

				-- remove the test rejection comments
				DELETE FROM [dbo].[Comment]
				WHERE [CommentTypeId] = 5 AND
				CAST([Identifier] AS INT) IN (SELECT [Id] FROM @ResultIds);

				-- remove sample rejection comments
				DELETE FROM [dbo].[Comment]
				WHERE [CommentTypeId] = 4 AND
				CAST([Identifier] AS INT) IN (SELECT [Id] FROM @ResultIds);

				-- Insert sample tracking history: WARNING!!! this should execute only if sample was rejected.
				SELECT @SampleTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
				SELECT @TestTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';

				-- get username
				SELECT @LoggedInUser =  [UserName] FROM [dbo].[Users];

				-- Write audit logs - sample
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				VALUES
					(@SampleTrackingTypeId,@Cin,2,CONCAT('Sample ',@Cin,' Rejection cancelled by user ',@LoggedInUser));

				-- Write audit logs - Tests
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @TestTrackingTypeId,@Cin,2,CONCAT('Sample ',@Cin,
						', rejection cancellation caused test rejection cancellations for: ',[T].[TestNamesRejected])
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
				-- return data - sample status
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
END

