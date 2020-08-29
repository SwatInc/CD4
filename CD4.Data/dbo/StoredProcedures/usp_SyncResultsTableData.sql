-- This procedure should be called only when there are tests to be inserted and tests to be removed
-- Otherwise use either of the following procedures
	-- [dbo].[usp_InsertResultsTableData]
	-- [dbo].[usp_RemoveResultsTableData]
CREATE PROCEDURE [dbo].[usp_SyncResultsTableData]
	@TestsToInsert [dbo].[ResultTableInsertDataUDT] READONLY,
	@TestsToRemove [dbo].[ResultTableInsertDataUDT] READONLY,
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
    BEGIN TRANSACTION;
		BEGIN TRY
				DECLARE @AuditTypeIdTest int;
				DECLARE @Username varchar(50);
                DECLARE @TrackingData TABLE ([Id] INT PRIMARY KEY IDENTITY, [ResultId] int)
                DECLARE @Cin VARCHAR(50);
				DECLARE @TempTrackingHistory TABLE ([ResultId] INT NOT NULL, [StatusId] INT NOT NULL);

                -- TRACKING: Tests to remove
                SELECT TOP 1 @Cin =  [Sample_Cin] FROM @TestsToRemove;
                DELETE FROM [dbo].[ResultTracking]
				OUTPUT DELETED.[ResultId], 8 INTO @TempTrackingHistory
                WHERE [ResultId] IN 
                (
                    SELECT [Id] 
                    FROM [dbo].[Result] 
                    WHERE [Sample_Cin] = @Cin AND [TestId] IN 
                    (
                        SELECT [TestId] FROM @TestsToRemove
                    )
                );
				--REFERENCE RANGE: remove reference ranges for tests to be removed.
				DELETE FROM [dbo].[ResultReferenceRanges]
				WHERE [ResultId] IN (SELECT [ResultId] FROM @TempTrackingHistory);

                --SYNC
				--remove tests requested for removal
				DELETE FROM [dbo].[Result] 
				WHERE 
				([TestId] IN (SELECT [R].[TestId]  FROM @TestsToRemove [R])) AND
				[Sample_Cin] = (SELECT TOP(1)[R].[Sample_Cin] FROM @TestsToRemove [R]);

				--add tests requested for insertion
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
                OUTPUT inserted.[Id] INTO @TrackingData
				SELECT [I].[Sample_Cin], [I].[TestId] FROM @TestsToInsert [I];

				-- REFERENCE RANGE: insert reference ranges for inserted tests
				DECLARE @Counter INT;
				DECLARE @MaxValue INT;
				DECLARE @InsertedResultId int;
				SELECT @MaxValue = COUNT([ResultId]) FROM @TrackingData;
				SET @Counter=1
				WHILE ( @Counter <= @MaxValue)
				BEGIN
					SELECT @InsertedResultId = [ResultId] FROM @TrackingData WHERE [Id] = @Counter;
					EXEC [dbo].[usp_InsertResultReferenceRange] @ResultId = @InsertedResultId;
					SET @Counter  = @Counter  + 1;
				END

                -- TRACKING: Added tests
                INSERT INTO [dbo].[ResultTracking] ([ResultId],[StatusId],[UsersId])
				OUTPUT INSERTED.[ResultId], 1 INTO @TempTrackingHistory
				SELECT [ResultId],1,@UserId FROM @TrackingData;
                -- removed tests

				-- TRACKING HISTORY
				INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[UsersId])
				SELECT 3,[ResultId],@UserId FROM @TrackingData;

                -- AUDIT
				--audit trail, tests added
				SELECT @AuditTypeIdtest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
				SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
				
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @AuditTypeIdtest
					, [I].[Sample_Cin]
					, 1 -- registered status
					, (SELECT CONCAT('User: ',@Username,' registered for Cin: ',[Sample_Cin],' ',[Description]) FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
				FROM @TestsToInsert [I];

				--audit trail, tests removed
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @AuditTypeIdtest
					, [I].[Sample_Cin]
					, 8 -- removed status
					, (SELECT CONCAT('User: ',@Username,' removed test for Cin: ',[Sample_Cin],' ',[Description]) FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
				FROM @TestsToRemove [I];

				COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
END;