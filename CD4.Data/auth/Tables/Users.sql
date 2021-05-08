CREATE TABLE [dbo].[Users](
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[UserName] [nvarchar](256) NULL,
	[Fullname] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[FullNameLocal] nvarchar(256) NULL, -- localization
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL, 
    CONSTRAINT [AK_Users_Username] UNIQUE ([UserName])
);


