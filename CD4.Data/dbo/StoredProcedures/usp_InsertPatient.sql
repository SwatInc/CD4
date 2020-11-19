﻿CREATE PROCEDURE [dbo].[usp_InsertPatient]
	@Fullname nvarchar(100),
	@NidPp nvarchar(50),
	@Birthdate char(8),
	@GenderId int,
	@AtollId int,
	@CountryId int,
	@Address varchar(100),
	@PhoneNumber varchar(20)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [dbo].[Patient] ([FullName], [NidPp], [Birthdate],[GenderId], [AtollId], [CountryId], [Address], [PhoneNumber])
	OUTPUT INSERTED.Id
	VALUES (@Fullname, @NidPp, @Birthdate, @GenderId, @AtollId, @CountryId, @Address, @PhoneNumber);

	--how do I audit this?
END