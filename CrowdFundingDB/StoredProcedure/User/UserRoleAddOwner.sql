CREATE PROCEDURE [dbo].[UserAddOwner]
	
	@idUser int
AS
BEGIN
	INSERT INTO User_Role (IdRole, IdUser) VALUES (3, @idUser)
END
