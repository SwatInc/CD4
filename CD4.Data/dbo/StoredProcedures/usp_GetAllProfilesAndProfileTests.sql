CREATE PROCEDURE [dbo].[usp_GetAllProfilesAndProfileTests]
AS
BEGIN
SET NOCOUNT ON;
SELECT [p].[Id] AS [ProfileId]
, [p].[Description] AS [Profile]
, [t].[Id] AS [TestId]
, [t].[Description] AS [Test]
, [t].[Mask]
, [t].[ResultDataTypeId]
, [r].[Id] AS [ResultDataTypeId]
, [r].[Name] AS [ResultDataType]
FROM [dbo].[Profiles] [p]
INNER JOIN [dbo].[Profile_Tests][pt] ON [p].[Id] = [pt].[ProfileId]
INNER JOIN [dbo].[Test] [t] ON [pt].[TestId] = [t].[Id]
INNER JOIN [dbo].[ResultDataType] [r] ON [t].[ResultDataTypeId] = [r].[Id];
END
