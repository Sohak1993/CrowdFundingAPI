﻿CREATE TABLE [dbo].[Step_User]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	IdUser INT NOT NULL,
	IdProject INT NOT NULL,
	IdStep INT NOT NULL

	FOREIGN KEY(IdUser) REFERENCES [User](Id),
	FOREIGN KEY(IdProject) REFERENCES Project(Id),
	FOREIGN KEY(IdStep) REFERENCES Step(id)
)
