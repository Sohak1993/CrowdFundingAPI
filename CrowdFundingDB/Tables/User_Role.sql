﻿CREATE TABLE [dbo].[User_Role]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	IdRole INT NOT NULL,
	IdUser INT NOT NULL,

	FOREIGN KEY(IdUser) REFERENCES [User](Id),
	FOREIGN KEY(IdRole) REFERENCES Role(Id)

)