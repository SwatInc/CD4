CREATE TABLE [dbo].[Profiles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_Profiles_ProfileDescription] UNIQUE ([Description])
)
