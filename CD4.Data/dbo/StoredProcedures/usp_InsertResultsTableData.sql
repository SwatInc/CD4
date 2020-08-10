﻿CREATE PROCEDURE [dbo].[usp_InsertResultsTableData]
	@TestsToInsert [dbo].[ResultTableInsertDataUDT] READONLY,
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
            
			DECLARE @TrackingData TABLE ([ResultId] int)
			DECLARE @AuditTypeIdTest int;
			DECLARE @Username varchar(50);

			--add tests requested for insertion
			INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
            OUTPUT inserted.[Id] INTO @TrackingData
			SELECT [I].[Sample_Cin], [I].[TestId] FROM @TestsToInsert [I];

            -- TRACKING: Added tests
            INSERT INTO [dbo].[ResultTracking] ([ResultId],[StatusId],[UsersId])
			SELECT [ResultId],1,@UserId FROM @TrackingData;

            -- AUDIT
			--audit trail, tests added
			SELECT @AuditTypeIdtest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
			SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
				
			INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
			SELECT @AuditTypeIdtest
				, [I].[Sample_Cin]
				, 1 -- registered status
				, (SELECT CONCAT('User: ',@Username,N' registered for Cin: ',[Sample_Cin] ,N' ', [Description]) 
			FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
			FROM @TestsToInsert [I];

	COMMIT TRANSACTION;
			SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;
