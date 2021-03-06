﻿CREATE PROCEDURE [dbo].[usp_RemoveResultsTableData]
	@TestsToRemove [dbo].[ResultTableInsertDataUDT] READONLY,
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY

            DECLARE @AuditTypeIdTest int;
            DECLARE @Cin VARCHAR(50);
			DECLARE @Username varchar(50);
			--DECLARE @ResultIdsToRemove TABLE ([Id] INT NOT NULL UNIQUE);
			DECLARE @TempTrackingHistory TABLE ([ResultId] INT NOT NULL, [StatusId] INT NOT NULL);


            -- TRACKING: Tests to remove

			-- get the Cin from tests to remove
            SELECT TOP 1 @Cin =  [Sample_Cin] FROM @TestsToRemove;
            --remove relavent tracking data and return removed result Ids

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

			--remove from tracking history
			DELETE FROM [dbo].[TrackingHistory]
			WHERE [ResultId]  IN 
            (
                SELECT [ResultId] FROM @TempTrackingHistory
            );

			--REFERENCE RANGE: remove reference ranges for tests to be removed.
			DELETE FROM [dbo].[ResultReferenceRanges]
			WHERE [ResultId] IN (SELECT [ResultId] FROM @TempTrackingHistory);

			--remove tests requested for removal
			DELETE FROM [dbo].[Result] 
			WHERE 
			([TestId] IN (SELECT [R].[TestId]  FROM @TestsToRemove [R])) AND
			[Sample_Cin] = (SELECT TOP(1)[R].[Sample_Cin] FROM @TestsToRemove [R]);

			-- TRACKING HISTORY
			--INSERT INTO [dbo].[TrackingHistory]([TrackingType],[ResultId],[StatusId])
			--SELECT 3,[Id],8 FROM @ResultIdsToRemove;

            -- AUDIT
			SELECT @AuditTypeIdtest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
			SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;

			--audit trail, tests removed
			INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
			SELECT @AuditTypeIdtest
				, [I].[Sample_Cin]
				, 8 -- removed status
				, (SELECT CONCAT('User: ',@Username,' removed test for Cin: ',[Sample_Cin],' ',[Description]) FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
			FROM @TestsToRemove [I];
	COMMIT TRANSACTION;
			SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;