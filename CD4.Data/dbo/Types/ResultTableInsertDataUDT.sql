
CREATE TYPE [dbo].[ResultTableInsertDataUDT] AS TABLE
(
	[TestId] INT NOT NULL PRIMARY KEY, 
	[Sample_Cin] VARCHAR(50) NOT NULL,
	[TestStatusId] INT NOT NULL
)