CREATE PROCEDURE [dbo].[DecideAndExecInsertOrUpdateSampleAcceptedDatetime]
	@Cin varchar(50),
	@AcceptedAt char(19) -- format 'yyyy-MM-dd HH:mm:ss'
AS
BEGIN
	DECLARE @AcceptedStatusId int;
	DECLARE @IsAccepted int;

    SELECT @AcceptedStatusId = [Id] 
	FROM [dbo].[Status] 
	WHERE [Status] = 'Received';

	SELECT @IsAccepted = COUNT(1) 
	FROM [dbo].[TrackingHistory] 
	WHERE [StatusId] = @AcceptedStatusId AND [SampleCin] = @Cin;

	IF @IsAccepted > 0   
		BEGIN
			EXEC [dbo].[usp_UpdateAcceptedDateTimeForSampleFromBilling] @Cin = @Cin ,@AcceptedAt = @AcceptedAt;
		END
	ELSE
		BEGIN
			EXEC [dbo].[usp_InsertAcceptedDateTimeForSampleFromBilling] @Cin =@Cin ,@AcceptedAt = @AcceptedAt;
		END

END
