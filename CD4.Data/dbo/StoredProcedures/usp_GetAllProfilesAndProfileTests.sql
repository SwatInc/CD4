CREATE PROCEDURE [dbo].[usp_GetAllProfilesAndProfileTests]
AS
BEGIN
SET NOCOUNT ON;

DECLARE @IsProfile bit;
SELECT @IsProfile = 1;

SELECT [P].[Id],[P].[Description], @IsProfile AS [IsProfile]
FROM [dbo].[Profiles] [P];

SELECT [PT].[ProfileId]
, [T].[Id] AS [TestId] 
, [T].[Description] AS [Test]
, [T].[Mask]
, [T].[Reportable] AS [IsReportable]
, [RD].[Name] AS [ResultDataType]
FROM [dbo].[Profile_Tests] [PT] 
INNER JOIN [dbo].[Test] [T] ON [PT].[TestId] = [T].[Id]
INNER JOIN [dbo].[ResultDataType] [RD] ON [T].[ResultDataTypeId] = [RD].[Id];

END
