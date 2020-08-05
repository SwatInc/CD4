﻿CREATE PROCEDURE [dbo].[usp_UpdateSampleWithCin]
	@Cin varchar(50),
	@SiteId int,
	@CollectionDate date,
	@ReceivedDate date
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY

				UPDATE [dbo].[Sample]
				SET [SiteId] = @SiteId
				WHERE [Cin] = @Cin;

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;
