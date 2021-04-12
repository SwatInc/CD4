CREATE PROCEDURE [dbo].[usp_SearchPatientByNidPp]
	@NidPp nvarchar(50)
AS
BEGIN
SET NOCOUNT ON;
SELECT [P].[Id]
, [P].[FullName]
, [P].[NidPp]
, [P].[Birthdate]
, [G].[Gender]
, [A].[Atoll]
, [A].[Island]
, [C].[Country]
, [P].[Address]
, [P].[PhoneNumber]
, [P].[InstituteAssignedPatientId]
FROM [dbo].[Patient] [P]
INNER JOIN [dbo].[Atoll] [A] ON [P].[AtollId] = [A].[Id]
INNER JOIN [dbo].[Gender] [G] ON [P].[GenderId] = [G].[Id]
INNER JOIN [dbo].[Country] [C] ON [P].[CountryId] = [C].[Id]
WHERE [P].[NidPp] = @NidPp;
END