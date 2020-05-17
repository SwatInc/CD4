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

--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Sites' )
--DELETE FROM [dbo].[Sites];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Country' )
--DELETE FROM [dbo].[Country];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Gender' )
--DELETE FROM [dbo].[Gender];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Atoll' )
--DELETE FROM [dbo].[Atoll];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ClinicalDetail' )
--DELETE FROM [dbo].[ClinicalDetail];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Profile_Tests' )
--DELETE FROM [dbo].[Profile_Tests];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Profiles' )
--DELETE FROM [dbo].[Profiles];
--GO
--IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'Test' )
--DELETE FROM [dbo].[Test];
--GO


--EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CD4Data'
--GO
--use [CD4Data];
--GO
--use [master];
--GO
--USE [master]
--GO
--ALTER DATABASE [CD4Data] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
--GO
--USE [master]
--GO

--DROP DATABASE [CD4Data]
--GO

--DECLARE @DoesDatabaseExist int;

--SET @DoesDatabaseExist = (SELECT COUNT(*) FROM [dbo].[sysdatabases] [d] WHERE [d].[name] = N'CD4Data');

--IF (@DoesDatabaseExist > 0)
--BEGIN

--EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'CD4Data';
--USE [master];
--DROP DATABASE [CD4Data];

--END
