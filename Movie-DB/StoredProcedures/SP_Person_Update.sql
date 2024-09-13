CREATE PROCEDURE [dbo].[SP_Person_Update]
	@id INTEGER,
	@lastname NVARCHAR(32),
	@firstname NVARCHAR(32),
	@birthdate DATE
AS
BEGIN
	UPDATE [Person] 
		SET	[LastName] = @lastname,
			[FirstName] = @firstname,
			[BirthDate] = @birthdate
		WHERE [PersonId] = @id
END