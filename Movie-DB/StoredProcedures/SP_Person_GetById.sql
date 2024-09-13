CREATE PROCEDURE [dbo].[SP_Person_GetById]
	@id INTEGER
AS
BEGIN
	SELECT * FROM [Person]
		WHERE [PersonId] = @id
END
