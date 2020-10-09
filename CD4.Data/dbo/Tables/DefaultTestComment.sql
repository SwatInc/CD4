CREATE TABLE [dbo].[DefaultTestComment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[TestId] INT NOT NULL,
	[CommentListId] INT NOT NULL, 
    CONSTRAINT [FK_DefaultTestComment_CommentList] FOREIGN KEY ([CommentListId]) REFERENCES [dbo].[CommentList]([Id]), 
    CONSTRAINT [FK_DefaultTestComment_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id])
)
