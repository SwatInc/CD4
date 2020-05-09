/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Sites] ([Name]) VALUES 
('FARUKOLHU'),
('ANANTARA'),
('KUREIDHOO'),
('IGMH'),
('ISLAND SAFARI'),
('FIF'),
('VELIDHOO'),
('VELIDHOO ISOLATION FACILITY'),
('VILIVARU'),
('HOLIDAY ISLAND RESORT'),
('ROYAL ISLAND'),
('HPA'),
('VEL-IF'),
('ERI-QF'),
('FLU CLINIC-IGMH'),
('RRT-MALE'),
('RRT MALE'),
('HIH-IF'),
('SENAHIYA'),
('RRT-MALE'''),
('FLU CLINIC'),
('HA.ULIGAM HEALTH CENTRE'),
('IGMH FLU CLINIC'),
('HIH'),
('IGMH ER'),
('FLU CINIC'),
('RRT HMH');

INSERT INTO [dbo].[Country] ([Country]) VALUES 
('MALDIVIAN'),
('BANGLADESHI'),
('INDIAN');