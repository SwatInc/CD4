CREATE TABLE [dbo].[CommentList]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] varchar(1000) not null,
	[IsAvailableAsPatientComment] bit not null,
	[IsAvailableAsRequestComment] bit not null,
	[IsAvailableAsSampleComment] bit not null,
	[IsActive] bit not null,
	[UpdatedDate] DATETIMEOFFSET NOT NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL,
)
