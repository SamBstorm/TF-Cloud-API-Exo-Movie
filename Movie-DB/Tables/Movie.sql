CREATE TABLE [dbo].[Movie]
(
	[MovieId] INT NOT NULL IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(64) NOT NULL,
	[SubTitle] NVARCHAR(64),
	[Synopsis] NVARCHAR(512),
	[ReleaseDate] DATE NOT NULL,
	[MainCategory] NVARCHAR(32) NOT NULL,
	CONSTRAINT FK_Movie_Category FOREIGN KEY ([MainCategory]) REFERENCES [Category]([CatName])
)
