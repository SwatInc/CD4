﻿CREATE PROCEDURE [dbo].[usp_InsertTest]
	@DisciplineId int,
	@Description nvarchar(100),
	@SampleTypeId int,
	@ResultDataTypeId int,
	@Mask varchar(50),
	@UnitId int,
	@Reportable bit,
	@Code varchar(3),
	@DefaultCommented bit,
	@SortOrder int,
	@PrimaryHeader varchar(200) = '',
	@SecondaryHeader varchar(200) = ''
AS
BEGIN

DECLARE @InsertedTestId int;

	INSERT INTO [dbo].[Test]
		([DisciplineId]
		,[Description]
		,[SampleTypeId]
		,[ResultDataTypeId]
		,[Mask],[UnitId]
		,[Reportable]
		,[Code]
		,[DefaultCommented]
		,[SortOrder]
		,[PrimaryHeader]
		,[SecondaryHeader]) 
	VALUES
		(@DisciplineId
		,@Description
		,@SampleTypeId
		,@ResultDataTypeId
		,@Mask
		,@UnitId
		,@Reportable
		,@Code
		,@DefaultCommented
		,@SortOrder
		,@PrimaryHeader
		,@SecondaryHeader);

	SET @InsertedTestId = SCOPE_IDENTITY();

	SELECT 
		[t].[Id]
	  , [d].[Description] AS [Discipline]
	  , [t].[Description]
	  , [st].[Description] AS [SampleType]
	  , [r].[Name] AS [ResultDataType]
	  , [t].[Mask]
	  , [u].[Unit]
	  , [t].[Code]
	  , [t].[Reportable] AS [IsReportable]
	  , [t].[DefaultCommented]
	  , [t].[PrimaryHeader]
	  , [t].[SecondaryHeader]
	FROM [dbo].[Test] [t]
	INNER JOIN [dbo].[ResultDataType][r]  ON [t].[ResultDataTypeId] = [r].[Id]
	INNER JOIN [dbo].[Discipline] [d] ON [t].[DisciplineId] = [d].[Id]
	INNER JOIN [dbo].[SampleType] [st] ON [t].[SampleTypeId] = [st].[Id]
	INNER JOIN [dbo].[Unit] [u] ON [t].[UnitId] = [u].[Id]
	WHERE [t].[Id] = @InsertedTestId;

END
