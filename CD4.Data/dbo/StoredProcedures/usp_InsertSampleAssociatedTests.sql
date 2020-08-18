CREATE PROCEDURE [dbo].[usp_InsertSampleAssociatedTests]
	@Sample_Cin varchar(50),
	@TestId int
	--Result and result date is null
AS
BEGIN
SET NOCOUNT ON;
	
	DECLARE @InsertedResultRecordId int;
	DECLARE @AuditTypeIdTest int;
	DECLARE @TestDescription varchar(50);
	DECLARE @Username varchar(50);
	DECLARE @TempTrackingHistory AS TABLE(
						[TrackingType] INT,
						[AnalysisRequestId] INT,
						[SampleCin] varchar(50),
						[ResultId] int,
						[TimeStamp] DATETIMEOFFSET);

	INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId])
	OUTPUT INSERTED.Id
	VALUES ( @Sample_Cin ,@TestId);

	-- TRACKING 
	SELECT @InsertedResultRecordId = SCOPE_IDENTITY();
	INSERT INTO [dbo].[ResultTracking]([ResultId],[StatusId],[UsersId])
	OUTPUT 3, INSERTED.[ResultId],INSERTED.[CreatedAt]
			INTO @TempTrackingHistory([TrackingType],[ResultId],[TimeStamp])
		 VALUES
		 (@InsertedResultRecordId, 1,1);

	-- AUDIT ENTRY
	SELECT @AuditTypeIdTest =[Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';
	SELECT @TestDescription = [Description] FROM [dbo].[Test] WHERE [Id] = @TestId;
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = 1 -- Get the Id passed in.
 	INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details])
	VALUES (@AuditTypeIdTest,@Sample_Cin,1,
			'Tests added to sample '+@Sample_Cin+ ': '+ @TestDescription+ ' by user: ' +@Username);
END