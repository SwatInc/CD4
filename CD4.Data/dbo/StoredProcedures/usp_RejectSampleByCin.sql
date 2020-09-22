CREATE PROCEDURE [dbo].[usp_RejectSampleByCin]
	@Cin varchar(50),
	@Comment varchar(2000)
AS
BEGIN
	-- remove result for sample
	-- change sample status to rejected
	-- insert comment
END
