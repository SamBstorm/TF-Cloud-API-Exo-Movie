﻿CREATE TABLE [dbo].[Person]
(
	[PersonId] INT IDENTITY NOT NULL PRIMARY KEY,
	[LastName] NVARCHAR(32) NOT NULL,
	[FirstName] NVARCHAR(32) NOT NULL,
	[BirthDate] DATE NOT NULL
)
