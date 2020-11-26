CREATE PROCEDURE [dbo].[usp_UpdateGlobalSettings]
	@VerifyNidPpOnOrder bit,
	@Id int
AS
BEGIN
	UPDATE [dbo].[GlobalSettings]
	SET [VerifyNidPpOnOrder] = @VerifyNidPpOnOrder
	WHERE [Id] = @Id;
END
