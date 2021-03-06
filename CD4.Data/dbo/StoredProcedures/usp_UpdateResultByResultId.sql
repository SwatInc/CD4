﻿CREATE PROCEDURE [dbo].[usp_UpdateResultByResultId]
	@Result NVARCHAR(50),
	@ResultId int,
	@StatusId int,
	@ReferenceCode char(2),
	@UsersId int
AS
BEGIN
SET NOCOUNT ON;
SET XACT_ABORT ON;
    BEGIN TRANSACTION;
		BEGIN TRY

		DECLARE @ResultDate DATETIME2;
		DECLARE @PreviousData nvarchar(100);
		DECLARE @CurrentData nvarchar(100);
		DECLARE @Cin varchar(50);
		DECLARE @AuditTypeIdTest int;
		DECLARE @Username varchar(256);

		--AUDIT PROCESS
		--get cin
		SELECT @Cin = [Sample_Cin] FROM [dbo].[Result] WHERE [Id] = @ResultId;

		-- get initial auditing data
		SELECT @PreviousData = CONCAT(' Test: [',[R].[Sample_Cin],' | ',[T].[Description],'] with result: ', [R].[Result])
		FROM [dbo].[Status] [S]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [S].[Id] = [RT].[StatusId]
		INNER JOIN [dbo].[Result] [R] ON [RT].[ResultId] = [R].[Id]
		INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
		WHERE [RT].[ResultId] = @ResultId;

		-- UPDATE PROCESS
		--update result
			UPDATE [dbo].[Result]
			SET [Result] = @Result,
				[ReferenceCode] = @ReferenceCode
			WHERE [Id] = @ResultId;
		
		-- update result status
		UPDATE [dbo].[ResultTracking]
		SET StatusId = @StatusId,
			UsersId = @UsersId
		WHERE ResultId = @ResultId;

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

		SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UsersId;

		INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
		VALUES(@AuditTypeIdTest,@Cin, @StatusId,CONCAT('PREVIOUS: ',@PreviousData,' | CURRENT: ', @CurrentData,' by user: ',@Username));

		-- select return data
		SELECT [R].[Id] AS [ResultId],
			   [R].[Sample_Cin] AS [Cin],
			   [R].[Result],
			   [R].[ReferenceCode],
			   [RT].[StatusId]
		FROM [dbo].[Result] [R]
		INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
		WHERE [R].[Id] = @ResultId;

		COMMIT TRANSACTION;
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
			THROW;
		END CATCH;
END;