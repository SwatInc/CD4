-- this table sets up comment types assigned for the comments in comments list and sets whether the comment is active/is-use
CREATE TABLE [dbo].[CommentList_CommentType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CommentListId] int not null,
	[CommentTypeId] int not null,
	[IsActive] bit not null, 
    CONSTRAINT [FK_CommentList_CommentType_CommentList] FOREIGN KEY ([CommentListId]) REFERENCES [dbo].[CommentList]([Id]), 
    CONSTRAINT [FK_CommentCommentType_CommentType] FOREIGN KEY ([CommentTypeId]) REFERENCES [dbo].[CommentType]([Id]),
)
