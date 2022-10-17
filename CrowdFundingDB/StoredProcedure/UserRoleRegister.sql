CREATE PROCEDURE [dbo].[UserRoleRegister]
	@email VARCHAR(100)
AS
	DECLARE @userId INT
	SELECT @userId = Id FROM [User] WHERE Email = @email
	INSERT INTO User_Role (IdRole, IdUser) VALUES (2, @userId)
RETURN 0
