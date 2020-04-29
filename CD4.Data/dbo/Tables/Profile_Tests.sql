CREATE TABLE [dbo].[Profile_Tests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProfileId] INT NOT NULL, 
    [TestId] INT NOT NULL, 
    CONSTRAINT [FK_Profile_Tests_Tests] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test]([Id]), 
    CONSTRAINT [FK_Profile_Tests_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [dbo].[Profiles]([Id])
)
