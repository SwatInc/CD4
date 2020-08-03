CREATE PROCEDURE [dbo].[usp_InsertSample]
	@Cin varchar(50),
	@AnalysisRequestId int,
	@SiteId int,
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
	SET XACT_ABORT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			
			--variables
			DECLARE @AuditTypeId int;
			DECLARE @DemoUserId int = 1;
			DECLARE @Username varchar(50);

			--insert sample
			INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId])
			VALUES (@Cin, @AnalysisRequestId, @SiteId);

			--insert sample status as registered (1).
			INSERT INTO [dbo].[SampleTracking] ([SampleCin],[StatusId],[UsersId])
			VALUES (@Cin,1,@DemoUserId);
			--ToDo: Set users Id via parameter in the above query.

			--select the audit type
			SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
			--select username for audit
			SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
			--insert audit Trail
			INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details]) VALUES
			(@AuditTypeId,@Cin,1,'Sample: '+ @Cin +' created by user: '+ @UserName +' at '+GETDATE());

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	 END CATCH
END
