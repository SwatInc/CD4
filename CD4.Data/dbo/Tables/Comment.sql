-- This table is used to store actual patient, sample and test comments
CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CommentListId] int not null,
	[CommentTypeId] int not null,
	[PatientId] int,
	[Cin] varchar(50),
	[ResultId] int,
	[UserId] int not null,
	[UpdatedAt] DATETIMEOFFSET NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL, 
    CONSTRAINT [FK_Comment_CommentList] FOREIGN KEY ([CommentListId]) REFERENCES [dbo].[CommentList]([Id]), 
    CONSTRAINT [FK_Comment_CommentType] FOREIGN KEY ([CommentTypeId]) REFERENCES [dbo].[CommentType]([Id]),


)
