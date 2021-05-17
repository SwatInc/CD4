CREATE PROCEDURE [dbo].[usp_GetAllTestsForConfiguration]
AS
BEGIN
SET NOCOUNT ON;
	SELECT 
		[t].[Id]
	  , [d].[Description] AS [Discipline]
	  , [t].[Description]
	  , [st].[Description] AS [SampleType]
	  , [r].[Name] AS [ResultDataType]
	  , [t].[Mask]
	  , [u].[Unit]
	  , [t].[Code]
	  , [t].[Reportable] AS [IsReportable]
	  , [t].[DefaultCommented]
	FROM [dbo].[Test] [t]
	INNER JOIN [dbo].[ResultDataType][r]  ON [t].[ResultDataTypeId] = [r].[Id]
	INNER JOIN [dbo].[Discipline] [d] ON [t].[DisciplineId] = [d].[Id]
	INNER JOIN [dbo].[SampleType] [st] ON [t].[SampleTypeId] = [st].[Id]
	INNER JOIN [dbo].[Unit] [u] ON [t].[UnitId] = [u].[Id];
END
