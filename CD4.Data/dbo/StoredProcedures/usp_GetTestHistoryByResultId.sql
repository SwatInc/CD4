CREATE PROCEDURE [dbo].[usp_GetTestHistoryByResultId]
	@ResultId int,
	@AnalysisRequestId int
AS
BEGIN
	--auto number, Result, ResultDate
	DECLARE @TestHistoryData TABLE
	(
		[Id] int identity,
		[Result] varchar(50),
		ResultDate datetimeoffset
	);

	INSERT INTO @TestHistoryData ([Result], [ResultDate])
	SELECT [R].[Result], [RT].[CreatedAt] AS [ResultDate]
	FROM [dbo].[Result] [R]
	INNER JOIN [dbo].[ResultTracking] [RT] ON [RT].[ResultId] = [R].[Id]
	WHERE [RT].[StatusId] = 5  AND 
	[R].[Id] IN 
		(
			SELECT [R].[Id]
			FROM [dbo].[Result] [R]
			INNER JOIN [dbo].[Test] [T] ON [T].[Id] = [R].[TestId]
			INNER JOIN [dbo].[Sample] [S] ON [S].[Cin] = [R].[Sample_Cin]
			INNER JOIN [dbo].[AnalysisRequest] [AR] ON [AR].[Id] = [S].[AnalysisRequestId]
			INNER JOIN [dbo].[Patient] [P] ON [P].[Id] = [AR].[PatientId]
			WHERE 
			[T].[Id] IN 
				(SELECT [TestId] FROM [dbo].[Result] WHERE [Id] = @ResultId) 
			AND
			[P].[Id] IN 
				(SELECT [PatientId] AS [Id] FROM [dbo].[AnalysisRequest] WHERE [Id] = @AnalysisRequestId)
		)
	ORDER BY [ResultDate];

	SELECT [Id], [Result],[ResultDate] FROM @TestHistoryData;
END
