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

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Sites' )
DELETE FROM [dbo].[Sites];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Country' )
DELETE FROM [dbo].[Country];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Gender' )
DELETE FROM [dbo].[Gender];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Atoll' )
DELETE FROM [dbo].[Atoll];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ClinicalDetail' )
DELETE FROM [dbo].[ClinicalDetail];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Profile_Tests' )
DELETE FROM [dbo].[Profile_Tests];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Profiles' )
DELETE FROM [dbo].[Profiles];
GO
IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Test' )
DELETE FROM [dbo].[Test];
GO
