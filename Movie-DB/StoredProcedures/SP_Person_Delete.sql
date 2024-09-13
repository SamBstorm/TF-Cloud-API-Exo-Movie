CREATE PROCEDURE [dbo].[SP_Person_Delete]
	@id INTEGER
AS
BEGIN
	DELETE FROM [Person]
		WHERE [PersonId] = @id
END
