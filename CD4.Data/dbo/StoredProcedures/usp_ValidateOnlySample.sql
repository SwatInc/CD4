CREATE PROCEDURE [dbo].[usp_ValidateOnlySample]
	@Cin varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Sample]
	SET [StatusId] = 5
	WHERE [Cin] = @Cin;
END