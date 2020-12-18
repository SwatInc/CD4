CREATE PROCEDURE [dbo].[usp_FetchResultWithStatusDataByCin]
	@Cin varchar(50)
AS
BEGIN
	 SELECT [R].[Id] AS [ResultId],
			[R].[Sample_Cin] AS [Cin],
			[R].[Result],
			[R].[ReferenceCode],
			[RT].[StatusId],
			[T].[Description] AS [TestName],
            [U].[Unit]
	 FROM [dbo].[Sample] [S]
	 INNER JOIN [dbo].[Result] [R] ON [S].[Cin] = [R].[Sample_Cin]
	 INNER JOIN [dbo].[Test] [T] ON [R].[TestId] = [T].[Id]
     INNER JOIN [dbo].[Unit] [U] ON [T].[UnitId] = [U].[Id]
	 INNER JOIN [dbo].[ResultTracking] [RT] ON [R].[Id] = [RT].[ResultId]
	 WHERE [S].[Cin] = @Cin;
END
