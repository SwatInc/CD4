CREATE TABLE [dbo].[AnalysisRequest_ClinicalDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AnalysisRequestId] INT NOT NULL, 
    [ClinicalDetailsId] INT NOT NULL, 
    CONSTRAINT [FK_AnalysisRequest_ClinicalDetail_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [FK_AnalysisRequest_ClinicalDetail_ClinicalDetails] FOREIGN KEY ([ClinicalDetailsId]) REFERENCES [dbo].[ClinicalDetail]([Id])
)
