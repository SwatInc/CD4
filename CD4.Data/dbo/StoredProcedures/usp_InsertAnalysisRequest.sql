CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequest]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20)
AS
BEGIN
SET NOCOUNT ON;
	DECLARE @InsertedRequestId int;
	DECLARE @AuditTypeIdRequest int;
	DECLARE @AuditPatientInfo varchar(200);

	INSERT INTO [dbo].[AnalysisRequest]([PatientId], [EpisodeNumber], [Age])
	OUTPUT INSERTED.Id
	VALUES (@PatientId, @EpisodeNumber, @Age);

	SELECT @InsertedRequestId = SCOPE_IDENTITY();

	-- TRACKING
	-- Insert rows into table 'RequestTracking' in schema '[dbo]'
	INSERT INTO [dbo].[RequestTracking]
	( -- Columns to insert data into
	 [AnalysisRequestId],[StatusId],[UsersId]
	)
	VALUES
	( -- First row: values for the columns in the list above
	 @InsertedRequestId, 1, 1
	);

	--AUDIT
	SELECT @AuditPatientInfo = CONCAT([Fullname], ' (',[Id],' | ',[NidPp],')') FROM [dbo].[Patient] WHERE [Id] = @PatientId;
	SELECT @AuditTypeIdRequest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'AnalysisRequest';

	INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[StatusId],[Details])
		 VALUES
			   (@AuditTypeIdRequest,
			   1,
			   'Created analysis request for episode number: ['+@EpisodeNumber+'] by user: NA for '+ @AuditPatientInfo);
END