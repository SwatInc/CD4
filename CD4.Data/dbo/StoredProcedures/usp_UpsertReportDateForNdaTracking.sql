CREATE PROCEDURE [dbo].[usp_UpsertReportDateForNdaTracking]
	@SampleCins  [dbo].[SampleCinsUDT] READONLY,
	@ReportDate char(8),
	@LoggedInUserId int
AS
BEGIN
	WHILE (@ReportDate IS NOT NULL)
		BEGIN
			DECLARE @AnalysisReportDate DATETIMEOFFSET(7) = CAST('20210301' AS DATETIME) AT TIME ZONE 'Pakistan Standard Time';
			DECLARE @ReportedLookupId INT;
			DECLARE @SampleAuditTypeId INT;
			DECLARE @UserName varchar(50);

			SELECT @ReportedLookupId = [Id] 
			FROM [dbo].[NdaLookup]
			WHERE [Description] = 'Reported';

			-- DELETE
			DELETE FROM [NdaTimeTracking]
			WHERE [NdaLookupId] = @ReportedLookupId AND 
				  [Cin] IN (SELECT [Cin] FROM @SampleCins);

			-- INSERT
			INSERT [dbo].[NdaTimeTracking] ([Cin],[TrackedTime],[NdaLookupId],[CreatedBy])
			SELECT Cin,@AnalysisReportDate,@ReportedLookupId,@LoggedInUserId
			FROM @SampleCins


			--AUDIT TRAIL
			SELECT @SampleAuditTypeId = [Id]
			FROM [dbo].[AuditTypes]
			WHERE [Description] = 'Sample';

			SELECT @UserName = [UserName] 
			FROM [dbo].[Users]
			WHERE [Id] = @LoggedInUserId;

			INSERT INTO [dbo].[AuditTrail]([AuditTypeId],[Cin],[StatusId],[Details])
			SELECT @SampleAuditTypeId, [SampleCin] AS [Cin], [StatusId], CONCAT(@Username,' has set Reported date set for sample ',[SampleCin],': ',@AnalysisReportDate)
			FROM [dbo].[SampleTracking]
			WHERE [SampleCin] IN (SELECT [Cin] AS [SampleCin] FROM @SampleCins);

			--report back the cin and report date for UI update
			SELECT [Cin],[TrackedTime] AS [ReportDate]
			FROM [dbo].[NdaTimeTracking]
			WHERE [NdaLookupId] = @ReportedLookupId AND 
				  [Cin] IN (SELECT DISTINCT([Cin]) FROM @SampleCins)

				  
	BREAK;
		END
END
