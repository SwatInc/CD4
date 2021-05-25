CREATE PROCEDURE [dbo].[usp_InsertResultComment]
	@CommentListId int,
	@ResultId  int,
	@UserId int
AS
BEGIN
	--insert the comment
	DECLARE @ResultCommentTypeId int = 3; -- RESULT COMMENT
	INSERT INTO [dbo].[Comment]([CommentListId],[CommentTypeId],[Identifier],[UserId],[CreatedAt],[UpdatedAt])
	VALUES (@CommentListId, @ResultCommentTypeId, @ResultId,@UserId,GETDATE(), GETDATE());
	
	-- insert audit trail

END
