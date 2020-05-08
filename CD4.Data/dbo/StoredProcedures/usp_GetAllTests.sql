CREATE PROCEDURE [dbo].[usp_GetAllTests]
AS
BEGIN
SET NOCOUNT ON;
SELECT [t].[Id], [t].[Description], [t].[ResultDataTypeId], [r].[Name] AS [ResultDataType], [t].[Mask], [t].[Reportable] 
FROM [dbo].[Test] [t]
INNER JOIN [dbo].[ResultDataType][r] ON [t].[ResultDataTypeId] = [r].[Id];
END
