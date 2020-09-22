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


)
