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

INSERT INTO [dbo].[Gender] ([Gender]) VALUES 
('MALE'),
('FEMALE'),
('UNKNOWN'),
('NOT AVAILABLE')

INSERT INTO [dbo].[Atoll]([Atoll],[Island]) VALUES
('AA','BODUFOLHUDHOO')
, ('AA','FERIDHOO')
, ('AA','HIMANDHOO')
, ('AA','MAALHOS')
, ('AA','MATHIVERI')
, ('AA','RASDHOO')
, ('AA','THODDOO')
, ('AA','UKULHAS')
, ('AA','FESDHOO')
, ('ADH','DHANGETHI')
, ('ADH','DHIDDHOO')
, ('ADH','DHIGURAH')
, ('ADH','FENFUSHI')
, ('ADH','HAGGNAAMEEDHOO')
, ('ADH','KUNBURUDHOO')
, ('ADH','MAAMIGILI')
, ('ADH','MAHIBADHOO')
, ('ADH','MANDHOO')
, ('ADH','OMADHOO')
, ('B','DHARAVANDHOO')
, ('B','DHONFANU')
, ('B','EYDHAFUSHI')
, ('B','FEHENDHOO')
, ('B','FULHADHOO')
, ('B','GOIDHOO')
, ('B','HITHAADHOO')
, ('B','KIHAADHOO')
, ('B','KAMADHOO')
, ('B','KENDHOO')
, ('B','KIHAADHOO')
, ('B','KUDARIKILU')
, ('B','MAALHOS')
, ('B','THULHAADHOO')
, ('DH','BANDIDHOO')
, ('DH','GEMENDHOO')
, ('DH','HULHUDHELI')
, ('DH','KUDAHUVADHOO')
, ('DH','MAAENBOODHOO')
, ('DH','MEEDHOO')
, ('DH','RINBUDHOO')
, ('DH','VAANEE')
, ('F','BILEDDHOO')
, ('F','DHARANBOODHOO')
, ('F','FEEALI')
, ('F','FILITHEYO')
, ('F','MAGOODHOO')
, ('F','NILANDHOO')
, ('GA','DHAANDHOO')
, ('GA','DHEWADHOO')
, ('GA','DHIYADHOO')
, ('GA','GEMANAFUSHI')
, ('GA','KANDUHULHUDHOOO')
, ('GA','KOLAMAAFUSHI')
, ('GA','KONDEY')
, ('GA','MAAMENDHOO')
, ('GA','NILANDHOO')
, ('GA','VILINGILI')
, ('GDH','FARES MAATHODAA')
, ('GDH','FIYOAREE')
, ('GDH','GADDHOO')
, ('GDH','HOANDEDDHOO')
, ('GDH','MAATHODAA')
, ('GDH','MADAVELI')
, ('GDH','NADELLA')
, ('GDH','RATHAFANDHOO')
, ('GDH','THINADHOO')
, ('GDH','VAADHOO')
, ('GN','FUVAHMULAH')
, ('HA','BAARAH')
, ('HA','BERINMADHOO')
, ('HA','DHIDDHOO')
, ('HA','FILLADHOO')
, ('HA','HATHIFUSHI')
, ('HA','HOARAFUSHI')
, ('HA','IHAVANDHOO')
, ('HA','KELAA')
, ('HA','MAARANDHOO')
, ('HA','MULHADHOO')
, ('HA','MURAIDHOO')
, ('HA','THAKANDHOO')
, ('HA','THURAAKUNU')
, ('HA','ULIGAMU')
, ('HA','UTHEEMU')
, ('HA','VASHAFARU')
, ('HDH','FARIDHOO')
, ('HDH','FINEY')
, ('HDH','HANIMAADHOO')
, ('HDH','HIRIMARADHOO')
, ('HDH','KULHUDHUFFUSHI')
, ('HDH','KUMUNDHOO')
, ('HDH','KUNBURUDHOO')
, ('HDH','KUNBURUDHOO')
, ('HDH','MAAVAIDHOO')
, ('HDH','MAKUNUDHOO')
, ('HDH','NAIVAADHOO')
, ('HDH','NELLAIDHOO')
, ('HDH','NEYKURENDHOO')
, ('HDH','NOLHIVARAM')
, ('HDH','NOLHIVARANFARU')
, ('HDH','VAIKARADHOO')
, ('HDH','KURINBI')
, ('K','DHIFFUSHI')
, ('K','GAAFARU')
, ('K','GULHI')
, ('K','GURAIDHOO')
, ('K','HULHUMALÉ')
, ('K','HIMMAFUSHI')
, ('K','HURAA')
, ('K','KAASHIDHOO')
, ('K','MALE')
, ('K','MAAFUSHI')
, ('K','THULUSDHOO')
, ('K','VILLIGINLI')
, ('L','DHANBIDHOO')
, ('L','FONADHOO')
, ('L','GAADHOO')
, ('L','GAN')
, ('L','HITHADHOO')
, ('L','ISDHOO')
, ('L','KALHAIDHOO')
, ('L','KUNAHANDHOO')
, ('L','MAABAIDHOO')
, ('L','MAAMENDHOO')
, ('L','MAAVAH')
, ('L','MUNDOO')
, ('L','KALAIDHOO')
, ('LH','HINNAVARU')
, ('LH','KURENDHOO')
, ('LH','MAAFILAAFUSHI')
, ('LH','NAIFARU')
, ('LH','OLHIVELIFUSHI')
, ('M','BOLI MULAH')
, ('M','DHIGGARU')
, ('M','KOLHUFUSHI')
, ('M','MADIFUSHI')
, ('M','MADUVVARI')
, ('M','MULAH')
, ('M','NAALAAFUSHI')
, ('M','RAIMMANDHOO')
, ('M','VEYVAH')
, ('M','MULI')
, ('N','FODHDHOO')
, ('N','HENBANDHOO')
, ('N','HOLHUDHOO')
, ('N','KENDHIKOLHUDHOO')
, ('N','KUDAFAREE')
, ('N','LANDHOO')
, ('N','LHOHI')
, ('N','MAAFARU')
, ('N','MAALHENDHOO')
, ('N','MAGOODHOO')
, ('N','MANADHOO')
, ('N','MILADHOO')
, ('N','VELIDHOO')
, ('R','ALIFUSHI')
, ('R','ANGOLHITHEEMU')
, ('R','FAINU')
, ('R','HULHUDHUFFAARU')
, ('R','INGURAIDHOO')
, ('R','INNAMAADHOO')
, ('R','DHUVAAFARU')
, ('R','KINOLHAS')
, ('R','MAAKURATHU')
, ('R','MADUVVARI')
, ('R','MEEDHOO')
, ('R','RASGETHEEMU')
, ('R','RASMAADHOO')
, ('R','UNGOOFAARU')
, ('R','VAADHOO')
, ('R','KANDHOLHUDHOO')
, ('S','FEYDHOO')
, ('S','HITHADHOO')
, ('S','HULHUDHOO')
, ('S','MARADHOO')
, ('S','MEEDHOO')
, ('S','MARADHOO-FEYDHOO')
, ('SH','BILEFFAHI')
, ('SH','FEEVAH')
, ('SH','FEYDHOO')
, ('SH','FIRUNBAIDHOO')
, ('SH','FOAKAIDHOO')
, ('SH','FUNADHOO')
, ('SH','GOIDHOO')
, ('SH','KANDITHEEMU')
, ('SH','KOMANDOO')
, ('SH','LHAIMAGU')
, ('SH','MAAKANDOODHOO')
, ('SH','MAAUNGOODHOO')
, ('SH','MAROSHI')
, ('SH','MILANDHOO')
, ('SH','NARUDHOO')
, ('SH','NOOMARAA')
, ('TH','BURUNEE')
, ('TH','DHIYAMINGILI')
, ('TH','GAADHIFFUSHI')
, ('TH','GURAIDHOO')
, ('TH','HIRILANDHOO')
, ('TH','KANDOODHOO')
, ('TH','KINBIDHOO')
, ('TH','MADIFUSHI')
, ('TH','OMADHOO')
, ('TH','THIMARAFUSHI')
, ('TH','VANDHOO')
, ('TH','VEYMANDOO')
, ('TH','VILUFUSHI')
, ('V','FELIDHOO')
, ('V','FULIDHOO')
, ('V','KEYODHOO')
, ('V','RAKEEDHOO')
, ('V','THINADHOO');

INSERT INTO [dbo].[ClinicalDetail]([Detail]) VALUES
('Fever')
,('Cough')
,('Runny Nose')
,('Breathing Difficulty')
,('Travel History')

INSERT INTO [dbo].[ResultDataType]([Name]) VALUES
('NUMERIC'),
('CODIFIED'),
('TEXTUAL');

DECLARE @CodifiedId int;
DECLARE @NumericId int;
SELECT @CodifiedId =  [Id] FROM [dbo].[ResultDataType] [r] WHERE [r].[Name] = 'CODIFIED'; 
SELECT @NumericId =  [Id] FROM [dbo].[ResultDataType] [r] WHERE [r].[Name] = 'NUMERIC'; 

INSERT INTO [dbo].[Test]([Description],[Mask],[Reportable],[ResultDataTypeId]) VALUES
('E Gene','##.##',1,@NumericId),
('EAV (Internal Control)','##.##',1,@NumericId),
('RdRP Gene','##.##',1,@NumericId),
('SARS-CoV-2 Result','##.##',1,@CodifiedId);

INSERT INTO [dbo].[Profiles]([Description]) VALUES
('SARS CoV Profile');

DECLARE @CovProfileId int;
SELECT @CovProfileId =  [Id] FROM [dbo].[Profiles] [p] WHERE [p].[Description] = 'SARS CoV Profile'; 

DECLARE @egene int;
DECLARE @eav int;
DECLARE @rdrp int;
DECLARE @result int;

SELECT @egene =  [Id] FROM [dbo].[Test] [t] WHERE [t].[Description] = 'E Gene'; 
SELECT @eav =  [Id] FROM [dbo].[Test] [t] WHERE [t].[Description] = 'EAV (Internal Control)'; 
SELECT @rdrp =  [Id] FROM [dbo].[Test] [t] WHERE [t].[Description] = 'RdRP Gene'; 
SELECT @result =  [Id] FROM [dbo].[Test] [t] WHERE [t].[Description] = 'SARS-CoV-2 Result'; 

INSERT INTO [dbo].[Profile_Tests]([ProfileId],[TestId]) VALUES
(@CovProfileId,@egene),
(@CovProfileId,@eav),
(@CovProfileId,@rdrp),
(@CovProfileId,@result);

--Preparing to insert patient
DECLARE @MaleGenderId int;
DECLARE @SHithadhooId int;
DECLARE @MaldivesCountryId int;

SELECT @MaleGenderId = [Id] FROM [dbo].[Gender] WHERE [Gender] = 'MALE';
SELECT @SHithadhooId = [Id] FROM [dbo].[Atoll] WHERE [Atoll] = 'S' AND [Island] = 'Hithadhoo';
SELECT @MaldivesCountryId = [Id] FROM [dbo].[Country] WHERE [Country] = 'MALDIVIAN';

INSERT INTO [dbo].[Patient] 
([FullName],[NidPp],[Birthdate],[GenderId],[AtollId],[CountryId],[Address],[PhoneNumber]) VALUES
('Ahmed Hussain','A1234567','19910214',@MaleGenderId,@SHithadhooId,@MaldivesCountryId,'Some Address','772342300');

SELECT @MaleGenderId = [Id] FROM [dbo].[Gender] WHERE [Gender] = 'FEMALE';
SELECT @SHithadhooId = [Id] FROM [dbo].[Atoll] WHERE [Atoll] = 'K' AND [Island] = 'MALE';
SELECT @MaldivesCountryId = [Id] FROM [dbo].[Country] WHERE [Country] = 'BANGLADESHI';

INSERT INTO [dbo].[Patient] 
([FullName],[NidPp],[Birthdate],[GenderId],[AtollId],[CountryId],[Address],[PhoneNumber]) VALUES
('Aminath Hussain','A987654','19800214',@MaleGenderId,@SHithadhooId,@MaldivesCountryId,'Some Some Address','973465347');


--Get a patient Id
DECLARE @PatientId int;
DECLARE @ScientistId int;
DECLARE @InsertedRequestId int;
DECLARE @SiteId int;
DECLARE @TestId_One int;
DECLARE @TestId_Two int;
DECLARE @ClinicalDetail_One int;
DECLARE @ClinicalDetail_Two int;
DECLARE @Cin varchar(50) = 'nCoV-2346/20';


SET @PatientId = (SELECT TOP(1) [P].[Id] FROM [dbo].[Patient] [P]);

--Insert a scientist
INSERT INTO [dbo].[Scientist] ([Name]) VALUES 
('Some Scientist')
SET @ScientistId = (SELECT TOP(1)Id FROM [dbo].[Scientist] ORDER BY [Id] DESC);

--Insert the Analysis Request
INSERT INTO [dbo].[AnalysisRequest] ([PatientId], [Age], [CheckedBy], [ApprovedBy]) VALUES
(@PatientId, 23, @ScientistId,@ScientistId);

SET @InsertedRequestId = (SELECT TOP(1)Id FROM [dbo].[AnalysisRequest] ORDER BY [Id] DESC);
SET @SiteId  = (SELECT TOP(1)Id FROM [dbo].[Sites]);

--insert Clinical details
SET @ClinicalDetail_One = (SELECT TOP(1)[Id] FROM [dbo].[ClinicalDetail] ORDER BY [Id] ASC);
SET @ClinicalDetail_Two = (SELECT TOP(1)[Id] FROM [dbo].[ClinicalDetail] ORDER BY [Id] DESC);

INSERT INTO [dbo].[AnalysisRequest_ClinicalDetail]([AnalysisRequestId], [ClinicalDetailsId]) VALUES
(@InsertedRequestId, @ClinicalDetail_One),
(@InsertedRequestId, @ClinicalDetail_Two);

--Insert Sample
INSERT INTO [dbo].[Sample] ([Cin], [AnalysisRequestId], [SiteId], [CollectionDate],[ReceivedDate])
VALUES
(@Cin, @InsertedRequestId, @SiteId, GETDATE(), GETDATE());

--Get Some Test Ids
SET @TestId_One = (SELECT TOP(1)[T].[Id] FROM [dbo].[Test] [T] ORDER BY [T].[Id] ASC);
SET @TestId_Two = (SELECT TOP(1)[T].[Id] FROM [dbo].[Test] [T] ORDER BY [T].[Id] DESC);


--Insert Result
INSERT INTO [dbo].[Result] ([AnalysisRequestId], [Sample_Cin], [TestId]) VALUES
(@InsertedRequestId,@Cin, @TestId_One),
(@InsertedRequestId,@Cin, @TestId_Two);




