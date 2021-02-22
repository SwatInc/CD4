CREATE PROCEDURE [dbo].[usp_UpdatePatientWithId]
	@Id int,
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
	UPDATE [dbo].[Patient]
	SET [FullName] = @Fullname,
		[NidPp] = @NidPp,
		[Birthdate] = @Birthdate,
		[GenderId] = @GenderId,
		[AtollId] = @AtollId,
		[CountryId] = @CountryId,
		[Address] = @Address,
		[PhoneNumber] = @PhoneNumber
	WHERE [Id] = @Id;

	SELECT [Id]
		  ,[Fullname]
		  ,[NidPp]
		  ,[Birthdate]
		  ,[GenderId]
		  ,[AtollId]
		  ,[CountryId]
		  ,[Address]
		  ,[PhoneNumber]
	FROM [dbo].[Patient]
	WHERE [Id] = @Id;
END
