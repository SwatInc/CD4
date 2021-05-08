CREATE PROCEDURE [dbo].[usp_UpdateSamplePriorityByCin]
	@Cin varchar(50),
	@Priority bit,
	@UserId int
AS
BEGIN
	DECLARE @PriorityCurrent bit;
	DECLARE @Username varchar(50);
	DECLARE @SampleStatus int;

	--get required data
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
	SELECT @PriorityCurrent = [IsStat] FROM [dbo].[Sample] WHERE [Cin] = @Cin;
	SELECT @SampleStatus = [StatusId] FROM [dbo].[SampleTracking] WHERE [SampleCin] = @Cin;

	--set requested priority if different from current
	UPDATE [dbo].[Sample] 
	SET [IsStat] = @Priority
	WHERE @PriorityCurrent <> @Priority AND [Cin] = @Cin;

	--audit
	DECLARE @InsertedId int;
	DECLARE @AuditDetails varchar(500) = CONCAT(@Username, ' requested sample priority to change from ', @PriorityCurrent, ' to ', @Priority);
	EXEC [dbo].[usp_InsertSampleAuditTrail] 
		  @Cin
		, @SampleStatus
		, @AuditDetails
		, @InsertedId OUTPUT;
END
