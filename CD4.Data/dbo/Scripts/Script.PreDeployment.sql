/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--DELETE FROM [dbo].[Sites];
--DELETE FROM [dbo].[Country];
--DELETE FROM [dbo].[Gender];
--DELETE FROM [dbo].[Atoll];
--DELETE FROM [dbo].[ClinicalDetail];
--DELETE FROM [dbo].[Profile_Tests];
--DELETE FROM [dbo].[Profiles];
--DELETE FROM [dbo].[Test];
