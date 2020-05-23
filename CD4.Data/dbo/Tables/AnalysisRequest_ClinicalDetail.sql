CREATE TABLE [dbo].[AnalysisRequest_ClinicalDetail]
(
	[Id] INT NOT NULL IDENTITY, 
    [AnalysisRequestId] INT NOT NULL, 
    [ClinicalDetailsId] INT NOT NULL, 
    CONSTRAINT [FK_AnalysisRequest_ClinicalDetail_AnalysisRequest] FOREIGN KEY ([AnalysisRequestId]) REFERENCES [dbo].[AnalysisRequest]([Id]), 
    CONSTRAINT [FK_AnalysisRequest_ClinicalDetail_ClinicalDetails] FOREIGN KEY ([ClinicalDetailsId]) REFERENCES [dbo].[ClinicalDetail]([Id]), 
    CONSTRAINT [PK_AnalysisRequest_ClinicalDetail] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_AnalysisRequest_ClinicalDetail_Column] UNIQUE ([AnalysisRequestId],[ClinicalDetailsId])
)
