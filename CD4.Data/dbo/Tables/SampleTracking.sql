CREATE TABLE [dbo].[SampleTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SampleCin] VARCHAR(50) NOT NULL, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
)
