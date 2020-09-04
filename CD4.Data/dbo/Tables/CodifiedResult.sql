CREATE TABLE [dbo].[CodifiedResult]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Code] VARCHAR(50) NOT NULL, 
    [ReferenceCode] CHAR(2) NOT NULL DEFAULT 'NM', 
    CONSTRAINT [AK_CodifiedResult_Code] UNIQUE ([Code])

    /*
    REF Codes
    [NM] Normal (black and normal font-weight)
    [AT] Attention (Yellow and bold)
    [PA] Pathology (Brown and bold)
    [HP] Panic/HighPathology (Red and bold)
    [NA] Not acceptable / Exceeds acceptability (Blue and bold)
    */
)
