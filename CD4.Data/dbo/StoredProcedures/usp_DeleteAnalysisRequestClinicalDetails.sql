CREATE PROCEDURE [dbo].[usp_DeleteAnalysisRequestClinicalDetails]
	@AnalysisRequestId int
AS
BEGIN
/*
This procedure needs to be called only when clinical details for the analysis request needs to be deleted.
If clinical details need to synchronised (deletion followed by insertion), use the procedure [dbo].[usp_SyncClinicalDetails]
*/
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				--drop old data
				DELETE FROM [dbo].[AnalysisRequest_ClinicalDetail] WHERE [AnalysisRequestId] = @AnalysisRequestId;

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
