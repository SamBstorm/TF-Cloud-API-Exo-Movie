CREATE PROCEDURE [dbo].[SP_Movie_Insert]
	@title NVARCHAR(64),
	@releaseDate DATE,
	@category NVARCHAR(32),
	@subtitle NVARCHAR(64),
	@synopsis NVARCHAR(512)
AS
BEGIN
	INSERT INTO [Movie] ([Title], [SubTitle], [Synopsis], [ReleaseDate], [MainCategory])
		OUTPUT [inserted].[MovieId]
		VALUES (@title, @subtitle, @synopsis, @releaseDate, @category)
END
