CREATE PROCEDURE [dbo].[usp_UpdateGlobalSettings]
	@JsonSettings varchar(max)
AS
BEGIN
	DELETE FROM [dbo].[GlobalSettings];

	UPDATE [dbo].[GlobalSettings]
	SET [JsonSettings] = @JsonSettings
END
