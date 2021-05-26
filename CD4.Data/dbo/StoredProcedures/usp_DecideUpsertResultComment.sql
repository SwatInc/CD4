CREATE PROCEDURE [dbo].[usp_DecideUpsertResultComment]
	@CommentListId int,
	@ResultId int, -- Identifier
	@UserId int 
AS
BEGIN

	DECLARE @CommentId int; -- The Id from dbo.Comment
	DECLARE @ResultCommentTypeId int = 3;

	--get the test comment if a comment exists for the test, otherwise 0
	SELECT @CommentId  = ISNULL([Id], 0) 
	FROM [dbo].[Comment] 
	WHERE 
		[Identifier] = @ResultId AND
		[CommentTypeId] = @ResultCommentTypeId;


	IF @CommentId > 0   
		BEGIN
			EXEC [dbo].[usp_UpdateResultComment]
				@CommentId = @CommentId,
				@CommentListId = @CommentListId,
				@UserId = @UserId;
		END;
	ELSE
		BEGIN
			EXEC [dbo].[usp_InsertResultComment]
				@CommentListId = @CommentListId,
				@ResultId  = @ResultId,
				@UserId = @UserId;				
		END;
END