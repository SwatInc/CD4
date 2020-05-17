CREATE TABLE [dbo].[Result]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Sample_Cin] VARCHAR(50) NOT NULL,
    [TestId] INT NOT NULL, 
    [Result] VARCHAR(50) NULL, 
    [ResultDate] DATE NULL, --if result not null, get system date GETDATE()   
    CONSTRAINT [FK_Result_Test] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_Result_Sample] FOREIGN KEY ([Sample_Cin]) REFERENCES [dbo].[Sample]([Cin]))