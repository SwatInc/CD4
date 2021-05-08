CREATE PROCEDURE [dbo].[usp_InsertPatient]
	@Fullname nvarchar(100),
	@NidPp nvarchar(50),
	@Birthdate char(8),
	@GenderId int,
	@AtollId int,
	@CountryId int,
	@Address varchar(100),
	@PhoneNumber varchar(20),
	@InstituteAssignedPatientId bigint
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[Patient] ([InstituteAssignedPatientId],[FullName], [NidPp], [Birthdate],[GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
	OUTPUT INSERTED.Id
	VALUES (@InstituteAssignedPatientId,@Fullname, @NidPp, @Birthdate, @GenderId, @AtollId, @CountryId, @Address, @PhoneNumber);

	--how do I audit this?
END