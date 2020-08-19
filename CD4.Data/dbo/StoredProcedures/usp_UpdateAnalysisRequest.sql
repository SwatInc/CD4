CREATE PROCEDURE [dbo].[usp_UpdateAnalysisRequest]
	@Id int,
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20)
AS
BEGIN
SET NOCOUNT ON;
	
	DECLARE @AuditTypeIdRequest int;
	DECLARE @CurrentStatusId int;
	DECLARE @RequestTraceBeforeUpdate varchar(100);
	DECLARE @RequestTraceAfterUpdate varchar(100);
	DECLARE @Username varchar(50);

	-- collect data before update.
	SELECT @RequestTraceBeforeUpdate  = CONCAT([P].[Fullname], ' [',[P].[Id],' | ',[P].[NidPp],']. Episode Number: ', [AR].[EpisodeNumber],' and age: ',[AR].[Age]) 
	FROM [dbo].[AnalysisRequest] [AR]
	INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
	WHERE [AR].[Id] = @Id

	UPDATE [dbo].[AnalysisRequest]
	SET [PatientId] = @PatientId,
		[EpisodeNumber] = @EpisodeNumber,
		[Age] = @Age
	WHERE [Id] = @Id;

	-- Todo: TRACKING
	-- AUDIT: Analysis Request details updated for sample
	--collect data after update
	SELECT @RequestTraceAfterUpdate  = CONCAT([P].[Fullname], ' [',[P].[Id],' | ',[P].[NidPp],']. Episode Number: ', [AR].[EpisodeNumber],' and age: ',[AR].[Age])  
	FROM [dbo].[AnalysisRequest] [AR]
	INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
	WHERE [AR].[Id] = @Id;

	SELECT @AuditTypeIdRequest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'AnalysisRequest';
	SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = 1 -- Get the Id passed in.
	SELECT @CurrentStatusId = [Id] FROM [dbo].[RequestTracking] WHERE [AnalysisRequestId] = @Id;

	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[StatusId],[Details])
		 VALUES
			   (@AuditTypeIdRequest,
			   1,
			   'Analysis Request updated. BEFORE: '+@RequestTraceBeforeUpdate+', AFTER: '+@RequestTraceAfterUpdate+ 'by user: '+@Username);
END
