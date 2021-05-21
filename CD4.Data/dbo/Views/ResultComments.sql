CREATE VIEW [dbo].[ResultComments]
WITH SCHEMABINDING
	AS 
	SELECT
	[C].[Identifier] AS [ResultId],
	[CL].[Description] AS [Comment]
FROM [dbo].[Comment] [C]
INNER JOIN [dbo].[CommentList] [CL] ON [C].[CommentListId] = [CL].[Id]
INNER JOIN [dbo].[CommentType] [CT] ON [C].[CommentTypeId] = [CT].Id
WHERE [CL].[IsActive] = 1 AND [CT].[Description] = 'Result';
GO

CREATE UNIQUE CLUSTERED INDEX 
    [ucidx_RESULT_ID]
ON [dbo].[ResultComments]([ResultId]);
GO