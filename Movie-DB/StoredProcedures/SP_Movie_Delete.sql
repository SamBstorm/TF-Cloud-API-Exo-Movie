CREATE PROCEDURE [dbo].[SP_Movie_Delete]
	@id INTEGER
AS
BEGIN
	DELETE FROM [Movie]
		WHERE [MovieId] = @id
END
