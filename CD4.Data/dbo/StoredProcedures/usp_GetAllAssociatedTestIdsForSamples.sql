CREATE PROCEDURE [dbo].[usp_GetAllAssociatedTestIdsForSamples]
	@SampleCins  [dbo].[SampleCinsUDT] READONLY
AS
BEGIN
	SELECT [R].[Sample_Cin] AS [Cin], [R].[TestId]
	FROM [dbo].[Result] [R]
	WHERE [R].[Sample_Cin] IN (SELECT DISTINCT([Cin]) AS [Cin] FROM @SampleCins);
END
