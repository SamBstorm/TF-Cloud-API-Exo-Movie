CREATE PROCEDURE [dbo].[SP_Person_Insert]
	@lastname NVARCHAR(32),
	@firstname NVARCHAR(32),
	@birthdate DATE
AS
BEGIN
	INSERT INTO [Person] ([LastName], [FirstName], [BirthDate])
		OUTPUT [inserted].[PersonId]
		VALUES (@lastname, @firstname, @birthdate)
END
