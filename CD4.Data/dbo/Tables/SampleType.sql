CREATE TABLE [dbo].[SampleType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Colour] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_SampleType_Description] UNIQUE ([Description])
)
