CREATE PROCEDURE [dbo].[usp_GetSpecifiedLowReferenceLimitValue]
	@LowLimitValue DECIMAL(10,8) output,
	@TestId int,
	@GenderId int,
    @AgeInDays int,
    @ReferenceTypeId int
AS
BEGIN
    SELECT @LowLimitValue = [LowLimitValue] 
    FROM [dbo].[ReferenceData] [RD]
    INNER JOIN [dbo].[ReferenceRange] [RR] ON [RR].[Id] = [RD].[ReferenceRangeId]
    WHERE [RR].[TestId] = @TestId AND 
          [RR].[GenderId] = @GenderId AND
          [RR].[FromAgeDays] < @AgeInDays AND
          [RR].[ToAgeDays] > @AgeInDays AND
          [RD].[ReferenceTypeId] = @ReferenceTypeId;
END
