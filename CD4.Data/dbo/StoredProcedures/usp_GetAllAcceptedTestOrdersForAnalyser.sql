CREATE PROCEDURE [dbo].[usp_GetAllAcceptedTestOrdersForAnalyser]
	@AnalyserName varchar(50),
	@UsersId int
AS
BEGIN

DECLARE @AnalyserId int  = 0;
DECLARE @ReceivedStatusId int = 3;
DECLARE @ProcessingStatusId int = 6;
DECLARE @TestTrackingId int  = 3;
DECLARE @Username varchar(50);

DECLARE @SamplesWithStatusChange TABLE([Cin] varchar(50)) -- to enable the recording sample tracking history
DECLARE @Orders TABLE 
(
	[Download] varchar(50),
	[Sid] varchar(50),
	[SamplePriority] bit,
	[TestPriority] bit,
	[ResultId] int,
	[EpisodeNumber] varchar(15),
	[Age] varchar(20),
	[FullName] varchar(100),
	[NidPp] varchar(50),
	[Birthdate] Date,
	[Address] varchar(100)
);

SELECT @AnalyserId = [Id] FROM [dbo].[Analyser] WHERE [Description] = @AnalyserName;
SELECT @Username = [UserName] FROM [dbo].[Users] WHERE [Id] = @UsersId;

INSERT INTO @Orders
SELECT
	[cm].[Download],
	[r].[Sample_Cin] AS [Sid],
	[s].[IsStat] AS [SamplePriority],
	[r].[IsStat] AS [TestPriority],
	[r].[Id] as [ResultId],
	[ar].[EpisodeNumber],
	[ar].[Age],
	[p].[FullName],
	[p].[NidPp],
	[p].[Birthdate],
	[p].[Address]
FROM [dbo].[ChannelMap] [cm]
INNER JOIN [dbo].[Result] [r] ON [cm].[TestId] = [r].[TestId]
INNER JOIN [dbo].[Sample] [s] ON [s].[Cin]  = [r].[Sample_Cin]
INNER JOIN [dbo].[AnalysisRequest] [ar] ON [ar].[Id] = [s].[AnalysisRequestId]
INNER JOIN [dbo].[Patient] [p] ON [p].[Id] = [ar].[PatientId]
INNER JOIN [dbo].[ResultTracking] [rt] ON [r].[Id] = [rt].[ResultId]
WHERE [rt].[StatusId] = @ReceivedStatusId
  AND [cm].[AnalyserId] = @AnalyserId
  AND [cm].[Enabled] = 1;
  
  -- Sample and result status management
  --========================================
  --update sample to processing
UPDATE [dbo].[SampleTracking]
SET StatusId = @ProcessingStatusId,
	UsersId = @UsersId
OUTPUT INSERTED.[SampleCin] INTO @SamplesWithStatusChange
WHERE
	[StatusId] = @ReceivedStatusId AND 
	SampleCin IN 
			(SELECT DISTINCT([Sid]) AS [SampleCin] FROM @Orders);

  --update result status
UPDATE [dbo].[ResultTracking]
SET StatusId = @ProcessingStatusId,
	UsersId = @UsersId
WHERE ResultId IN 
(
	SELECT [ResultId] FROM @Orders
);
 	
	-- Tracking history - test
INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[ResultId],[StatusId],[UsersId])
SELECT @TestTrackingId,[ResultId],@ReceivedStatusId,@UsersId
FROM @Orders;
	-- Tracking history - test
INSERT INTO [dbo].[TrackingHistory] ([TrackingType],[SampleCin],[StatusId],[UsersId])
SELECT @TestTrackingId,[Cin],@ReceivedStatusId,@UsersId
FROM @SamplesWithStatusChange;

  --Audit trail
  --====================

INSERT INTO [dbo].[AuditTrail]([Cin],[AuditTypeId],[StatusId],[Details])
SELECT DISTINCT([Sid]), 
	   @TestTrackingId
	  ,@ReceivedStatusId
	  ,CONCAT('Orders: ',STRING_AGG([Download],'|'),' downloaded to analyser interface: ', @AnalyserName, ' by ',@Username)
FROM @Orders
GROUP BY [Sid];

  --return orders
  --====================
  SELECT 
	 STRING_AGG([Download],'|') AS [Download]
	,[Sid]
	,[SamplePriority]
	,[TestPriority]
	,[EpisodeNumber]
	,[Age]
	,[FullName]
	,[NidPp]
	,[Birthdate]
	,[Address]
 FROM @Orders
 GROUP BY
	 [Sid]
	,[SamplePriority]
	,[TestPriority]
	,[EpisodeNumber]
	,[Age]
	,[FullName]
	,[NidPp]
	,[Birthdate]
	,[Address]
END
