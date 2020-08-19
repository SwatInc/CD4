﻿CREATE PROCEDURE [dbo].[usp_UpdateResultByResultId]
	@Result VARCHAR(50),
	@ResultId int,
	@StatusId int,
	@UsersId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
DECLARE @ReturnValue bit = 0;
    BEGIN TRANSACTION;
		BEGIN TRY

		DECLARE @ResultDate DATETIME2;
		DECLARE @PreviousData varchar(50);
		DECLARE @CurrentData varchar(50);
		DECLARE @Cin varchar(50);
		DECLARE @AuditTypeIdTest int;
		--AUDIT PROCESS
		--get cin
		SELECT @Cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;

		-- get initial auditing data
		SELECT @PreviousData = CONCAT(' Test: ['+[R].[Sample_Cin]+' | ',[T].[Description],'] with result: '+ [R].[Result])
		FROM [dbo].[Status] [S]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [S].[Id] = [RT].[StatusId]
		INNER JOIN [dbo].[Result] [R] ON [RT].[ResultId] = [R].[Id]
		INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
		WHERE [RT].[ResultId] = @ResultId;

		-- UPDATE PROCESS
		--update result
			UPDATE [dbo].[Result]
			SET [Result] = @Result
			WHERE [Id] = @ResultId;
		
		-- update result status
		UPDATE [dbo].[ResultTracking]
		SET StatusId = @StatusId,
			UsersId = @UsersId
		WHERE ResultId = @ResultId

		-- TRACKING
		UPDATE [dbo].[ResultTracking]
		SET [StatusId] = @StatusId,
			[UsersId] = @UsersId
		WHERE [ResultId] = @ResultId;

		-- TRACKING HISTORY
		INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId]) VALUES
		(3,@ResultId,@StatusId,@UsersId);

		
		-- AUDIT PROCESS
		-- get after updated auditing data
		SELECT @CurrentData = CONCAT(' Test: [',[R].[Sample_Cin],' | ',[T].[Description],'] with result: ', [R].[Result])
		FROM [dbo].[Status] [S]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [S].[Id] = [RT].[StatusId]
		INNER JOIN [dbo].[Result] [R] ON [RT].[ResultId] = [R].[Id]
		INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
		WHERE [RT].[ResultId] = @ResultId;

		SELECT @AuditTypeIdTest = [Id] FROM [dbo].[AuditTypes] WHERE [Description] = 'Test';

		INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
		VALUES(@AuditTypeIdTest,@Cin, @StatusId,CONCAT('PREVIOUS: ',@PreviousData,' |. CURRENT: ', @CurrentData));

		COMMIT TRANSACTION;
			SET @ReturnValue = 1;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
SELECT @ReturnValue;
END;