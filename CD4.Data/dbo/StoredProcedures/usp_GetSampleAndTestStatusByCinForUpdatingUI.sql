CREATE PROCEDURE [dbo].[usp_GetSampleAndTestStatusByCinForUpdatingUI]
	@Cin varchar(50)
AS
BEGIN

		 -- return data - sample status
        SELECT [SampleCin] AS [Cin],
               [StatusId]
        FROM [dbo].[SampleTracking]
        WHERE [SampleCin] = @Cin;
        -- return data - result status, result and reference code
        SELECT [RT].[ResultId],
               [R].[Sample_Cin] AS [Cin],
               [R].[Result],
               [R].[ReferenceCode],
               [RT].[StatusId]
        FROM [dbo].[ResultTracking] [RT]
            INNER JOIN [dbo].[Result] [R]
                ON [RT].[ResultId] = [R].[Id]
        WHERE [R].[Sample_Cin] = @Cin;
END