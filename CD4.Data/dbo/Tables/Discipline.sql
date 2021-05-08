CREATE TABLE [dbo].[Discipline]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(100) NOT NULL, 
    [Code] VARCHAR(3) NULL DEFAULT 'U' -- code to be used on barcode to indicate discipline
)
