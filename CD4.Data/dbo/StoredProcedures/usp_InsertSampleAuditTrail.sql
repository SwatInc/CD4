CREATE PROCEDURE [dbo].[usp_InsertSampleAuditTrail]
    @Cin varchar(50),
    @StatusId int,
    @Details varchar(2000),
	@InsertedId int output
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @SampleAuditTypeId int;
	DECLARE @InsertedData TABLE ([InsertedId] int not null);

    SELECT @SampleAuditTypeId = [Id]
    FROM [dbo].[AuditTypes]
    WHERE [Description] = 'Sample';

    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO [dbo].[AuditTrail]
        (
            [AuditTypeId],
            [Cin],
            [StatusId],
            [Details]
        )
        OUTPUT INSERTED.[Id] INTO @InsertedData
        VALUES
        (@SampleAuditTypeId, @Cin, 7, @Details);

        COMMIT TRANSACTION;

		SELECT TOP(1) @InsertedId = [InsertedId] FROM @InsertedData;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END