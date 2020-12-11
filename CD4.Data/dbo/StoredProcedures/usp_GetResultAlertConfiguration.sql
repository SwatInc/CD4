CREATE PROCEDURE [dbo].[usp_GetResultAlertConfiguration]
AS
BEGIN
	SELECT
		 [t].[Description] AS [TestName]
		,[rac].[Result]
		,[rdt].[Name] AS [ResultType]
		,[rac].[AlertMessage]
		,[rac].[Operator]
	FROM [dbo].[ResultAlertConfiguration] [rac]
	INNER JOIN [dbo].[Test] [t] ON [rac].[TestId] = [t].[Id]
	INNER JOIN [dbo].[ResultDataType] [rdt] ON [t].[ResultDataTypeId] = [rdt].[Id]
END
