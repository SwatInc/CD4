CREATE TABLE [dbo].[SampleType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Colour] VARCHAR(50) NOT NULL, 
    [Code] VARCHAR(3) NOT NULL DEFAULT 'U', -- to be used on barcode, U for Unspecified
    CONSTRAINT [AK_SampleType_Description] UNIQUE ([Description])
)
