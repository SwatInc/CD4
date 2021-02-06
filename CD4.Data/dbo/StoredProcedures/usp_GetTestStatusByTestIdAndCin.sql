CREATE PROCEDURE [dbo].[usp_GetTestStatusByTestIdAndCin]
	@TestId int,
	@Cin varchar(50)
AS
BEGIN
	SELECT [rt].[StatusId] AS [TestStatus]
	FROM [dbo].[Result] [r]
	INNER JOIN [dbo].[ResultTracking] [rt] ON [r].[Id] = [rt].[ResultId]
	WHERE [r].[TestId] = @TestId AND [r].[Sample_Cin] = @Cin;
END
