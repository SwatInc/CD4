CREATE PROCEDURE [dbo].[usp_CollectAllSamplesForEpisode]
	@EpisodeNumber varchar(15),
	@UserId int
AS
BEGIN
	DECLARE @SampleCin varchar(50);
    DECLARE @Counter int  = 0;
    DECLARE @RecordsNumber int;
    DECLARE @SampleCins TABLE([Cin] varchar(50));

    INSERT INTO @SampleCins([Cin])
    SELECT [s].[Cin] 
    FROM [dbo].[Sample] [s]
    INNER JOIN [dbo].[AnalysisRequest] [ar] ON [s].[AnalysisRequestId] = [ar].[Id]
    WHERE [ar].[EpisodeNumber] = @EpisodeNumber;

    SELECT @RecordsNumber = COUNT([Cin]) FROM @SampleCins;

    WHILE @Counter < @RecordsNumber 
    BEGIN
        SELECT @SampleCin = [Cin]
        FROM @SampleCins
        ORDER BY [Cin]
        OFFSET @Counter ROWS FETCH NEXT 1 ROWS ONLY;
    
        EXECUTE [dbo].[usp_DecideToAndExecuteMarkSampleCollected] 
        @Cin = @SampleCin,
        @UserId = @UserId;

        SET @Counter = @Counter + 1;
    END;
END
