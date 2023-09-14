USE inlock_games_codeFirst_tarde;
GO

INSERT INTO Estudio
VALUES (NEWID(),'Blizzard'),(NEWID(),'Rockstar Studios'),(NEWID(),'Square Enix');
GO

INSERT INTO Jogo
VALUES (NEWID(),'Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-09-24',99, '51CB0AB5-8321-4B22-AE7F-EDB4F9BB340C')
	  ,(NEWID(),'Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','2012-09-27',90,'4ED603F3-FA3E-46C8-A834-527D70D14BA3');
GO

INSERT INTO TipoUsuario
VALUES (NEWID(),'Comum'),(NEWID(),'Administrador');
GO

INSERT INTO Usuario
VALUES (NEWID(),'cliente@cliente.com','cliente','418DB853-CA40-4E10-9300-98800B0A3771')
      ,(NEWID(),'admin@admin.com','admin','C0D11C6F-0A6D-4242-906E-8636EEC1452C');
GO

