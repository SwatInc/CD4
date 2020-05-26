CREATE PROCEDURE [dbo].[usp_UpdateResultByResultId]
	@Result VARCHAR(50),
	@ResultId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY

			UPDATE [dbo].[Result]
			SET [Result] = @Result,
				[ResultDate] = GETDATE()
			WHERE [Id] = @ResultId;
		
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