--THIS PROCEDURE IS CALLED IF THE INSERTED REQUEST DOES NOT HAVE ANY CLINICAL DETAILS
CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequestSampleAndRequestedTests]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@Cin varchar(50),
	@SampleStatusId int,
	@SiteId int,
	@UserId int,
	@RequestedTestData [dbo].[ResultTableInsertDataUDT] READONLY
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY
				DECLARE @TrackingData TABLE ([Id] INT PRIMARY KEY IDENTITY(1,1), [ResultId] int);
				DECLARE @AnalysisRequestId int;
				DECLARE @AuditTypeId int;
				DECLARE @DemoUserId int = 1;
				DECLARE @Username varchar(50);
				DECLARE @TestsRegistered varchar(500);
				DECLARE @TempTrackingHistory AS TABLE(
									[TrackingType] INT,
									[AnalysisRequestId] INT,
									[SampleCin] varchar(50),
									[ResultId] int,
									[TimeStamp] DATETIMEOFFSET);

				--used to catch all inserted ids
				DECLARE @InsertedId TABLE ([Id] int);

				--insert into dbo.AnalysisRequest
				INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
				OUTPUT INSERTED.Id INTO @InsertedId
				VALUES (@PatientId, @EpisodeNumber, @Age);

				--set inserted analysis requestId
				SELECT @AnalysisRequestId =  [Id] FROM @InsertedId;

				--insert into dbo.Sample
				INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId])
				VALUES (@Cin,@AnalysisRequestId , @SiteId);

				--insert into dbo.Result
				INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
				OUTPUT INSERTED.[Id] INTO @TrackingData
				SELECT [TD].[Sample_Cin], [TD].[TestId]
				FROM @RequestedTestData [TD];

				-- REFERENCE RANGE: insert reference ranges for inserted tests
				DECLARE @Counter INT;
				DECLARE @MaxValue INT;
				DECLARE @InsertedResultId int;
				SELECT @MaxValue = COUNT([ResultId]) FROM @TrackingData;
				SET @Counter=1
				WHILE ( @Counter <= @MaxValue)
				BEGIN
					SELECT @InsertedResultId = [ResultId] FROM @TrackingData WHERE [Id] = @Counter;
					EXEC [dbo].[usp_InsertResultReferenceRange] @ResultId = @InsertedResultId;
					SET @Counter  = @Counter  + 1;
				END

				--TRACKING (StatusId for registered (1).)
				--request tracking
				INSERT INTO [dbo].[RequestTracking]([AnalysisRequestId],[StatusId],[UsersId]) 
				OUTPUT 1, INSERTED.[AnalysisRequestId], INSERTED.[CreatedAt]
						INTO @TempTrackingHistory([TrackingType],[AnalysisRequestId],[TimeStamp])
				VALUES (@AnalysisRequestId,1,@DemoUserId) 
				--sample tracking
				INSERT INTO [dbo].[SampleTracking] ([SampleCin],[StatusId],[UsersId])
				OUTPUT 2,INSERTED.[SampleCin],INSERTED.[CreatedAt]
					INTO @TempTrackingHistory([TrackingType],[SampleCin],[TimeStamp])
				VALUES (@Cin,1,@DemoUserId);
				--tests/results tracking
				INSERT INTO [dbo].[ResultTracking] ([ResultId],[StatusId],[UsersId])
				OUTPUT 3, INSERTED.[ResultId],INSERTED.[CreatedAt]
						INTO @TempTrackingHistory([TrackingType],[ResultId],[TimeStamp])
				SELECT [Id], 1,@UserId FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin;
				
				--TRACKING HISTORY
				INSERT INTO [dbo].[TrackingHistory]([TrackingType],[AnalysisRequestId],[SampleCin],[ResultId],[StatusId],[UsersId],[TimeStamp])
				SELECT [TrackingType],[AnalysisRequestId],[SampleCin],[ResultId],1,@UserId,[TimeStamp]
				FROM @TempTrackingHistory;

				--AUDIT TRAIL
				--select username for audit
				SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;
				--request record audit
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'AnalysisRequest';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[StatusId],[Details]) VALUES
				(@AuditTypeId,1,'Request registered for sample number: '+ @Cin+ ' by ' +@UserName+ ' at '+ CONVERT(varchar(25),GETDATE(),127))
				--insert sample audit Trail
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Sample';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details]) VALUES
				(@AuditTypeId,@Cin,1,'Sample: '+ @Cin +' created by user: '+ @UserName +' at '+ CONVERT(varchar(25),GETDATE(),127));
				--get tests registered for Cin
				SELECT @TestsRegistered = STRING_AGG([T].[Description],',') 
				FROM [dbo].[Result] [R]
				INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
				WHERE [R].[Sample_Cin] = @Cin;
				--insert tests audit trail
				SELECT @AuditTypeId = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
				INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[StatusId],[Details]) VALUES
				(@AuditTypeId,1,'Tests registered for sample number '+ @Cin+ ':'+@TestsRegistered+ ' by '+@UserName+ ' at '+ CONVERT(varchar(25),GETDATE(),127))

				COMMIT TRANSACTION;
				SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION; 
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;