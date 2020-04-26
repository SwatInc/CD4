CREATE TABLE [dbo].[Patient]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FullName] VARCHAR(200) NULL, 
    [NidPp] VARCHAR(50) NULL,
    [Age] INT NULL, 
    [Birthdate] DATE NULL,  
    [GenderId] INT NOT NULL, --MALE, FEMALE, UNKNOWN
    [AtollId] INT NOT NULL DEFAULT 0,  -- 0 will be as UNKNOWN Atoll table
    [Address] VARCHAR(100) NULL, 
    [PhoneNumber] VARCHAR(20) NULL, 
    CONSTRAINT [FK_Patient_Gender] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Gender]([Id]), 
    CONSTRAINT [AK_Patient_NidPp] UNIQUE ([NidPp]), 
    CONSTRAINT [FK_Patient_Atoll] FOREIGN KEY ([AtollId]) REFERENCES [dbo].[Atoll]([Id]))
