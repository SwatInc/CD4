CREATE TABLE [dbo].[Contacts_Sites]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ContactsId] int not null,
	[SitesId] int not null,
	[IsPrimary] bit not null DEFAULT 0
	/*
	***IMPORTANT NOTE****
	Same SitesId should not have multiple IsPrimary = true values
	handle this in storedProcedure
	*/
    CONSTRAINT [FK_Contacts-Sites_Contacts] FOREIGN KEY ([ContactsId]) REFERENCES [dbo].[Contacts]([Id]), 
    CONSTRAINT [FK_Contacts-Sites_Sites] FOREIGN KEY ([SitesId]) REFERENCES [dbo].[Sites]([Id])
)
