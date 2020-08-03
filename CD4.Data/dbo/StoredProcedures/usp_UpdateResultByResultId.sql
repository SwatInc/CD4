CREATE PROCEDURE [dbo].[usp_UpdateResultByResultId]
	@Result VARCHAR(50),
	@ResultId int,
	@StatusId int,
	@UsersId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY

		DECLARE @ResultDate DATETIME2;

		--update result
			UPDATE [dbo].[Result]
			SET [Result] = @Result
				--[ResultDate] = GETDATE(),
				--[StatusId] = @StatusId
			WHERE [Id] = @ResultId;
		
		-- update result status
		UPDATE [dbo].[ResultTracking]
		SET StatusId = @StatusId,
			UsersId = @UsersId
		WHERE ResultId = @ResultId

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