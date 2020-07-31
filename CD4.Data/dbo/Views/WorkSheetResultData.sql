--This view needs to be filtered manually to exclude completed samples(i.e. Samples which
--have values saved for all tests.)
--This view will output all results records in the database... ever!
CREATE VIEW [dbo].[WorkSheetResultData]
WITH SCHEMABINDING
AS
SELECT [R].[Id],
	   [S].[AnalysisRequestId],
	   [S].[Cin],
	   [D].[Description] AS [Discipline],
	   [T].[Description],
	   [R].[Result],
	   [U].[Unit],
	   [DT].[Name] AS [DataType],
	   [T].[Mask],
	   [R].[StatusId]
FROM [dbo].[Result] [R]
INNER JOIN [dbo].[Sample] [S] ON [R].[Sample_Cin] = [S].[Cin]
INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
INNER JOIN [dbo].[ResultDataType] [DT] ON [T].[ResultDataTypeId] = [DT].[Id]
INNER JOIN [dbo].[Discipline] [D] ON [D].[Id] = [T].[DisciplineId]
INNER JOIN [dbo].[Unit] [U] ON [U].[Id] = [T].[UnitId]
GO
CREATE UNIQUE CLUSTERED INDEX [IX_Id_WorkSheetResultData]
ON [dbo].[WorkSheetResultData] ([Id])
GO
CREATE NONCLUSTERED INDEX [IX_Cin_WorkSheetResultData]
ON [dbo].[WorkSheetResultData] ([Cin])
GO