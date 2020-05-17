CREATE PROCEDURE [dbo].[usp_InsertSample]
	@Cin varchar(50),
	@AnalysisRequestId int,
	@SiteId int,
	@CollectionDate char(8),
	@ReceivedDate char(8)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[Sample]([Cin], [AnalysisRequestId], [SiteId], [CollectionDate], [ReceivedDate])
	VALUES (@Cin, @AnalysisRequestId, @SiteId, @CollectionDate, @ReceivedDate);
END
