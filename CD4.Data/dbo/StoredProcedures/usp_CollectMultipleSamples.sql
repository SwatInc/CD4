CREATE PROCEDURE [dbo].[usp_CollectMultipleSamples]
	@SampleCins  [dbo].[SampleCinsUDT] READONLY,
	@UserId int
AS
BEGIN
	DECLARE @SampleCin varchar(50);
    DECLARE @Counter int  = 0;
    DECLARE @RecordsNumber int;

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
