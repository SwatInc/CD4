/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
Post deployment script for Abdul Samadh Memorial Hospital			
--------------------------------------------------------------------------------------
*/

-- INSERT SITES
INSERT INTO [dbo].[Sites] ([Name])
  VALUES ('PHELBOTOMY');

-- INSERT NATIONALITIES
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

-- INSERT GENDERS
INSERT INTO [dbo].[Gender] ([Gender])
  VALUES ('MALE'),
  ('FEMALE'),
  ('UNKNOWN'),
  ('NOT AVAILABLE');

-- INSERT ATOLLS
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

-- INSERT CLINICAL DETAILS
INSERT INTO [dbo].[ClinicalDetail] ([Detail])
  VALUES ('Fever')
  , ('Cough')
  , ('Runny Nose')
  , ('Breathing Difficulty')
  , ('Travel History');

-- DATA TYPES
INSERT INTO [dbo].[ResultDataType] ([Name])
  VALUES ('NUMERIC'),
  ('CODIFIED'),
  ('TEXTUAL');

-- CODIFIED RESULTS
INSERT INTO [dbo].[CodifiedResult] ([Code], [ReferenceCode])
  VALUES ('POSITIVE', 'PA'),
  ('NEGATIVE', 'NM'),
  ('REACTIVE', 'PA'),
  ('NON-REACTIVE', 'NM'),
  ('INCONCLUSIVE', 'NM');

--INSERT SAMPLE TYPES
INSERT INTO [dbo].[SampleType] ([Description], [Colour])
  VALUES ('SERUM', 'Red'),
   ('URINE', 'White'),
  ('WHOLE BLOOD', 'Lavender');

--INSERT DISCIPLINES
INSERT INTO [dbo].[Discipline] ([Description])
  VALUES ('DIAGNOSTIC HAEMATOLOGY'),
  ('MOLECULAR BIOLOGY'),
  ('FORENSIC MEDICINE');

-- UNITS
INSERT INTO [dbo].[Unit] ([Unit])
  VALUES (' '),
  ('mg/dL'),
  ('%'),
  ('ng/mL'),
  ('ug/mL');