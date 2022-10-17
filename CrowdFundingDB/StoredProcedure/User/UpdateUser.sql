CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@nickName VARCHAR(50),
	@email VARCHAR(100),
	@birthdate DATE
AS
BEGIN
	UPDATE [User]
	SET NickName = @nickName, Email = @email, BirthDate = @birthdate
	WHERE Id = @id
END
