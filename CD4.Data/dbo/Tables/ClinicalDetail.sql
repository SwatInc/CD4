CREATE TABLE [dbo].[ClinicalDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Detail] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_ClinicalDetail_Detail] UNIQUE ([Detail])
)
