--This view needs to be filtered manually to exclude completed samples(i.e. Samples which
--have values saved for all tests.)
--This view will output all results records in the database... ever!
CREATE VIEW [dbo].[WorkSheetResultData]
WITH SCHEMABINDING
AS
SELECT [R].[Id],
	   [S].[AnalysisRequestId],
	   [S].[Cin],
	   [T].[Description],
	   [R].[Result],
	   [DT].[Name] AS [DataType],
	   [T].[Mask]
FROM [dbo].[Result] [R]
INNER JOIN [dbo].[Sample] [S] ON [R].[Sample_Cin] = [S].[Cin]
INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
INNER JOIN [dbo].[ResultDataType] [DT] ON [T].[ResultDataTypeId] = [DT].[Id]
GO
CREATE UNIQUE CLUSTERED INDEX IX_WorkSheetResultData_Id 
ON [dbo].[WorkSheetResultData] (Id);
GO