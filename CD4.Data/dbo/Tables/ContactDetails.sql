CREATE TABLE [dbo].[ContactDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ContactsId] INT NOT NULL,
	[Contact] varchar(100) not null,
	[ContactType] int not null, 
    CONSTRAINT [FK_ContactDetails_Contacts] FOREIGN KEY ([ContactsId]) REFERENCES [dbo].[Contacts]([Id]), 
    CONSTRAINT [FK_ContactDetails_ContactType] FOREIGN KEY ([ContactType]) REFERENCES [dbo].[ContactType]([Id])
)
