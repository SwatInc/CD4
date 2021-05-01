--This view needs to be filtered manually to exclude completed samples(i.e. Samples which
--have values saved for all tests.)
--This view will output all results records in the database... ever!
CREATE VIEW [dbo].[WorkSheetResultData]
AS
SELECT [R].[Id],
	   [S].[AnalysisRequestId],
	   [S].[Cin],
	   [D].[Description] AS [Discipline],
	   [D].[Id] AS [DisciplineId],
	   [T].[Description],
	   [R].[Result],
	   [U].[Unit],
	   [DT].[Name] AS [DataType],
	   [T].[Mask],
	   [RT].[StatusId],
	   [R].[ReferenceCode],
	   [R].[IsDeltaOk],
	   [T].[Reportable]
FROM [dbo].[Result] [R]
INNER JOIN [dbo].[Sample] [S] ON [R].[Sample_Cin] = [S].[Cin]
INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
INNER JOIN [dbo].[ResultDataType] [DT] ON [T].[ResultDataTypeId] = [DT].[Id]
INNER JOIN [dbo].[Discipline] [D] ON [D].[Id] = [T].[DisciplineId]
INNER JOIN [dbo].[Unit] [U] ON [U].[Id] = [T].[UnitId]
LEFT JOIN [dbo].[ResultTracking] [RT] ON [RT].[ResultId] = [R].[Id]; --tracking current result status.
GO