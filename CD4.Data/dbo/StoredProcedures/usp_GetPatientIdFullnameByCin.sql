CREATE PROCEDURE [dbo].[usp_GetPatientIdFullnameByCin]
	 @Cin VARCHAR(50)
AS
BEGIN
	SELECT [P].[NidPp], [P].[FullName]
	FROM [dbo].[Sample] [S]
	INNER JOIN [dbo].[AnalysisRequest] [AR] ON [S].[AnalysisRequestId] = [AR].[Id]
	INNER JOIN [dbo].[Patient] [P] ON [AR].[PatientId] = [P].[Id]
	WHERE [S].[Cin] = @Cin;
END;