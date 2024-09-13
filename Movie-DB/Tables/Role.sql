CREATE TABLE [dbo].[Role]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY,
	[PersonId] INT NOT NULL,
	[MovieId] INT NOT NULL,
	[CharacterName] NVARCHAR(64) NOT NULL,
	CONSTRAINT FK_Role_Person FOREIGN KEY ([PersonId]) REFERENCES [Person]([PersonId]),
	CONSTRAINT FK_Role_Movie FOREIGN KEY ([MovieId]) REFERENCES [Movie]([MovieId])
)
