CREATE PROCEDURE [dbo].[usp_LoadStaticDataForBulkImport]
AS
BEGIN
	-- load genders list
    SELECT [Id],[Gender] FROM [dbo].[Gender];
	-- load atoll island data
    SELECT [Id],[Atoll],[Island] FROM [dbo].[Atoll];
	-- load Sites data
    SELECT [Id],[Name] FROM [dbo].[Sites];
	-- load all nationalities
    SELECT [Id],[Country] FROM [dbo].[Country];
	-- load all clinical details data
    SELECT [Id],[Detail] FROM [dbo].[ClinicalDetail];
	-- load all tests data
    SELECT [Id],[Description] FROM [dbo].[Test];
END
