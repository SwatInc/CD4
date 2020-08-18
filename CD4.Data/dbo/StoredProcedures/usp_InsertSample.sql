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
			DECLARE @TempTrackingHistory AS TABLE(
								[TrackingType] INT,
								[AnalysisRequestId] INT,
								[SampleCin] varchar(50),
								[ResultId] int,
								[TimeStamp] DATETIMEOFFSET);

			--insert sample
			INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId])
			VALUES (@Cin, @AnalysisRequestId, @SiteId);

			--insert sample status as registered (1).
			INSERT INTO [dbo].[SampleTracking] ([SampleCin],[StatusId],[UsersId])
			OUTPUT 2,INSERTED.[SampleCin],INSERTED.[CreatedAt]
				INTO @TempTrackingHistory([TrackingType],[SampleCin],[TimeStamp])
			VALUES (@Cin,1,@DemoUserId);
			--ToDo: Set users Id via parameter in the above query.

			--TRACKING HISTORY
			INSERT INTO [dbo].[TrackingHistory]([TrackingType],[AnalysisRequestId],[SampleCin],[ResultId],[StatusId],[UsersId],[TimeStamp])
			SELECT [TrackingType],[AnalysisRequestId],[SampleCin],[ResultId],1,@UserId,[TimeStamp]
			FROM @TempTrackingHistory;

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
