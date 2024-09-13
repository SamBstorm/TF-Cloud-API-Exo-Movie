CREATE PROCEDURE [dbo].[SP_Movie_GetById]
	@id INTEGER
AS
BEGIN
	SELECT * FROM [Movie]
		WHERE [MovieId] = @id
END
