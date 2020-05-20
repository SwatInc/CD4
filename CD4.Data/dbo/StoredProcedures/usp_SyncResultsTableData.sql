CREATE PROCEDURE [dbo].[usp_SyncResultsTableData]
	@TestsToInsert [dbo].[ResultTableInsertDataUDT] READONLY,
	@TestsToRemove [dbo].[ResultTableInsertDataUDT] READONLY
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				
				--remove tests requested for removal
				DELETE FROM [dbo].[Result] 
				WHERE 
				([TestId] IN (SELECT [R].[TestId]  FROM @TestsToRemove [R])) AND
				[Sample_Cin] = (SELECT TOP(1)[R].[Sample_Cin] FROM @TestsToRemove [R]);

				--add tests requested for insertion
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
				SELECT [I].[Sample_Cin], [I].[TestId] FROM @TestsToInsert [I];

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
				IF (XACT_STATE()) = -1  
				BEGIN  
					ROLLBACK TRANSACTION; 
				END;
				THROW;
		END CATCH;
SELECT @ReturnValue;
END;