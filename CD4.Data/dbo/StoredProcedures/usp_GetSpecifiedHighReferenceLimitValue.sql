CREATE PROCEDURE [dbo].[usp_GetSpecifiedHighReferenceLimitValue]
	@HighLimitValue DECIMAL(10,3) output,
	@TestId int,
	@GenderId int,
    @AgeInDays int,
    @ReferenceTypeId int
AS
BEGIN
    SELECT @HighLimitValue =  [HighLimitValue] 
    FROM [dbo].[ReferenceData] [RD]
    INNER JOIN [dbo].[ReferenceRange] [RR] ON [RR].[Id] = [RD].[ReferenceRangeId]
    WHERE [RR].[TestId] = @TestId AND 
          [RR].[GenderId] = @GenderId AND
          [RR].[FromAgeDays] < @AgeInDays AND
          [RR].[ToAgeDays] > @AgeInDays AND
          [RD].[ReferenceTypeId] = @ReferenceTypeId;
END