CREATE PROCEDURE [dbo].[usp_GetResultCommentsByResultId]
	@ResultId int
AS
BEGIN
	SELECT [ResultId], [Comment] 
	FROM [dbo].[ResultComments] WITH (NOEXPAND)
	WHERE 
		[ResultId] = @ResultId;
END
