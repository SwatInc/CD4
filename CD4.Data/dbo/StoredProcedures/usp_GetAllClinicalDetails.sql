CREATE PROCEDURE [dbo].[usp_GetAllClinicalDetails]
AS
BEGIN
SET NOCOUNT ON;
SELECT [c].[Id], [c].[Detail] AS [ClinicalDetail] FROM [dbo].[ClinicalDetail][c];
END

