CREATE PROCEDURE [dbo].[usp_CancelTestRejectionByResultId]
	@ResultId int,
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
				DEClARE @Cin varchar(50);
				DECLARE @ResultIds TABLE (
					Id int
				);

				--Get the corresponding cin for the test
				SELECT @Cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;

				-- mark the specified rejected test as collected
				UPDATE [dbo].[ResultTracking]
				SET [StatusId] = 2	-- 2 is collected
				OUTPUT INSERTED.[ResultId] INTO @ResultIds -- this line required?
				WHERE [StatusId] = 7 -- 7 is rejected
					  AND [ResultId] = @ResultId;

				-- mark the sample as collected if rejected.
				UPDATE [dbo].[SampleTracking]
				SET [StatusId] = 2 -- 2 is collected
				WHERE [SampleCin] = @Cin AND [StatusId] = 7;

				-- remove the test rejection comments
				DELETE FROM [dbo].[Comment]
				WHERE [CommentTypeId] = 5 AND
				CAST([Identifier] AS INT) IN (SELECT [Id] FROM @ResultIds);

				-- remove any sample rejection comments
				DELETE FROM [dbo].[Comment]
				WHERE [CommentTypeId] = 4 AND
				CAST([Identifier] AS VARCHAR(50)) = @Cin;

				-- AUDIT
				SELECT @SampleTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
				SELECT @TestTrackingTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
				
				-- get username
				SELECT @LoggedInUser =  [UserName] FROM [dbo].[Users];

				-- Write audit logs - sample. if sample rejection got cancelled.
				--Todo

				-- Write audit logs - Tests
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @TestTrackingTypeId,@Cin,2,CONCAT('Rejection cancelled for test: ',[T].[TestNamesRejected], ' by user ', @LoggedInUser)
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
