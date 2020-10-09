CREATE TABLE [dbo].[CommentList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] varchar(1000) not null,
	[IsActive] bit not null,
	[UpdatedDate] DATETIMEOFFSET NOT NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL,
)
