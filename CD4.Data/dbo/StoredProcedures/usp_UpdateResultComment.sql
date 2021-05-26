-- Do not call this procedure directly. Use the usp_DecideUpsertResultComment instead
CREATE PROCEDURE [dbo].[usp_UpdateResultComment]
	@CommentId int,
	@CommentListId int,
	@UserId int
AS
BEGIN

	--update the comment
	UPDATE [dbo].[Comment]
	SET	
		[CommentListId] = @CommentListId,
		[UpdatedAt] = GETDATE()
	WHERE [Id] = @CommentId;

	--insert audit trail
	--todo

END
