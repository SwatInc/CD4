CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Fullname] varchar(100) NOT NULL,
	[Designation] varchar(100) NOT NULL,
	[Address] varchar(100) NOT NULL,
	[Notes] varchar(200) NOT NULL,
	[IsPrimary] bit NOT NULL
)