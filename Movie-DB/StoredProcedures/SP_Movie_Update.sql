CREATE PROCEDURE [dbo].[SP_Movie_Update]
	@id INTEGER,
	@title NVARCHAR(64),
	@releaseDate DATE,
	@category NVARCHAR(32),
	@subtitle NVARCHAR(64),
	@synopsis NVARCHAR(512)
AS
BEGIN
	UPDATE [Movie] 
		SET	[Title] = @title,
			[SubTitle] =@subtitle,
			[Synopsis] = @synopsis,
			[ReleaseDate] = @releaseDate,
			[MainCategory] = @category
		WHERE [MovieId] = @id
END