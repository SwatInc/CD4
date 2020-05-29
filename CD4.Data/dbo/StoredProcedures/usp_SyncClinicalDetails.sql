
CREATE PROCEDURE [dbo].[usp_SyncClinicalDetails]
	@CsvClinicalDetailIds varchar(100),
	@AnalysisRequestId int
AS
BEGIN
/*
This procedure cannot sync clinical details if all clinical details are to be removed.
The scenario will result in an FK violation in the insert statement since there would be no clinical detail ids to enter.

This scnario is implemented in another procedure because implementing this would create two different execution plans for this usp in application use.
That could be a performance penalty.
refer to usp_DeleteAnalysisRequestClinicalDetails
*/
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				--drop old data
				DELETE FROM [dbo].[AnalysisRequest_ClinicalDetail] WHERE [AnalysisRequestId] = @AnalysisRequestId;

				--insert the new data
				INSERT INTO [dbo].[AnalysisRequest_ClinicalDetail]([AnalysisRequestId],[ClinicalDetailsId])
				SELECT @AnalysisRequestId AS [AnalysisRequestId] ,CAST(value as int) AS [ClinicalDetailsId] 
				FROM STRING_SPLIT(@CsvClinicalDetailIds,',');

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