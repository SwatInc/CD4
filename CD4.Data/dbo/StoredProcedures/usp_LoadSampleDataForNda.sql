CREATE PROCEDURE [dbo].[usp_LoadSampleDataForNda]
	@FromDate char(8),
	@ToDate char(8),
	@SampleStatusId int
AS
BEGIN
	/*NOTE required fields
	Check Box (To multi-select rows)				| ** ignore
	Register Number (Institute Assigned Patient Id) | dbo.Patient
	Sample Number									| dbo.Samples
	Status											| dbo.SampleTracking
	Tested By										| [View] dbo.NdaAssaysTestedDetails
	Cal And QC validated by							| [View] dbo.NdaCalControlsValidatedDetails
	Received Date									| [dbo].[TrackingHistory]
	Processed Date									| ** Ignore; for now
	Validated Date									| [View] [dbo].[SampleValidatedTimings]
	Reported Date									| [View] [dbo].[NdaRequestsReportedDetails]
	*/
WHILE (@FromDate IS NOT NULL) AND (@ToDate <> '')
	BEGIN
		DECLARE @From DATE = CAST(@FromDate AS DATE);
		DECLARE @To DATE = CAST(@ToDate AS DATE);

		SELECT 
			 [p].[InstituteAssignedPatientId]
			,[s].[Cin]
			,[st].[StatusId] AS [StatusIconId]
			,[natd].[AnalysedBy]
			,[nccvd].[QcCalValidatedBy]
			,[sct].[CollectedAt] AS [CollectedDate]
			,[srt].[ReceivedAt] AS [ReceivedDate]
			,[svt].[ValidatedAt] AS [ValdidatedDate]
			,[nrrd].[ReportedAt] AS [ReportedDate]
		FROM [dbo].[Sample] [s]
		INNER JOIN [dbo].[AnalysisRequest] [ar] ON [s].[AnalysisRequestId] = [ar].[Id]
		INNER JOIN [dbo].[Patient] [p] ON [ar].[PatientId] = [p].[Id]
		INNER JOIN [dbo].[SampleTracking] [st] ON [s].[Cin] = [st].[SampleCin]
		LEFT JOIN [dbo].[NdaAssaysTestedDetails] [natd] ON [s].[Cin] = [natd].[Cin]
		LEFT JOIN [dbo].[NdaCalControlsValidatedDetails] [nccvd] ON [s].[Cin] = [nccvd].[Cin]
		LEFT JOIN [dbo].[SampleValidatedTimings] [svt] ON [svt].[Cin] = [s].[Cin]
		LEFT JOIN [dbo].[NdaRequestsReportedDetails] [nrrd] ON [nrrd].[Cin] = [s].[Cin]
		LEFT JOIN [dbo].[SampleReceivedTimings] [srt] ON [srt].[Cin] = [s].[Cin]
		LEFT JOIN [dbo].[SampleCollectionTimings] [sct] ON [sct].[Cin] = [s].[Cin]
		WHERE ([srt].[ReceivedAt] BETWEEN @From AND @To) AND [st].[StatusId] = @SampleStatusId;
BREAK;
	END
END

