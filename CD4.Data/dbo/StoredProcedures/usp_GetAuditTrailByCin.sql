CREATE PROCEDURE [dbo].[usp_GetAuditTrailByCin]
	@Cin varchar(50)
AS
BEGIN
	SELECT [CreatedAt]
		  ,[Details]
		  ,[Cin]
	FROM [dbo].[AuditTrail]
	WHERE [Cin] = @Cin;
END