﻿CREATE PROCEDURE [dbo].[usp_InsertResultReferenceRange]
	@ResultId int
AS
BEGIN
    -- declare variables
    DECLARE @PatientAndTestData TABLE([AgeInDays] INT,[GenderId] INT, TestId INT);
    DECLARE @AgeInDays INT;
    DECLARE @GenderId INT;
    DECLARE @TestId INT;

    DECLARE @NormalId INT;
    DECLARE @AttentionId INT;
    DECLARE @PathologyId INT;
    DECLARE @PanicId INT;
    DECLARE @NotAcceptableId INT;

    DECLARE @NormalHighLimit DECIMAL(10, 3); 
    DECLARE @NormalLowLimit DECIMAL(10, 3);
    DECLARE @AttentionHighLimit DECIMAL(10, 3); 
    DECLARE @AttentionLowLimit DECIMAL(10, 3);
    DECLARE @PathologyHighLimit DECIMAL(10, 3); 
    DECLARE @PathologyLowLimit DECIMAL(10, 3);
    DECLARE @HighPathologyHighLimit DECIMAL(10, 3); 
    DECLARE @HighPathologyLowLimit DECIMAL(10, 3);
    DECLARE @AbsoluteDeltaLowLimit DECIMAL(10, 3);
    DECLARE @AbsoluteDeltaHighLimit DECIMAL(10, 3);
    DECLARE @RelativeDeltaLowLimit DECIMAL(10, 3);
    DECLARE @RelativeDeltaHighLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityAbsoluteLow_DeltaLowLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityAbsoluteLow_DeltaHighLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityAbsoluteHigh_DeltaLowLimt DECIMAL(10, 3);
    DECLARE @OutOfNormalityAbsoluteHigh_DeltaHighLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityRelativeLow_DeltaLowLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityRelativeLow_DeltaHighLimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityRelativeHigh_DeltaLowlimit DECIMAL(10, 3);
    DECLARE @OutOfNormalityRelativeHigh_DeltaHighLimit DECIMAL(10, 3); 
    DECLARE @DisplayNormalRange VARCHAR(100);

    --get patient specific data
    INSERT INTO @PatientAndTestData ([AgeInDays],[GenderId],[TestId])
    SELECT DATEDIFF(d,[P].[Birthdate],GETDATE()) AS [AgeInDays], [P].[GenderId],[R].[TestId]
    FROM [dbo].[Patient] [P]
    INNER JOIN [dbo].[AnalysisRequest] [AR] ON [AR].[PatientId] = [P].[Id]
    INNER JOIN [dbo].[Sample] [S] ON [S].[AnalysisRequestId]  = [AR].[Id]
    INNER JOIN [dbo].[Result] [R] ON [R].[Sample_Cin] = [S].[Cin]
    WHERE [R].[Id] = @ResultId;
    --get them out to variables
    SELECT @AgeInDays = [AgeInDays] FROM @PatientAndTestData;
    SELECT @GenderId = [GenderId] FROM @PatientAndTestData;
    SELECT @TestId = [TestId] FROM @PatientAndTestData;
    
    -- get the reference type Ids
    SELECT @NormalId = [Id] FROM [dbo].[ReferenceType] WHERE [Description] = 'Normal';
    SELECT @AttentionId = [Id] FROM [dbo].[ReferenceType] WHERE [Description] = 'Attention';
    SELECT @PathologyId = [Id] FROM [dbo].[ReferenceType] WHERE [Description] = 'Pathology';
    SELECT @PanicId = [Id] FROM [dbo].[ReferenceType] WHERE [Description] = 'Panic / High Pathology';
    SELECT @NotAcceptableId = [Id] FROM [dbo].[ReferenceType] WHERE [Description] = 'Not Acceptable';

    --get the fields for insert

    --normal high limit
    EXEC [dbo].[usp_GetSpecifiedHighReferenceLimitValue] @NormalHighLimit OUTPUT, @TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @NormalId;
    --normal low limit
    EXEC [dbo].[usp_GetSpecifiedLowReferenceLimitValue] @NormalLowLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @NormalId;
    --attention high limit
    EXEC [dbo].[usp_GetSpecifiedHighReferenceLimitValue] @AttentionHighLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @AttentionId;
    --attention low limit
    EXEC [dbo].[usp_GetSpecifiedLowReferenceLimitValue] @AttentionLowLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @AttentionId;
    --pathology high limit
    EXEC [dbo].[usp_GetSpecifiedHighReferenceLimitValue] @PathologyHighLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @PathologyId;
    --pathology low limit
    EXEC [dbo].[usp_GetSpecifiedLowReferenceLimitValue] @PathologyLowLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @PathologyId;
    --high pathology high limit
    EXEC [dbo].[usp_GetSpecifiedHighReferenceLimitValue] @HighPathologyHighLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @PanicId;
    --high pathology low limit
    EXEC [dbo].[usp_GetSpecifiedLowReferenceLimitValue] @HighPathologyLowLimit OUTPUT,@TestId = @TestId, @GenderId  = @GenderId, @AgeInDays = @AgeInDays, @ReferenceTypeId = @PanicId;
    -- select display reference range
    SELECT @DisplayNormalRange = [DisplayNormalRange]
    FROM [dbo].[ReferenceRange]
    WHERE [TestId] = @TestId AND 
          [GenderId] = @GenderId AND
          (@AgeInDays >= [FromAgeDays] AND [ToAgeDays] >= @AgeInDays);

    INSERT INTO [dbo].[ResultReferenceRanges]
               ([ResultId]
               ,[NormalHighLimit]
               ,[NormalLowLimit]
               ,[AttentionHighLimit]
               ,[AttentionLowLimit]
               ,[PathologyHighLimit]
               ,[PathologyLowLimit]
               ,[HighPathologyHighLimit]
               ,[HighPathologyLowLimit]
               ,[DisplayNormalRange])
         VALUES
               (@ResultId
               ,COALESCE(@NormalHighLimit,-1)
               ,COALESCE(@NormalLowLimit,-1)
               ,COALESCE(@AttentionHighLimit,-1)
               ,COALESCE(@AttentionLowLimit,-1)
               ,COALESCE(@PathologyHighLimit,-1)
               ,COALESCE(@PathologyLowLimit,-1)
               ,COALESCE(@HighPathologyHighLimit,-1)
               ,COALESCE(@HighPathologyLowLimit,-1)
               ,@DisplayNormalRange);
END