﻿CREATE TABLE [dbo].[PersistedGrants](
	[Key] [NVARCHAR](200) NOT NULL,
	[Type] [NVARCHAR](50) NOT NULL,
	[SubjectId] [NVARCHAR](200) NULL,
	[ClientId] [NVARCHAR](200) NOT NULL,
	[CreationTime] [DATETIME2](7) NOT NULL,
	[Expiration] [DATETIME2](7) NULL,
	[Data] [NVARCHAR](MAX) NOT NULL,
 CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO