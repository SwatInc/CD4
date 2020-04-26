CREATE TABLE [dbo].[Sample]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cin] VARCHAR(50) NOT NULL, 
    [Site] INT NOT NULL DEFAULT 0, -- 0 is UNKNOWN on SITES TABLE
    [CollectionDate] DATE NULL , 
    [ReceivedDate] DATE NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [AK_Sample_Cin] UNIQUE ([Cin]) 
)
