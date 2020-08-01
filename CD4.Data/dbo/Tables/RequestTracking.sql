CREATE TABLE [dbo].[RequestTracking]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AnalysisRequestId] INT NOT NULL, 
    [StatusId] INT NOT NULL, 
    [UsersId] INT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
)
