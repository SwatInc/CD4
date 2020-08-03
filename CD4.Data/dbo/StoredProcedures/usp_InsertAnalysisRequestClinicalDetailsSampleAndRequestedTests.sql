CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequestClinicalDetailsSampleAndRequestedTests]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@Cin varchar(50),
	@SampleStatusId int,
	@SiteId int,
	@CommaDelimitedClinicalDetailsIds varchar(100),
	@UserId int,
	@RequestedTestData [dbo].[ResultTableInsertDataUDT] READONLY
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				
				DECLARE @AnalysisRequestId int;
				DECLARE @AuditTypeId int;
				DECLARE @DemoUserId int = 1;
				DECLARE @Username varchar(50);
				DECLARE @TestsRegistered varchar(500);

				--used to catch all inserted ids
				DECLARE @InsertedId TABLE ([Id] int);

				--insert into dbo.AnalysisRequest
				INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
				OUTPUT INSERTED.Id INTO @InsertedId
				VALUES (@PatientId, @EpisodeNumber, @Age);

				--set inserted analysis requestId
				SELECT @AnalysisRequestId =  [Id] FROM @InsertedId;

				--insert clincial details
				INSERT INTO [dbo].[AnalysisRequest_ClinicalDetail]([AnalysisRequestId],[ClinicalDetailsId])
				SELECT @AnalysisRequestId AS [AnalysisRequestId] ,CAST(value as int) AS [ClinicalDetailsId] 
				FROM STRING_SPLIT(@CommaDelimitedClinicalDetailsIds,',');

				--insert into dbo.Sample
				INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId])
				VALUES (@Cin,@AnalysisRequestId , @SiteId);

				--insert into dbo.Result
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
				SELECT [TD].[Sample_Cin], [TD].[TestId]
				FROM @RequestedTestData [TD];

				--TRACKING (StatusId for registered (1).)
				--request tracking
				INSERT INTO [dbo].[RequestTracking]([AnalysisRequestId],[StatusId],[UsersId]) 
				VALUES (@AnalysisRequestId,1,@DemoUserId) 
				--sample tracking
				INSERT INTO [dbo].[SampleTracking] ([SampleCin],[StatusId],[UsersId])
				VALUES (@Cin,1,@DemoUserId);
				--tests tracking
				INSERT INTO [dbo].[ResultTracking] ([ResultId],[StatusId],[UsersId])
				SELECT [Id], 1,@UserId FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;
				
				--AUDIT TRAIL
				--select username for audit
				SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
				--request record audit
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'AnalysisRequest';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[StatusId],[Details]) VALUES
				(@AuditTypeId,1,'Request registered for sample number: '+ @Cin+ ' by ' +@UserName+ ' at '+ GETDATE())
				--insert sample audit Trail
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details]) VALUES
				(@AuditTypeId,@Cin,1,'Sample: '+ @Cin +' created by user: '+ @UserName +' at '+GETDATE());
				--get tests registered for Cin
				SELECT @TestsRegistered = STRING_AGG([T].[Description],',') 
				FROM [dbo].[Result] [R]
				INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
				WHERE [R].[Sample_Cin] = @Cin;
				--insert tests audit trail
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[StatusId],[Details]) VALUES
				(@AuditTypeId,1,'Tests registered for sample number '+ @Cin+ ':'+@TestsRegistered+ ' by '+@UserName+ ' at '+ GETDATE())

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;