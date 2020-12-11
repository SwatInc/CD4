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
  VALUES ('Afghan'),
('Albanian'),
('Algerian'),
('American'),
('Andorran'),
('Angolan'),
('Anguillan'),
('Argentine'),
('Armenian'),
('Australian'),
('Austrian'),
('Azerbaijani'),
('Bahamian'),
('Bahraini'),
('Bangladeshi'),
('Barbadian'),
('Belarusian'),
('Belgian'),
('Belizean'),
('Beninese'),
('Bermudian'),
('Bhutanese'),
('Bolivian'),
('Botswanan'),
('Brazilian'),
('British'),
('British Virgin Islander'),
('Bruneian'),
('Bulgarian'),
('Burkinan'),
('Burmese'),
('Burundian'),
('Cambodian'),
('Cameroonian'),
('Canadian'),
('Cape Verdean'),
('Cayman Islander'),
('Central African'),
('Chadian'),
('Chilean'),
('Chinese'),
('Citizen of Antigua and Barbuda'),
('Citizen of Bosnia and Herzegovina'),
('Citizen of Guinea-Bissau'),
('Citizen of Kiribati'),
('Citizen of Seychelles'),
('Citizen of the Dominican Republic'),
('Citizen of Vanuatu'),
('Colombian'),
('Comoran'),
('Congolese (Congo)'),
('Congolese (DRC)'),
('Cook Islander'),
('Costa Rican'),
('Croatian'),
('Cuban'),
('Cymraes'),
('Cymro'),
('Cypriot'),
('Czech'),
('Danish'),
('Djiboutian'),
('Dominican'),
('Dutch'),
('East Timorese'),
('Ecuadorean'),
('Egyptian'),
('Emirati'),
('English'),
('Equatorial Guinean'),
('Eritrean'),
('Estonian'),
('Ethiopian'),
('Faroese'),
('Fijian'),
('Filipino'),
('Finnish'),
('French'),
('Gabonese'),
('Gambian'),
('Georgian'),
('German'),
('Ghanaian'),
('Gibraltarian'),
('Greek'),
('Greenlandic'),
('Grenadian'),
('Guamanian'),
('Guatemalan'),
('Guinean'),
('Guyanese'),
('Haitian'),
('Honduran'),
('Hong Konger'),
('Hungarian'),
('Icelandic'),
('Indian'),
('Indonesian'),
('Iranian'),
('Iraqi'),
('Irish'),
('Israeli'),
('Italian'),
('Ivorian'),
('Jamaican'),
('Japanese'),
('Jordanian'),
('Kazakh'),
('Kenyan'),
('Kittitian'),
('Kosovan'),
('Kuwaiti'),
('Kyrgyz'),
('Lao'),
('Latvian'),
('Lebanese'),
('Liberian'),
('Libyan'),
('Liechtenstein citizen'),
('Lithuanian'),
('Luxembourger'),
('Macanese'),
('Macedonian'),
('Malagasy'),
('Malawian'),
('Malaysian'),
('Maldivian'),
('Malian'),
('Maltese'),
('Marshallese'),
('Martiniquais'),
('Mauritanian'),
('Mauritian'),
('Mexican'),
('Micronesian'),
('Moldovan'),
('Monegasque'),
('Mongolian'),
('Montenegrin'),
('Montserratian'),
('Moroccan'),
('Mosotho'),
('Mozambican'),
('Namibian'),
('Nauruan'),
('Nepalese'),
('New Zealander'),
('Nicaraguan'),
('Nigerian'),
('Nigerien'),
('Niuean'),
('North Korean'),
('Northern Irish'),
('Norwegian'),
('Omani'),
('Pakistani'),
('Palauan'),
('Palestinian'),
('Panamanian'),
('Papua New Guinean'),
('Paraguayan'),
('Peruvian'),
('Pitcairn Islander'),
('Polish'),
('Portuguese'),
('Prydeinig'),
('Puerto Rican'),
('Qatari'),
('Romanian'),
('Russian'),
('Rwandan'),
('Salvadorean'),
('Sammarinese'),
('Samoan'),
('Sao Tomean'),
('Saudi Arabian'),
('Scottish'),
('Senegalese'),
('Serbian'),
('Sierra Leonean'),
('Singaporean'),
('Slovak'),
('Slovenian'),
('Solomon Islander'),
('Somali'),
('South African'),
('South Korean'),
('South Sudanese'),
('Spanish'),
('Sri Lankan'),
('St Helenian'),
('St Lucian'),
('Stateless'),
('Sudanese'),
('Surinamese'),
('Swazi'),
('Swedish'),
('Swiss'),
('Syrian'),
('Taiwanese'),
('Tajik'),
('Tanzanian'),
('Thai'),
('Togolese'),
('Tongan'),
('Trinidadian'),
('Tristanian'),
('Tunisian'),
('Turkish'),
('Turkmen'),
('Turks and Caicos Islander'),
('Tuvaluan'),
('Ugandan'),
('Ukrainian'),
('Uruguayan'),
('Uzbek'),
('Vatican citizen'),
('Venezuelan'),
('Vietnamese'),
('Vincentian'),
('Wallisian'),
('Welsh'),
('Yemeni'),
('Zambian'),
('Zimbabwean');


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

INSERT INTO [dbo].[Patient] ([FullName], [NidPp], [Birthdate], [GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
  VALUES ('Ahmed Hussain', 'A1234567', '19910214', @MaleGenderId, @SHithadhooId, @MaldivesCountryId, 'Some Address', '772342300');

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

INSERT INTO [dbo].[Patient] ([FullName], [NidPp], [Birthdate], [GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
  VALUES ('Aminath Hussain', 'A987654', '19800214', @FeMaleGenderId, @SHithadhooId, @MaldivesCountryId, 'Some Some Address', '973465347');


--insert user: Bismillah.123!
SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('1', 'swatincadmin', 'Ibrahim Hussain', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('2', 'Hishmath', 'Hishmath Ibrahim', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('3', 'shaaif', 'Mohamed Shaaif Thaufeeg', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('4', 'Aliumar', 'Ali Umar', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('5', 'Aisha', 'Aishath Rasheed', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('6', 'Nashima', 'Nashima Mohamed Rasheed', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('7', 'Hashma', 'Hawwa Hashma Ali', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('8', 'Shanee', 'Fathimath Shaanee', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('9', 'Aliabdulla', 'Ali Abdulla', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF


SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('10', 'Kathuma', 'Kathuma Abdulla', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('11', 'Anisha', 'Fathimath Anisha Ali', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('12', 'Nasfa', 'Mariyam Nasfa', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('13', 'Shafa', 'Aminath Shafa Mohamed', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('14', 'Shaffah', 'Ismail Shaffah', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF


SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('15', 'Aiman', 'Mohamed Aiman', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF


SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('16', 'Faiha', 'Fathimath Faiha Ibrahim', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF



--1 = Swat, Inc Developer
--2 = Laboratory Manager
--3 = On-site IT
--4 = Laboratory Technologist
--5 = Pathologist
--6 = Phlebotomist
--7 = Reception Staff

--insert roles
INSERT INTO [dbo].[Roles] ([Id], [Name])
  VALUES ('1', 'Swat, Inc Developer'),
  ('2', 'Laboratory Manager'),
  ('3', 'On-site IT'),
  ('4', 'Laboratory Technologist'),
  ('5', 'Pathologist'),
  ('6', 'Phlebotomist'),
  ('7', 'Reception Staff');

--setup user roles
INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId])
  VALUES ('1', '1'),
  ('2', '2'),
  ('3', '4'),
  ('4', '4'),
  ('5', '4'),
  ('6', '4'),
  ('7', '4'),
  ('8', '4'),
  ('9', '4'),
  ('10', '4'),
  ('16', '7'),
  ('11', '7'),
  ('12', '7'),
  ('13', '7'),
  ('14', '7'),
  ('15', '3');


--setup user claims - develper
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
    ('1', 'Ribbon.GeneralPage'),
    ('1', 'AcceptSamplesView');

    --setup user claims - labManager
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('2', 'ribbon'),
    ('2', 'OrderEntryView'),
    ('2', 'ResultEntryView'),
    ('2', 'OrderEntry.Search'),
    ('2', 'OrderEntry.SearchReq'),
    ('2', 'OrderEntry.Remove'),
    ('2', 'OrderEntry.Confirm'),
    ('2', 'OrderEntry.PrintBarcode'),
    ('2', 'ResultEntryView.LoadWorksheet'),
    ('2', 'ResultEntryView.Report'),
    ('2', 'ResultEntry.ValidateSampleOrTest'),
    ('2', 'ResultEntry.ViewAuditTrail'),
    ('2', 'ResultEntry.PrintReport'),
    ('2', 'ResultEntry.RejectSampleOrTest'),
    ('2', 'ResultEntry.CancelSampleOrTestRejection'),
    ('2', 'ResultEntry.ShowTestHistory'),
    ('2', 'MainView'),
    ('2', 'Ribbon.Profile'),
    ('2', 'Ribbon.ConfigurationPage'),
    ('2', 'Ribbon.GeneralPage'),
    ('2', 'AcceptSamplesView');

    --setup user claims - OnSite IT
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('3', 'ribbon'),
    ('3', 'OrderEntryView'),
    ('3', 'ResultEntryView'),
    ('3', 'OrderEntry.Search'),
    ('3', 'OrderEntry.SearchReq'),
    ('3', 'ResultEntryView.LoadWorksheet'),
    ('3', 'ResultEntryView.Report'),
    ('3', 'ResultEntry.ViewAuditTrail'),
    ('3', 'ResultEntry.PrintReport'),
    ('3', 'ResultEntry.ShowTestHistory'),
    ('3', 'MainView'),
    ('3', 'Ribbon.Profile'),
    ('3', 'Ribbon.ConfigurationPage'),
    ('3', 'Ribbon.GeneralPage');

    --setup user claims - technologist
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('4', 'ribbon'),
    ('4', 'OrderEntryView'),
    ('4', 'ResultEntryView'),
    ('4', 'OrderEntry.Search'),
    ('4', 'OrderEntry.SearchReq'),
    ('4', 'OrderEntry.Remove'),
    ('4', 'OrderEntry.Confirm'),
    ('4', 'OrderEntry.PrintBarcode'),
    ('4', 'ResultEntryView.LoadWorksheet'),
    ('4', 'ResultEntryView.Report'),
    ('4', 'ResultEntry.ValidateSampleOrTest'),
    ('4', 'ResultEntry.ViewAuditTrail'),
    ('4', 'ResultEntry.PrintReport'),
    ('4', 'ResultEntry.RejectSampleOrTest'),
    ('4', 'ResultEntry.CancelSampleOrTestRejection'),
    ('4', 'ResultEntry.ShowTestHistory'),
    ('4', 'MainView'),
    ('4', 'Ribbon.Profile'),
    ('4', 'Ribbon.GeneralPage'),
    ('4', 'AcceptSamplesView');

--setup user claims - pathologist
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('5', 'ribbon'),
    ('5', 'OrderEntryView'),
    ('5', 'ResultEntryView'),
    ('5', 'OrderEntry.Search'),
    ('5', 'OrderEntry.SearchReq'),
    ('5', 'OrderEntry.Remove'),
    ('5', 'OrderEntry.Confirm'),
    ('5', 'OrderEntry.PrintBarcode'),
    ('5', 'ResultEntryView.LoadWorksheet'),
    ('5', 'ResultEntryView.Report'),
    ('5', 'ResultEntry.ValidateSampleOrTest'),
    ('5', 'ResultEntry.ViewAuditTrail'),
    ('5', 'ResultEntry.PrintReport'),
    ('5', 'ResultEntry.RejectSampleOrTest'),
    ('5', 'ResultEntry.CancelSampleOrTestRejection'),
    ('5', 'ResultEntry.ShowTestHistory'),
    ('5', 'MainView'),
    ('5', 'Ribbon.Profile'),
    ('5', 'Ribbon.GeneralPage'),
    ('5', 'AcceptSamplesView');

--setup user claims - phlebotomist
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('6', 'ribbon'),
    ('6', 'OrderEntryView'),
    ('6', 'ResultEntryView'),
    ('6', 'OrderEntry.Search'),
    ('6', 'OrderEntry.SearchReq'),
    ('6', 'OrderEntry.Remove'),
    ('6', 'OrderEntry.Confirm'),
    ('6', 'OrderEntry.PrintBarcode'),
    ('6', 'ResultEntryView.LoadWorksheet'),
    ('6', 'MainView'),
    ('6', 'Ribbon.Profile'),
    ('6', 'Ribbon.GeneralPage'),
    ('6', 'AcceptSamplesView');

    --setup user claims - reception staff
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES ('7', 'ribbon'),
    ('7', 'OrderEntryView'),
    ('7', 'ResultEntryView'),
    ('7', 'OrderEntry.Search'),
    ('7', 'OrderEntry.SearchReq'),
    ('7', 'OrderEntry.Remove'),
    ('7', 'OrderEntry.Confirm'),
    ('7', 'OrderEntry.PrintBarcode'),
    ('7', 'ResultEntry.PrintReport'),
    ('7', 'MainView'),
    ('7', 'Ribbon.Profile'),
    ('7', 'Ribbon.GeneralPage'),
    ('7', 'AcceptSamplesView');

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
  VALUES (2, 1, 4, 1),
         (3, 1, 5, 1),
         (4,2, 4, 1), 
         (5, 1, 5, 1);
GO
SET IDENTITY_INSERT [dbo].[CommentList_CommentType] OFF
GO

INSERT [dbo].[ResultAlertConfiguration]([TestId],[Result],[AlertMessage],[Operator],[IsEnabled])
VALUES
(@result,'POSITIVE',CONCAT('Result for ',@result,' is POSITIVE. Are you sure that you want to print the report?'));

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