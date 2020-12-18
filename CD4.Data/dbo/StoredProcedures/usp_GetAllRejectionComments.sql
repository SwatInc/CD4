CREATE PROCEDURE [dbo].[usp_GetAllCommentsByTypeId]
 @CommentTypeId int
AS
BEGIN
	SELECT [CL].[Id], [CL].[Description] AS [Comment]
	FROM [dbo].[CommentList] [CL]
	INNER JOIN [dbo].[CommentList_CommentType] [CCT] ON [CL].[Id] = [CCT].[CommentListId]
	INNER JOIN [dbo].[CommentType] [CT] ON [CCT].[CommentTypeId] = [CT].[Id]
	WHERE [CT].[Id] = @CommentTypeId AND 
		  [CCT].[IsActive] = 1 AND
		  [CL].[IsActive] = 1;
END