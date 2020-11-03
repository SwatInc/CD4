CREATE PROCEDURE [dbo].[usp_CancelTestValidation]
	@ResultId int,
	@Cin varchar(50),
	@UsersId int
AS
BEGIN
SET NOCOUNT ON;
	SET XACT_ABORT ON;
	BEGIN TRY
		BEGIN TRANSACTION;
			
			--variables
			DECLARE @ToValidateStatus int = 4;
			DECLARE @TestStatusBeforeUpdate int;
			DECLARE @SampleStatusBeforeUpdate int;
			DECLARE @ValidatedStatus int = 5;
			DECLARE @RejectedStatus int = 5;
			DECLARE @TestCountNotValidatedNotRejected int = 0;
			DEClARE @AuditText varchar(200);
			DECLARE @TestName varchar(50);
			DEClARE @Username varchar(50);
			DECLARE @AuditTypeIdTest int;

			--Get current test status
			SELECT @TestStatusBeforeUpdate = [StatusId] 
			FROM [dbo].[ResultTracking] [RT]
			WHERE [RT].[ResultId]  = @ResultId;

			SELECT @SampleStatusBeforeUpdate = [StatusId]
			FROM [dbo].[SampleTracking] [ST]
			WHERE [ST].[SampleCin] = @Cin;

			--set specified result status to collected
			UPDATE [dbo].[ResultTracking]
			SET [StatusId] = @ToValidateStatus
			WHERE [ResultId] = @ResultId AND [StatusId] = @ValidatedStatus;

			-- count not validated and not rejected tests in sample.
			SELECT @TestCountNotValidatedNotRejected = COUNT([StatusId]) 
			FROM [dbo].[ResultTracking] [RT]
			WHERE [RT].[ResultId] IN --sub query gets all ResultIds corresponding to the Cin
				(SELECT [Id] FROM [dbo].[Result] WHERE [Sample_Cin] = @Cin) AND
			[RT].[StatusId] <> @ValidatedStatus AND
			[RT].[StatusId] <> @RejectedStatus;

			--set sample status as collected if sample has not-validated and not-rejected tests
			UPDATE [dbo].[SampleTracking]
			SET [StatusId] = @ToValidateStatus
			WHERE @TestCountNotValidatedNotRejected > 0 AND
			[StatusId] = @ValidatedStatus AND
			[SampleCin] = @Cin;

			-- insert test tracking history
			INSERT INTO [dbo].[TrackingHistory]([TrackingType],[ResultId],[StatusId],[UsersId])
			SELECT 3,@ResultId,[RT].[StatusId],@UsersId
			FROM [dbo].[ResultTracking] [RT]
			WHERE [RT].[StatusId] = @ToValidateStatus AND 
			[RT].[StatusId] <> @TestStatusBeforeUpdate AND
			[RT].[ResultId] = @ResultId;

			-- insert sample tracking History
			INSERT INTO [dbo].[TrackingHistory]([TrackingType],[SampleCin],[StatusId],[UsersId])
			SELECT 2,@Cin,[ST].[StatusId],@UsersId
			FROM [dbo].[SampleTracking] [ST]
			WHERE [ST].[StatusId] = @ToValidateStatus AND 
			[ST].[StatusId] <> @SampleStatusBeforeUpdate AND
			[ST].[SampleCin] = @Cin;

			-- insert audit trail
			--get test name
			SELECT @TestName = [T].[Description]
			FROM [dbo].[Test] [T]
			INNER JOIN [dbo].[Result] [R] ON [T].[Id] = [R].[TestId]
			WHERE [R].[Id] = @ResultId;
			--get username
			SELECT @Username  = [UserName] FROM [dbo].[Users] WHERE [Id] = @UsersId;
			SELECT @AuditText = CONCAT('Cancelled validation for test [ ',@TestName,' ] by user ',@Username);

			SELECT @AuditTypeIdTest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';

			INSERT INTO [dbo].[AuditTrail] ([AuditTypeId],[Cin],[StatusId],[Details])
			SELECT @AuditTypeIdTest,@Cin,[StatusId],@AuditText
			FROM [dbo].[ResultTracking] [RT]
			WHERE [RT].[ResultId] = @ResultId;

		COMMIT TRANSACTION;

		 -- return data - sample status
        SELECT [SampleCin] AS [Cin],
               [StatusId]
        FROM [dbo].[SampleTracking]
        WHERE [SampleCin] = @Cin;
        -- return data - result status, result and reference code
        SELECT [RT].[ResultId],
               [R].[Sample_Cin] AS [Cin],
               [R].[Result],
               [R].[ReferenceCode],
               [RT].[StatusId]
        FROM [dbo].[ResultTracking] [RT]
            INNER JOIN [dbo].[Result] [R]
                ON [RT].[ResultId] = [R].[Id]
        WHERE [RT].[ResultId] = @ResultId;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	 END CATCH
END

