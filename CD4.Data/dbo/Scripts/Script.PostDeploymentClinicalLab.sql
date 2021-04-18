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
  VALUES ('NATIONAL DRUG AGENCY'), ('MEDLAB DIAGNOSTICS');

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
('UNKNOWN'),
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
  ('NON-REACTIVE', 'NM'),
  ('INCONCLUSIVE', 'NM'),
  ('ދައްކާ POSITIVE', 'PA'),
  ('ނުދައްކާ NEGATIVE', 'NM');

--insert sample types
INSERT INTO [dbo].[SampleType] ([Description], [Colour])
  VALUES ('SERUM', 'Red'),
   ('URINE', 'White'),
  ('WHOLE BLOOD', 'Lavender');

--insert disciplines
INSERT INTO [dbo].[Discipline] ([Description])
  VALUES ('DIAGNOSTIC HAEMATOLOGY'),
  ('MOLECULAR BIOLOGY'),
  ('FORENSIC MEDICINE');

--insert units
INSERT INTO [dbo].[Unit] ([Unit])
  VALUES (' '),
  ('mg/dL'),
  ('%'),
  ('ng/mL'),
  ('ug/mL');

DECLARE @DoA varchar(100) = 'FORENSIC MEDICINE';
DECLARE @DoAId int;
DECLARE @IsDoAInserted int;

DECLARE @SampleType varchar(50) = 'URINE';
DECLARE @UrineId int;
DECLARE @IsSampleInserted int;

DECLARE @ResultDataType varchar(50) = 'CODIFIED';
DECLARE @ResultDataTypeNumeric varchar(50) = 'NUMERIC';
DECLARE @IsResultDataTypeInserted int;
DECLARE @ResultDataTypeId int;
DECLARE @ResultDataTypeNumericId int;
DECLARE @ResultUnit_blank_Id int;
DECLARE @ResultUnit_ngml_Id int;
DECLARE @ResultUnit_ugml_Id int;

DECLARE @CodifiedResultPos nvarchar(50) = N'ދައްކާ POSITIVE';
DECLARE @CodifiedResultNeg nvarchar(50) = N'ނުދައްކާ NEGATIVE';
DECLARE @CodifiedPosId int;
DECLARE @CodifiedNegId int;
DECLARE @IsCodifiedPosInserted int;
DECLARE @IsCodifiedNegInserted int;

-- INSERT DoA SECTION
SELECT @IsDoAInserted = COUNT([Id]) FROM dbo.Discipline WHERE [Description] = @DoA;
	IF(@IsDoAInserted = 0)
    BEGIN
        --insert DoA section
        INSERT INTO dbo.Discipline([Description]) VALUES (@DoA); 
    END
    --get DoA section Id
    SELECT @DoAId = [Id] FROM dbo.Discipline WHERE [Description] = @DoA;

-- insert sample type
SELECT @IsSampleInserted = COUNT([Id]) FROM dbo.SampleType WHERE [Description] = @SampleType;
    IF(@IsSampleInserted = 0)
    BEGIN
        --insert sample type
        INSERT INTO dbo.SampleType([Description],[Colour]) VALUES (@SampleType,'Black');
    END
    SELECT @UrineId = [Id] FROM dbo.SampleType WHERE [Description] = @SampleType;

-- insert result data type
SELECT @IsResultDataTypeInserted  = COUNT([Id]) FROM dbo.ResultDataType WHERE [Name] = @ResultDataType;
    IF(@IsResultDataTypeInserted = 0)
    BEGIN
        INSERT INTO dbo.ResultDataType([Name]) VALUES (@ResultDataType);
    END
    SELECT @ResultDataTypeId = [Id] FROM dbo.ResultDataType WHERE [Name] = @ResultDataType;
    SELECT @ResultDataTypeNumericId = [Id] FROM dbo.ResultDataType WHERE [Name] = @ResultDataTypeNumeric;

-- read unit Ids
SELECT @ResultUnit_blank_Id = [Id] FROM dbo.Unit WHERE Unit  = ' ';
SELECT @ResultUnit_ngml_Id = [Id] FROM dbo.Unit WHERE Unit  = 'ng/mL';
SELECT @ResultUnit_ugml_Id = [Id] FROM dbo.Unit WHERE Unit  = 'ug/mL';
SELECT @ResultUnit_mgdL_Id = [Id] FROM dbo.Unit WHERE Unit  = 'mg/dL';

-- insert codified POS
SELECT @IsCodifiedPosInserted  = COUNT([Id]) FROM dbo.CodifiedResult WHERE [Code] = @CodifiedResultPos;
    IF(@IsCodifiedPosInserted = 0)
    BEGIN
        INSERT INTO dbo.CodifiedResult([Code],[ReferenceCode]) VALUES (@CodifiedResultPos, 'PA');
    END
    SELECT @CodifiedPosId = [Id] FROM dbo.CodifiedResult WHERE [Code] = @CodifiedResultPos;

-- insert codified NEG
SELECT @IsCodifiedNegInserted  = COUNT([Id]) FROM dbo.CodifiedResult WHERE [Code] = @CodifiedResultNeg;
    IF(@IsCodifiedNegInserted = 0)
    BEGIN
        INSERT INTO dbo.CodifiedResult([Code],[ReferenceCode]) VALUES (@CodifiedResultNeg, 'NM');
    END
    SELECT @CodifiedNegId = [Id] FROM dbo.CodifiedResult WHERE [Code] = @CodifiedResultNeg;

INSERT INTO dbo.Test([DisciplineId],[Description],[SampleTypeId],[ResultDataTypeId],[Mask],[UnitId],[Reportable],[DeafultCommented])
VALUES
(@DoAId,N'Opiates_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Benzodiazepine-1_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Benzodiazepine-2_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Cocaine_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Cannabinoids_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Amphetamine_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Ethanol_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),
(@DoAId,N'Methadone_I',@UrineId,@ResultDataTypeId,CONCAT(@CodifiedPosId,'|',@CodifiedNegId),@ResultUnit_blank_Id,1,0),

(@DoAId,N'Opiates',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Benzodiazepine-1',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Benzodiazepine-2',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Cocaine',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Cannabinoids',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Amphetamine',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0),
(@DoAId,N'Ethanol',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_mgdL_Id,1,0),
(@DoAId,N'Methadone',@UrineId,@ResultDataTypeNumericId,'###.##',@ResultUnit_ngml_Id,1,0);

--PREPARE INSERT REFERENCE RANGES
DECLARE @OpiatesId int;
DECLARE @Benzodiazepine1Id int;
DECLARE @Benzodiazepine2Id int;
DECLARE @CocaineId int;
DECLARE @CannabinoidsId int;
DECLARE @AmphetamineId int;
DECLARE @EthanolId int;
DECLARE @MethadoneId int;

SELECT @OpiatesId = [Id] FROM dbo.Test where [Description] = 'Opiates';
SELECT @Benzodiazepine1Id = [Id] FROM dbo.Test where [Description] = 'Benzodiazepine-1';
SELECT @Benzodiazepine2Id = [Id] FROM dbo.Test where [Description] = 'Benzodiazepine-2';
SELECT @CocaineId = [Id] FROM dbo.Test where [Description] = 'Cocaine';
SELECT @CannabinoidsId = [Id] FROM dbo.Test where [Description] = 'Cannabinoids';
SELECT @AmphetamineId = [Id] FROM dbo.Test where [Description] = 'Amphetamine';
SELECT @EthanolId = [Id] FROM dbo.Test where [Description] = 'Ethanol';
SELECT @MethadoneId = [Id] FROM dbo.Test where [Description] = 'Methadone';

--INSERT REFERENCE RANGES
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @OpiatesId,1,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @OpiatesId,2,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @OpiatesId,3,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @OpiatesId,4,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine1Id,1,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine1Id,2,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine1Id,3,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine1Id,4,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine2Id,1,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine2Id,2,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine2Id,3,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @Benzodiazepine2Id,4,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CocaineId,1,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CocaineId,2,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CocaineId,3,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CocaineId,4,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CannabinoidsId,1,0,73000,0,0,'NEGATIVE <50'+ CHAR(13)+CHAR(10)+'POSITIVE >50';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CannabinoidsId,2,0,73000,0,0,'NEGATIVE <50'+ CHAR(13)+CHAR(10)+'POSITIVE >50';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CannabinoidsId,3,0,73000,0,0,'NEGATIVE <50'+ CHAR(13)+CHAR(10)+'POSITIVE >50';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @CannabinoidsId,4,0,73000,0,0,'NEGATIVE <50'+ CHAR(13)+CHAR(10)+'POSITIVE >50';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @AmphetamineId,1,0,73000,0,0,'NEGATIVE <500'+ CHAR(13)+CHAR(10)+'POSITIVE >500';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @AmphetamineId,2,0,73000,0,0,'NEGATIVE <500'+ CHAR(13)+CHAR(10)+'POSITIVE >500';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @AmphetamineId,3,0,73000,0,0,'NEGATIVE <500'+ CHAR(13)+CHAR(10)+'POSITIVE >500';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @AmphetamineId,4,0,73000,0,0,'NEGATIVE <500'+ CHAR(13)+CHAR(10)+'POSITIVE >500';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @EthanolId,1,0,73000,0,0,'NEGATIVE <100'+ CHAR(13)+CHAR(10)+'POSITIVE >100';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @EthanolId,2,0,73000,0,0,'NEGATIVE <100'+ CHAR(13)+CHAR(10)+'POSITIVE >100';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @EthanolId,3,0,73000,0,0,'NEGATIVE <100'+ CHAR(13)+CHAR(10)+'POSITIVE >100';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @EthanolId,4,0,73000,0,0,'NEGATIVE <100'+ CHAR(13)+CHAR(10)+'POSITIVE >100';

INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @MethadoneId,1,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @MethadoneId,2,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @MethadoneId,3,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';
INSERT INTO [dbo].[ReferenceRange]([TestId],[GenderId],[FromAgeDays],[ToAgeDays],[DeltaValidityIntervalDays],[BiasFactor],[DisplayNormalRange])
SELECT @MethadoneId,4,0,73000,0,0,'NEGATIVE <300'+ CHAR(13)+CHAR(10)+'POSITIVE >300';


-- INSERT USERS
--insert user: Bismillah.123!
SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('1', 'swatincadmin', 'Ibrahim Hussain', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('2', 'Billing Module', 'Billing', '', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('3', 'CD4 Interface',  'CD4 Interface', '', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('4', 'samaahath', 'Samahath Ahmed', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('5', 'fakhira', 'Fakhira Adnan', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('6', 'suhaila', 'Suhaila Mohamed', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('7', 'aishath.nasha', 'Aishath Nasha', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('8', 'aishath.adam', 'Aishath Adam', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('9', 'ali', 'Ali Shah', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

SET IDENTITY_INSERT [Users] ON
INSERT INTO [dbo].[Users] ([Id], [UserName], [Fullname], [PasswordHash], [AccessFailedCount], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled])
  VALUES ('10', 'shaanee', 'Fathimath Shaanee', 'SHA512:88:lhOgh7mA9H1w9L9wu6FoVPUiK+sYR4Tr5A==:8Y2OSxfDTkF9zcplYHlU5LZ/zM3cvpycvAWeEbUxQeR1I3/mCxb7tLt5bBLl2FWJmPEubhYyH0s9tFP60Wo3EQ==', 0, 0, 0, 0, 0);
SET IDENTITY_INSERT [Users] OFF

INSERT INTO [dbo].[Roles] ([Id], [Name])
  VALUES ('1', 'Swat, Inc Developer'),
  ('2', 'Laboratory Manager'),
  ('3', 'On-site IT'),
  ('4', 'Laboratory Technologist'),
  ('5', 'Pathologist'),
  ('6', 'Phlebotomist'),
  ('7', 'Reception Staff');


--setup user claims - develper
INSERT INTO [dbo].[RoleClaims] ([RoleId], [ClaimValue])
  VALUES  ('1', 'ResultEntryView.ReadWriteAccess'),
    ('1', 'ResultEntry.ExportReport'),
    ('1', 'ribbon'),
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



insert into dbo.UserRoles(userid, roleId) VALUES
(1,1)

--billing tests mapping 
insert into [dbo].[BillingTestCodeMap](TestId, [billingtestid])
select [Id],[Id] FROM dbo.Test

INSERT INTO dbo.NdaLookup([Description]) VALUES
('Collected'),
('Received'),
('Tested'),
('Reported'),
('QcAndCalValidated');