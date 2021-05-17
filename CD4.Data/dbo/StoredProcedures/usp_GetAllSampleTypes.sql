CREATE PROCEDURE [dbo].[usp_GetAllSampleTypes]

AS
BEGIN
	SELECT [Id],[Description],[Colour],[Code]
	FROM [dbo].[SampleType];
END
