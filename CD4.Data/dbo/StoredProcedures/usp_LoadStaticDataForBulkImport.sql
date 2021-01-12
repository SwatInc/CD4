CREATE PROCEDURE [dbo].[usp_LoadStaticDataForBulkImport]
AS
BEGIN
SET NOCOUNT ON;
	-- load genders list
    EXEC [dbo].[usp_GetAllGenders];
	-- load atoll island data
    EXEC [dbo].[usp_GetAllAtollAndIslands];
	-- load Sites data
    EXEC [dbo].[usp_GetAllSites];
	-- load all nationalities
    EXEC [dbo].[usp_GetAllNationalities];
	-- load all clinical details data
    EXEC [dbo].[usp_GetAllClinicalDetails];
	-- load all tests data
    EXEC [dbo].[usp_GetAllTests];
END
