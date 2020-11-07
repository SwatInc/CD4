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
INSERT INTO [dbo].[Sites] ([Name])
  VALUES ('FARUKOLHU'),
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

INSERT INTO [dbo].[Country] ([Country])
  VALUES ('MALDIVIAN'),
  ('BANGLADESHI'),
  ('INDIAN');

INSERT INTO [dbo].[Gender] ([Gender])
  VALUES ('MALE'),
  ('FEMALE'),
  ('UNKNOWN'),
  ('NOT AVAILABLE')

INSERT INTO [dbo].[Atoll] ([Atoll], [Island])
  VALUES ('AA', 'BODUFOLHUDHOO')
  , ('AA', 'FERIDHOO')
  , ('AA', 'HIMANDHOO')
  , ('AA', 'MAALHOS')
  , ('AA', 'MATHIVERI')
  , ('AA', 'RASDHOO')
  , ('AA', 'THODDOO')
  , ('AA', 'UKULHAS')
  , ('AA', 'FESDHOO')
  , ('ADH', 'DHANGETHI')
  , ('ADH', 'DHIDDHOO')
  , ('ADH', 'DHIGURAH')
  , ('ADH', 'FENFUSHI')
  , ('ADH', 'HAGGNAAMEEDHOO')
  , ('ADH', 'KUNBURUDHOO')
  , ('ADH', 'MAAMIGILI')
  , ('ADH', 'MAHIBADHOO')
  , ('ADH', 'MANDHOO')
  , ('ADH', 'OMADHOO')
  , ('B', 'DHARAVANDHOO')
  , ('B', 'DHONFANU')
  , ('B', 'EYDHAFUSHI')
  , ('B', 'FEHENDHOO')
  , ('B', 'FULHADHOO')
  , ('B', 'GOIDHOO')
  , ('B', 'HITHAADHOO')
  , ('B', 'KIHAADHOO')
  , ('B', 'KAMADHOO')
  , ('B', 'KENDHOO')
  , ('B', 'KIHAADHOO')
  , ('B', 'KUDARIKILU')
  , ('B', 'MAALHOS')
  , ('B', 'THULHAADHOO')
  , ('DH', 'BANDIDHOO')
  , ('DH', 'GEMENDHOO')
  , ('DH', 'HULHUDHELI')
  , ('DH', 'KUDAHUVADHOO')
  , ('DH', 'MAAENBOODHOO')
  , ('DH', 'MEEDHOO')
  , ('DH', 'RINBUDHOO')
  , ('DH', 'VAANEE')
  , ('F', 'BILEDDHOO')
  , ('F', 'DHARANBOODHOO')
  , ('F', 'FEEALI')
  , ('F', 'FILITHEYO')
  , ('F', 'MAGOODHOO')
  , ('F', 'NILANDHOO')
  , ('GA', 'DHAANDHOO')
  , ('GA', 'DHEWADHOO')
  , ('GA', 'DHIYADHOO')
  , ('GA', 'GEMANAFUSHI')
  , ('GA', 'KANDUHULHUDHOOO')
  , ('GA', 'KOLAMAAFUSHI')
  , ('GA', 'KONDEY')
  , ('GA', 'MAAMENDHOO')
  , ('GA', 'NILANDHOO')
  , ('GA', 'VILINGILI')
  , ('GDH', 'FARES MAATHODAA')
  , ('GDH', 'FIYOAREE')
  , ('GDH', 'GADDHOO')
  , ('GDH', 'HOANDEDDHOO')
  , ('GDH', 'MAATHODAA')
  , ('GDH', 'MADAVELI')
  , ('GDH', 'NADELLA')
  , ('GDH', 'RATHAFANDHOO')
  , ('GDH', 'THINADHOO')
  , ('GDH', 'VAADHOO')
  , ('GN', 'FUVAHMULAH')
  , ('HA', 'BAARAH')
  , ('HA', 'BERINMADHOO')
  , ('HA', 'DHIDDHOO')
  , ('HA', 'FILLADHOO')
  , ('HA', 'HATHIFUSHI')
  , ('HA', 'HOARAFUSHI')
  , ('HA', 'IHAVANDHOO')
  , ('HA', 'KELAA')
  , ('HA', 'MAARANDHOO')
  , ('HA', 'MULHADHOO')
  , ('HA', 'MURAIDHOO')
  , ('HA', 'THAKANDHOO')
  , ('HA', 'THURAAKUNU')
  , ('HA', 'ULIGAMU')
  , ('HA', 'UTHEEMU')
  , ('HA', 'VASHAFARU')
  , ('HDH', 'FARIDHOO')
  , ('HDH', 'FINEY')
  , ('HDH', 'HANIMAADHOO')
  , ('HDH', 'HIRIMARADHOO')
  , ('HDH', 'KULHUDHUFFUSHI')
  , ('HDH', 'KUMUNDHOO')
  , ('HDH', 'KUNBURUDHOO')
  , ('HDH', 'KUNBURUDHOO')
  , ('HDH', 'MAAVAIDHOO')
  , ('HDH', 'MAKUNUDHOO')
  , ('HDH', 'NAIVAADHOO')
  , ('HDH', 'NELLAIDHOO')
  , ('HDH', 'NEYKURENDHOO')
  , ('HDH', 'NOLHIVARAM')
  , ('HDH', 'NOLHIVARANFARU')
  , ('HDH', 'VAIKARADHOO')
  , ('HDH', 'KURINBI')
  , ('K', 'DHIFFUSHI')
  , ('K', 'GAAFARU')
  , ('K', 'GULHI')
  , ('K', 'GURAIDHOO')
  , ('K', 'HULHUMALÉ')
  , ('K', 'HIMMAFUSHI')
  , ('K', 'HURAA')
  , ('K', 'KAASHIDHOO')
  , ('K', 'MALE')
  , ('K', 'MAAFUSHI')
  , ('K', 'THULUSDHOO')
  , ('K', 'VILLIGINLI')
  , ('L', 'DHANBIDHOO')
  , ('L', 'FONADHOO')
  , ('L', 'GAADHOO')
  , ('L', 'GAN')
  , ('L', 'HITHADHOO')
  , ('L', 'ISDHOO')
  , ('L', 'KALHAIDHOO')
  , ('L', 'KUNAHANDHOO')
  , ('L', 'MAABAIDHOO')
  , ('L', 'MAAMENDHOO')
  , ('L', 'MAAVAH')
  , ('L', 'MUNDOO')
  , ('L', 'KALAIDHOO')
  , ('LH', 'HINNAVARU')
  , ('LH', 'KURENDHOO')
  , ('LH', 'MAAFILAAFUSHI')
  , ('LH', 'NAIFARU')
  , ('LH', 'OLHIVELIFUSHI')
  , ('M', 'BOLI MULAH')
  , ('M', 'DHIGGARU')
  , ('M', 'KOLHUFUSHI')
  , ('M', 'MADIFUSHI')
  , ('M', 'MADUVVARI')
  , ('M', 'MULAH')
  , ('M', 'NAALAAFUSHI')
  , ('M', 'RAIMMANDHOO')
  , ('M', 'VEYVAH')
  , ('M', 'MULI')
  , ('N', 'FODHDHOO')
  , ('N', 'HENBANDHOO')
  , ('N', 'HOLHUDHOO')
  , ('N', 'KENDHIKOLHUDHOO')
  , ('N', 'KUDAFAREE')
  , ('N', 'LANDHOO')
  , ('N', 'LHOHI')
  , ('N', 'MAAFARU')
  , ('N', 'MAALHENDHOO')
  , ('N', 'MAGOODHOO')
  , ('N', 'MANADHOO')
  , ('N', 'MILADHOO')
  , ('N', 'VELIDHOO')
  , ('R', 'ALIFUSHI')
  , ('R', 'ANGOLHITHEEMU')
  , ('R', 'FAINU')
  , ('R', 'HULHUDHUFFAARU')
  , ('R', 'INGURAIDHOO')
  , ('R', 'INNAMAADHOO')
  , ('R', 'DHUVAAFARU')
  , ('R', 'KINOLHAS')
  , ('R', 'MAAKURATHU')
  , ('R', 'MADUVVARI')
  , ('R', 'MEEDHOO')
  , ('R', 'RASGETHEEMU')
  , ('R', 'RASMAADHOO')
  , ('R', 'UNGOOFAARU')
  , ('R', 'VAADHOO')
  , ('R', 'KANDHOLHUDHOO')
  , ('S', 'FEYDHOO')
  , ('S', 'HITHADHOO')
  , ('S', 'HULHUDHOO')
  , ('S', 'MARADHOO')
  , ('S', 'MEEDHOO')
  , ('S', 'MARADHOO-FEYDHOO')
  , ('SH', 'BILEFFAHI')
  , ('SH', 'FEEVAH')
  , ('SH', 'FEYDHOO')
  , ('SH', 'FIRUNBAIDHOO')
  , ('SH', 'FOAKAIDHOO')
  , ('SH', 'FUNADHOO')
  , ('SH', 'GOIDHOO')
  , ('SH', 'KANDITHEEMU')
  , ('SH', 'KOMANDOO')
  , ('SH', 'LHAIMAGU')
  , ('SH', 'MAAKANDOODHOO')
  , ('SH', 'MAAUNGOODHOO')
  , ('SH', 'MAROSHI')
  , ('SH', 'MILANDHOO')
  , ('SH', 'NARUDHOO')
  , ('SH', 'NOOMARAA')
  , ('TH', 'BURUNEE')
  , ('TH', 'DHIYAMINGILI')
  , ('TH', 'GAADHIFFUSHI')
  , ('TH', 'GURAIDHOO')
  , ('TH', 'HIRILANDHOO')
  , ('TH', 'KANDOODHOO')
  , ('TH', 'KINBIDHOO')
  , ('TH', 'MADIFUSHI')
  , ('TH', 'OMADHOO')
  , ('TH', 'THIMARAFUSHI')
  , ('TH', 'VANDHOO')
  , ('TH', 'VEYMANDOO')
  , ('TH', 'VILUFUSHI')
  , ('V', 'FELIDHOO')
  , ('V', 'FULIDHOO')
  , ('V', 'KEYODHOO')
  , ('V', 'RAKEEDHOO')
  , ('V', 'THINADHOO');

INSERT INTO [dbo].[ClinicalDetail] ([Detail])
  VALUES ('Fever')
  , ('Cough')
  , ('Runny Nose')
  , ('Breathing Difficulty')
  , ('Travel History')

INSERT INTO [dbo].[ResultDataType] ([Name])
  VALUES ('NUMERIC'),
  ('CODIFIED'),
  ('TEXTUAL');

INSERT INTO [dbo].[CodifiedResult] ([Code], [ReferenceCode])
  VALUES ('POSITIVE', 'PA'),
  ('NEGATIVE', 'NM'),
  ('REACTIVE', 'PA'),
  ('NON-REACTIVE', 'NM');

--insert sample types
INSERT INTO [dbo].[SampleType] ([Description], [Colour])
  VALUES ('SERUM', 'Red'),
  ('WHOLE BLOOD', 'Lavender');

--insert disciplines
INSERT INTO [dbo].[Discipline] ([Description])
  VALUES ('DIAGNOSTIC HAEMATOLOGY'),
  ('MOLECULAR BIOLOGY');
--insert units
INSERT INTO [dbo].[Unit] ([Unit])
  VALUES (' '),
  ('mg/dL'),
  ('%');

DECLARE @CodifiedId int;
DECLARE @NumericId int;
DECLARE @NumericIdSerum int;
DECLARE @SampleTypeIdSerum int;
DECLARE @SampleTypeIdWb int;
DECLARE @DisciplineMolecular int;
DECLARE @DisciplineHaematology int;
DECLARE @UnitmgdL int;
DECLARE @UnitPercent int;
DECLARE @UnitNA int;
SELECT
  @SampleTypeIdSerum = [Id]
FROM [dbo].[SampleType]
WHERE [Description] = 'SERUM';
SELECT
  @SampleTypeIdWb = [Id]
FROM [dbo].[SampleType]
WHERE [Description] = 'WHOLE BLOOD';
SELECT
  @CodifiedId = [Id]
FROM [dbo].[ResultDataType] [r]
WHERE [r].[Name] = 'CODIFIED';
SELECT
  @NumericId = [Id]
FROM [dbo].[ResultDataType] [r]
WHERE [r].[Name] = 'NUMERIC';
SELECT
  @DisciplineMolecular = [Id]
FROM [dbo].[Discipline] [d]
WHERE [d].[Description] = 'MOLECULAR BIOLOGY';
SELECT
  @DisciplineHaematology = [Id]
FROM [dbo].[Discipline] [d]
WHERE [d].[Description] = 'DIAGNOSTIC HAEMATOLOGY';
SELECT
  @UnitmgdL = [Id]
FROM [dbo].[unit] [u]
WHERE [u].[Unit] = 'mg/dL';
SELECT
  @UnitPercent = [Id]
FROM [dbo].[unit] [u]
WHERE [u].[Unit] = '%';
SELECT
  @UnitNA = [Id]
FROM [dbo].[unit] [u]
WHERE [u].[Unit] = ' ';


INSERT INTO [dbo].[Test] ([DisciplineId], [SampleTypeId], [Description], [Mask], [Reportable], [ResultDataTypeId], [UnitId], [DeafultCommented])
  VALUES (@DisciplineMolecular, @SampleTypeIdSerum, 'E Gene', '##.##', 1, @NumericId, @UnitNA, 0),
  (@DisciplineMolecular, @SampleTypeIdSerum, 'EAV (Internal Control)', '##.##', 1, @NumericId, @UnitNA, 0),
  (@DisciplineMolecular, @SampleTypeIdSerum, 'RdRP Gene', '##.##', 1, @NumericId, @UnitNA, 0),
  (@DisciplineMolecular, @SampleTypeIdSerum, 'SARS-CoV-2 Result', '1|2', 1, @CodifiedId, @UnitNA, 0),
  (@DisciplineHaematology, @SampleTypeIdWb, 'Haemoglobin', '##.##', 1, @NumericId, @UnitmgdL, 0),
  (@DisciplineHaematology, @SampleTypeIdWb, 'Haematocrit', '##.##', 1, @NumericId, @UnitPercent, 0);

INSERT INTO [dbo].[Profiles] ([Description])
  VALUES ('SARS CoV Profile'),
  ('Hb/PCV');

DECLARE @CovProfileId int;
DECLARE @CovProfileIdHbPcv int;
SELECT
  @CovProfileId = [Id]
FROM [dbo].[Profiles] [p]
WHERE [p].[Description] = 'SARS CoV Profile';
SELECT
  @CovProfileIdHbPcv = [Id]
FROM [dbo].[Profiles] [p]
WHERE [p].[Description] = 'Hb/PCV';

DECLARE @egene int;
DECLARE @eav int;
DECLARE @rdrp int;
DECLARE @result int;
DECLARE @resultHb int;
DECLARE @resultPCV int;

SELECT
  @egene = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'E Gene';
SELECT
  @eav = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'EAV (Internal Control)';
SELECT
  @rdrp = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'RdRP Gene';
SELECT
  @result = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'SARS-CoV-2 Result';
SELECT
  @resultHb = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'Haemoglobin';
SELECT
  @resultPCV = [Id]
FROM [dbo].[Test] [t]
WHERE [t].[Description] = 'Haematocrit';

INSERT INTO [dbo].[Profile_Tests] ([ProfileId], [TestId])
  VALUES (@CovProfileId, @egene),
  (@CovProfileId, @eav),
  (@CovProfileId, @rdrp),
  (@CovProfileId, @result),
  (@CovProfileIdHbPcv, @resultHb),
  (@CovProfileIdHbPcv, @resultPCV);

--Preparing to insert patient
DECLARE @MaleGenderId int;
DECLARE @FeMaleGenderId int;
DECLARE @SHithadhooId int;
DECLARE @MaldivesCountryId int;

SELECT
  @MaleGenderId = [Id]
FROM [dbo].[Gender]
WHERE [Gender] = 'MALE';
SELECT
  @SHithadhooId = [Id]
FROM [dbo].[Atoll]
WHERE [Atoll] = 'S'
AND [Island] = 'Hithadhoo';
SELECT
  @MaldivesCountryId = [Id]
FROM [dbo].[Country]
WHERE [Country] = 'MALDIVIAN';

--INSERT INTO [dbo].[Patient] ([FullName], [NidPp], [Birthdate], [GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
--  VALUES ('Ahmed Hussain', 'A1234567', '19910214', @MaleGenderId, @SHithadhooId, @MaldivesCountryId, 'Some Address', '772342300');

SELECT
  @FeMaleGenderId = [Id]
FROM [dbo].[Gender]
WHERE [Gender] = 'FEMALE';
SELECT
  @SHithadhooId = [Id]
FROM [dbo].[Atoll]
WHERE [Atoll] = 'K'
AND [Island] = 'MALE';
SELECT
  @MaldivesCountryId = [Id]
FROM [dbo].[Country]
WHERE [Country] = 'BANGLADESHI';

--INSERT INTO [dbo].[Patient] ([FullName], [NidPp], [Birthdate], [GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
--  VALUES ('Aminath Hussain', 'A987654', '19800214', @FeMaleGenderId, @SHithadhooId, @MaldivesCountryId, 'Some Some Address', '973465347');


--insert user: Bismillah.123!
SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('1', 'swatincadmin', 'Ibrahim Hussain', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

--insert roles
INSERT INTO [dbo].[Roles] ([Id], [Name])
  VALUES ('1', 'Swat, Inc Developer');

--setup user roles
INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId])
  VALUES ('1', '1');

--setup user claims
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('1', 'ribbon'),
    ('1', 'OrderEntryView'),
    ('1', 'ResultEntryView'),
    ('1', 'OrderEntry.Search'),
    ('1', 'OrderEntry.SearchReq'),
    ('1', 'OrderEntry.Remove'),
    ('1', 'OrderEntry.Confirm'),
    ('1', 'OrderEntry.PrintBarcode'),
    ('1', 'ResultEntryView.LoadWorksheet'),
    ('1', 'ResultEntryView.Report'),
    ('1', 'ResultEntry.ValidateSampleOrTest'),
    ('1', 'ResultEntry.ViewAuditTrail'),
    ('1', 'ResultEntry.PrintReport'),
    ('1', 'ResultEntry.RejectSampleOrTest'),
    ('1', 'ResultEntry.CancelSampleOrTestRejection'),
    ('1', 'ResultEntry.ShowTestHistory'),
    ('1', 'MainView'),
    ('1', 'Ribbon.Profile'),
    ('1', 'Ribbon.ConfigurationPage'),
    ('1', 'Ribbon.GeneralPage');

--insert status table data
INSERT INTO [dbo].[Status] ([Status])
  VALUES ('Registered'), ('Collected'), ('Received'), ('ToValidate'), ('Validated'), ('Processing'), ('Rejected'), ('Removed');


-- insert system printer
INSERT INTO [dbo].[Printers] ([Description])
  VALUES ('\\RECEPTION1\BarcodePrinter');
INSERT INTO [dbo].[Printers] ([Description])
  VALUES ('OneNote for Windows 10');
INSERT INTO [dbo].[PrinterTypes] ([Description])
  VALUES ('Barcode Printer');
INSERT INTO [dbo].[PrinterTypes] ([Description])
  VALUES ('Document Printer');
INSERT INTO [dbo].[WorkStations] ([Description])
  VALUES ('IbrahimHucyn');
INSERT INTO [dbo].[WorkStationPrinters] ([WorkStationId], [PrinterId], [PrinterTypeId])
  VALUES (1, 1, 1);
INSERT INTO [dbo].[WorkStationPrinters] ([WorkStationId], [PrinterId], [PrinterTypeId])
  VALUES (1, 2, 2);


-- Insert rows into table 'dbo.AuditTypes' in schema '[dbo]'
INSERT INTO [dbo].[AuditTypes] ([Description])
  VALUES ('AnalysisRequest'),
  ('Sample'),
  ('Test');

-- REFEENCE RANGES SET UP
-- reference type
INSERT INTO [dbo].[ReferenceType] ([Description])
  VALUES ('Normal'),
  ('Attention'),
  ('Pathology'),
  ('Panic / High Pathology'),
  ('Not Acceptable');

DECLARE @NormalId int;
DECLARE @AttentionId int;
DECLARE @PathologyId int;
DECLARE @PanicId int;
DECLARE @NotAcceptableId int;

-- get the reference type Ids
SELECT
  @NormalId = [Id]
FROM [dbo].[ReferenceType]
WHERE [Description] = 'Normal';
SELECT
  @AttentionId = [Id]
FROM [dbo].[ReferenceType]
WHERE [Description] = 'Attention';
SELECT
  @PathologyId = [Id]
FROM [dbo].[ReferenceType]
WHERE [Description] = 'Pathology';
SELECT
  @PanicId = [Id]
FROM [dbo].[ReferenceType]
WHERE [Description] = 'Panic / High Pathology';
SELECT
  @NotAcceptableId = [Id]
FROM [dbo].[ReferenceType]
WHERE [Description] = 'Not Acceptable';

-- insert reference range
--haemoglobin, normal , female, age 0 to 73000 days
--PCV, normal , female, age 0 to 73000 days
INSERT INTO [dbo].[ReferenceRange] ([TestId], [GenderId], [FromAgeDays], [ToAgeDays], [DeltaValidityIntervalDays], [BiasFactor], [DisplayNormalRange])
  VALUES (@resultHb, @FeMaleGenderId, 0, 73000, 0, 0, '11 - 18.2 g/dL'),
  (@resultPCV, @FeMaleGenderId, 0, 73000, 0, 0, '33.0 - 54.6 %');

-- get reference range ids
DECLARE @ReferenceRangeHgbId int;
DECLARE @ReferenceRangePCVId int;

SELECT
  @ReferenceRangeHgbId = [Id]
FROM [ReferenceRange]
WHERE [TestId] = @resultHb;
SELECT
  @ReferenceRangePCVId = [Id]
FROM [ReferenceRange]
WHERE [TestId] = @resultPCV;

-- insert referece data for Hb and PCV
INSERT INTO [dbo].[ReferenceData] ([ReferenceRangeId], [ReferenceTypeId], [LowLimitValue], [HighLimitValue])
  VALUES (@ReferenceRangeHgbId, @NormalId, 11.0, 18.2), -- HGB
  (@ReferenceRangeHgbId, @AttentionId, 9.0, 20.2),
  (@ReferenceRangeHgbId, @PathologyId, 7.0, 20.9),
  (@ReferenceRangeHgbId, @PanicId, 6.0, 21.9),
  (@ReferenceRangeHgbId, @NotAcceptableId, 2.0, 25.9),
  (@ReferenceRangePCVId, @NormalId, 33.0, 54.6), -- PCV
  (@ReferenceRangePCVId, @AttentionId, 27.0, 60.2),
  (@ReferenceRangePCVId, @PathologyId, 21.0, 60.9),
  (@ReferenceRangePCVId, @PanicId, 18.0, 65.7),
  (@ReferenceRangePCVId, @NotAcceptableId, 6.0, 77.9);

USE [CD4Data]
GO
SET IDENTITY_INSERT [dbo].[CommentList] ON
GO
INSERT [dbo].[CommentList] ([Id], [Description], [IsActive], [UpdatedDate], [CreatedDate])
  VALUES (1, N'Sample haemolysed.', 1, GETDATE(), GETDATE()),
         (2, N'Sample insufficient.', 1, GETDATE(), GETDATE());
GO
SET IDENTITY_INSERT [dbo].[CommentList] OFF
GO
SET IDENTITY_INSERT [dbo].[CommentType] ON
GO
INSERT [dbo].[CommentType] ([Id], [Description])
  VALUES (1, N'Patient'), (2, N'Sample'), (3, N'Test'),(4, N'SampleRejection'),(5, N'TestRejection');
GO
SET IDENTITY_INSERT [dbo].[CommentType] OFF
GO
SET IDENTITY_INSERT [dbo].[CommentList_CommentType] ON
GO
INSERT [dbo].[CommentList_CommentType] ([Id], [CommentListId], [CommentTypeId], [IsActive])
  VALUES (2, 1, 4, 1), (3, 1, 5, 1),(4,2, 4, 1), (5, 1, 5, 1);
GO
SET IDENTITY_INSERT [dbo].[CommentList_CommentType] OFF
GO

----Get a patient Id
--DECLARE @PatientId int;
--DECLARE @ScientistId int;
--DECLARE @InsertedRequestId int;
--DECLARE @SiteId int;
--DECLARE @TestId_One int;
--DECLARE @TestId_Two int;
--DECLARE @ClinicalDetail_One int;
--DECLARE @ClinicalDetail_Two int;
--DECLARE @Cin varchar(50) = 'nCoV-2346/20';
--DECLARE @EpisodeNumber varchar(15) = 'BS1234567';


--SET @PatientId = (SELECT TOP(1) [P].[Id] FROM [dbo].[Patient] [P]);

----Insert a scientist
--INSERT INTO [dbo].[Scientist] ([Name]) VALUES 
--('Some Scientist')
--SET @ScientistId = (SELECT TOP(1)Id FROM [dbo].[Scientist] ORDER BY [Id] DESC);

----Insert the Analysis Request
--INSERT INTO [dbo].[AnalysisRequest] ([PatientId],[EpisodeNumber], [Age], [CheckedBy], [ApprovedBy]) VALUES
--(@PatientId,@EpisodeNumber,23, @ScientistId,@ScientistId);

--SET @InsertedRequestId = (SELECT TOP(1)Id FROM [dbo].[AnalysisRequest] ORDER BY [Id] DESC);
--SET @SiteId  = (SELECT TOP(1)Id FROM [dbo].[Sites]);

----insert Clinical details
--SET @ClinicalDetail_One = (SELECT TOP(1)[Id] FROM [dbo].[ClinicalDetail] ORDER BY [Id] ASC);
--SET @ClinicalDetail_Two = (SELECT TOP(1)[Id] FROM [dbo].[ClinicalDetail] ORDER BY [Id] DESC);

--INSERT INTO [dbo].[AnalysisRequest_ClinicalDetail]([AnalysisRequestId], [ClinicalDetailsId]) VALUES
--(@InsertedRequestId, @ClinicalDetail_One),
--(@InsertedRequestId, @ClinicalDetail_Two);

----Insert Sample
--INSERT INTO [dbo].[Sample] ([Cin], [AnalysisRequestId], [SiteId], [CollectionDate],[ReceivedDate])
--VALUES
--(@Cin, @InsertedRequestId, @SiteId, GETDATE(), GETDATE());

----Get Some Test Ids
--SET @TestId_One = (SELECT TOP(1)[T].[Id] FROM [dbo].[Test] [T] ORDER BY [T].[Id] ASC);
--SET @TestId_Two = (SELECT TOP(1)[T].[Id] FROM [dbo].[Test] [T] ORDER BY [T].[Id] DESC);


----Insert Result
--INSERT INTO [dbo].[Result] ([Sample_Cin], [TestId]) VALUES
--(@Cin, @TestId_One),
--(@Cin, @TestId_Two);
--GO