CREATE PROCEDURE [dbo].[usp_SyncResultsTableData]
	@TestsToInsert [dbo].[ResultTableInsertDataUDT] READONLY,
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
				DECLARE @Username varchar(50);
				--remove tests requested for removal
				DELETE FROM [dbo].[Result] 
				WHERE 
				([TestId] IN (SELECT [R].[TestId]  FROM @TestsToRemove [R])) AND
				[Sample_Cin] = (SELECT TOP(1)[R].[Sample_Cin] FROM @TestsToRemove [R]);

				--add tests requested for insertion
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
				SELECT [I].[Sample_Cin], [I].[TestId] FROM @TestsToInsert [I];

				COMMIT TRANSACTION;

				--audit trail, tests added
				SELECT @AuditTypeIdtest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
				
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @AuditTypeIdtest
					, [I].[Sample_Cin]
					, 1 -- registered status
					, (SELECT 'User: '+@Username+' registered for Cin: '+[Sample_Cin] +' '+ [Description] FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
				FROM @TestsToInsert [I];

				--audit trail, tests removed
				INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
				SELECT @AuditTypeIdtest
					, [I].[Sample_Cin]
					, 7 -- rejected status
					, (SELECT 'User: '+@Username+' rejected test for Cin: '+[Sample_Cin] +' '+ [Description] FROM [dbo].[Test] WHERE [Id] = [I].[TestId]) 
				FROM @TestsToRemove [I];

				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;