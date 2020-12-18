CREATE PROCEDURE [dbo].[usp_GetSampleStatus]
	@Cin varchar(50)
AS
BEGIN
	SELECT [StatusId]
	FROM [dbo].[SampleTracking] [st]
	WHERE [st].[SampleCin] = @Cin;
END