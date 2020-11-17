CREATE PROCEDURE [dbo].[usp_InsertAnalysisRequest]
	@PatientId int,
	@EpisodeNumber varchar(15),
	@Age varchar(20),
	@UserId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
    BEGIN TRANSACTION;
		BEGIN TRY

			DECLARE @InsertedRequestId int;
			DECLARE @LoggedInUser varchar(256);
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

			SELECT @AuditTypeIdRequest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'AnalysisRequest';
			-- TRACKING HISTORY
			INSERT INTO [dbo].[TrackingHistory]([TrackingType],[AnalysisRequestId],[StatusId],[UsersId])
			VALUES (@AuditTypeIdRequest,@InsertedRequestId,1,1)

			-- get username
			SELECT @LoggedInUser =  [UserName] FROM [dbo].[Users] WHERE [Id] = @UserId;

			--AUDIT
			SELECT @AuditPatientInfo = CONCAT([FullName], ' (',[Id],' | ',[NidPp],')') FROM [dbo].[Patient] WHERE [Id] = @PatientId;

			INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[StatusId],[Details])
				 VALUES
					   (@AuditTypeIdRequest,
					   1,
					   CONCAT('Created analysis request for episode number: [',@EpisodeNumber,'] by user: ',@LoggedInUser,' for ', @AuditPatientInfo));

	COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
END;